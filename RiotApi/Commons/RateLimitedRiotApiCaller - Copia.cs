using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace RiotApi.Commons
{
    public sealed class RateLimitedRiotApiCaller : BaseRiotApiCaller
    {
        private static RateLimitedRiotApiCaller _instance;

        // Lock synchronization object
        private static object syncLock = new object();

        //
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private RateLimiter _limiter = new RateLimiter(new RateLimiter.RateLimit() { CallPerLimit = 10, SecondsPerLimit = 10 }, new RateLimiter.RateLimit() { CallPerLimit = 500, SecondsPerLimit = 600 });
        
        int _Error429Count = 0;//cancellare solo per debug
        Random random = new Random(0);//cancellare solo per debug

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

            WebRequest request = PrepareRequest(requestUrl);
            System.Net.ServicePointManager.DefaultConnectionLimit = 7;
            bool simulate500 = false;//cancellare solo per test

            //
            _semaphore.Wait();
            {
                // Aspettiamo che sia disponibile una call
                while (_limiter.WaitForCall(region) == false) { }
                try
                {
                    
                    response = request.GetResponse();
                 /*   if (random.Next(0, 1000) > 900 && _limiter.contatore<10) {
                        simulate500 = true; Console.WriteLine("SIMULAZIONE ERROR 500!"); 
                        throw new WebException(); 
                    }*/
                    _limiter.RegisterCall(region);
                    Console.WriteLine("Contatore Call: " + _limiter.contatore + " Timer: " + DateTime.Now.ToString("hh:mm:ss:fff"));
                    registered = true;
                    _semaphore.Release();
                }
                catch (Exception ex)
                {
                    HttpWebResponse errorResponse = ((WebException)ex).Response as HttpWebResponse;

                    if (errorResponse == null && simulate500==false)
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
                            retryAfter = Int32.Parse(tempRetry); _Error429Count++;
                            Console.WriteLine("Errore 429 con Header[\"Retry-After\"] = " + retryAfter); Console.Beep(); Console.Beep();
                        }
                        else
                        {
                            Console.WriteLine("Errore 429 senza Header[\"Retry-After\"] = 1");
                        }
                        Console.Beep();
                        registered = true;
                        _limiter.RegisterCall(region);
                        _limiter.ResetIn(retryAfter + 1);
                        if (_Error429Count>20)
                        {
                            Console.WriteLine("4 erorri");
                        }
                        Console.WriteLine("ResetIn chiamato interamente a MakeApiCall");
                        _semaphore.Release();

                        return MakeApiCall(requestUrl, region);
                    }
                    else if (errorCode != 200)
                    {
                        Console.WriteLine("WebEccezione " + errorCode + " ");
                    }
//                     string responseContent = "";
// 
//                     using (StreamReader r = new StreamReader(errorResponse.GetResponseStream()))
//                     {
//                         responseContent = r.ReadToEnd();
//                     }
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
            string result = null;

            // Creare la request

            //      Attivare semaphore

            //          controllare e attendere il rate limit

            //          eseguire la GetResponse

            //          Prendere il timer della call

            //      Stoppare il semaphore

            // Leggere lo stream dati json

            WebRequest request = PrepareRequest(requestUrl);

            //
            await _semaphore.WaitAsync();
            {
                _limiter.WaitForCall(region);
                //try
                {
                    WebResponse response = await GetResponseAsync(request);
                }
                // catch (Exception ex)
                {
                    Console.WriteLine("Eccezzione");
                    //    throw;
                }

                _limiter.RegisterCall(region);
            }
            _semaphore.Release();


            return result;
            return await Task.FromResult<string>("");
        }
    }
}
