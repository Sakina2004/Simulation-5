using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Simulation_5.DataAccessLayer;
using Simulation_5.Models;
using Simulation_5.ViewModels.PositionGetVm;
using Simulation_5.ViewModels.WorkerViewModels;
using System.Drawing;

namespace Simulation_5.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkerController(AppDbContext _context ) : Controller
    {
        public async Task <IActionResult> Index()
        {
            var workers = await _context.Workers.Select(x => new WorkerGetVm
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Description = x.Description,
                ImagePath = x.ImagePath,
                PositionId = x.PositionId,
            }).ToListAsync();
            return View(workers);
        }
      private async Task ViewBags()
      {
            var positions = await _context.Positions.Select(x => new PositionGetVm()
            {
                Id = x.Id,
               fullname = x.fullname,
            }).ToListAsync();
            ViewBag.Positions = positions;
      }
        public async Task<IActionResult>Create()
        {
            await ViewBags();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(WorkerCreateVm vm)
        {
            await ViewBags();
            if (!ModelState.IsValid)
                return View(vm);
            if(vm.Image.Length * 1024* 1024 > 2)
            {
                ModelState.AddModelError("image", "Shekilin uzunlughu max 2kb olmalidir!");
            }
            if(!vm.Image.ContentType.StartsWith("Image"))
            {
                ModelState.AddModelError("image", "Datanin shekil formatinda oldughuna diqqet edin!");
            }
            string filename = Guid.NewGuid().ToString() + vm.Image.FileName;
            string path = Path.Combine("wwwroot", "images", filename);
            using FileStream stream = new(path, FileMode.OpenOrCreate);
            await vm.Image.CopyToAsync(stream);
            Worker worker = new()
            {
                Fullname = vm.Fullname,
                ImagePath=filename,
                Description=vm.Description,
                PositionId=vm.PositionId,
            };
            await _context.Workers.AddAsync(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Delete(int? id)
        {
            if (!id.HasValue || id < 1)
                return BadRequest();
            var entity=await _context.Workers.Where(x=>x.Id==id).ExecuteDeleteAsync();
            if (entity == 0)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Update(int? id,)
    }
}