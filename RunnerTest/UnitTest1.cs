using DemoTest;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using ZooplaTest;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RunnerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var action = new Action1();
            var response = action.Test1();
            Assert.AreEqual("this is some test input", response.Result);
           
            // Or else can create a disctionary and read the key value pairs
           /* var response1 = JsonConvert.DeserializeObject<Dictionary<String,String>>(response);
            Assert.AreEqual("this is some test input", response1["result"].ToString());*/
        }

        [TestMethod]
        public void TestMethod2()
        {
            var action = new Action1();
            var response = action.Test2();
            Assert.AreEqual("this is some test _____", response.Result);

            // Or else can create a disctionary and read the key value pairs
            /* var response1 = JsonConvert.DeserializeObject<Dictionary<String,String>>(response);
             Assert.AreEqual("this is some test input", response1["result"].ToString());*/
        }
        // another way of writing the same test 
        [TestMethod]
        public void StatusCodeTest()
        {
            // arrange
            RestClient client = new RestClient("https://www.purgomalum.com");
            RestRequest request = new RestRequest("/service/json?text=this is some test input", Method.Get);

            RestResponse response = client.Execute(request);
            var Content = response.Content;
            Console.WriteLine(Content);

            Model model = JsonConvert.DeserializeObject<Model>(Content);


            // assert
            Assert.AreEqual(model.Result, "this is some test input");
        }
    }
}