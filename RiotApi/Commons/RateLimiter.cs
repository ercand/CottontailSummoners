using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Commons
{
    public class RateLimiter
    {
        public int contatore = 0;//cancellare la usiamo solo nel debug
        /// <summary>
        /// Padding per le chiamate da 10 secondi
        /// </summary>
        int _paddingTenSeconds = 100;

        /// <summary>
        /// Padding per le chiamate da 10 minuti
        /// </summary>
        int _paddingTenMinutes = 100;
        bool _usePadding = true;
        int _delayBeforetReset = 300;
        private RateLimit _rateLimitTenSeconds = null;
        private RateLimit _rateLimitTenMinutes = null;

        /*      private Dictionary<RiotApi.Commons.Enums.Region, DateTime> firstRequestsInLastTenS = new Dictionary<RiotApi.Commons.Enums.Region, DateTime>();
              private Dictionary<RiotApi.Commons.Enums.Region, DateTime> firstRequestsInLastTenM = new Dictionary<RiotApi.Commons.Enums.Region, DateTime>();
              private Dictionary<RiotApi.Commons.Enums.Region, int> numberOfRequestsInLastTenS = new Dictionary<RiotApi.Commons.Enums.Region, int>();
              private Dictionary<RiotApi.Commons.Enums.Region, int> numberOfRequestsInLastTenM = new Dictionary<RiotApi.Commons.Enums.Region, int>();*/

        private Dictionary<RiotApi.Commons.Enums.Region, SingleRateLimit> _requestForTenSeconds = new Dictionary<RiotApi.Commons.Enums.Region, SingleRateLimit>();
        private Dictionary<RiotApi.Commons.Enums.Region, SingleRateLimit> _requestForTenMinutes = new Dictionary<RiotApi.Commons.Enums.Region, SingleRateLimit>();

        private DateTime _resetIn = DateTime.MinValue;

        public RateLimiter(RateLimit rateLimitTenSeconds, RateLimit rateLimitTenMinutes)
        {
            this._rateLimitTenSeconds = rateLimitTenSeconds;
            this._rateLimitTenMinutes = rateLimitTenMinutes;

            //
            _requestForTenSeconds.Add(Enums.Region.BR, new SingleRateLimit(Enums.Region.BR));
            _requestForTenSeconds.Add(Enums.Region.EUNE, new SingleRateLimit(Enums.Region.EUNE));
            _requestForTenSeconds.Add(Enums.Region.EUW, new SingleRateLimit(Enums.Region.EUW));
            _requestForTenSeconds.Add(Enums.Region.KR, new SingleRateLimit(Enums.Region.KR));
            _requestForTenSeconds.Add(Enums.Region.LAN, new SingleRateLimit(Enums.Region.LAN));
            _requestForTenSeconds.Add(Enums.Region.LAS, new SingleRateLimit(Enums.Region.LAS));
            _requestForTenSeconds.Add(Enums.Region.NA, new SingleRateLimit(Enums.Region.NA));
            _requestForTenSeconds.Add(Enums.Region.OCE, new SingleRateLimit(Enums.Region.OCE));
            _requestForTenSeconds.Add(Enums.Region.RU, new SingleRateLimit(Enums.Region.RU));
            _requestForTenSeconds.Add(Enums.Region.TR, new SingleRateLimit(Enums.Region.TR));
            _requestForTenSeconds.Add(Enums.Region.JP, new SingleRateLimit(Enums.Region.JP));
            _requestForTenSeconds.Add(Enums.Region.GLOBAL, new SingleRateLimit(Enums.Region.GLOBAL));

            //
            _requestForTenMinutes.Add(Enums.Region.BR, new SingleRateLimit(Enums.Region.BR));
            _requestForTenMinutes.Add(Enums.Region.EUNE, new SingleRateLimit(Enums.Region.EUNE));
            _requestForTenMinutes.Add(Enums.Region.EUW, new SingleRateLimit(Enums.Region.EUW));
            _requestForTenMinutes.Add(Enums.Region.KR, new SingleRateLimit(Enums.Region.KR));
            _requestForTenMinutes.Add(Enums.Region.LAN, new SingleRateLimit(Enums.Region.LAN));
            _requestForTenMinutes.Add(Enums.Region.LAS, new SingleRateLimit(Enums.Region.LAS));
            _requestForTenMinutes.Add(Enums.Region.NA, new SingleRateLimit(Enums.Region.NA));
            _requestForTenMinutes.Add(Enums.Region.OCE, new SingleRateLimit(Enums.Region.OCE));
            _requestForTenMinutes.Add(Enums.Region.RU, new SingleRateLimit(Enums.Region.RU));
            _requestForTenMinutes.Add(Enums.Region.TR, new SingleRateLimit(Enums.Region.TR));
            _requestForTenMinutes.Add(Enums.Region.JP, new SingleRateLimit(Enums.Region.JP));
            _requestForTenMinutes.Add(Enums.Region.GLOBAL, new SingleRateLimit(Enums.Region.GLOBAL));
        }

        public void ResetIn(int resetSecond)
        {
            _resetIn = DateTime.Now.AddSeconds(resetSecond);
            Console.WriteLine("ResetIn(" + resetSecond + ") - Timer scadenza: " + DateTime.Now.ToString("hh:mm:ss"));
        }
        public int WaitForCall(RiotApi.Commons.Enums.Region region, int extraDelay = 0)
        {
            bool nextCallsReset = false;

            if (_resetIn != DateTime.MinValue)
            {
                if ((_resetIn - DateTime.Now).TotalMilliseconds > 0)
                { return -1; }
                else
                    _resetIn = DateTime.MinValue;
                Console.WriteLine("_resetSecond concluso - " + DateTime.Now.ToString("hh:mm:ss"));
            }

            double timeElapsedFromFirstCall10M = (DateTime.Now - _requestForTenMinutes[region].FirstCall).TotalMilliseconds;
            double timeRateLimitCall10M = (_rateLimitTenMinutes.SecondsPerLimit) * 1000.0;
            double timeElapsedFromFirstCall10S = (DateTime.Now - _requestForTenSeconds[region].FirstCall).TotalMilliseconds;
            double timeRateLimitCall10S = (_rateLimitTenSeconds.SecondsPerLimit) * 1000.0;

            // Controlliamo che non sia stato raggiunto o superato il limite di Call per minuto, se è stato oltrepassato allora controlliamo che siano passati i secondi necessari al reset delle Call per minuto
            if (_requestForTenMinutes[region].RequestCount >= _rateLimitTenMinutes.CallPerLimit)
            {
                nextCallsReset = true;
                // Se non sono passati il numero di secondi/minuti necessari al reset del RateLimit dobbiamo aspettare
                if (timeElapsedFromFirstCall10M - timeRateLimitCall10M < 0) { return -1; }
            }

            // Se è stato superato il limite di Request allora attendiamo i secondi necessari al reset
            if (_requestForTenSeconds[region].RequestCount >= _rateLimitTenSeconds.CallPerLimit)
            {
                nextCallsReset = true;
                // Se non sono passati il numero di secondi/minuti necessari al reset del RateLimit dobbiamo aspettare
                if (timeElapsedFromFirstCall10S - (timeRateLimitCall10S + _delayBeforetReset) < 0)
                {
                    return -1;
                }
            }

            // Padding
            if ((timeElapsedFromFirstCall10M >= timeRateLimitCall10M - _paddingTenMinutes && timeElapsedFromFirstCall10M <= timeRateLimitCall10M)
                //    || (DateTime.Now - _requestForTenMinutes[region].FirstCall).TotalMilliseconds < _paddingTenMinutes
                )
            {
                //   return false;
            }
            if ((timeElapsedFromFirstCall10S >= timeRateLimitCall10S - _paddingTenSeconds && timeElapsedFromFirstCall10S <= timeRateLimitCall10S)
                //  || (DateTime.Now - _requestForTenSeconds[region].FirstCall).TotalMilliseconds < _paddingTenSeconds
                )
            {
                return -1;
            }
            if ((_requestForTenSeconds[region].RequestCount >= _rateLimitTenSeconds.CallPerLimit)==false &&(timeElapsedFromFirstCall10S - (timeRateLimitCall10S + _delayBeforetReset) > 0)==true)
            {
             //   nextCallsReset = true;
            }
            if (nextCallsReset) { return 0; } else { return 1; }
            // Tutti i controlli sono stati superati, possiamo effettuare una Call alle API
            return 0;
        }

        public void PreRegisterCall(Enums.Region region)
        {
            // Controlliamo se sono trascorsi i minuti/secondi del RateLimit e resettiamone i valori
            if ((DateTime.Now - _requestForTenMinutes[region].FirstCall).TotalMilliseconds > _rateLimitTenMinutes.SecondsPerLimit * 1000.0)// && _requestForTenMinutes[region].RequestCount == 1)
            {
                Console.WriteLine("Reset 10 Minutes - New TimerStart: " + DateTime.Now.ToString("hh:mm:ss:ffff"));
                _requestForTenMinutes[region].FirstCall = DateTime.Now;
                _requestForTenMinutes[region].RequestCount = 0;
            }

            if ((DateTime.Now - _requestForTenSeconds[region].FirstCall).TotalMilliseconds > _rateLimitTenSeconds.SecondsPerLimit * 1000.0)// && _requestForTenSeconds[region].RequestCount == 1)
            {
                Console.WriteLine("Reset 10 Seconds - New TimerStart: " + DateTime.Now.ToString("hh:mm:ss:ffff"));
                _requestForTenSeconds[region].FirstCall = DateTime.Now;
                _requestForTenSeconds[region].RequestCount = 0;
            }
        }

        public void PostRegisterCall(Enums.Region region)
        {
            if (_requestForTenMinutes[region].RequestCount == 1)
            {
                _requestForTenMinutes[region].FirstCall = DateTime.Now;
            }

            if (_requestForTenSeconds[region].RequestCount == 1)
            {
                _requestForTenSeconds[region].FirstCall = DateTime.Now;
            }
        }

        /// <summary>
        /// Questo metodo ritornerà quando sarà possibile una chiamata alle Riot API nel rispetto del RateLimite
        /// </summary>
        /// <param name="region">Regione su cui si intende eseguire la chiamata alle Riot API</param>
        public bool RegisterCall(RiotApi.Commons.Enums.Region region, int callToCount = 1)
        {
            DateTime tempData = DateTime.Now;
            bool result = false;

            // Vogliamo effettuare una chiamata alle API aumenta il contatore di 1
            _requestForTenMinutes[region].RequestCount += callToCount;
            _requestForTenSeconds[region].RequestCount += callToCount;
            contatore++;
            // Controlla che non sia stato superato il numero massimo di chiamate effettuabili in 10 minuti/secondi. Nel caso fosse stato superato aspetta
            if (_requestForTenMinutes[region].RequestCount > _rateLimitTenMinutes.CallPerLimit)
            {
                Console.WriteLine("chiamate per 10minuti superato");
                //               int excetedCount = _requestForTenMinutes[region].RequestCount - _rateLimitTenMinutes.CallPerLimit;
                //                _requestForTenMinutes[region].RequestCount = excetedCount;

                //                 Aspettiamo che passino i minuti necessari al reset del limite.
                //                             if ((DateTime.Now - _requestForTenMinutes[region].FirstCall).TotalMilliseconds > _rateLimitTenMinutes.SecondsPerLimit * 1000.0)
                //                             {
                //                                 //   _requestForTenMinutes[region].FirstCall = DateTime.Now;
                //                                 _requestForTenMinutes[region].RequestCount = 0;
                //                             }
            }

            if (_requestForTenSeconds[region].RequestCount > _rateLimitTenSeconds.CallPerLimit)
            {
                Console.WriteLine("chiamate per 10sec superato");
                double s = (DateTime.Now - _requestForTenSeconds[region].FirstCall).TotalMilliseconds;
                double s2 = _rateLimitTenSeconds.SecondsPerLimit * 1000.0;

                //                int excetedCount = _requestForTenSeconds[region].RequestCount - _rateLimitTenSeconds.CallPerLimit;
                //                _requestForTenSeconds[region].RequestCount = excetedCount;
                //                 if (s > s2)
                //                 {
                //                     s = (DateTime.Now - _requestForTenSeconds[region].FirstCall).TotalMilliseconds;
                // 
                //                     //     _requestForTenSeconds[region].FirstCall = DateTime.Now;
                //                     _requestForTenSeconds[region].RequestCount = 0;
                //                 }
            }
            // Controlliamo se sono trascorsi i minuti/secondi del RateLimit e resettiamone i valori
            if ((DateTime.Now - _requestForTenMinutes[region].FirstCall).TotalMilliseconds > _rateLimitTenMinutes.SecondsPerLimit * 1000.0)// && _requestForTenMinutes[region].RequestCount == 1)
            {
                Console.WriteLine("Reset 10 Minutes - New TimerStart: " + DateTime.Now.ToString("hh:mm:ss:ffff"));
                _requestForTenMinutes[region].FirstCall = DateTime.Now;
                _requestForTenMinutes[region].RequestCount = 1;
                result = true;
            }

            if ((DateTime.Now - _requestForTenSeconds[region].FirstCall).TotalMilliseconds > _rateLimitTenSeconds.SecondsPerLimit * 1000.0)// && _requestForTenSeconds[region].RequestCount == 1)
            {
                Console.WriteLine("Reset 10 Seconds - New TimerStart: " + DateTime.Now.ToString("hh:mm:ss:ffff"));
                _requestForTenSeconds[region].FirstCall = DateTime.Now;
                _requestForTenSeconds[region].RequestCount = 1;
                result = true;
            }

            return result;
        }

        private class SingleRateLimit
        {
            public RiotApi.Commons.Enums.Region Region { get; set; }
            public DateTime FirstCall { get; set; }
            public int RequestCount { get; set; }

            public SingleRateLimit(RiotApi.Commons.Enums.Region region)
            {
                this.Region = region;
                FirstCall = DateTime.MinValue;
                RequestCount = int.MaxValue;
            }
        }


        /// <summary>
        /// Classe che memorizza il numero massimo di chiamate effettuabili e l'intervallo di tempo per effettuarle
        /// </summary>
        public class RateLimit
        {
            /// <summary>
            /// Numero massimo di chiamate consentite nell'intervallo di tempo
            /// </summary>
            public int CallPerLimit { get; set; }


            /// <summary>
            /// Durata, in secondi, dell'intervallo di tempo
            /// </summary>
            public int SecondsPerLimit { get; set; }
        }
    }
}
