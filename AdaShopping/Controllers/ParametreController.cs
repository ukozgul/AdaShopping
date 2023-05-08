using AdaShopping.Data;
using AdaShopping.Dtos;
using AdaShopping.IService;
using AdaShopping.Models.ParametreModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdaShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametreController : ControllerBase
    {

        private readonly IShoppingService _service;

        public ParametreController(IShoppingService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Parametre> TestVerisiOlustur(int musteriAdet, int sepetAdet)
        {

            _service.AddMusteri(musteriAdet, sepetAdet);
            return Ok();

        }


        [HttpGet]
        public ActionResult<List<DtoSehirAnaliz>> SehirBazliAnalizYap()
        {
            var result =_service.GetAnaliz();
            return Ok(result);
        }



    }
}

//TestVerisiOlustur(int musteriAdet, int sepetAdet)