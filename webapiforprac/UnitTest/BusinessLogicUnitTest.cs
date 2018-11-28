using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using webapiforprac;
using System.Collections.Generic;
using webapiforprac.Controllers;
using webapiforprac.Models;

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
                continentId=1,

            };
            var countrytList = businessLogic.ShowCountryByContinentId(continentModel);
            Assert.IsNotNull(countrytList);
        }
        [TestMethod]
        public void CityListTest()
        {
            BusinessLogic businessLogic = new BusinessLogic();
            ForCountry countryModel = new ForCountry
            {
                countryId = 1,

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
                name = "Manish",
                continentId = 2,
            countryId=5,
            cityId=14,
            remember=true

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
                id=3,
                name = "Piyush",
                continentId = 2,
                countryId = 5,
                cityId = 14,
                remember = true

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
