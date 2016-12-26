using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web;
using MVCEntityWebBLL;
using MVCEntityWebBOL;
using System.Configuration;
using RestSharp;

namespace MVCEntityWeb.Helper
{
    public class UrlServerData : IUrlServerData
    {
        private readonly RestClient _client;
        private readonly string _url = ConfigurationManager.AppSettings["webapibaseurl"];

        public UrlServerData()
        {
            _client = new RestClient(_url);
        }

        public List<tbl_Url> Get()
        {
            var request = new RestRequest("api/url/get", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute<List<tbl_Url>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }


        public List<tbl_Url> GetByID(int ID)
         {
              var request = new RestRequest("api/url/get/{ID}", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddParameter("ID", ID, ParameterType.UrlSegment);
            var response = _client.Execute<List<tbl_Url>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);
            return response.Data;

         }
   

        public List<tbl_Url> DeleteDataList(int ID)
        {
            var request = new RestRequest("api/url/DeleteDataList/{ID}", Method.DELETE) { RequestFormat = DataFormat.Json };
            request.AddParameter("ID", ID, ParameterType.UrlSegment);
            var response = _client.Execute<List<tbl_Url>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }


        public List<tbl_Url> AddUpdateDataList(tbl_Url myUrl)
        {
            var request = new RestRequest("api/url", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(myUrl);
            var response = _client.Execute<List<tbl_Url>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }

    }
}