using Microsoft.AspNetCore.Mvc;

namespace evaluation2.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            // Logic for users' data and history
            return View();
        }

        public ActionResult Users()
        {
            // Logic for users' data and history
            return View();
        }

        // Action for Donations page
        public ActionResult Donations()
        {
            // Logic for handling donations
            return View();
        }

        // Action for Notices management page
        public ActionResult Notices()
        {
            // Logic for managing notices
            return View();
        }

        // Action for Volunteers page
        public ActionResult Volunteers()
        {
            // Logic for handling volunteers
            return View();
        }

        // Action for Logout page
        public ActionResult Logout()
        {
            // Logic for logging out, such as clearing the session or authentication token
            return RedirectToAction("Index", "Home"); // Redirect to home page or login page
        }
    }
}
