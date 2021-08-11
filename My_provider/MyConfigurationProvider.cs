using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace My_provider
{
    public class MyConfigurationProvider : ConfigurationProvider
    {
        public string _filepath { get; set; }
        public MyConfigurationProvider(string path)
        {
            _filepath = path;
        }
        public override void Load()
        {
            var result = new Dictionary<string, string>();
            using (FileStream fileStream = new FileStream(_filepath, FileMode.Open))
            {
                using(StreamReader streamReader = new StreamReader(fileStream))
                {
                    string dataString;
                    while((dataString = streamReader.ReadLine()) != null)
                    {
                        var configPair = dataString.Split("=");
                        if (configPair.Length == 2)
                        {
                            result[configPair[0]] = configPair[1];
                        }
                    }
                }
            }
            Data = result;
        }
    }
}
