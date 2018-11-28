using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaniPocAPI.Models;

namespace HaniPocAPI
{
    public class BusinessLogic
    {
        private TestMVCEntities _db = new TestMVCEntities();
        
        public List<Continent> ShowContinentGetAll()
        {
            List<Continent> continent = _db.Continents.ToList();
            return continent;
        }

        public List<Country> ShowCountryByContinentId(ContinentModelForId continentModelForId)
        {
            List<Country> country = _db.Countries.Where(x => x.Continent_Id == continentModelForId.ContinentId).ToList();
            return country;
        }

        public List<City> ShowCityByCountryId(CountryModelForId countryModelForId)
        {
            List<City> city = _db.Cities.Where(x => x.Country_Id == countryModelForId.CountryId).ToList();
            return city;
        }

        public int AddDetail(SaveDetailModels model)
        {
            SaveDetail saveDetail = new SaveDetail();
            saveDetail.Name = model.Name;
            saveDetail.Continent = model.ContinentId;
            saveDetail.Country = model.CountryId;
            saveDetail.City = model.CityId;
            saveDetail.Remember = model.Remember ?? false;
            _db.SaveDetails.Add(saveDetail);
            int countOfDetailSaved = _db.SaveChanges();
            return countOfDetailSaved;
        }

        public int UpdateDetail(SaveDetailModels model)
        {
            int countOfDetailUpdated = 0;
            SaveDetail saveDetail = _db.SaveDetails.FirstOrDefault(x => x.Id == model.Id);
            if (saveDetail != null)
            {
                saveDetail.Name = model.Name;
                saveDetail.Continent = model.ContinentId;
                saveDetail.Country = model.CountryId;
                saveDetail.City = model.CityId;
                saveDetail.Remember = model.Remember;
                countOfDetailUpdated = _db.SaveChanges();

            }
            return countOfDetailUpdated;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteDetail(SaveDetailModels model)
        {
            int countOfDetailDeleted = 0;
            SaveDetail saveDetail = _db.SaveDetails.FirstOrDefault(x => x.Id == model.Id);
            if (saveDetail != null)
            {
                _db.SaveDetails.Remove(saveDetail);
                countOfDetailDeleted = _db.SaveChanges();
            }
            return countOfDetailDeleted;
        }


        public List<GridModels> ShowAllDetails()
        {
            List<GridModels> gridModels = _db.SaveDetails.AsEnumerable().Select((x, i) => new GridModels
            {
                SnoId = i + 1,
                Id = x.Id,
                Name = x.Name,
                ContinentName = _db.Continents.FirstOrDefault(y => x.Continent == y.Id).Continent_Name,
                ContinentId = x.Continent,
                CountryName = _db.Countries.FirstOrDefault(y => x.Country == y.Id).Country_Name,
                CountryId = x.Country,
                CityName = _db.Cities.FirstOrDefault(y => x.City == y.Id).City_Name,
                CityId = x.City,
                RememberMe = x.Remember
            }).ToList();
            return gridModels;
        }
    }
}