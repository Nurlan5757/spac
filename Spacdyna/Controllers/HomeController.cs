using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spacdyna.DAL;
using Spacdyna.ViewsModels;
using System.Diagnostics;

namespace Spacdyna.Controllers
{
    public class HomeController (SpacContext _context) : Controller
    {
       

        public async Task<IActionResult> Index()
        {
            return View(await _context.provides.Select(a=> new GetVM
            {
                Title = a.Title,    
                Subtitle = a.Subtitle,  
                Image=a.Image,

            }).ToListAsync());
        }
    }
}
