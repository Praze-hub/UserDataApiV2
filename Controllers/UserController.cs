using WellaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WellaApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase{
    [HttpGet("Admins")]
    [Authorize(Roles = "Administrator")]
    public IActionResult AdminsEndpoint()
    {
        var currentUser = GetCurrentUser();
        return Ok($"Hi {currentUser.Username}, you are a {currentUser.Role}");
    }

    [HttpGet("Students")]
    [Authorize(Roles="Student")]
    public IActionResult SellersEndpoint()
    {
        var currentUser = GetCurrentUser();
        return Ok($"Hi {currentUser.Username}, you are a {currentUser.Role}");
    }
    [HttpGet("AdminsAndStudent")]
    [Authorize(Roles = "Administrator, Student")]
    public IActionResult AdminsAndSellerEndPoint()
    {
        var currentUser = GetCurrentUser();
        return Ok($"Hi {currentUser.Username}, you are an {currentUser.Role}");

    }
    [HttpGet("Public")]
    public IActionResult Public()
    {
        return Ok("Hi you are on a public property");

    }
    private UserData GetCurrentUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity != null)
        {
            var userClaims = identity.Claims;

            return new UserData{
               Username = userClaims.FirstOrDefault(o=>o.Type == ClaimTypes.NameIdentifier)?.Value,
               EmailAddress = userClaims.FirstOrDefault(o=>o.Type == ClaimTypes.Email)?.Value,
               FirstName = userClaims.FirstOrDefault(o=>o.Type == ClaimTypes.GivenName)?.Value,
               LastName = userClaims.FirstOrDefault(o=>o.Type == ClaimTypes.Surname)?.Value,
            //    Phonenumber = userClaims.FirstOrDefault(o=>o.Type == ClaimTypes.MobilePhone)?.Value,
               Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value

            };
        }
        return null;
    }
    }
}