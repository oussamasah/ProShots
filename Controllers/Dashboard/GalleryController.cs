using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProShots.Areas.Identity.Data;
using ProShots.Data;
using ProShots.Models;
using ProShots.Models.ModelForm;
using System.Threading.Tasks;

namespace ProShots.Controllers.Dashboard
{
    [Authorize]
    public class GalleryController : Controller
    {
        private readonly UserManager<User> _userManager;
        public readonly ProShotsContext _db;
        public GalleryController(ProShotsContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _db = context;
            
}


        // GET: MediaController
        public async Task<ActionResult> Index()
        {
            var medias = await _db.Medias.Where(m => m.User == _userManager.GetUserId(User)).ToListAsync();

            var tag =   new List<string>();
            foreach (var item in medias)
            {
                var t = item.Tag;
                List<string>? result = t?.Split(',').ToList();
                foreach (var item1 in result)
                {
                    if(!item1.Equals(""))
                         tag.Add(item1);
                }
               
            }
            tag = tag.Distinct().ToList();
            ViewData["Tags"] = tag;
            ViewData["Medias"] = medias;
            var events = await _db.Events.Where(m => m.User == _userManager.GetUserId(User)).ToListAsync();
            ViewData["Events"] = events;
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Add()
        {
           var sectors =  await _db.Sectors.OrderBy(s=>s.Id).ToListAsync();
           ViewData["Sectors"] = sectors;
            return View();
        }


        [HttpPost]
         public async Task<ActionResult> Add(GalleryForm form)
        {
            var sectors = await _db.Sectors.OrderBy(s => s.Id).ToListAsync();
            ViewData["Sectors"] = sectors;

            var files = Request.Form.Files.ToList();

            if (files.Count == 0)
            {
                ModelState.AddModelError("Images", "Images are required");
                return View(form);
            }
             foreach (var file in files)
              {
                    var allowedEx = new List<string> { ".jpg", ".png", ".jpeg" };
                    if (!allowedEx.Contains(Path.GetExtension(file.FileName).ToLower()))
                    {
                        ModelState.AddModelError("Images", "Only jpg,jpeg and png file allowed");
                        return View(form);
                }
              }


            if (!ModelState.IsValid)
            {
                return View(form);
            }




            var categ = new Event
            {
                Title = form.Title,
                Description = form.Description,
                Sector = form.Sector,
                User = _userManager.GetUserId(User)
            };
            _db.Events.Add(categ);
            _db.SaveChanges();

            string fileuserpath = _userManager.GetUserName(User) + "/" + form.Title;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/gallery/" + fileuserpath);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (var file in files)
            {
                string fileNameWithPath = Path.Combine(path, file.FileName);
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }


                var media = new Media
                { 
                    Title= form.Title,
                    Path = fileuserpath+"/"+ file.FileName,
                    Description = form.Description,
                    Event = categ.Id,
                    User = _userManager.GetUserId(User)
                };
                _db.Medias.Add(media);
                _db.SaveChanges();
            }
           



            return RedirectToAction("Index");

        }
        [HttpGet]
        // GET: MediaController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var media = await _db.Medias.FindAsync(id);
            var Lismedia = await _db.Medias.Where(m => m.Event == media.Event).Where(m=>m.Id != media.Id).ToListAsync();
            if (media == null)
            {
                return NotFound();

            }
            var modelView = new MediaForm();

            modelView.Id = media.Id;
            modelView.Title = media.Title;
            modelView.Description = media.Description;
            modelView.Tag = media.Tag;
            modelView.Event = media.Event;
            modelView.State = media.State;


            ViewData["img"] = media;
            ViewData["Lismedia"] = Lismedia;
            return View(modelView);
        }
        [HttpPost]
        // GET: MediaController/Details/5
        public async Task<ActionResult> Details(MediaForm modelform)
        {
            var media = await _db.Medias.FindAsync(modelform.Id);
            if (media == null)
            {
                return NotFound();

            }
            var Lismedia = await _db.Medias.Where(m => m.Event == media.Event).Where(m=>m.Id != media.Id).ToListAsync();

            var modelView = new MediaForm();

        
            media.Title = modelform.Title;
            media.Description = modelform.Description;
            media.Tag = modelform.Tag;
            media.State = modelform.State;
            _db.SaveChanges();

      
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Editimage(Guid id)
        {
            var img = await _db.Medias.FindAsync(id);
            return View(img);
        }

        // GET: MediaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediaController/Create
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

        // GET: MediaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MediaController/Edit/5
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

        // GET: MediaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MediaController/Delete/5
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
