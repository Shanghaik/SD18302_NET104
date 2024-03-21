using App_Data_ClassLib.IRepository;
using App_Data_ClassLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Repository
{
    public class AllRepository<G> : IAllRepository<G> where G : class
    {
        SD18302_NET104Context context;
        DbSet<G> dbset; // CRUD trên DBset vì nó đại diện cho bảng
        // Khi cần gọi lại và dùng thật thì lại cần chính xác nó là DBSet nào
        // Lúc đó ta sẽ gán dbset = DBset cần dùng
        public AllRepository()
        {
            context = new SD18302_NET104Context();
        }
        public AllRepository(DbSet<G> dbset, SD18302_NET104Context context)
        {
            this.dbset = dbset; // Gán lại khi dùng
            this.context = context;
        }
        public bool CreateObj(G obj) // Thêm mới
        {
            try
            {
                dbset.Add(obj);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteObj(dynamic id)
        {
            try
            {
                // Tìm trong bảng đối tượng cần xóa
                var deleteObj = dbset.Find(id); // find truyền vào thuộc tính
                // chỉ sử dụng với PK
                dbset.Remove(deleteObj); // xóa
                context.SaveChanges(); // Lưu lại
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<G> GetAll()
        {
            return dbset.ToList();
        }

        public G GetByID(dynamic id)
        {
            return dbset.Find(id);
        }

        public bool UpdateObj(G obj)
        {
            try
            {
                dbset.Update(obj); // sửa
                context.SaveChanges(); // Lưu lại
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
