using System;
using TechTalk.SpecFlow;
using DemoTest;
using Newtonsoft.Json;
using RestSharp;

namespace RunnerTest.FeatureFiles
{
    [Binding]
    public class CheckResultStepDefinitionsNew
    {
        RestClient client = new RestClient("https://www.purgomalum.com");
        RestRequest request = null;
        RestResponse response = null;
        Model model = null;
        string statusCode = string.Empty;
        string statusType = string.Empty;
        string statusDesc = string.Empty;

        [Given(@"User Passes the query parameter with text""([^""]*)""")]
        public void GivenUserPassesTheQueryParameter(string queryparam)
        {
            //arrange
            request = new RestRequest("/service/json?text=" + queryparam, Method.Get);
        }


        [When(@"User creates a request URI")]
        public void WhenUserCreatesARequestURI()
        {
            //act
            response = client.Execute(request);
            var Content = response.Content;

            // using the Model class and Deserializing the Json

#pragma warning disable CS8601 // Possible null reference assignment.
            model = JsonConvert.DeserializeObject<Model>(Content);
#pragma warning restore CS8601 // Possible null reference assignment.
            statusCode = response.StatusCode.ToString();
            statusType = response.ContentType;
            statusDesc = response.StatusDescription;
        }

        [Then(@"Assert the response for the text""([^""]*)""")]
        public void ThenAssertTheResponseForTheText(string expected)
        {
            // assert
            Assert.AreEqual("OK", statusCode);
            Assert.AreEqual(model.Result, expected); // verifying the parameter
            Assert.AreSame("OK", statusDesc);
            Assert.AreEqual("application/json", statusType);
        }

        //Test 2
        [Given(@"Query Param with text""([^""]*)"" is replaced with ""([^""]*)""")]
        public void GivenQueryParamWithTextIsReplacedWith(string pathparam, string queryparam)
        {
            //arrange
            request = new RestRequest("/service/json?text=" + pathparam + queryparam, Method.Get);
        }


        //Test 2
        [Then(@"Assert the response for the replaced text""([^""]*)""")]
        public void ThenAssertTheResponseForTheReplacedText(string expected)
        {
            // assert
            Assert.AreEqual("OK", statusCode);
            Assert.IsTrue(model.Result.Contains(expected)); // verifying the parameter
            Assert.AreSame("OK", statusDesc);
            Assert.AreEqual("application/json", statusType);
        }
        //Test 4 
        [Then(@"Assert the response")]
        public void ThenAssertTheResponse()
        {
            // assert
            Assert.AreEqual("OK", statusCode);
            Assert.IsTrue(model.Error.Equals("User Replacement Text Exceeds Limit of 20 Characters.")); // verifying the parameter
            Assert.AreSame("OK", statusDesc);
            Assert.AreEqual("application/json", statusType);
        }


    }




}


 



