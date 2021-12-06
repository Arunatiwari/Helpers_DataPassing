using Helpers_DataPassing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Helpers_DataPassing.Models.UserModel;

namespace Helpers_DataPassing.Controllers
{
    public class AccountController : Controller
    {
        List<Country> LstCountries;
        List<City> LstCities;
        public AccountController()
        {
            LstCountries = new List<Country>()
            {
                new Country(){CountryId=1, CountryName="India"},
                new Country(){CountryId=2, CountryName="New ZeeLand"}
            };

            LstCities = new List<City>()
            {
                new City(){CityId=1, CityName="Delhi", CountryId=1},
                new City(){CityId=2, CityName="Bangalore", CountryId = 1},
                new City(){CityId=3, CityName="Auckland", CountryId=2},
                new City(){CityId=4, CityName="Hamilton", CountryId=2}
            };
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.LstCountries = new SelectList(LstCountries, "CountryId", "CountryName");
            ViewData["Gender"] = new List<string>()
            {
                new string("Male"),
                new string("Female")
            };
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public JsonResult getCity(int CountryId)
        {
            List<City> Cities = LstCities.FindAll(x => x.CountryId == CountryId);
            return Json(Cities);
        }


    }
}
