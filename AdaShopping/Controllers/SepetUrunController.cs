using AdaShopping.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdaShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SepetUrunController : ControllerBase
    {
        private readonly IShoppingService _service;

        public SepetUrunController(IShoppingService service)
        {
            _service = service;
        }



    }
}
