using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _dbContext;

       public DbManageController(AppDbContext dbContext)
       {
           _dbContext = dbContext;
       }
        

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteDb()
        {
            return View();
        }
        [TempData]
        public string StatusMessage{get; set;}
        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync()//Phương thức bất đồng bộ
        {
            var success = await _dbContext.Database.EnsureDeletedAsync();
            StatusMessage =success ? "Không xóa được" : "Xóa database thành công";
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Migrate()//Phương thức bất đồng bộ
        {
           await _dbContext.Database.MigrateAsync();
            StatusMessage = "Cập nhập database thành công";
            return RedirectToAction(nameof(Index));
        }
    }
}