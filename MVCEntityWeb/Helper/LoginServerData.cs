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
    public class LoginServerData : ILoginServerData
    {
        private readonly RestClient _client;
        private readonly string _url = ConfigurationManager.AppSettings["webapibaseurl"];

      
        public LoginServerData()
        {
            _client = new RestClient(_url);
        }
        public List<tbl_User> GetUser(string UserName, string Password)
        {
            var request = new RestRequest("api/Login/GetUser/", Method.GET) { RequestFormat = DataFormat.Json };
            //request.AddBody("UserName:"+ UserName + ",Password="+ Password + "");
            //request.RequestFormat = DataFormat.Json;
            request.AddParameter("UserName", UserName, ParameterType.UrlSegment);
            request.AddParameter("Password", Password, ParameterType.UrlSegment);
            var response = _client.Execute<List<tbl_User>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }
    }
}