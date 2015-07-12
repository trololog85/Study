using System.Threading.Tasks;
using System.Web.Http;
using MongoDbWebApi.Models;

namespace MongoDbWebApi.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Registration(User user)
        {
            var objServer = MongoServer.Create;
        }
    }
}
