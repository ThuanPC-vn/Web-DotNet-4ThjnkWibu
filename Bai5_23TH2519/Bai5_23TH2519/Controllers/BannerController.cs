using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai5_23TH2519.Controllers
{
    public class BannerController : Controller
    {
        // GET: Banner
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeBanner(HttpPostedFileBase banner)
        {
            // Lấy tên file từ file tải lên
            String postedFileName = System.IO.Path.GetFileName(banner.FileName);

            // Kiểm tra và loại bỏ khoảng trắng nếu có
            if (postedFileName.Contains(" "))
            {
                postedFileName = postedFileName.Replace(" ", "-");
            }

            // Đường dẫn lưu file
            var path = Server.MapPath("/Images/" + postedFileName);

            // Lưu file vào thư mục Images
            banner.SaveAs(path);

            // Lưu tên file vào banner.txt
            String fSave = Server.MapPath("/banner.txt");
            System.IO.File.WriteAllText(fSave, postedFileName);

            return View("Index");
        }
    }
}