using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLHH.DAL;

namespace ForAsync.Controllers
{
    public class HomeController: Controller
    {
        private HongLienContext _hongLienContext;

        public HomeController(HongLienContext hongLienContext)
        {
            _hongLienContext = hongLienContext;
        }

        public IActionResult Index()
        {
            //Task.Run(() => UpdateTest());
            var taskUpdate = UpdateTestAsync();
            //UpdateTestNormal();
            return Ok("Hello World from a controller");
        }
        //public async Task<IActionResult> Index()
        //{
        //    Task.Run(() => UpdateTest());
        //    var taskUpdate = UpdateTestAsync();
        //    await taskUpdate;
        //    UpdateTestNormal();
        //    return Ok("Hello World from a controller");
        //}

        public void UpdateTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HongLienContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=ForTest;Trusted_Connection=True;MultipleActiveResultSets=true");
            var a = new HongLienContext(optionsBuilder.Options);
            var entityTypes = a.EntityTypes.ToList();
            foreach (var entityType in entityTypes)
            {
                entityType.EntityTypeName = "II" + entityType.EntityTypeName;
            }
            a.SaveChanges();
        }

        public async Task UpdateTestAsync()
        {
            var entityTypes = await _hongLienContext.EntityTypes.Take(2000).Skip(1).ToListAsync();
            foreach (var entityType in entityTypes)
            {
                entityType.EntityTypeName = entityType.EntityTypeName + "II";
            }
            await _hongLienContext.SaveChangesAsync();
        }

        public void UpdateTestNormal()
        {
            var entityTypes = _hongLienContext.EntityTypes.Take(2000).Skip(1).ToList();
            foreach (var entityType in entityTypes)
            {
                entityType.EntityTypeName = entityType.EntityTypeName + "C";
            }
            _hongLienContext.SaveChanges();
        }
    }
}
