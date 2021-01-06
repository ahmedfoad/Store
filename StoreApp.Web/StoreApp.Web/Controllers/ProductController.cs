using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Models;
using StoreApp.Repository;
using StoreApp.Repository.ModelRepository;


namespace StoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly UnitOfWork UnitOfWork;

        public ProductController(IUnitOfWork IUnitOfWork)
        {
            UnitOfWork = IUnitOfWork as UnitOfWork;
        }
        // GET: Products
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.products = UnitOfWork.ProductRepository.GetAll();
            return View(model);
        }

        // GET: ttt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = UnitOfWork.ProductRepository.Find(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ttt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ttt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Product product)
        {
            if (ModelState.IsValid)
            {
                
                UnitOfWork.ProductRepository.Add(product);
                UnitOfWork.Commit();
                
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ttt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = UnitOfWork.ProductRepository.Find(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ttt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.ProductRepository.Update(product);
                    UnitOfWork.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(ProductExists(product.Id)))
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
            return View(product);
        }

        // GET: ttt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = UnitOfWork.ProductRepository.Find(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ttt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = UnitOfWork.ProductRepository.Find(id);

            UnitOfWork.ProductRepository.Delete(product);
            UnitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return UnitOfWork.ProductRepository.Any(id);
        }
    }
}
   
