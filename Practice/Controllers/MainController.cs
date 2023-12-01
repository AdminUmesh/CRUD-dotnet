using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Controllers
{
    public class MainController : Controller
    {
        // GET: HomeController1
        private readonly StudentContext _Db;
        public MainController(StudentContext Db)
        {
            _Db = Db;
        }
        public ActionResult Index()
        {
            try
            {
                var StdDetails= from a in _Db.example
                    select new StudentTable
                    {
                        ID = a.ID,
                        Name =a.Name,
                        Email= a.Email
                    };
                return View(StdDetails.ToList());
            }
            catch (Exception ex)
            {
            return View();
            }
        }


        // GET: HomeController1/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        public  ActionResult Create(StudentTable collection)
        {
            try
            {
                _Db.example.Add(collection);
                 _Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(StudentTable obj)
        {
            return View(obj);
        }

        [HttpPost]
        public ActionResult EditSave(StudentTable collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Db.example.Update(collection);
                    _Db.SaveChangesAsync();
                return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var student = _Db.example.Find(id);
                if (student == null)
                {
                    return View();
                }

                _Db.example.Remove(student);
                _Db.SaveChangesAsync();

               return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
