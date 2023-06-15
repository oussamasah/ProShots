// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using ProShots.Areas.Identity.Data;
using ProShots.Models;

namespace ProShots.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }


            public string Description { get; set; }


            [Display(Name = "Cover")]
            public IFormFile Cover { get; set; }


            [Display(Name = "Photo")]
            public IFormFile Photo { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var userdata = await _userManager.GetUserAsync(User);

            Username = userName;
          

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Description = userdata.Description,

               
            };

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            ViewData["user"]=user;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
        
          
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            if (Input.Photo != null && Input.Photo.Length > 0)
            {
                var allowedEx = new List<string> { ".jpg", ".png", ".jpeg" };
                if (!allowedEx.Contains(Path.GetExtension(Input.Photo.FileName).ToLower()))
                {
                    ModelState.AddModelError("Input.Photo", "Only jpg,jpeg and png file allowed");
                   return Page();
                } 

                var name = Guid.NewGuid() + Path.GetExtension(Input.Photo.FileName);


                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/profiles/");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);


                string fileNameWithPath = Path.Combine(path, name);

                using (var image = Image.Load(Input.Photo.OpenReadStream()))
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
                if (user.Photo !=null)
                {
                    string exitFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/profiles/" + user.Photo);
                    System.IO.File.Delete(exitFile);
                }
                user.Photo = name;
            }
            if (Input.Cover != null && Input.Cover.Length > 0)
            {
                var allowedEx = new List<string> { ".jpg", ".png", ".jpeg" };
                if (!allowedEx.Contains(Path.GetExtension(Input.Cover.FileName).ToLower()))
                {
                    ModelState.AddModelError("Input.Cover", "Only jpg,jpeg and png file allowed");
                    return Page();
                }

                var name = Guid.NewGuid() + Path.GetExtension(Input.Cover.FileName);


                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/profiles/Cover");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);


                string fileNameWithPath = Path.Combine(path, name);

                using (var image = Image.Load(Input.Cover.OpenReadStream()))
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
                if (user.Cover != null)
                {
                    string exitFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/profiles/Cover/" + user.Cover);
                    System.IO.File.Delete(exitFile);
                }
                user.Cover = name;
            }

      

            user.Description = Input.Description;
            user.PhoneNumber = Input.PhoneNumber;
         
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                  //  return RedirectToPage();
                }
            }
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
