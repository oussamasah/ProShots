using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProShots.Data;

namespace ProShots.Controllers.Dashboard
{
  
    public class BlogController : Controller
    {
        private readonly ProShotsContext _db;
        public BlogController(ProShotsContext context)
        {
            _db=context;
        }
        // GET: BlogController
        public async Task<ActionResult> Index()
        {
           var posts = await _db.Posts.ToListAsync();
            var data = new List<Object>();
            foreach (var item in posts)
            {
                var comments = await _db.Comments.Where(c => c.Post == item.Id).ToListAsync();

                var d = new List<Object>
                {
                   item,
                   comments

                };
                data.Prepend(d);
            }
            
            return View(data);
        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: BlogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogController/Edit/5
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

        // GET: BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogController/Delete/5
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
