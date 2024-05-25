using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockReository _stockRepo;
        public PortfolioController(UserManager<AppUser> userManager, 
        IStockReository stockRepo)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetUserPotfolio()
        {
            var userName = User.GetUserName();
        }
    }
}