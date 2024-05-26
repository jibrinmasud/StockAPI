using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
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
        private readonly IPortfolioRepository _productRepo;
        public PortfolioController(UserManager<AppUser> userManager, 
        IStockReository stockRepo, IPortfolioRepository portfolioRepo)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _productRepo = portfolioRepo;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetUserPotfolio()
        {
            var userName = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(userName);
            var userPortolio = await _productRepo.GetUserPotfolio(appUser);

            return Ok(userPortolio);
        }
    }
}