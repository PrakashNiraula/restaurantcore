using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RestSharp;

namespace FoodieCore.module
{
    public class onlinedata
    {

        
        public IRestResponse getonlinedata()
        {
            RestClient client = new RestClient("http://www.21sttech.info/api/all_products.php");
         
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var body = @"{
            " + "\n" +
            @"    ""apikey"":""DesktopApp""
            " + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var res=client.Execute(request);
            return res;


        }



    }
}
