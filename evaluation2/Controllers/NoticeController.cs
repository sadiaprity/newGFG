using evaluation2.Data;
using evaluation2.Models;
using Microsoft.AspNetCore.Mvc;

namespace evaluation2.Controllers
{
    public class NoticeController : Controller
    {
        
            private readonly MyDbContext _context;

            public NoticeController(MyDbContext context)
            {
                _context = context;
            }

            // GET: Display Notices
            public IActionResult Index()
            {
                var notices = _context.Notice.OrderByDescending(n => n.CreatedAt).ToList();
                return View(notices);
            }

            // POST: Create Notice
            [HttpPost]
            public IActionResult Create(Notice notice)
            {
                if (ModelState.IsValid)
                {
                    _context.Notice.Add(notice);
                    _context.SaveChanges();
                return RedirectToAction("Index","Notice");
            }
                return Json(new { success = false });
            }

            // GET: Fetch Notice for Edit
            public IActionResult GetNotice(int id)
            {
                var notice = _context.Notice.Find(id);
                if (notice == null)
                    return NotFound();
                return Json(notice);
            }

         // POST: Update Notice        
        [HttpPost]
        public IActionResult Update(int id, Notice notice)
        {
            if (ModelState.IsValid)
            {
                // Find the existing notice by id
                var existingNotice = _context.Notice.FirstOrDefault(n => n.Id == id);
                if (existingNotice != null)
                {
                    // Update the existing notice
                    existingNotice.Title = notice.Title;
                    existingNotice.Description = notice.Description;
                    existingNotice.Area = notice.Area;

                    _context.SaveChanges();
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }


        // POST: Delete Notice
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var notice = _context.Notice.Find(id);
            if (notice == null)
            {
                return NotFound(); // You can return an error message or redirect elsewhere.
            }

            _context.Notice.Remove(notice);
            _context.SaveChanges();

            return RedirectToAction("Index"); // Redirect back to the list of notices.
        }


    }
}


