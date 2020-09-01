using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpportunityTracker.Models;
using OpportunityTracker.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace OpportunityTracker.Controllers
{
     [Authorize]
    public class HomeController : Controller
    {
        IStoreOpportunity _opportunityStorage;

        private readonly UserManager<IdentityUser> _userManager;
      

        public HomeController(IStoreOpportunity myOpportunityStorage,UserManager<IdentityUser> userManager)
        {
            _opportunityStorage = myOpportunityStorage;
           _userManager=userManager;
        }

        public IActionResult Index()
        {
            var userOpportunity = _opportunityStorage.getAllOpportunities(UserId());
            return View("Dashboard",userOpportunity);
        }

        public IActionResult Create(){
            ViewBag.editing = false;
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(Opportunity newOpportunity){
            newOpportunity.Id = Guid.NewGuid();
            newOpportunity.UserId = UserId();
            _opportunityStorage.createOpportunity(newOpportunity);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id){
            var existingOpportunity = _opportunityStorage.getById(id);
            ViewBag.editing =true;
            return View("Upsert",existingOpportunity);
        }

        [HttpPost]
        public IActionResult Update(Opportunity updateOpportunity){
            updateOpportunity.UserId = UserId();
            _opportunityStorage.updateOpportunity(updateOpportunity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Guid id){
            _opportunityStorage.deleteOpportunity(id);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        private Guid UserId() {
            var userId = _userManager.GetUserId(User);
            return Guid.Parse(userId);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
