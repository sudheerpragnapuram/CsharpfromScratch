
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



       
            String myJsonString = File.ReadAllText("CsharpFundas/testData.Json");
            var jsonObject = JToken.Parse(myJsonString);
            Console.WriteLine( jsonObject.SelectToken("username").Value<string>());
        
