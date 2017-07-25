using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace RiotApi.Commons
{
    public sealed class RateLimitedRiotApiCaller : BaseRiotApiCaller
    {
        private static RateLimitedRiotApiCaller _instance;

        // Lock synchronization object
        private static object syncLock = new object();

        //
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private RateLimiter _limiter = new RateLimiter(new RateLimiter.RateLimit() { CallPerLimit = 10 - 1, SecondsPerLimit = 10 }, new RateLimiter.RateLimit() { CallPerLimit = 500-2, SecondsPerLimit = 600 });

        int _Error429Count = 0;//cancellare solo per debug
        Random random = new Random(0);//cancellare solo per debug

        private RateLimitedRiotApiCaller() { }

        public static RateLimitedRiotApiCaller GetInstance()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new RateLimitedRiotApiCaller();
                    }
                }
            }
            return _instance;
        }

        public override string MakeApiCall(string requestUrl, Enums.Region region)
        {
            string result = String.Empty;
            bool registered = false;
            WebResponse response = null;

            WebRequest request = PrepareWebRequest(requestUrl);
            request.Proxy = WebRequest.DefaultWebProxy;
            //System.Net.WebRequest.DefaultWebProxy = null;
            System.Net.ServicePointManager.UseNagleAlgorithm = false; ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.DefaultConnectionLimit = 7;

            //
            _semaphore.Wait();
            {
                int firstCall = -1;
                // Aspettiamo che sia disponibile una call
                while (firstCall < 0) { firstCall = _limiter.WaitForCall(region); }
                try
                {
                    if (firstCall == 0)
                    {

                    }
                    else
                    {

                    }
                    System.Diagnostics.Debug.WriteLine("Response()        Timer: " + DateTime.Now.ToString("hh:mm:ss:fff") + "FirstCall: " + firstCall);
                    Console.WriteLine("Response()        Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                    response = request.GetResponse();

                    _limiter.RegisterCall(region);
                    System.Diagnostics.Debug.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                    Console.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                    registered = true;
                    _semaphore.Release();
                }
                catch (Exception ex)
                {
                    _limiter.RegisterCall(region); // Tutte le chiamate alle API contano anche in caso di errore, quindi registriamo la call
                    HttpWebResponse errorResponse = ((WebException)ex).Response as HttpWebResponse;

                    if (errorResponse == null)
                        throw; //errorResponse not of type HttpWebResponse

                    int errorCode = errorResponse != null ? (int)errorResponse.StatusCode : 500;//(int)errorResponse.StatusCode;
                    if (errorCode == (int)Enums.RiotApiErrorCode.RATE_LIMIT_EXCEEDED)
                    {
                        int retryAfter = 1;

                        // Controlliamo la presenza dell'header "Retry-After". Se l'header è presente l'errore è causato dall'utente altrimenti è un problema esterno
                        // Riproviamo a effetturare la Call dopo un numero di secondi pari al valore di "Retry-After" altrimenti riproviamo dopo 1 secondo
                        string tempRetry = errorResponse.Headers["Retry-After"];
                        if (tempRetry != null)
                        {
                            retryAfter = Int32.Parse(tempRetry);
                            _Error429Count++;
                            Console.WriteLine("Errore 429 con Header[\"Retry-After\"] = " + retryAfter); Console.Beep(); Console.Beep();
                            System.Diagnostics.Trace.WriteLine("Errore 429 con Header[\"Retry-After\"] = " + retryAfter);
                        }
                        else //questo "else" è inutile per ora
                        {
                            Console.Beep();
                            Console.WriteLine("Errore 429 senza Header[\"Retry-After\"] = 1");
                            System.Diagnostics.Trace.WriteLine("Errore 429 senza Header[\"Retry-After\"] = 1");
                        }

                        registered = true;
                      //  _limiter.RegisterCall(region);
                        _limiter.ResetIn(retryAfter);

                        Console.WriteLine("ResetIn chiamato interamente a MakeApiCall");
                        _semaphore.Release();

                        return MakeApiCall(requestUrl, region);
                    }
                    else if (errorCode != 200)
                    {
                        Console.WriteLine("WebEccezione " + errorCode + " ");
                        System.Diagnostics.Trace.WriteLine("WebEccezione " + errorCode + " ");

                        if (errorCode == (int)Enums.RiotApiErrorCode.NOT_FOUND) // Error 404
                        {
                            throw new Exceptions.RiotApiException(Enums.RiotApiErrorCode.NOT_FOUND);
                        }
                        
                    }
                    string responseContent = "";

                    using (StreamReader r = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        responseContent = r.ReadToEnd();
                    }
                    Console.WriteLine("Eccezzione");
                    //throw;
                }
                finally
                {
                    // Console.WriteLine("codice finally");
                    if (registered == false)
                    {
                        if (response != null)
                            response.Close();
                        response = null;
                        _semaphore.Release();
                    }
                }

                // _limiter.RegisterCall(region);
            }
            //  _semaphore.Release();
            if (response != null)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
                response.Close();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public override async Task<string> MakeApiCallAsync(string requestUrl, Enums.Region region)
        {
            string result = String.Empty;
            bool registered = false;
            WebResponse response = null;
            bool makeRecallBecauseError429 = false;

            WebRequest request = PrepareWebRequest(requestUrl);
            request.Proxy = WebRequest.DefaultWebProxy;
            //System.Net.WebRequest.DefaultWebProxy = null;
            System.Net.ServicePointManager.UseNagleAlgorithm = false; ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.DefaultConnectionLimit = 17;

            //
            await _semaphore.WaitAsync();
            {
                int firstCall = -1;
                // Aspettiamo che sia disponibile una call
                while (firstCall < 0) { firstCall = _limiter.WaitForCall(region); }
                try
                {
                    if (firstCall == 0)
                    {
                        Console.WriteLine("ResponseAsync()        Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                        // System.Diagnostics.Debug.WriteLine("ResponseAsync()        Timer: " + DateTime.Now.ToString("hh:mm:ss:fff") + "FirstCall: " + firstCall);
                        System.Diagnostics.Trace.WriteLine("ResponseAsync()        Timer: " + DateTime.Now.ToString("hh:mm:ss:fff") + "   FirstCall: " + firstCall);
                        response = await request.GetResponseAsync();

                        _limiter.RegisterCall(region);
                        System.Diagnostics.Debug.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                        Console.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                        registered = true;
                        _semaphore.Release();
                    }
                    else
                    {
                        _limiter.RegisterCall(region);
                        _semaphore.Release();
                        System.Diagnostics.Debug.WriteLine("ResponseAsync()        Timer: " + DateTime.Now.ToString("hh:mm:ss:fff") + "   FirstCall: " + firstCall);
                        response = await request.GetResponseAsync();

                        System.Diagnostics.Debug.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                        Console.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                        registered = true;
                    }

                }
                catch (Exception ex)
                {
                    if (firstCall == 0)
                        _limiter.RegisterCall(region); // Tutte le chiamate alle API contano anche in caso di errore, quindi registriamo la call
                    if (firstCall == 0)
                            _semaphore.Release();

                    HttpWebResponse errorResponse = ((WebException)ex).Response as HttpWebResponse;

                    if (errorResponse == null)
                        throw; //errorResponse not of type HttpWebResponse

                    int errorCode = errorResponse != null ? (int)errorResponse.StatusCode : 500;//(int)errorResponse.StatusCode;
                    if (errorCode == (int)Enums.RiotApiErrorCode.RATE_LIMIT_EXCEEDED)
                    {
                        makeRecallBecauseError429 = true;
                        int retryAfter = 1;

                        // Controlliamo la presenza dell'header "Retry-After". Se l'header è presente l'errore è causato dall'utente altrimenti è un problema esterno
                        // Riproviamo a effetturare la Call dopo un numero di secondi pari al valore di "Retry-After" altrimenti riproviamo dopo 1 secondo
                        string tempRetry = errorResponse.Headers["Retry-After"];
                        if (tempRetry != null)
                        {
                            
                            retryAfter = Int32.Parse(tempRetry);
                            
                            _Error429Count++;
                            Console.WriteLine("Errore 429 con Header[\"Retry-After\"] = " + retryAfter); Console.Beep(); Console.Beep();
                            System.Diagnostics.Trace.WriteLine("Errore 429 con Header[\"Retry-After\"] = " + retryAfter);
                        }
                        else //questo "else" è inutile per ora
                        {
                         //   Console.Beep();
                            Console.WriteLine("Errore 429 senza Header[\"Retry-After\"] = 1");
                            System.Diagnostics.Trace.WriteLine("Errore 429 senza Header[\"Retry-After\"] = 1");
                        }

                        registered = true;
                   //     _limiter.RegisterCall(region);
                        _limiter.ResetIn(retryAfter);

                        Console.WriteLine("ResetIn chiamato interamente a MakeApiCall");
                        


                    }
                    else if (errorCode != 200)
                    {
                        Console.WriteLine("WebEccezione " + errorCode + " ");
                        System.Diagnostics.Trace.WriteLine("WebEccezione " + errorCode + " ");
                        if (errorCode == (int)Enums.RiotApiErrorCode.NOT_FOUND) // Error 404
                        {
                            throw new Exceptions.RiotApiException(Enums.RiotApiErrorCode.NOT_FOUND);
                        }

                    }
                    string responseContent = "";

                    using (StreamReader r = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        responseContent = r.ReadToEnd();
                    }
                    Console.WriteLine("Eccezzione");
                    //throw;
                }
                finally
                {
                    // Console.WriteLine("codice finally");
                    if (registered == false)
                    {
                        if (response != null)
                            response.Close();
                        response = null;
                        _semaphore.Release();
                    }
                }
                if (makeRecallBecauseError429)
                {
                    return await MakeApiCallAsync(requestUrl, region);
                }

                // _limiter.RegisterCall(region);
            }
            //  _semaphore.Release();
            if (response != null)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = await reader.ReadToEndAsync();
                }
                response.Close();
            }

            return result;
        }
    }


    /*
     * public override async Task<string> MakeApiCallAsync(string requestUrl, Enums.Region region)
        {
            string result = String.Empty;
            bool registered = false;
            WebResponse response = null;
            bool makeRecallBecauseError429 = false;

            WebRequest request = PrepareWebRequest(requestUrl);
            request.Proxy = WebRequest.DefaultWebProxy;
            //System.Net.WebRequest.DefaultWebProxy = null;
            System.Net.ServicePointManager.UseNagleAlgorithm = false; ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.DefaultConnectionLimit = 7;

            //
            await _semaphore.WaitAsync();
            {
                int firstCall = -1;
                // Aspettiamo che sia disponibile una call
                while (firstCall < 0) { firstCall = _limiter.WaitForCall(region); }
                try
                {
                    if (firstCall == 0)
                    {
                        Console.WriteLine("Response()        Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                        System.Diagnostics.Debug.WriteLine("Response()        Timer: " + DateTime.Now.ToString("hh:mm:ss:fff") + "FirstCall: " + firstCall);
                        System.Diagnostics.Trace.WriteLine("Response()        Timer: " + DateTime.Now.ToString("hh:mm:ss:fff") + "FirstCall: " + firstCall);
                        response = await request.GetResponseAsync();

                        _limiter.RegisterCall(region);
                        System.Diagnostics.Debug.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                        Console.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                        registered = true;
                        _semaphore.Release();
                    }
                    else
                    {
                        _limiter.RegisterCall(region);
                        _semaphore.Release();
                        System.Diagnostics.Debug.WriteLine("Response()        Timer: " + DateTime.Now.ToString("hh:mm:ss:fff") + "FirstCall: " + firstCall);
                        response = await request.GetResponseAsync();

                        System.Diagnostics.Debug.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                        Console.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                        registered = true;
                    }

                }
                catch (Exception ex)
                {
                    if (firstCall == 0)
                        _limiter.RegisterCall(region); // Tutte le chiamate alle API contano anche in caso di errore, quindi registriamo la call
                    HttpWebResponse errorResponse = ((WebException)ex).Response as HttpWebResponse;

                    if (errorResponse == null)
                        throw; //errorResponse not of type HttpWebResponse

                    int errorCode = errorResponse != null ? (int)errorResponse.StatusCode : 500;//(int)errorResponse.StatusCode;
                    if (errorCode == (int)Enums.RiotApiErrorCode.RATE_LIMIT_EXCEEDED)
                    {
                        makeRecallBecauseError429 = true;
                        int retryAfter = 1;

                        // Controlliamo la presenza dell'header "Retry-After". Se l'header è presente l'errore è causato dall'utente altrimenti è un problema esterno
                        // Riproviamo a effetturare la Call dopo un numero di secondi pari al valore di "Retry-After" altrimenti riproviamo dopo 1 secondo
                        string tempRetry = errorResponse.Headers["Retry-After"];
                        if (tempRetry != null)
                        {
                            retryAfter = Int32.Parse(tempRetry);
                            _Error429Count++;
                            Console.WriteLine("Errore 429 con Header[\"Retry-After\"] = " + retryAfter);// Console.Beep(); Console.Beep();
                            System.Diagnostics.Trace.WriteLine("Errore 429 con Header[\"Retry-After\"] = " + retryAfter);
                        }
                        else //questo "else" è inutile per ora
                        {
                            Console.Beep();
                            Console.WriteLine("Errore 429 senza Header[\"Retry-After\"] = 1");
                            System.Diagnostics.Trace.WriteLine("Errore 429 senza Header[\"Retry-After\"] = 1");
                        }

                        registered = true;
                   //     _limiter.RegisterCall(region);
                        
                            _limiter.ResetIn(retryAfter);

                        Console.WriteLine("ResetIn chiamato interamente a MakeApiCall");
                        if (firstCall == 0)
                            _semaphore.Release();


                    }
                    else if (errorCode != 200)
                    {
                        if (errorCode == (int)Enums.RiotApiErrorCode.NOT_FOUND) // Error 404
                        {
                            throw new Exceptions.RiotApiException(Enums.RiotApiErrorCode.NOT_FOUND);
                        }
                        Console.WriteLine("WebEccezione " + errorCode + " ");
                    }
                    string responseContent = "";

                    using (StreamReader r = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        responseContent = r.ReadToEnd();
                    }
                    Console.WriteLine("Eccezzione");
                    //throw;
                }
                finally
                {
                    // Console.WriteLine("codice finally");
                    if (registered == false)
                    {
                        if (response != null)
                            response.Close();
                        response = null;
                        _semaphore.Release();
                    }
                }
                if (makeRecallBecauseError429)
                {
                    return await MakeApiCallAsync(requestUrl, region);
                }

                // _limiter.RegisterCall(region);
            }
            //  _semaphore.Release();
            if (response != null)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = await reader.ReadToEndAsync();
                }
                response.Close();
            }

            return result;
        }
    }
     * */
}