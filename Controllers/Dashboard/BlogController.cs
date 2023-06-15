using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using ProShots.Areas.Identity.Data;
using ProShots.Data;
using ProShots.Models;
using ProShots.Models.ModelForm;
using System.Diagnostics;
using System.Xml.Linq;

namespace ProShots.Controllers.Dashboard
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly UserManager<User> _userManager;
        public readonly ProShotsContext _db;
        public BlogController(ProShotsContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _db = context;
        }
        // GET: BlogController
        public async Task<ActionResult> Index()
        {
            var posts = await _db.Posts.GroupJoin(_db.Comments,
                t1 => t1.Id,
                t2 => t2.Post,
                (t1, t2Group) => new { table1 = t1, table2Group = t2Group })
                .SelectMany(x => x.table2Group.DefaultIfEmpty(),
                (t1, t2) => new { post = t1.table1, comment = t2 ?? null }
                ).Where(x => x.post.User == _userManager.GetUserId(User))
                .ToListAsync();

            ViewData["Posts"] = posts;
            return View();
        }

        // GET: BlogController/Details/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {

            var post = await _db.Posts.FindAsync(id);


            if (post == null)
            {
                return NotFound();
            }
            else if (post.User != _userManager.GetUserId(User))
            {
                return BadRequest();
            }

            var comments = await _db.Comments.GroupJoin(_db.Comments,
                 t1 => t1.Id,
                 t2 => t2.CommentId,
                 (t1, t2Group) => new { table1 = t1, table2Group = t2Group })
                 .SelectMany(x => x.table2Group.DefaultIfEmpty(),
                 (t1, t2) => new { comment = t1.table1, reply = t2 ?? null }
                 ).Where(x => x.comment.CommentId == 0).Where(x => x.comment.Post == id)
                 .ToListAsync();
            ViewData["Comments"] = comments;
            var modelForm = new PostForm();
            modelForm.Id = post.Id;
            modelForm.Title = post.Title;
            modelForm.Content = post.Content;
            modelForm.Status = post.Status;
            return View("Create", modelForm);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(PostForm form)
        {

            if (!ModelState.IsValid)
            {
                return View(form);
            }
            var post = await _db.Posts.FindAsync(form.Id);
            if (post == null)
            {
                return NotFound();
            }
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                var allowedEx = new List<string> { ".jpg", ".png", ".jpeg" };
                if (!allowedEx.Contains(Path.GetExtension(files["Thumbnail"].FileName).ToLower()))
                {
                    ModelState.AddModelError("Thumbnail", "Only jpg,jpeg and png file allowed");
                    return View(form);
                }

                var name = Guid.NewGuid() + Path.GetExtension(files["Thumbnail"].FileName);

                string fileuserpath = _userManager.GetUserName(User);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/" + fileuserpath);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);


                string fileNameWithPath = Path.Combine(path, name);
                try
                {
                    using (var image = Image.Load(files["Thumbnail"].OpenReadStream()))
                    {
                        // Define the maximum width for the resized image
                        int maxWidth = 800;

                        // Calculate the new dimensions while maintaining the aspect ratio
                        int newWidth = image.Width > maxWidth ? maxWidth : image.Width;
                        int newHeight = (int)((double)newWidth / image.Width * image.Height);

                        // Resize the image while maintaining the aspect ratio
                        image.Mutate(x => x.Resize(newWidth, newHeight));

                        // Compress the image and save it
                        image.Save(fileNameWithPath);
                    }
                    if (post.Thumbnail != null && !post.Thumbnail.Equals("/post_thumbnail.jpg"))
                    {
                        string exitFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/" + post.Thumbnail);
                        System.IO.File.Delete(exitFile);
                    }
                    post.Thumbnail = fileuserpath + "/" + name;

                }
                catch (Exception e)

                {
                    Console.WriteLine(e.Message);
                    return BadRequest();

                }

            }

            post.Title = form.Title;
            post.Content = form.Content;
            post.Status = form.Status;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: BlogController/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            var post = new Post
            {
                Title = form.Title,

                Content = form.Content,
                Status = form.Status,
                User = _userManager.GetUserId(User)
            };
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                var allowedEx = new List<string> { ".jpg", ".png", ".jpeg" };
                if (!allowedEx.Contains(Path.GetExtension(files["Thumbnail"].FileName).ToLower()))
                {
                    ModelState.AddModelError("Thumbnail", "Only jpg,jpeg and png file allowed");
                    return View(form);
                }

                var name = Guid.NewGuid() + Path.GetExtension(files["Thumbnail"].FileName);

                string fileuserpath = _userManager.GetUserName(User);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/" + fileuserpath);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);


                string fileNameWithPath = Path.Combine(path, name);
                try
                {
                    using (var image = Image.Load(files["Thumbnail"].OpenReadStream()))
                    {
                        // Define the maximum width for the resized image
                        int maxWidth = 800;

                        // Calculate the new dimensions while maintaining the aspect ratio
                        int newWidth = image.Width > maxWidth ? maxWidth : image.Width;
                        int newHeight = (int)((double)newWidth / image.Width * image.Height);

                        // Resize the image while maintaining the aspect ratio
                        image.Mutate(x => x.Resize(newWidth, newHeight));

                        // Compress the image and save it
                        image.Save(fileNameWithPath);
                    }
                    post.Thumbnail = fileuserpath + "/" + name;

                }
                catch (Exception e)

                {
                    Console.WriteLine(e.Message);
                    return BadRequest();

                }
            }


            _db.Posts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpPost]

        public async Task<ActionResult> Filter(string search)
        {
            dynamic posts;
            if (search == null || search.Length == 0)
            {
                posts = await _db.Posts.GroupJoin(_db.Comments,
                                    t1 => t1.Id,
                                    t2 => t2.Post,
                                    (t1, t2Group) => new { table1 = t1, table2Group = t2Group })
                                    .SelectMany(x => x.table2Group.DefaultIfEmpty(),
                                    (t1, t2) => new { post = t1.table1, comment = t2 ?? null }
                                    ).Where(x => x.post.User == _userManager.GetUserId(User)).ToListAsync();
            }
            else
            {
                posts = await _db.Posts.GroupJoin(_db.Comments,
                 t1 => t1.Id,
                 t2 => t2.Post,
                 (t1, t2Group) => new { table1 = t1, table2Group = t2Group })
                 .SelectMany(x => x.table2Group.DefaultIfEmpty(),
                 (t1, t2) => new { post = t1.table1, comment = t2 ?? null }
                 ).Where(x => x.post.User == _userManager.GetUserId(User)).Where(x => x.post.Title.Contains(search) || x.post.Content.Contains(search)).ToListAsync();
            }


            return PartialView("_PartialPostList", posts);

        }




        // POST: BlogController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            var comments = await _db.Comments.Where(m => m.Post == post.Id).ToListAsync();
            foreach (var item in comments)
            {
                _db.Remove(item);
            }
            if (post.Thumbnail != null && !post.Thumbnail.Equals("/post_thumbnail.jpg"))
            {
                string exitFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/" + post.Thumbnail);
                System.IO.File.Delete(exitFile);
            }
            _db.Remove(post);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
