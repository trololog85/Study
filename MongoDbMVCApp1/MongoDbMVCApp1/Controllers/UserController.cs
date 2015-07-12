using System.Web.Mvc;

namespace MongoDbMVCApp1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Registration()
        {
            return View();
        }
    }
}