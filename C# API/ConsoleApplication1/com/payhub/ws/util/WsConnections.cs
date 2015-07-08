using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.util
{
    public class WsConnections
    {
        public HttpWebRequest setHeadersPost(string operationUrl, string token)
        {
            var request = (HttpWebRequest)WebRequest.Create(operationUrl);
            request.ContentType = "text/json";
            request.Method = "POST";
            request.Headers.Add("Authorization", "Bearer " + token);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            return request;
        }
        public HttpWebRequest setHeadersGet(string operationUrl, string token)
        {
            var request = (HttpWebRequest)WebRequest.Create(operationUrl);
            request.ContentType = "text/json";
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + token);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            return request;
        }
        public string doPost(HttpWebRequest request, string _url)
        {
            string result = null;
            string responseObject;
            try
            {               
                var response = (HttpWebResponse)request.GetResponse();//You return this response.
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();

                    // if status is 200 then get the data from refund response;
                    if (HttpStatusCode.Created == response.StatusCode)
                    {
                        string completePath = response.Headers["Location"];
                        int lastSlash = completePath.LastIndexOf("/");
                        string transactionId = completePath.Substring(lastSlash + 1);

                        var responseDataRequest = setResponseDataURI(_url + transactionId, request);
                        //responseObject = getResponseData(responseDataRequest);
                        
                        return responseObject=doGet(responseDataRequest);
                        

                    }
                    else
                    {
                        return result;
                    }

                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)//You return wex.Response instead
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            result = reader.ReadToEnd();
                            return result;
                        }
                    }
                }
            }
            return result;
        }
        public string doGet(HttpWebRequest responseDataRequest)
        {
            try
            {
                var response = (HttpWebResponse)responseDataRequest.GetResponse();//You return this response.
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string result = reader.ReadToEnd();                                      
                    return result;

                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)//You return wex.Response instead
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            return reader.ReadToEnd();                            
                        }
                    }
                }
            }


            //refund deserializedProduct = JsonConvert.DeserializeObject<refund>(output);
            return null;
        }

        public HttpWebRequest setResponseDataURI(string path, HttpWebRequest request)
        {
            var req = (HttpWebRequest)WebRequest.Create(path);
            req.ContentType = "text/json";
            req.Method = "GET";
            req.Headers.Add("Authorization", request.Headers.Get("Authorization"));
            req.ContentType = "application/json";
            req.Accept = "application/json";
            return req;

        }
    }
}
