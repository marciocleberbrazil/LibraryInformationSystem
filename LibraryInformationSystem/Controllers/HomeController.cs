using LibraryInformationSystem.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LibraryInformationSystem.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Accesses
        public ActionResult Index()
        {
            var accesses = db.Accesses.Include(a => a.Book).Include(a => a.Borrower);
            return View(accesses.ToList());
        }

        // GET: Accesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access access = db.Accesses.Find(id);
            if (access == null)
            {
                return HttpNotFound();
            }
            return View(access);
        }

        // GET: Accesses/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title");
            ViewBag.BorrowerId = new SelectList(db.Borrowers, "BorrowerId", "FirstName");
            return View();
        }

        // POST: Accesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessId,DueDate,IsReserved,BorrowerId,BookId")] Access access)
        {
            if (ModelState.IsValid)
            {
                db.Accesses.Add(access);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", access.BookId);
            ViewBag.BorrowerId = new SelectList(db.Borrowers, "BorrowerId", "FirstName", access.BorrowerId);
            return View(access);
        }

        // GET: Accesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access access = db.Accesses.Find(id);
            if (access == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", access.BookId);
            ViewBag.BorrowerId = new SelectList(db.Borrowers, "BorrowerId", "FirstName", access.BorrowerId);
            return View(access);
        }

        // POST: Accesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessId,DueDate,IsReserved,BorrowerId,BookId")] Access access)
        {
            if (ModelState.IsValid)
            {
                db.Entry(access).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", access.BookId);
            ViewBag.BorrowerId = new SelectList(db.Borrowers, "BorrowerId", "FirstName", access.BorrowerId);
            return View(access);
        }

        // GET: Accesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access access = db.Accesses.Find(id);
            if (access == null)
            {
                return HttpNotFound();
            }
            return View(access);
        }

        // POST: Accesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Access access = db.Accesses.Find(id);
            db.Accesses.Remove(access);
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