using DemoTest;
using Newtonsoft.Json;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace RunnerTest.FeatureFiles
{
    [Binding]
    public class CheckResultStepDefinitions
    {

        RestClient client = new RestClient("https://www.purgomalum.com");
        RestRequest request = null;
        Model model = null;
         string statusCode = null;

       /* public CheckResultStepDefinitions(string statusCode )
        {

            this.statusCode = statusCode;
        }*/

        [Given(@"Pass the test url")]
        public void GivenPassTheTestUrl()
        {
            // arrange
           
             request = new RestRequest("/service/json?text=this is some test input", Method.Get);
        }

        [When(@"Perform an action on the url")]
        public void WhenPerformAnActionOnTheUrl()
        {
            // act
            RestResponse response = client.Execute(request);
            var Content = response.Content;
            Console.WriteLine(Content);
            model = JsonConvert.DeserializeObject<Model>(Content);
             statusCode = response.StatusCode.ToString();
            var statusType = response.ContentType;
            var statusDesc = response.StatusDescription;
            Console.WriteLine(statusCode);
           

            
        }

        [Then(@"Assert the url")]
        public void ThenAssertTheUrl()
        {
            // assert
            Assert.AreEqual("OK", statusCode);
            //Assert.IsFalse();
            Assert.AreEqual(model.Result, "this is some test input");
            
        }
    }
}
