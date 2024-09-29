using Bai5_23TH2519.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai5_23TH2519.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase Avatar, EmpModel emp)
        {
            //Lấy thông tin từ input type=file có tên Avatar 
            string postedFileName = System.IO.Path.GetFileName(Avatar.FileName);

            //Thay thế khoảng trắng bằng ký tự "-" để tránh lỗi
            if (postedFileName.Contains(" "))
            {
                postedFileName = postedFileName.Replace(" ", "-");
            }

            //Lưu hình đại diện về Server 
            var path = Server.MapPath("/Images/" + postedFileName);
            Avatar.SaveAs(path);
            string fSave = Server.MapPath("/emp.txt");
            var emInfo = new Dictionary<string, string>
            {
                { "EmpID", emp.EmpID },
                { "Name", emp.Name },
                { "BirthOfDate", emp.BirthOfDate.ToShortDateString() },
                { "Job", emp.Job },
                { "Address", emp.Address },
                { "Email", emp.Email },
                { "Password", emp.Password },
                { "Department", emp.Department },
                { "PostedFileName", postedFileName }
            };

            // Chuyển đổi từ mảng thành string
            var lines = new List<string>();
            foreach (var kvp in emInfo)
            {
                lines.Add($"{kvp.Value}");
            }

            //Lưu các thông tin vào tập tin emp.txt 
            System.IO.File.WriteAllLines(fSave, lines);

            //Ghi nhận các thông tin đăng ký để hiện thị trên View Confirm 
            ViewBag.EmpID = emInfo["EmpID"];
            ViewBag.Name = emInfo["Name"];
            ViewBag.BirthOfDate = emInfo["BirthOfDate"].ToString();
            ViewBag.Job = emInfo["Job"];
            ViewBag.Address = emInfo["Address"];
            ViewBag.Email = emInfo["Email"];
            ViewBag.Password = emInfo["Password"];
            ViewBag.Department = emInfo["Department"];
            ViewBag.Avatar = "/Images/" + emInfo["PostedFileName"];
            return View("Confirm");
        }
        public ActionResult Confirm(EmpModel emp)
        {
            return View();
        }
    }
}