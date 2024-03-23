using App_Data_ClassLib.Models;
using App_Data_ClassLib.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_MVC.Controllers
{
    public class UserController : Controller
    {
        SD18302_NET104Context _context;
        AllRepository<User> _repo;
        DbSet<User> _users;
        public UserController()
        {
            // Khởi tạo DBContext
            _context = new SD18302_NET104Context();
            // Khởi tạo repository với 2 tham số là DbSet và DBContext
            _users = _context.Users;
            _repo = new AllRepository<User>(_users, _context);
        }
        // Lấy ra tất cả danh sách Users
        public IActionResult Index()
        {
            var userData = _repo.GetAll();
            return View(userData);
        }
        // Thêm data
        public IActionResult Create() // Action để mở form điền thông tin user
        {
            return View();
        }
        // Action để thực hiện thêm vào DB
        [HttpPost]
        public IActionResult Create(User user)
        {
            user.ID = Guid.NewGuid();   
            _repo.CreateObj(user);
            return RedirectToAction("Index");
        }
        // Sửa
        public IActionResult Edit(Guid id) // Form load ra đối tượng cần sửa
        {
            // Lấy ra đối tượng cần sửa
            var updateUser = _repo.GetByID(id);
            return View(updateUser);
        }
        // Sửa
        public IActionResult EditUser(User user) // Action này thực hiện thay đổi, khi cần thì trỏ tới nó
        {
            _repo.UpdateObj(user);
            return RedirectToAction("Index");
        }
        // Xóa
        public IActionResult Delete(Guid id) {
            _repo.DeleteObj(id);
            return RedirectToAction("Index");
        }
        // Thông tin Details
        public IActionResult Details(Guid id)
        {
            var getUser = _repo.GetByID(id);
            return View(getUser);
        }

        public IActionResult Login() // Action này return về View để mở View cho phép nhập thông tin đăng nhập
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Login(string username, string password) // Action này thực hiện đăng nhập
        {
            var user = _repo.GetAll().FirstOrDefault(p=>p.Username == username && p.Password == password);
            if (user != null)
            {
                //return Content("Đăng nhập oke");
                // Dùng TempData để lưu trữ dữ liệu đăng nhập tạm thời 
                TempData["login"] = username;
                return RedirectToAction("Index", "Home");
            }
            else return Content("Đăng nhập thất bại");
        }

    }
}
