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
    public class CategoryServerData : ICategoryServerData
    {

        private readonly RestClient _client;
        private readonly string _url = ConfigurationManager.AppSettings["webapibaseurl"];

        public CategoryServerData()
        {
            _client = new RestClient(_url);
        }

        public List<tbl_Category> Get()
        {
            var request = new RestRequest("api/Category/get", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute<List<tbl_Category>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }


        public List<tbl_Category> GetByID(int ID)
        {
            var request = new RestRequest("api/url/GetByID/{ID}", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddParameter("ID", ID, ParameterType.UrlSegment);
            var response = _client.Execute<List<tbl_Category>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);
            return response.Data;

        }


        public List<tbl_Category> DeleteDataList(int ID)
        {
            var request = new RestRequest("api/url/DeleteDataList/{ID}", Method.DELETE) { RequestFormat = DataFormat.Json };
            request.AddParameter("ID", ID, ParameterType.UrlSegment);
            var response = _client.Execute<List<tbl_Category>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }


        public List<tbl_Category> AddUpdateDataList(tbl_Category myCategory)
        {
            var request = new RestRequest("api/url", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(myCategory);
            var response = _client.Execute<List<tbl_Category>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }
    }
}