using Newtonsoft.Json;

namespace DemoTest
{
   
    public  class Model
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}