using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeworkASPCRUD.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using HomeworkASPCRUD.Models;
using Microsoft.EntityFrameworkCore;


namespace HomeworkASPCRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly HomeworkDbContext _context;
        public ProductController(HomeworkDbContext context)
        {
            _context = context;
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = _context.Products.Include("Category").ToList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create   
        [HttpGet]
        public ActionResult Create()
        {
            var groupList = _context.Categories.Select(c => new SelectListItem{
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            groupList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "Seçin",
                Selected = true,
                Disabled = true
            });

            ViewBag.Categories = groupList;

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var groupList = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            groupList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "Seçin",
                Selected = true,
                Disabled = true
            });

            ViewBag.Categories = groupList;

            return View(product);
            
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _context.Products.Include("Category").FirstOrDefault(p=> p.Id==id);
            if (product == null) return NotFound();

            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            //var product = _context.Products.Include("Category").FirstOrDefault(p => p.Id == id);
            var product = _context.Products.Include("Category").FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteProduct (int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                _context.Products.Remove(product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}