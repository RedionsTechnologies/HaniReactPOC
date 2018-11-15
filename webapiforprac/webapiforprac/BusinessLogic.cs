using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapiforprac.Models;

namespace webapiforprac
{
    public class BusinessLogic
    {
        private TestMVCEntities db = new TestMVCEntities();
        
        public List<tblContinent> ShowContinent()
        {
            List<tblContinent> continent = db.tblContinents.ToList();
            return continent;
        }

        public List<tblCountry> ShowCountry(ForContinent forContinent)
        {
            List<tblCountry> country = db.tblCountries.Where(x => x.Continent_Id == forContinent.continentId).ToList();
            return country;
        }

        public List<tblCity> ShowCity(ForCountry forCountry)
        {
            List<tblCity> city = db.tblCities.Where(x => x.Country_Id == forCountry.countryId).ToList();
            return city;
        }

        public int Detail(SaveDetailModels model)
        {
            SaveDetail saveDetail = new SaveDetail();
            saveDetail.Name = model.name;
            saveDetail.Continent = model.continentId;
            saveDetail.Country = model.countryId;
            saveDetail.City = model.cityId;
            saveDetail.Remember = model.remember ?? false;
            db.SaveDetails.Add(saveDetail);
            int i = db.SaveChanges();
            return i;
        }

        public int UpdateDetail(SaveDetailModels model)
        {
            int i = 0;
            SaveDetail saveDetail = db.SaveDetails.FirstOrDefault(x => x.Id == model.id);
            if (saveDetail != null)
            {
                saveDetail.Name = model.name;
                saveDetail.Continent = model.continentId;
                saveDetail.Country = model.countryId;
                saveDetail.City = model.cityId;
                saveDetail.Remember = model.remember;
                i = db.SaveChanges();

            }
            return i;
        }


        public int DeleteDetail(SaveDetailModels model)
        {
            int i = 0;
            SaveDetail saveDetail = db.SaveDetails.FirstOrDefault(x => x.Id == model.id);
            if (saveDetail != null)
            {
                db.SaveDetails.Remove(saveDetail);
                i = db.SaveChanges();
            }
            return 1;
        }


        public List<GridModels> ShowAllDetails()
        {
            List<GridModels> gridModels = db.SaveDetails.AsEnumerable().Select((x, i) => new GridModels
            {
                sId = i + 1,
                Id = x.Id,
                name = x.Name,
                continentName = db.tblContinents.FirstOrDefault(y => x.Continent == y.Id).Continent_Name,
                cntId = x.Continent,
                countryName = db.tblCountries.FirstOrDefault(y => x.Country == y.Id).Country_Name,
                cutId = x.Country,
                cityName = db.tblCities.FirstOrDefault(y => x.City == y.Id).City_Name,
                ctyId = x.City,
                rememberMe = x.Remember
            }).ToList();
            return gridModels;
        }
    }
}