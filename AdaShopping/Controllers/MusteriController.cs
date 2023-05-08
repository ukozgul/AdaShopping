using AdaShopping.Dtos;
using AdaShopping.IService;
using AdaShopping.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdaShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private readonly IShoppingService _service;

        public MusteriController(IShoppingService service)
        {
            _service = service;
        }

        ////Müşteri Ekleme
        //[HttpPost]
        //[Route("MusteriEkle")]
        //public async Task<ActionResult<Musteri>> AddMusteri(MusteriDto command)
        //{
        //    _service.AddMusteri(command);
        //    return Ok(command);
        //}

        //Müsterileri Getir
        [HttpGet]
        [Route("MusterileriGetir")]
        public async Task<ActionResult<List<MusteriDto>>> GetMusteriler()
        {
            var result=_service.GetAllMusteri();
            return Ok(result);
        }

        //Tek Müsteri Getir
        [HttpGet]
        [Route("MusteriGetir")]
        public async Task<ActionResult<Musteri>> GetMusteri(int id)
        {
            var result=_service.GetMusteri(id);
            return Ok(result);
        }

    }
}
