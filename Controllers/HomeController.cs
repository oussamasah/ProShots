using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProShots.Areas.Identity.Data;
using ProShots.Data;
using ProShots.Models;
using System.Diagnostics;

namespace ProShots.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        public readonly ProShotsContext _db;
        public HomeController(ProShotsContext context, UserManager<User> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _userManager = userManager;
            _db = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _db.Users.ToListAsync();
            ViewData["Users"] = users;
            return View();
        }
        public async Task<IActionResult> Profile(string id)
        {
            if (id == null)
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();


            var posts = await _db.Posts.GroupJoin(_db.Comments,
                                     t1 => t1.Id,
                                     t2 => t2.Post,
                                     (t1, t2Group) => new { table1 = t1, table2Group = t2Group })
                                     .SelectMany(x => x.table2Group.DefaultIfEmpty(),
                                     (t1, t2) => new { post = t1.table1, comment = t2 ?? null }
                                     ).Where(x => x.post.User == id).ToListAsync();

            var gallery = await _db.Medias.GroupJoin(_db.Events,
                                     t1 => t1.Event,
                                     t2 => t2.Id,
                                     (t1, t2Group) => new { table1 = t1, table2Group = t2Group })
                                     .SelectMany(x => x.table2Group.DefaultIfEmpty(),
                                     (t1, t2) => new { media = t1.table1, events = t2 ?? null }
                                     ).Where(x => x.media.User == id).ToListAsync();
            ViewData["Posts"] = posts;
            ViewData["Gallery"] = gallery;
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> Like(int id, string action)
        {
            if (id == null)
                return NotFound();
            if (action == null)
                return BadRequest();


            var post = await _db.Posts.FindAsync(id);
            if (post == null)
                return NotFound();

            if (action.Equals("-"))
                post.like = post.like - 1;

            if (action.Equals("+"))
                post.like = post.like + 1;


            _db.SaveChanges();
            return Json(post.like);

        }
        public async Task<IActionResult> Dislike(int id, string action)
        {
            if (id == null)
                return NotFound();
            if (action == null)
                return BadRequest();


            var post = await _db.Posts.FindAsync(id);
            if (post == null)
                return NotFound();

            if (action.Equals("-"))
                post.dislike = post.dislike - 1;

            if (action.Equals("+"))
                post.dislike = post.dislike + 1;


            _db.SaveChanges();
            return Json(post.dislike);

        }

    }
}