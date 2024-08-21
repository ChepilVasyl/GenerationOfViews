using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectWithFile.Data;
using ProjectWithFile.Models;

namespace ProjectWithFile.Controllers
{
    public class DollyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DollyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dolly
        public async Task<IActionResult> Index()
        {
            return View(await _context.DollyModels.ToListAsync());
        }

        // GET: Dolly/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dollyModel = await _context.DollyModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dollyModel == null)
            {
                return NotFound();
            }
            
            return View(dollyModel);
        }

        // GET: Dolly/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dolly/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Color")] DollyModel dollyModel, IFormFile file)
        {
            string baseUrl = "DollyImage";
            if (file != null && file.Length != 0)
            {
                var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DollyImage", file.FileName);
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            dollyModel.Url = baseUrl + '/' + file.FileName;
            if (ModelState.IsValid)
            {
                _context.Add(dollyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dollyModel);
        }

        // GET: Dolly/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dollyModel = await _context.DollyModels.FindAsync(id);
            if (dollyModel == null)
            {
                return NotFound();
            }
            return View(dollyModel);
        }

        // POST: Dolly/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Color,Url")] DollyModel dollyModel,IFormFile file)
        {
            if (id != dollyModel.Id)
            {
                return NotFound();
            }
            else
            {

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", dollyModel.Url);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                if (file != null && file.Length != 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DollyImage", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                dollyModel.Url = "DollyImage" + '/' + file.FileName;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dollyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DollyModelExists(dollyModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dollyModel);
        }

        // GET: Dolly/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dollyModel = await _context.DollyModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dollyModel == null)
            {
                return NotFound();
            }

            return View(dollyModel);
        }

        // POST: Dolly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dollyModel = await _context.DollyModels.FindAsync(id);
            if (dollyModel != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DollyImage", dollyModel.Url.Split("/")[1]);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                _context.DollyModels.Remove(dollyModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DollyModelExists(int id)
        {
            return _context.DollyModels.Any(e => e.Id == id);
        }
    }
}
