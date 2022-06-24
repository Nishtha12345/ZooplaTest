using DemoTest;
using Newtonsoft.Json;
using RestSharp;


namespace ZooplaTest
{
    public  class Action1
    {

        public  Model  Test1()
        {
            var restClient = new RestClient("https://www.purgomalum.com");
            var request = new RestRequest("/service/json?text=this is some test input",Method.Get);
            request.AddHeader("Content-Type","application/json");
            request.RequestFormat= DataFormat.Json;

            RestResponse response = restClient.Execute(request);
            var Content = response.Content;
            Console.WriteLine(Content);
          
            Model model = JsonConvert.DeserializeObject<Model>(Content);

            return model;
            //return Content;
            
        }

        public Model Test2()
        {
            var restClient = new RestClient(" https://www.purgomalum.com");
            var request = new RestRequest("/service/json?text=this is some test input&add=input&fill_char=_", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = restClient.Execute(request);
            var Content = response.Content;
            Console.WriteLine(Content);

            Model model = JsonConvert.DeserializeObject<Model>(Content);

            return model;
            //return Content;

        }

       

    }
}
