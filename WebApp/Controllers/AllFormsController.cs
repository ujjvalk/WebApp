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
    public class AllFormsController : Controller
    {
        private FormDBContext db = new FormDBContext();

        // GET: AllForms
        public async Task<ActionResult> Index()
        {
            return View(await db.Forms.ToListAsync());
        }

        // GET: AllForms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllForm allForm = await db.Forms.FindAsync(id);
            if (allForm == null)
            {
                return HttpNotFound();
            }
            return View(allForm);
        }

        // GET: AllForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email,Age,Gender,Standard,Division,Image,birthdate,AcadmicStartDate,AcadmicEndDate,Hobby,OtherActivity")] AllForm allForm)
        {
            if (ModelState.IsValid)
            {
                db.Forms.Add(allForm);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(allForm);
        }

        // GET: AllForms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllForm allForm = await db.Forms.FindAsync(id);
            if (allForm == null)
            {
                return HttpNotFound();
            }
            return View(allForm);
        }

        // POST: AllForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Email,Age,Gender,Standard,Division,Image,birthdate,AcadmicStartDate,AcadmicEndDate,Hobby,OtherActivity")] AllForm allForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allForm).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(allForm);
        }

        // GET: AllForms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllForm allForm = await db.Forms.FindAsync(id);
            if (allForm == null)
            {
                return HttpNotFound();
            }
            return View(allForm);
        }

        // POST: AllForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AllForm allForm = await db.Forms.FindAsync(id);
            db.Forms.Remove(allForm);
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
