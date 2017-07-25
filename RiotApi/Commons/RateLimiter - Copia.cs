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
        int _paddingTenMinutes = 1000;
        bool _usePadding = true;
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
            //_limitForTenSeconds.Add(Enums.Region.PBE, new SingleRateLimit(Enums.Region.PBE));

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
            //_limitForTenMinutes.Add(Enums.Region.PBE, new SingleRateLimit(Enums.Region.PBE));
        }

        public void ResetIn(int resetSecond)
        {
            _resetIn = DateTime.Now.AddSeconds(resetSecond);
            Console.WriteLine("ResetIn(" + resetSecond + ") - Timer scadenza: " + DateTime.Now.ToString("hh:mm:ss"));
        }
        public bool WaitForCall(RiotApi.Commons.Enums.Region region, int extraDelay = 0)
        {
            if (_resetIn != DateTime.MinValue)
            {
                if ((_resetIn - DateTime.Now).TotalMilliseconds > 0)
                { return false; }
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
                // Se non sono passati il numero di secondi/minuti necessari al reset del RateLimit dobbiamo aspettare
                if (timeElapsedFromFirstCall10M - timeRateLimitCall10M < 0) { return false; }
            }

            // Se i controlli del Rate Limit per i minuti passiamo al controllo dei Rate Limit per secondi
            if (_requestForTenSeconds[region].RequestCount >= _rateLimitTenSeconds.CallPerLimit)
            {
                // Se non sono passati il numero di secondi/minuti necessari al reset del RateLimit dobbiamo aspettare
                if (timeElapsedFromFirstCall10S - timeRateLimitCall10S < 0)
                {
                    return false;
                }
            }

            // Padding
            if (timeElapsedFromFirstCall10M >= timeRateLimitCall10M - _paddingTenMinutes && timeElapsedFromFirstCall10M <= timeRateLimitCall10M)
            {
                return false;
            }
            if (timeElapsedFromFirstCall10S >= timeRateLimitCall10S - _paddingTenSeconds && timeElapsedFromFirstCall10S <= timeRateLimitCall10S)
            {
                return false;
            }
            // Tutti i controlli sono stati superati, possiamo effettuare una Call alle API
            return true;
        }

        public void PreregisterCall(Enums.Region region) 
        {
            // Controlliamo se sono trascorsi i minuti/secondi del RateLimit e resettiamone i valori
            if ((DateTime.Now - _requestForTenMinutes[region].FirstCall).TotalMilliseconds > _rateLimitTenMinutes.SecondsPerLimit * 1000.0)// && _requestForTenMinutes[region].RequestCount == 1)
            {
                Console.WriteLine("Reset 10minuts: First Call: " + _requestForTenMinutes[region].FirstCall.ToString("hh:mm:ss") + " - RequestCount: " + _requestForTenMinutes[region].RequestCount);
                _requestForTenMinutes[region].FirstCall = DateTime.Now;
                _requestForTenMinutes[region].RequestCount = 0;
            }

            if ((DateTime.Now - _requestForTenSeconds[region].FirstCall).TotalMilliseconds > _rateLimitTenSeconds.SecondsPerLimit * 1000.0)// && _requestForTenSeconds[region].RequestCount == 1)
            {
                Console.WriteLine("Reset 10seconds: First Call: " + _requestForTenSeconds[region].FirstCall.ToString("hh:mm:ss") + " - RequestCount: " + _requestForTenSeconds[region].RequestCount + " - New TimerStart: " + DateTime.Now.ToString("hh:mm:ss:ffff"));
                _requestForTenSeconds[region].FirstCall = DateTime.Now;
                _requestForTenSeconds[region].RequestCount = 0;
            }
        }

        /// <summary>
        /// Questo metodo ritornerà quando sarà possibile una chiamata alle Riot API nel rispetto del RateLimite
        /// </summary>
        /// <param name="region">Regione su cui si intende eseguire la chiamata alle Riot API</param>
        public void RegisterCall(RiotApi.Commons.Enums.Region region)
        {
            DateTime tempData = DateTime.Now;
            contatore++;
            if (contatore == 9)
            {
                Console.WriteLine("Contantore " + contatore);
            }
            // Vogliamo effettuare una chiamata alle API aumenta il contatore di 1
            _requestForTenMinutes[region].RequestCount++;
            _requestForTenSeconds[region].RequestCount++;

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

            //solo debug canellare
            if (_requestForTenSeconds[region].RequestCount > 11 || _requestForTenMinutes[region].RequestCount > 501)
            {
                Console.WriteLine("Cazzzzzzzzzzzzzzzzzzzo");
            }
            // Controlliamo se sono trascorsi i minuti/secondi del RateLimit e resettiamone i valori
            if ((DateTime.Now - _requestForTenMinutes[region].FirstCall).TotalMilliseconds > _rateLimitTenMinutes.SecondsPerLimit * 1000.0)// && _requestForTenMinutes[region].RequestCount == 1)
            {
                Console.WriteLine("Reset 10minuts: First Call: " + _requestForTenMinutes[region].FirstCall.ToString("hh:mm:ss") + " - RequestCount: " + _requestForTenMinutes[region].RequestCount);
                _requestForTenMinutes[region].FirstCall = DateTime.Now;
                _requestForTenMinutes[region].RequestCount = 1;
                //    contatore = 1;
            }

            if ((DateTime.Now - _requestForTenSeconds[region].FirstCall).TotalMilliseconds > _rateLimitTenSeconds.SecondsPerLimit * 1000.0)// && _requestForTenSeconds[region].RequestCount == 1)
            {
                Console.WriteLine("Reset 10seconds: First Call: " + _requestForTenSeconds[region].FirstCall.ToString("hh:mm:ss") + " - RequestCount: " + _requestForTenSeconds[region].RequestCount + " - New TimerStart: " + DateTime.Now.ToString("hh:mm:ss:ffff"));
                _requestForTenSeconds[region].FirstCall = DateTime.Now;
                _requestForTenSeconds[region].RequestCount = 1;
                //   contatore = 1;
            }
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
                RequestCount = 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public class RateLimit
        {
            /// <summary>
            /// Numero massimo di chiamate consentite nell'intervallo di tempo <see cref="System.Console.WriteLine(System.String)"/>
            /// </summary>
            public int CallPerLimit { get; set; }


            /// <summary>
            /// Durata, in secondi, dell'intervallo di tempo
            /// </summary>
            public int SecondsPerLimit { get; set; }


            /// <summary>
            /// Numero massimo di chiamate consentite nell'intervallo di tempo <see cref="secondsPerLimit"/>
            /// </summary>
            //public long callsPerLimit = 0;

            /// <summary>
            /// Durata, in secondi, dell'intervallo di tempo
            /// </summary>
            // public long secondsPerLimit = 0;
        }
    }
}
