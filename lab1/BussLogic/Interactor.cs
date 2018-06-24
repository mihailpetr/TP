using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Web;
using System.Net;
using System.IO;

namespace BussLogic
{
    public class Interactor : IClient
    {
        public string clientID { get; set; }
        public string clientSecret { get; set; }
        public string foodCode { get; set; }
        public string apiUrl { get; set; }
        public int radius { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string icon_url { get; set; }
        //public string queryUrl { get; set; }
        //public IEnumerable<Foursquare.Venue> list { get; set; }
        //public string results { get; set; }
        public int selectCategory { get; set; }
        public string [] categoryCode = new[] {"4bf58dd8d48988d17f941735", "4d4b7105d754a06372d81259", "4bf58dd8d48988d181941735", 
		                                "4bf58dd8d48988d1e3931735", "4d4b7105d754a06374d81259", "4d4b7105d754a06376d81259", 
                                        "4d4b7105d754a06377d81259", "4bf58dd8d48988d104941735", "4d4b7105d754a06378d81259", "4d4b7105d754a06378d81259" };

        public Interactor()
        {
            clientID = "UCUKXZJTIQZBZ4DOV0N403J5Y55Z0IDB4IGAP5Y0CEDEE1WX";
            clientSecret = "TWIYGZRSP3MO4JW0PZZZ2CZBSYBOWJIBM4ES2KJ0HC05TXRR";
            //foodCode = "4d4b7105d754a06374d81259";
            apiUrl = "https://api.foursquare.com/v2/venues/search?";
            radius = 1000;
            latitude = "48.7";
            longitude = "44.5";
            icon_url = "";
            //queryUrl = apiUrl;
            //results = "";
            selectCategory = -1;
        }
        public string create_url()
        {
            string queryUrl;
            if (selectCategory < 0)
            {
                queryUrl = "";
                return queryUrl;
            }
            queryUrl = apiUrl;
            queryUrl += "client_id=" + clientID;
            queryUrl += "&client_secret=" + clientSecret;
            queryUrl += "&v=" + String.Format("{0:yyyyMMdd}", DateTime.Now);
            queryUrl += "&ll=" + latitude + "," + longitude;
            queryUrl += "&radius=" + radius.ToString();
            queryUrl += "&categoryId=" + categoryCode[selectCategory];
            return queryUrl;
        }
        public IEnumerable<Foursquare.Venue> get_json()
        {
            IEnumerable<Foursquare.Venue> list;
            string queryUrl = create_url();
            if (queryUrl == "")
            {
                list = null;
                return list;   
            }
            string jsonString = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryUrl);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }
            Foursquare returnValue = JsonConvert.DeserializeObject<Foursquare>(jsonString);
            list = returnValue.response.venues.OrderBy(x => x.location.distance);
            return list;
        }

        public string get_info(IEnumerable<Foursquare.Venue> list, bool test = false)
        {
            string results = "";
            if (list == null)
            {
                return results;
            }
            int ind = 0;
            foreach (var item in list)
            {
                ind++;
                results += ind.ToString() + "." + " " + item.name + "; ";
                if (item.location != null)
                {
                    results += "Расстояние до места: " + item.location.distance.ToString() + " м; ";
                    if (item.location.formattedAddress != null)
                    {
                        results += "Адрес: ";
                        for (int i = item.location.formattedAddress.Count - 1; i >= 0; i--)
                            results += item.location.formattedAddress[i] + " ";
                    }
                    results += "; ";
                }
                if (item.categories != null)
                    results += "Категория заведения: " + item.categories[0].pluralName;
                if (!test)
                    results += "\r\n";
            }
            return results;
        }
    }
}
