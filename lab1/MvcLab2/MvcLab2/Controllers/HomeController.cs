using MvcLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace MvcLab2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            InteractorModel interactor = new InteractorModel();
            return View(interactor);
        }
        [HttpPost]
        public ActionResult Index(InteractorModel interactor)
        {
            if (HelperModel.latitude != null && HelperModel.longitude != null)
            {
                interactor.latitude = HelperModel.latitude;
                interactor.longitude = HelperModel.longitude;
            }
            interactor.get_json2();
            interactor.get_info();
            return View(interactor);
        }
        [HttpPost]
        public void Action(String items)
        {
            HelperModel.latitude = HelperModel.GetUntilOrEmpty(items, false);
            HelperModel.longitude = HelperModel.GetUntilOrEmpty(items, true);
        }

    }
}
