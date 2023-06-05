using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProShots.Areas.Identity.Data;

namespace ProShots.Controllers.Dashboard
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<User> _userManager;

        public DashboardController(UserManager<User> userManager)
        {
            this._userManager = userManager;
        }
        // GET: DashboarController
        public ActionResult Index()
        {
            ViewData["UserName"] =_userManager.GetUserName(this.User);
            return View();
        }
        public ActionResult Media()
        {
            ViewData["UserName"] =_userManager.GetUserName(this.User);
            return View();
        }

        // GET: DashboarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboarController/Create
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

        // GET: DashboarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboarController/Edit/5
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

        // GET: DashboarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboarController/Delete/5
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
