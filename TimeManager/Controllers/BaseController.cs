using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TimeManager.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected int GetCurrentUserId()
        {
            return 3;
            //return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}