using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

public partial class _Default : System.Web.UI.Page
{
    public class Location
    {
        public string IPAddress { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimeZone { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //string ipAddress = "2001:1970:51a2:9f00:f4eb:e86d:d17c:6d9a";
        if (string.IsNullOrEmpty(ipAddress))
        {
            ipAddress = Request.ServerVariables["REMOTE_ADDR"];
        }

        string APIKey = "2ec5b89b3540f4e2b83ee32862e297b051afc644738353b9f9b7dcd353ea86c5";
        string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=json", APIKey, ipAddress);
        using (WebClient client = new WebClient())
        {
            string json = client.DownloadString(url);
            Location location = new JavaScriptSerializer().Deserialize<Location>(json);
            List<Location> locations = new List<Location>();
            locations.Add(location);
            gvLocation.DataSource = locations;
            gvLocation.DataBind();
        }

        int counter = 0;
        if (Request.Cookies["pCookie"] != null)
            counter = Int32.Parse(Request.Cookies["pCookie"].Value);

        counter++;

        Response.Cookies["pCookie"].Value = counter.ToString();
        Response.Cookies["pCookie"].Expires = DateTime.Now.AddMonths(1);

        lblvisits.Text = counter.ToString();
    }
}