using App.BusinessLogicModel;
using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace App.PhoneNoDetection.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PhoneNoDetection(PhoneDetectionvM vM)
        {
            if (!string.IsNullOrEmpty(vM.PhoneNo))
            {                
                var detector = new PhoneNumberDetector();
                var phoneNumbersWithFormats = detector.DetectPhoneNumbers(vM.PhoneNo);
                return Json(phoneNumbersWithFormats, JsonRequestBehavior.AllowGet);
            }
            else
            {
                vM.msg = "Please Input Text to detect phone no.";
                return Json(vM.msg, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}