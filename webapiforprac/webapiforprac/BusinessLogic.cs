using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapiforprac.Models;

namespace webapiforprac
{
    public class BusinessLogic
    {
        private TestMVCEntities _db = new TestMVCEntities();
        
        public List<Continent> ShowContinentGetAll()
        {
            List<Continent> continent = _db.Continents.ToList();
            return continent;
        }

        public List<Country> ShowCountryByContinentId(ContinentModelForId forContinent)
        {
            List<Country> country = _db.Countries.Where(x => x.Continent_Id == forContinent.continentId).ToList();
            return country;
        }

        public List<City> ShowCityByCountryId(ForCountry forCountry)
        {
            List<City> city = _db.Cities.Where(x => x.Country_Id == forCountry.countryId).ToList();
            return city;
        }

        public int AddDetail(SaveDetailModels model)
        {
            SaveDetail saveDetail = new SaveDetail();
            saveDetail.Name = model.name;
            saveDetail.Continent = model.continentId;
            saveDetail.Country = model.countryId;
            saveDetail.City = model.cityId;
            saveDetail.Remember = model.remember ?? false;
            _db.SaveDetails.Add(saveDetail);
            int countOfDetailSaved = _db.SaveChanges();
            return countOfDetailSaved;
        }

        public int UpdateDetail(SaveDetailModels model)
        {
            int countOfDetailUpdated = 0;
            SaveDetail saveDetail = _db.SaveDetails.FirstOrDefault(x => x.Id == model.id);
            if (saveDetail != null)
            {
                saveDetail.Name = model.name;
                saveDetail.Continent = model.continentId;
                saveDetail.Country = model.countryId;
                saveDetail.City = model.cityId;
                saveDetail.Remember = model.remember;
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
            SaveDetail saveDetail = _db.SaveDetails.FirstOrDefault(x => x.Id == model.id);
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
                sId = i + 1,
                Id = x.Id,
                name = x.Name,
                continentName = _db.Continents.FirstOrDefault(y => x.Continent == y.Id).Continent_Name,
                cntId = x.Continent,
                countryName = _db.Countries.FirstOrDefault(y => x.Country == y.Id).Country_Name,
                cutId = x.Country,
                cityName = _db.Cities.FirstOrDefault(y => x.City == y.Id).City_Name,
                ctyId = x.City,
                rememberMe = x.Remember
            }).ToList();
            return gridModels;
        }
    }
}