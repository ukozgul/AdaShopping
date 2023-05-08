using AdaShopping.Dtos;
using AdaShopping.IService;
using AdaShopping.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdaShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SepetController : ControllerBase
    {
        private readonly IShoppingService _service;

        public SepetController(IShoppingService service)
        {
            _service = service;
        }

        ////Sepet Ekleme
        //[HttpPost]
        //public async Task<ActionResult<Sepet>> AddSepet(SepetDto command)
        //{
        //    _service.AddSepet(command);
        //    return Ok(command);
        //}

        //Sepetleri Getir
        [HttpGet]
        [Route("SepetleriGetir")]
        public async Task<ActionResult<List<Sepet>>> GetSepetler()
        {
            var result = _service.GetAllSepet();
            return Ok(result);
        }

        //Tek Sepet Getir
        [HttpGet]
        [Route("SepetGetir")]
        public async Task<ActionResult<Sepet>> GetSepet(int id)
        {
            var result=_service.GetSepet(id);
            return Ok(result);
        }




    }
}
