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

namespace MvcLab2.Models
{
    public class InteractorModel
    {
        public string clientID { get; set; }
        public string clientSecret { get; set; }
        public string foodCode { get; set; }
        public string apiUrl { get; set; }
        public int radius { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string icon_url;
        public string queryUrl { get; set; }
        public IEnumerable<FoursquareModel.Venue> list { get; set; }
        public string results { get; set; }

        public InteractorModel()
        {
            clientID = "UCUKXZJTIQZBZ4DOV0N403J5Y55Z0IDB4IGAP5Y0CEDEE1WX";
            clientSecret = "TWIYGZRSP3MO4JW0PZZZ2CZBSYBOWJIBM4ES2KJ0HC05TXRR";
            foodCode = "4d4b7105d754a06374d81259";
            apiUrl = "https://api.foursquare.com/v2/venues/search?";
            radius = 1000;
            latitude = "48.7";
            longitude = "44.5";
            icon_url = "";
            queryUrl = apiUrl;
            results = "";
        }

        public async void get_json()
        {
            queryUrl = apiUrl;
            queryUrl += "client_id=" + clientID;
            queryUrl += "&client_secret=" + clientSecret;
            queryUrl += "&v=" + String.Format("{0:yyyyMMdd}", DateTime.Now);

            queryUrl += "&ll=" + latitude + "," + longitude;

            queryUrl += "&radius=" + radius.ToString();

            queryUrl += "&categoryId=" + foodCode;

            HttpClient client = new HttpClient();
            string jsonString = null;
            try
            {
                jsonString = await client.GetStringAsync(queryUrl);
            }
            catch (Exception exp)
            {
            }
            if (jsonString != null)
            {
                FoursquareModel returnValue = JsonConvert.DeserializeObject<FoursquareModel>(jsonString);
                list = returnValue.response.venues.OrderBy(x => x.location.distance);
            }
            //icon_url = list.ElementAt(0).categories[0].icon.prefix + "100" + list.ElementAt(0).categories[0].icon.suffix;
        }

        public void get_json2()
        {
            queryUrl = apiUrl;
            queryUrl += "client_id=" + clientID;
            queryUrl += "&client_secret=" + clientSecret;
            queryUrl += "&v=" + String.Format("{0:yyyyMMdd}", DateTime.Now);

            queryUrl += "&ll=" + latitude + "," + longitude;

            queryUrl += "&radius=" + radius.ToString();

            queryUrl += "&categoryId=" + foodCode;

            string jsonString = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryUrl);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }
            FoursquareModel returnValue = JsonConvert.DeserializeObject<FoursquareModel>(jsonString);
            list = returnValue.response.venues.OrderBy(x => x.location.distance);
        }

        public void get_info()
        {
            if (list == null)
            {
                return;
            }
            int ind = 0;
            results = "";
            foreach (var item in list)
            {
                ind++;
                results += ind.ToString() + "." + " " + item.name + "; ";
                if (item.location != null)
                {
                    results += "Расстояние до места: " + item.location.distance.ToString() + " м; ";
                    results += "Адрес: ";
                    for (int i = item.location.formattedAddress.Count - 1; i >= 0; i--)
                        results += item.location.formattedAddress[i] + " ";
                    results += "; ";
                }
                if (item.categories != null)
                    results += "Категория заведения: " + item.categories[0].pluralName;
                results += "\r\n";
            }
        }
    }
}
