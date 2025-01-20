using SOAHomeWork.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAHomeWork.Data
{
    public class DatabaseManagement
    {
        public WorldEntities _db;
        public DatabaseManagement() 
        {
            _db = new WorldEntities();
        }
        // Get all countries from database.
        public List<country> getAllCountry() { 
            var allCountry = _db.countries.Take(50).ToList();
            return allCountry;
        }
        // Get country by country code.
        public List<country> getCountrybyCode(string code)
        {
            var response = _db.countries.Where(c => c.Code == code).ToList();
            return response;
        }
        // Get city by name.
        public List<city> getCityByName (string name)
        {
            var response = _db.cities.Where(c => c.Name == name).ToList();
            return response;
        }
        // Get all cities of a specific country.
        public List<city> getAllCitiesOfCountry (string country)
        {
            var response = _db.countries
                .Where(c => c.Name == country)
                .Join(_db.cities, code => code.Code, city => city.CountryCode, (code, city) => city)
                .ToList();
            return response;
        }
        //  Get all country by specific population
        public List<country> getAllCountryByPopulation (int population)
        {
            var response = _db.countries.Where(c => c.Population >= population).Take(50).ToList();
            return response;
        }
        // Get all Country by specific GNP
        public List<country> getAllCountryByGNP (decimal GNP)
        {
            var response = _db.countries.Where(c => c.GNP >= GNP).Take(50).ToList();
            return response;
        }
        // Get official language by CountryName
        public List<countrylanguage> getOfficialLanguageByCountryName (string countryName)
        {
            var response = _db.countries
                .Where(c => c.Name == countryName)
                .Join(_db.countrylanguages, country => country.Code, language => language.CountryCode, (country, language) => language)
                .Where(language => language.IsOfficial.ToUpper().Equals("T")).ToList();
            return response;
        }
    }
}