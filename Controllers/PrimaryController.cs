using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvCalc.Models;

namespace InvCalc.Controllers
{
    public class PrimaryController : Controller
    {
        private InvCalcEntities db = new InvCalcEntities();

        // GET: Primary
        public ActionResult Index()
        {
            return View(db.PrimaryTables.ToList());
        }

        // GET: Primary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimaryTable primaryTable = db.PrimaryTables.Find(id);
            if (primaryTable == null)
            {
                return HttpNotFound();
            }
            return View(primaryTable);
        }

        // GET: Primary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Primary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,InitialInvestment,TickerSymbol,PurchasePrice,PurchaseShares,PercentageDesired,TargetSalesPrice,InvestmentYield,EndBalance,Action,Result")] PrimaryTable primaryTable)
        {
            if (ModelState.IsValid)
            {
                db.PrimaryTables.Add(primaryTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(primaryTable);
        }

        // GET: Primary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimaryTable primaryTable = db.PrimaryTables.Find(id);
            if (primaryTable == null)
            {
                return HttpNotFound();
            }
            return View(primaryTable);
        }

        // POST: Primary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,InitialInvestment,TickerSymbol,PurchasePrice,PurchaseShares,PercentageDesired,TargetSalesPrice,InvestmentYield,EndBalance,Action,Result")] PrimaryTable primaryTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(primaryTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(primaryTable);
        }

        // GET: Primary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimaryTable primaryTable = db.PrimaryTables.Find(id);
            if (primaryTable == null)
            {
                return HttpNotFound();
            }
            return View(primaryTable);
        }

        // POST: Primary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrimaryTable primaryTable = db.PrimaryTables.Find(id);
            db.PrimaryTables.Remove(primaryTable);
            db.SaveChanges();
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
