using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HaniPocAPI;
using System.Collections.Generic;
using HaniPocAPI.Controllers;
using HaniPocAPI.Models;

namespace UnitTest
{
    [TestClass]
    public class BusinessLogicUnitTest
    {
        [TestMethod]
        public void ContinentListTest()
        {
            BusinessLogic businessLogic = new BusinessLogic();
            var continentList = businessLogic.ShowContinentGetAll();
            Assert.IsNotNull(continentList);
        }
        [TestMethod]
        public void CountryListTest()
        {
            BusinessLogic businessLogic = new BusinessLogic();
            ContinentModelForId continentModel = new ContinentModelForId
            {
                ContinentId=1,

            };
            var countrytList = businessLogic.ShowCountryByContinentId(continentModel);
            Assert.IsNotNull(countrytList);
        }
        [TestMethod]
        public void CityListTest()
        {
            BusinessLogic businessLogic = new BusinessLogic();
            CountryModelForId countryModel = new CountryModelForId
            {
                CountryId = 1,

            };
            var citytList = businessLogic.ShowCityByCountryId(countryModel);
            Assert.IsNotNull(countryModel);
        }

        [TestMethod]
        public void InsertTest()
        {
            BusinessLogic businessLogic = new BusinessLogic();
            SaveDetailModels detailModel = new SaveDetailModels
            {
                Name = "Manish",
                ContinentId = 2,
            CountryId=5,
            CityId=14,
            Remember=true

            };
            var addDetail = businessLogic.AddDetail(detailModel);
            Assert.AreNotEqual(0, addDetail);
        }

        [TestMethod]
        public void UpdateTest()
        {
            BusinessLogic businessLogic = new BusinessLogic();
            SaveDetailModels detailModel = new SaveDetailModels
            {
                Id=3,
                Name = "Piyush",
                ContinentId = 2,
                CountryId = 5,
                CityId = 14,
                Remember = true

            };
            var updateDetail = businessLogic.UpdateDetail(detailModel);
            Assert.AreNotEqual(0, updateDetail);
        }

        [TestMethod]
        public void AllDataTest()
        {
            BusinessLogic businessLogic = new BusinessLogic();
            var showAll = businessLogic.ShowAllDetails();
            Assert.IsNotNull(showAll);
        }
    }
}
