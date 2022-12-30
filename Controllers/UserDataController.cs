using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WellaApi.Models;
using WellaApi.DatabaseContext;
using AutoMapper;
using WellaApi.ViewModels;

namespace WellaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDataController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserDataController> _logger;
        public UserDataController(AppDbContext context, ILogger<UserDataController> logger, IMapper mapper){
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            _logger.LogInformation("This is the index page");
            var user = _context.UserDataTable.ToList();
            UserViewModel UserViewModel = _mapper.Map<UserViewModel>(user);
            return Ok(UserViewModel);
        }

        [HttpGet("[action]")]
        public IActionResult NewUser()
        {
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> NewUser(UserData user){

            if(ModelState.IsValid)
            {
                  _logger.LogInformation("This is the Create page");
                await _context.UserDataTable.AddAsync(user);
                await _context.SaveChangesAsync();
                

            }
                return Ok( "name is"+user.FirstName+user.LastName+"Phone number is"+user.Phonenumber);
            
        }   
         [HttpGet("[action]")]
         public async Task<IActionResult> EditAsync(int ID){
              _logger.LogInformation("This is the Edit page");
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x=>x.ID==ID);
            return Ok(user);

        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(UserData model){
              _logger.LogInformation("This is the Edit page");
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x=>x.ID==model.ID);
            _context.UserDataTable.Update(user);
            await _context.SaveChangesAsync();
            return Ok("name changed to "+model.FirstName+model.LastName);
        }

        [HttpGet("[action]")]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteAsync(int ID){
              _logger.LogInformation("This is the Delete page");
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x=>x.ID==ID);
            return Ok();
        }

       [HttpPost("[action]")]
        public async Task<IActionResult> DeleteAsync(UserData model){
              _logger.LogInformation("This is the Delete page");
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x=>x.ID==model.ID);
            _context.UserDataTable.Remove(user);
            await _context.SaveChangesAsync();
            return Ok("User successfully deleted");
        }

    }
}
