using App_Data_ClassLib.Models;
using App_Data_ClassLib.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_MVC.Controllers
{
    public class SanPhamController : Controller
    {
        SD18302_NET104Context _context;
        AllRepository<SanPham> _repo;
        DbSet<SanPham> _sps;
        public SanPhamController()
        {
            _context = new SD18302_NET104Context();
            _sps = _context.SanPhams;
            _repo= new AllRepository<SanPham>(_sps, _context);
        }
        // GET: SanPhamController
        public ActionResult Index()
        {
            var data = _repo.GetAll();
            return View(data);
        }

        // GET: SanPhamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SanPhamController/Create
        [HttpPost]
        public ActionResult Create(SanPham sp, IFormFile imgFile)
        {
            // Xây dựng 1 đường dẫn để lưu ảnh trong thư mục wwwroot
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imgFile.FileName);
            // Kết quả thu được có dạng như sau: wwwroot/img/concho.png
            // Thực hiện việc sao chép file được chọn vào thư mục root
            var stream = new FileStream(path, FileMode.Create); 
            // Thực hiện sao chép ảnh vào thư mục root
            imgFile.CopyTo(stream);
            sp.ImgURL = imgFile.FileName;
            _repo.CreateObj(sp);
            return RedirectToAction("Index");
        }

        
        public ActionResult Create()
        {
                return View();
        }

        // GET: SanPhamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPhamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SanPhamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
