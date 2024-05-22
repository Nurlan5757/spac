using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spacdyna.DAL;
using Spacdyna.Models;
using Spacdyna.ViewsModels;

namespace Spacdyna.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProvidesController : Controller
    {
        private readonly SpacContext _context;     

        public ProvidesController(SpacContext context)
        {
            _context = context;
        }

        // GET: Admin/Provides
        public async Task<IActionResult> Index()
        {
            return View(await _context.provides.Select(p => new GetSpacAdminVM
            {
                Id = p.Id,
                Title = p.Title,
                Subtitle = p.Subtitle,
                Image = p.Image,
            }).ToListAsync());

        }

        // GET: Admin/Provides/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]     
        public async Task<IActionResult> Create(CreateVM vm)
        {

            await _context.provides.AddAsync(new Provide
            {

                Title = vm.Title,
                Subtitle = vm.Subtitle,
                Image = vm.Image,
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }

        // GET: Admin/Provides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provide = await _context.provides.FindAsync(id);
            if (provide == null)
            {
                return NotFound();
            }
            return View(provide);
        }

        
        [HttpPost]
        
        public async Task<IActionResult> Edit(int id,  UpdateVM updateVM)
        {
           if(id==null && id < 1)
            {
                return NotFound();
            }
           var exsited=await _context.provides.FirstOrDefaultAsync(x => x.Id==id);
            if (exsited==null)
            {
                return NotFound();
            }
            exsited.Title = updateVM.Title;
            exsited.Subtitle = updateVM.Subtitle;
            exsited.Image = updateVM.Image;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Provides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Delete = await _context.provides.FirstOrDefaultAsync(m => m.Id == id);

            if (Delete == null)
            {
                return NotFound();
            }
            _context.Remove(Delete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
