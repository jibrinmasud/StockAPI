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
        private readonly IPortfolioRepository _portfolioRepo;
        public PortfolioController(UserManager<AppUser> userManager, 
        IStockReository stockRepo, IPortfolioRepository portfolioRepo)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _portfolioRepo = portfolioRepo;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetUserPotfolio()
        {
            var userName = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(userName);
            var userPortolio = await _portfolioRepo.GetUserPotfolio(appUser);

            return Ok(userPortolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio( string symbol)
        {
            var userName = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(userName);
            var stock = await  _stockRepo.GetBySymbolAsync(symbol);

            if(stock == null) return BadRequest("Stock not found");

            var userPortfolio = await _portfolioRepo.GetUserPotfolio(appUser);

            if(userPortfolio.Any(e=> e.Symbol.ToLower() == symbol.ToLower()))
             return BadRequest("Cannot Add same Stock to Portfolio");

             var portfolioModel = new Portfolio
             {
                StockId = stock.Id,
                AppUserId = appUser.Id
             };

             await _portfolioRepo.CreateAsync(portfolioModel);

             if(portfolioModel == null)
             {
                return StatusCode(500, "Could not create");
             } 
             else
             {
                return Created();
             }
             
        }
    }
}