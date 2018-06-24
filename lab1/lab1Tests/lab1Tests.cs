using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using BussLogic;
using Moq;
using System.IO;
using System.Reflection;

namespace lab1Tests
{
    [TestClass]
    public class lab1Tests
    {
        [TestMethod]
        public void check_is_digit()
        {
            Char ch = '5';
            bool digit = Helper.check_is_digit(ch);
            Assert.AreEqual(true, digit);
        }
        [TestMethod]
        public void testHelperUntil()
        {
            string ll = "44232.5343,65.9569";
            string expectStr = "44232.5343";
            string actStr = Helper.GetUntilOrEmpty(ll, false);
            Assert.AreEqual(expectStr, actStr);
        }
        [TestMethod]
        public void testHelperAfter()
        {
            string ll = "44232.5343,65.9569";
            string expectStr = "65.9569";
            string actStr = Helper.GetUntilOrEmpty(ll, true);
            Assert.AreEqual(expectStr, actStr);
        }
        [TestMethod]
        public void check_url()
        {
            Interactor interactor = new Interactor();
            var mock = new Mock<IClient>();
            mock.Setup(a => a.create_url()).Returns("https://api.foursquare.com/v2/venues/search?client_id=UCUKXZJTIQZBZ4DOV0N403J5Y55Z0IDB4IGAP5Y0CEDEE1WX&client_secret=TWIYGZRSP3MO4JW0PZZZ2CZBSYBOWJIBM4ES2KJ0HC05TXRR&v=20180528&ll=48.7,44.5&radius=1000&categoryId=4bf58dd8d48988d17f941735");
            var mockRes = mock.Object.create_url();
            interactor.selectCategory = 0;
            Assert.AreEqual(mockRes, interactor.create_url());
        }
        [TestMethod]
        public void check_json()
        {
            Interactor interactor = new Interactor();
            var mock = new Mock<IClient>();
            mock.Setup(a => a.get_json()).Returns(get_local_json());
            string results = interactor.get_info(mock.Object.get_json(), true);
            string expectRes = get_local_results();
            Assert.AreEqual(expectRes, results);
        }
        public IEnumerable<Foursquare.Venue> get_local_json()
        {
            IEnumerable<Foursquare.Venue> list;
            string jsonString = File.ReadAllText(@"test_data.json");
            Foursquare returnValue = JsonConvert.DeserializeObject<Foursquare>(jsonString);
            list = returnValue.response.venues.OrderBy(x => x.location.distance);
            return list;
        }
        public string get_local_results()
        {
            string results = File.ReadAllText(@"test_data_res.txt");
            string newRes = "";
            for (int i = 0; i < results.Length; i++)
            {
                if (results[i] != '\\')
                    newRes += results[i];
            }
            return newRes;
        }
    }
}
