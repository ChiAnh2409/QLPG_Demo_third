﻿using QLPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLPG.Controllers
{
    public class ThanhVienController: Controller
    {
        private QLPG1Entities db = new QLPG1Entities(); 
        public ActionResult ThanhVien() 
        {
            List<ThanhVien> list = new List<ThanhVien>();
            list = db.ThanhVien.ToList();
            return View(list);
        }
        public ActionResult ThemDK()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemDK(ThanhVien tv)
        {
            if (ModelState.IsValid)
            {
                DateTime now = DateTime.Now;
                tv.NgayTao = now;
                db.ThanhVien.Add(tv);
                db.SaveChanges();

                // Tạo thông báo cho admin và lưu vào TempData
                string adminNotification = $"Thành viên {tv.TenTV} đã đăng ký phần tập {tv.TenGT} vào ngày {tv.NgayTao} với số điện thoại là {tv.SDT}.";
                TempData["AdminNotification"] = adminNotification;

                // Tăng biến đếm thông báo mới
                int newNotificationCount = (int)(TempData["NewNotificationCount"] ?? 0);
                TempData["NewNotificationCount"] = newNotificationCount + 1;

                TempData["SuccessMessage"] = "Đăng ký thành công!";
            }

            // Trả lại cùng view ThemDK (tức là view hiện tại)
            return View("ThemDK");
        }
        public ActionResult ThemTV() 
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult ThemTV(ThanhVien tv)
        {
            DateTime now = DateTime.Now; 
            tv.NgayTao = now;
            db.ThanhVien.Add(tv);
            db.SaveChanges();
            return RedirectToAction("ThanhVien");
        }
        public ActionResult SuaTV(int id)
        {
            ThanhVien tv = db.ThanhVien.Find(id);
            return View(tv);
        }
        [HttpPost]
        public ActionResult SuaTV(ThanhVien tv)
        {
            //DateTime now = DateTime.Now;
            //tv.NgayTao = now;
            db.Entry(tv).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ThanhVien");
        }
        [HttpPost]
        public ActionResult XoaTV(int id)
        {
            ThanhVien tv = db.ThanhVien.Find(id);
            db.ThanhVien.Remove(tv);
            db.SaveChanges();
            return RedirectToAction("ThanhVien");
        }
        [HttpPost]
        public ActionResult TimKiemTV(string search)
        {
            // Thực hiện tìm kiếm dựa trên chuỗi `search`
            var results = db.ThanhVien.Where(tv => tv.TenTV.Contains(search)).ToList();

            return View("ThanhVien", results);
        }

    }
}