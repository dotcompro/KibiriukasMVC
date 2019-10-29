using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kibiriukas.Models
{
    public class GeoData
    {
        private string apiHttp { get; set; }
        private JObject results { get; set; }
        public JObject Results
        {
            get { return results; }
            set { results = value; }
        }
        public Dictionary<string, string> filters { get; set; }
        private List<object> autoCompleteGeoData { get; set; }
        public List<object> AutoCompleteGeoData
        {
            get { return autoCompleteGeoData; }
            set { autoCompleteGeoData = value; }
        }

        public GeoData(Dictionary<string, string> filters)
        {
            apiHttp = "http://api.geonames.org/searchJSON?username=dovileramanauske";
            setApiHttpWithFilters(filters);
            getAllResults();
        }

        private void getAllResults()
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                string jsonString = webClient.DownloadString(apiHttp);
                results = JsonConvert.DeserializeObject<JObject>(jsonString);
            }
        }

        public void GetAutoCompleteData(int resultCount)
        {
            if (resultCount > 0)
            {
                autoCompleteGeoData = new List<object>();
                int iteratorLength = results["geonames"].Count() <= resultCount ? results["geonames"].Count() - 1 : resultCount;
                for (int i = 0; i <= iteratorLength; i++)
                {
                    JToken locationName = results["geonames"][i]["name"];
                    autoCompleteGeoData.Add(new { value = locationName, label = locationName });
                }
            }
        }

        private void setApiHttpWithFilters(Dictionary<string, string> filters)
        {
            //string apiRequest = apiHttp;
            foreach (KeyValuePair<string, string> entry in filters)
            {
                if (entry.Value != null)
                    apiHttp = apiHttp + "&" + entry.Key + "=" + entry.Value;
            }
        }

    }
}