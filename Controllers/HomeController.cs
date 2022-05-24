using BuyOrSell.Data;
using BuyOrSell.Data.Entities;
using BuyOrSell.Models;
using BuyOrSell.Services;
using BuyOrSell.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PagedList;

namespace BuyOrSell.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;
        private readonly IBuyRepository _repository;
        private readonly BuyContext _db;


        public HomeController(IMailService mailService, IBuyRepository repository, BuyContext db)
        {
            _mailService = mailService;
            //_logger = logger;
            _repository = repository;
            _db = db;

        }



        public IActionResult Ads(string searchString, int? page)
        {
            //var ads = from a in _db.Ads
            //          select a;
            var results = _repository.GetAllAds();

            if (!String.IsNullOrEmpty(searchString))
            {
                page = 1;
                results = results.Where(s => s.Name!.ToLower().Contains(searchString.ToLower()));
            }





            var allAds = new List<AdViewModel>();
            foreach (var ad in results)
            {
                var newAd = new AdViewModel
                {
                    Id = ad.Id,
                    Name = ad.Name,
                    Description = ad.Description,
                    Url = ad.Url,
                    Price = ad.Price,
                    ApplicationUserId = ad.ApplicationUserId,
                    Cattegory = ad.Cattegory,
                    Town = ad.Town,
                    Date = ad.Date,

                    ApplicationUser = _db.ApplicationUser.Find("1")
                };

                allAds.Add(newAd);


            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(allAds.ToPagedList(pageNumber, pageSize));

            //return View(allAds);
        }




        // GET - CREATE
        public IActionResult Create()
        {

            return View();

        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ad obj)
        {

            if (ModelState.IsValid)

            {



                var res = _db.ApplicationUser.Find("1");
                obj.ApplicationUserId = res.Id;
                _db.Ads.Add(obj);


                _db.SaveChanges();
                return RedirectToAction(actionName: "Ads");
            }
            return View(obj);

        }

        // GET - EDIT   

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Ads.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ad obj)
        {

            if (ModelState.IsValid)

            {
                _db.Ads.Update(obj);


                _db.SaveChanges();
                return RedirectToAction(actionName: "Ads");
            }
            return View(obj);

        }

        // GET - DELETE

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Ads.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST - DELETE
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Ads.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Ads.Remove(obj);


            _db.SaveChanges();
            return RedirectToAction(actionName: "Ads");



        }




        [HttpGet("contact")]
        public IActionResult Contact()
        {


            return View();
        }



        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //send message
                _mailService.SendMessage("milosevic93@gmail.com", model.Subject, $"From:{model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }


            return View();
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




    }
}
