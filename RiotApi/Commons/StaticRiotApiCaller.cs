using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Commons
{
    public class StaticRiotApiCaller : BaseRiotApiCaller
    {
        public override string MakeApiCall(string requestUrl, Enums.Region region)
        {
            WebResponse response = null;
            String result = "";

            WebRequest request = PrepareWebRequest(requestUrl);

            response=base.GetResponse(request);


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

        public override async Task<string> MakeApiCallAsync(string requestUrl, Enums.Region region)
        {
            throw new NotImplementedException();

            WebResponse response = null;
            String result = "";

            WebRequest request = PrepareWebRequest(requestUrl);

            response = await base.GetResponseAsync(request);


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
}
