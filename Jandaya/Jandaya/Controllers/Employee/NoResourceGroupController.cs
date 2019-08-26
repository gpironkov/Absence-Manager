namespace Jandaya.Controllers.Employee
{
    using Microsoft.AspNetCore.Mvc;
    public class NoResourceGroupController : Controller
    {
        //[Route("Home/Index")]
        public IActionResult NoResGroup()
        {
            return View();
        }
    }
}