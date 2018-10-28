using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Temperature___Jovana_Gligorevic.Models;

namespace Temperature___Jovana_Gligorevic.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Index(decimal? latitude, decimal? longitude)
        {
            XmlNodeList atributi = null;
            TemperatureApi model = new TemperatureApi();
            if (latitude != null && longitude != null)
            {

                string api = "https://api.met.no/weatherapi/locationforecast/1.9/?lat=" + Math.Round((decimal)latitude, 2).ToString() + ";lon=" + Math.Round((decimal)longitude, 2).ToString();
                XmlDocument doc = new XmlDocument();
                doc.Load(api);
                XmlNodeList list = doc.GetElementsByTagName("time");

                DateTime date = DateTime.Now;

                foreach (XmlNode node in list)
                {
                    short fromH = Convert.ToInt16(node.Attributes["from"].InnerText.Split('T')[1].Split(':')[0]);
                    short toH = Convert.ToInt16(node.Attributes["to"].InnerText.Split('T')[1].Split(':')[0]);
                    if (fromH == date.Hour && toH == date.Hour)
                    {
                        atributi = node.ChildNodes[0].ChildNodes;
                    }
                }                            
            }

            foreach (XmlNode item in atributi)
            {
                switch (item.Name)
                {
                    case "temperature": model.Temperature = Convert.ToDecimal(item.Attributes["value"].Value); break;
                    case "windDirection": model.WindDirection = Convert.ToDecimal(item.Attributes["deg"].Value); break;
                    case "windSpeed": model.WindSpeed = Convert.ToDecimal(item.Attributes["mps"].Value); break;
                    case "humidity": model.Humidity = Convert.ToDecimal(item.Attributes["value"].Value); break;
                    case "pressure": model.Pressure = Convert.ToDecimal(item.Attributes["value"].Value); break;
                    case "cloudiness": model.Cloudiness = Convert.ToDecimal(item.Attributes["percent"].Value); break;
                    case "fog": model.Fog = Convert.ToDecimal(item.Attributes["percent"].Value); break;
                    case "lowClouds": model.LowClouds = Convert.ToDecimal(item.Attributes["percent"].Value); break;
                    case "mediumClouds": model.MediumClouds = Convert.ToDecimal(item.Attributes["percent"].Value); break;
                    case "highClouds": model.HighClouds = Convert.ToDecimal(item.Attributes["percent"].Value); break;
                    case "dewpointTemperature": model.DewpointTemperature = Convert.ToDecimal(item.Attributes["value"].Value); break;
                    default: break;
                }
            }
            return Json(model);
        }
    }
}