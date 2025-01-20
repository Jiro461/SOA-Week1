using SOAHomeWork.Data;
using SOAHomeWork.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SOAHomeWork
{
    /// <summary>
    /// Summary description for MyServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyServices : System.Web.Services.WebService
    {
        public readonly DatabaseManagement _db;
        public MyServices()
        {
            _db = new DatabaseManagement();
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<country> getAllCountry()
        {
            return _db.getAllCountry();
        }
        [WebMethod]
        public List<country> getCountryByCode(string code)
        {
            return _db.getCountrybyCode(code);
        }
        [WebMethod]
        public List<city> getCityByName(string name)
        {
            return _db.getCityByName(name);
        }
        [WebMethod]
        public List<city> getCityBySpecificCountry(string country)
        {
            return _db.getAllCitiesOfCountry(country);
        }
        [WebMethod]
        public List<country> getAllCountryByPopulation (int  population)
        {
            return _db.getAllCountryByPopulation(population);
        }
        [WebMethod]
        public List<country> getAllCountryByGNP(decimal GNP)
        {
            return _db.getAllCountryByGNP((decimal)GNP);
        }
        [WebMethod]
        public List<countrylanguage> getOfficialLanguageByCountryName (string countryName)
        {
            return _db.getOfficialLanguageByCountryName(countryName);
        }
    }
}
