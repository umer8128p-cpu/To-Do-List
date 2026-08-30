using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Diagnostics;
using System.Security.Claims;
using To_Do_List.Models;
using Microsoft.AspNetCore.Authorization;


namespace To_Do_List.Controllers
{
    [Authorize(Roles ="Admin,teamMembers")]
    public class TeamsController : Controller
    {
        private readonly ToDoListContext _context;

        public TeamsController(ToDoListContext context)
        {
            _context = context;
        }



        // GET: Teams
        [Authorize (Roles ="Admin")]
        public async Task<IActionResult> AdminTeams()
        {

            
            return View();
        }




        [Authorize(Roles = "Admin")]
        public  async Task<IActionResult> newTeam(int a)
        {


            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> newTeam()
        {


            return View();
        }






        private bool TblTeamExists(int id)
        {
            return _context.TblTeams.Any(e => e.TeamId == id);
        }
    }
}
