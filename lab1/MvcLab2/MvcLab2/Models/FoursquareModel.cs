﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace MvcLab2.Models
{
    public class FoursquareModel
    {
        public Meta meta { get; set; }
        public Item item { get; set; }
        public Notification notification { get; set; }
        public Contact contact { get; set; }
        public Location location { get; set; }
        public Icon icon { get; set; }
        public Category category { get; set; }
        public Stats stats { get; set; }
        public Specials specials { get; set; }
        public HereNow herenow { get; set; }
        public BeenHere beenhere { get; set; }
        public Menu menu { get; set; }
        public VenuePage venuepage { get; set; }
        public Venue venue { get; set; }
        public Response response { get; set; }
        public RootObject rootobject { get; set; }

        public class Meta
        {
            public int code { get; set; }
        }

        public class Item
        {
            public int unreadCount { get; set; }
        }

        public class Notification
        {
            public string type { get; set; }
            public Item item { get; set; }
        }

        public class Contact
        {
            public string phone { get; set; }
            public string formattedPhone { get; set; }
            public string twitter { get; set; }
            public string facebook { get; set; }
            public string facebookUsername { get; set; }
            public string facebookName { get; set; }
        }

        public class Location
        {
            public string address { get; set; }
            public string crossStreet { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
            public int distance { get; set; }
            public string postalCode { get; set; }
            public string cc { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public List<string> formattedAddress { get; set; }
        }

        public class Icon
        {
            public string prefix { get; set; }
            public string suffix { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pluralName { get; set; }
            public string shortName { get; set; }
            public Icon icon { get; set; }
            public bool primary { get; set; }
        }

        public class Stats
        {
            public int checkinsCount { get; set; }
            public int usersCount { get; set; }
            public int tipCount { get; set; }
        }

        public class Specials
        {
            public int count { get; set; }
            public List<object> items { get; set; }
        }

        public class HereNow
        {
            public int count { get; set; }
            public string summary { get; set; }
            public List<object> groups { get; set; }
        }

        public class BeenHere
        {
            public int count { get; set; }
            public bool marked { get; set; }
        }

        public class Menu
        {
            public string type { get; set; }
            public string label { get; set; }
            public string anchor { get; set; }
            public string url { get; set; }
            public string mobileUrl { get; set; }
        }

        public class VenuePage
        {
            public string id { get; set; }
        }

        public class Venue
        {
            public string id { get; set; }
            public string name { get; set; }
            public Contact contact { get; set; }
            public Location location { get; set; }
            public List<Category> categories { get; set; }
            public bool verified { get; set; }
            public Stats stats { get; set; }
            public Specials specials { get; set; }
            public HereNow hereNow { get; set; }
            public string storeId { get; set; }
            public string referralId { get; set; }
            public BeenHere beenHere { get; set; }
            public Menu menu { get; set; }
            public string url { get; set; }
            public VenuePage venuePage { get; set; }
        }

        public class Response
        {
            public List<Venue> venues { get; set; }
            public bool confident { get; set; }
        }

        public class RootObject
        {
            public Meta meta { get; set; }
            public List<Notification> notifications { get; set; }
            public Response response { get; set; }
        }
    }
}
