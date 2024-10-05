using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDBContext :DbContext   
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
               
        }
        public DbSet<Category> Categories { get; set; }
        // chỗ này là tạo 1 table name Categories trong database với các thuộc tính của Category trong model
        // sau đấy chạy câu lệnh add-migration AddCategoryTableToDb để tạo file migration, rồi chạy câu lệnh update-database để tạo table Categories trong database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Web Development", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Programming", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Networking", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Database", DisplayOrder = 4 }
                );
            //CẦN PHẢI ADD-MIGRATION CMD ĐỂ TẠO FILE MIGRATION MỚI CHẠY UPDATE-DATABASE ĐỂ TẠO TABLE TRONG DATABASE

            // when succes create in Migration, use update-database to up to the sql server
        }
    }
}
