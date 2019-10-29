using Kibiriukas.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Kibiriukas.ViewModels;
using Z.EntityFramework.Plus;
using Newtonsoft.Json.Linq;

namespace Kibiriukas.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context;

        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Profile
        [HttpGet]
        public ActionResult Index()
        {
            return View("Profile", getLoggedInUserProfileViewModel());
        }

        private ProfileViewModel getLoggedInUserProfileViewModel()
        {
            User user = getUserById(getLoggedInUserId());
            user.UserLanguages = _context.UserLanguage.Include("Language").Where(x => x.UserId == user.UserId).ToList();
            List<Language> languages = _context.Language.ToList();
            ProfileViewModel pvm = new ProfileViewModel { user = user, languages = languages, modelIsValid = ModelState.IsValid };
            return pvm;
        }

        private User getUserById(int id)
        {
            User user = _context.User.Include("UserLanguages").Where(x => x.UserId == id).First();
            return user;
        }

        private int getLoggedInUserId()
        {
            User user = _context.User.Where(x => x.Email == User.Identity.Name).First();
            return user.UserId;
        }

        private Language getLanguageById(int id)
        {
            Language language = _context.Language.Where(x => x.LanguageId == id).First();
            return language;
        }

        private void deleteUserLanguages(List<UserLanguage> languagesToBeDeleted)
        {
            foreach (UserLanguage toBeDeletedLang in languagesToBeDeleted)
                _context.UserLanguage.Where(userLang => userLang.UserLanguageId == toBeDeletedLang.UserLanguageId).Delete();
        }

        private void addUserLanguages(int userId, List<UserLanguage> languagesToBeAdded)
        {
            foreach (UserLanguage userLang in languagesToBeAdded)
            {
                _context.UserLanguage.Add(new UserLanguage { UserId = userId, LanguageId = userLang.LanguageId });
            }
        }

        /// <summary>
        /// If profile was saved: Saves user profile changes in the database.
        /// If edit profile form was canceled: passes the previously saved profile view model on to the view.  
        /// </summary>
        [HttpPost]
        public ActionResult SaveProfile(ProfileViewModel profileViewModel, string submit)
        {
            JsonResult geoData = GetGeoDataByExactName(profileViewModel.user.City);
            dynamic searchResults = JObject.Parse(geoData.Data.ToString());

            //edit profile form was canceled
            if (!ModelState.IsValid || searchResults.totalResultsCount <= 0)
            {
                ProfileViewModel pvm = getLoggedInUserProfileViewModel();
                pvm.modelIsValid = false;
                return View("Profile", pvm);
            }

            if (submit == "save")
            {
                User user = getUserById(profileViewModel.user.UserId);
                List<UserLanguage> languagesToBeDeleted = new List<UserLanguage>();
                List<UserLanguage> languagesToBeAdded = new List<UserLanguage>();

                if (profileViewModel.user.UserLanguages != null)
                    languagesToBeDeleted = user.UserLanguages.Where(userLang => !profileViewModel.user.UserLanguages.Any(pvm => pvm.UserLanguageId == userLang.UserLanguageId)).ToList();          
                else if (user.UserLanguages != null)//all user languages should be deleted
                    languagesToBeDeleted = user.UserLanguages.ToList();

                if (languagesToBeDeleted.Count() > 0)
                    deleteUserLanguages(languagesToBeDeleted);

                if (profileViewModel.user.UserLanguages != null)
                    languagesToBeAdded = profileViewModel.user.UserLanguages.Where(userLang => !user.UserLanguages.Any(x => x.UserLanguageId == userLang.UserLanguageId)).ToList();

                if (languagesToBeAdded.Count() > 0)
                    addUserLanguages(profileViewModel.user.UserId, languagesToBeAdded);

                if (profileViewModel.user.SelfIntroduction != user.SelfIntroduction)
                    user.SelfIntroduction = profileViewModel.user.SelfIntroduction;

                if (profileViewModel.user.City != user.City)
                { 
                    if (searchResults.totalResultsCount > 0)
                        user.City = profileViewModel.user.City;
                }

                if (_context.ChangeTracker.HasChanges())
                    _context.SaveChanges();
            }
            return View("Profile", getLoggedInUserProfileViewModel());
        }

        /// <summary>
        /// Returns the first four cities whose names start with the string in parameter
        /// </summary>
        [HttpGet]
        public JsonResult GetAutoCompleteGeoData(string location)
        {
            Dictionary<string, string> filters = new Dictionary<string, string>()
            {
                { "country", "LT"},
                {"lang", "LT" },
                {"feature_code", "PPL" },
                {"name_startsWith", location }
            };
            GeoData geoData = new GeoData(filters);
            geoData.GetAutoCompleteData(4);
            return Json(JsonConvert.SerializeObject(geoData.AutoCompleteGeoData), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Searches an exact match of the city string in the city API
        /// </summary>
        [HttpGet]
        public JsonResult GetGeoDataByExactName(string location)
        {
            Dictionary<string, string> filters = new Dictionary<string, string>()
            {
                { "country", "LT"},
                {"lang", "LT" },
                {"feature_code", "PPL" },
                {"name_equals", location }
            };

            GeoData geoData = new GeoData(filters);
            return Json(JsonConvert.SerializeObject(geoData.Results), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserLanguages()
        {
            int loggedInUserId = getLoggedInUserId();
            List<int> userlangIds = _context.UserLanguage.Where(x => x.UserId == loggedInUserId).Select(y => y.LanguageId).ToList();
            return Json(JsonConvert.SerializeObject(userlangIds), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Generates html for a newly added user language
        /// </summary>
        [HttpPost]
        public ViewResult AddLanguageRow(int languageId)
        {
            UserLanguage userLang = new UserLanguage();
            userLang.language = getLanguageById(languageId);
            userLang.LanguageId = userLang.language.LanguageId;
            userLang.UserId = getLoggedInUserId();
            return View("Partials/UserLanguageRow", userLang);
        }

        [HttpGet]
        public JsonResult GetUserSelfIntro()
        {
            int loggedInUserId = getLoggedInUserId();

            if (_context.User.Where(x => x.UserId == loggedInUserId).FirstOrDefault().SelfIntroduction == null)
                return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);
            
            return Json(JsonConvert.SerializeObject(_context.User.Where(x => x.UserId == loggedInUserId).FirstOrDefault().SelfIntroduction.ToString()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserCity()
        {
            int loggedInUserId = getLoggedInUserId();
            string city = _context.User.Where(x => x.UserId == loggedInUserId).First().City.ToString();
            return Json(JsonConvert.SerializeObject(city), JsonRequestBehavior.AllowGet);
        }
    }
}