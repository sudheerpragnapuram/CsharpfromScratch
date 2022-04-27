using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFramWork.Utilities
{
    public class JsonReader
    {
        public JsonReader()
        {

        }

        public string extractData(String tokenName)
        {
            String myJsonString = File.ReadAllText("Utilities/testData.Json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string[] extractDataArray(String tokenName)
        {
            String myJsonString = File.ReadAllText("Utilities/testData.Json");
            var jsonObject = JToken.Parse(myJsonString);
            List<String> productList = jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            // converting string of list into Array ny using .ToArray
            return productList.ToArray();

        }
    }
}

