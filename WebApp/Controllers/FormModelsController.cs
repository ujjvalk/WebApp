using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class FormModelsController : Controller
    {
        private FormDBContext db = new FormDBContext();

        // GET: FormModels
        public async Task<ActionResult> Index()
        {
            return View(await db.formModels.ToListAsync());
        }

        // GET: FormModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormModel formModel = await db.formModels.FindAsync(id);
            if (formModel == null)
            {
                return HttpNotFound();
            }
            return View(formModel);
        }

        // GET: FormModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Phone,Email,Gender,Password,Country,Terms")] FormModel formModel)
        {
            if (ModelState.IsValid)
            {
                db.formModels.Add(formModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(formModel);
        }

        // GET: FormModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormModel formModel = await db.formModels.FindAsync(id);
            if (formModel == null)
            {
                return HttpNotFound();
            }
            return View(formModel);
        }

        // POST: FormModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Phone,Email,Gender,Password,Country,Terms")] FormModel formModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(formModel);
        }

        // GET: FormModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormModel formModel = await db.formModels.FindAsync(id);
            if (formModel == null)
            {
                return HttpNotFound();
            }
            return View(formModel);
        }

        // POST: FormModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FormModel formModel = await db.formModels.FindAsync(id);
            db.formModels.Remove(formModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
