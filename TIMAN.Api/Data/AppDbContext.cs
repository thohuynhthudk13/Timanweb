using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Model;

namespace TIMAN.Api
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> products { set; get; }
        public DbSet<Category> categories { set; get; }
        public DbSet<Login> logins { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Categorys Table
            modelBuilder.Entity<Category>().HasData(
                new Category {Id=1, Name = "Giày nam" });
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 2, Name = "Giày nữ" });
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 3, Name = "Thời trang nam" });
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 4, Name = "Thời trang nữ" });
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 5, Name = "Thời trang bé yêu" });
            

            // Seed Products Table
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Name= "Giày Sandal Lưới Phối Da Nam XH01",
                CategoryId =  1,
                DateCreated = DateTime.Now,
                Id = 1,
                Price=578000,
                ThumbnailImage = "https://timan.vn/Thumb.ashx?s=650&file=/UploadImages/shops/giay-nam/XH01/giay-sandal-luoi-phoi-da-nam-XH01-1.jpg",
             });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Name = "Giày Thể Thao Da Nữ SZ04",
                CategoryId = 2,
                DateCreated = DateTime.Now,
                Id = 2,
                Price = 390000,
                ThumbnailImage = "https://timan.vn/Thumb.ashx?s=650&file=/UploadImages/shops/giay-nu/SZ04/giay-the-thao-da-nu-SZ04-1.jpg",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Name = "Áo Blazer Nam Hàn Quốc Màu Đen",
                CategoryId = 3,
                DateCreated = DateTime.Now,
                Id = 3,
                Price = 289000,
                ThumbnailImage = "https://cf.shopee.vn/file/562ca3c692126d72060fab9582481c7f",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Name = "Đầm yếm kẻ sọc ca rô",
                CategoryId = 4,
                DateCreated = DateTime.Now,
                Id = 4,
                Price = 554900,
                ThumbnailImage = "https://cf.shopee.vn/file/1ef91962b386461ee0dd99273142772b",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Name = "Bộ quần áo thu đông trẻ em 7-17kg (1-5 tuổi) ",
                CategoryId = 5,
                DateCreated = DateTime.Now,
                Id = 5,
                Price = 39000,
                ThumbnailImage = "https://cf.shopee.vn/file/986dfccc518fbfd7ab7b72f070b51939",
            });
             modelBuilder.Entity<Login>().HasData(new Login
             {
                UserName="admin",
                Password ="admin123"
            });
            
        }
    }
}
