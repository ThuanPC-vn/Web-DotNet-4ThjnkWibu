using Bai2_23TH2519.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai2_23TH2519.Controllers
{
    public class SinhVien_23TH2519Controller : Controller
    {
        // GET: SinhVien_23TH2519
        public ActionResult Index()
        {
            return View();
        }

        // Cách 1
        [HttpPost]
        public ActionResult Register1(FormCollection field)
        {
            ViewBag.Id = field["Id"];
            ViewBag.Name = field["Name"];
            ViewBag.Marks = field["Marks"];
            return View(ViewBag);
        }



        // Cách 2
        [HttpPost]
        public ActionResult Register2()
        {
            ViewBag.Id = Request["Id"];
            ViewBag.Name = Request["Name"];
            ViewBag.Marks = Request["Marks"];
            return View(ViewBag);
        }



        // Cách 3
        [HttpPost]
        public ActionResult Register3(string Id, string Name, string Marks)
        {
            ViewBag.Id = Id;
            ViewBag.Name = Name;
            ViewBag.Marks = Marks;
            return View(ViewBag);
        }



        // Cách 4
        [HttpPost]
        public ActionResult UseModel(SVModel sV)
        {
            ViewBag.Id = sV.Id;
            ViewBag.Name = sV.Name;
            ViewBag.Marks = sV.Marks;
            return View(ViewBag);
        }
    }
}