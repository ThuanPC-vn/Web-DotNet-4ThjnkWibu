using Bai6_23TH2519.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bai6_23TH2519.Controllers
{
    public class NhanViens23TH2519Controller : Controller
    {
        private QLNV_23TH2519Entities db = new QLNV_23TH2519Entities();


        // GET: NhanViens23TH2519
        public ActionResult GioiThieu_23TH2519()
        {
            return View();
        }

        public ActionResult TimKiem()
        {
            var nhanViens = db.NhanViens.Include(n => n.PhongBan);
            return View(nhanViens.ToList());
        }


        [HttpPost]
        public ActionResult TimKiem(int? maNV)
        {

            //var nhanViens = db.NhanViens.SqlQuery("exec NhanVien_DS '"+maNV+"' ");
            /// var nhanViens = db.NhanViens.SqlQuery("SELECT * FROM NhanVien WHERE id_NV='" + maNV + "'");
            var nhanViens = db.NhanViens.Where(abc => abc.id_NV == maNV);

            if (nhanViens != null)
            {
                ViewBag.Message = null;
                return View(nhanViens.ToList());
            }
            else
            {
                ViewBag.Message = "Không Có Nhân Viên Nào Mang ID Trên :(";
                return View(ViewBag);
            }

        }


        // GET: NhanViens23TH2519/TimKiem23TH2519

        [HttpGet]
        public ActionResult TimKiem_23TH2519(string maNV = "", string hoTen = "", string gioiTinh = "", string luongMin = "", string luongMax = "", string diaChi = "", string maPB = "")
        {
            string min = luongMin, max = luongMax;
            if (gioiTinh != "1" && gioiTinh != "0")
                gioiTinh = null;
            ViewBag.maNV = maNV;
            ViewBag.hoTen = hoTen;
            ViewBag.gioiTinh = gioiTinh;
            if (luongMin == "")
            {
                ViewBag.luongMin = "";
                min = "0";
            }
            else
            {
                ViewBag.luongMin = luongMin;
                min = luongMin;
            }
            if (max == "")
            {
                max = Int32.MaxValue.ToString();
                ViewBag.luongMax = "";// Int32.MaxValue.ToString(); 
            }
            else
            {
                ViewBag.luongMax = luongMax;
                max = luongMax;
            }
            ViewBag.diaChi = diaChi;
            ViewBag.MaPB = new SelectList(db.PhongBans, "id_PhongBan", "TenPhongBan");
            var nhanViens = db.NhanViens.SqlQuery("select'" + maNV + "','" + hoTen + "','" + gioiTinh + "','" + min + "','" + max + "',N'" + diaChi + "','" + maPB + "'");
            if (nhanViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(nhanViens.ToList());
        }


        // GET: NhanViens23TH2519
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.PhongBan);
            return View(nhanViens.ToList());
        }

        // GET: NhanViens23TH2519/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id.Value);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens23TH2519/Create
        public ActionResult Create()
        {
            ViewBag.id_PhongBan = new SelectList(db.PhongBans, "id_PhongBan", "TenPhongBan");
            return View();
        }

        // POST: NhanViens23TH2519/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoNV,TenNV,GioiTinh,NgaySinh,Luong,AnhNV,DiaChi,id_PhongBan")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {

                // Tìm giá trị id_NV lớn nhất hiện có và cộng thêm 1
                int maxId = db.NhanViens.Max(nv => (int?)nv.id_NV) ?? 0;
                nhanVien.id_NV = maxId + 1;

                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_PhongBan = new SelectList(db.PhongBans, "id_PhongBan", "TenPhongBan", nhanVien.id_PhongBan);
            return View(nhanVien);
        }

        // GET: NhanViens23TH2519/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_PhongBan = new SelectList(db.PhongBans, "id_PhongBan", "TenPhongBan", nhanVien.id_PhongBan);
            return View(nhanVien);
        }

        /**
         * To protect from overposting attacks, enable the specific properties you want to bind to, for 
         * more details see go.microsoft.com/fwlink/?LinkId=317598
         */
        // POST: NhanViens23TH2519/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_NV,HoNV,TenNV,GioiTinh,NgaySinh,Luong,AnhNV,DiaChi,id_PhongBan")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_PhongBan = new SelectList(db.PhongBans, "id_PhongBan", "TenPhongBan", nhanVien.id_PhongBan);
            return View(nhanVien);
        }

        // GET: NhanViens23TH2519/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens23TH2519/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}