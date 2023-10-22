using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAuctions.Areas.Identity.Data;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;
using WebAuctions.ViewModels;

namespace WebAuctions.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAuctionService auctionService;
        private readonly UserManager<WebAuctionsUser> _userManager;


        public AdminController(IAuctionService auctionService, UserManager<WebAuctionsUser> userManager)
        {
            this.auctionService = auctionService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<WebAuctionsUser> userList = _userManager.Users.ToList();
            List<UserVM> userListVM = new List<UserVM>();
            foreach (WebAuctionsUser wau in userList)
            {
                userListVM.Add(UserVM.FromWebAuctionUser(wau, _userManager).Result);
            }
            
            return View(userListVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(string removeUserUsername)
        {
            var user = _userManager.FindByEmailAsync(removeUserUsername).Result;
            if(user!= null)
            {
                _userManager.DeleteAsync(user);
            }
            List<WebAuctionsUser> userList = _userManager.Users.ToList();
            List<UserVM> userListVM = new List<UserVM>();
            foreach (WebAuctionsUser wau in userList)
            {
                userListVM.Add(UserVM.FromWebAuctionUser(wau, _userManager).Result);
            }

            return View(userListVM);


        }



    }
}
