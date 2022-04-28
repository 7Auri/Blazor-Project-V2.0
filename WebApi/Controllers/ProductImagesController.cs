using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAProduct.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpPost("add")]
        public IActionResult Add(int productId, [FromForm] IFormFile file)
        {
            var result = _productImageService.Add(productId, file);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(int id, [FromForm] IFormFile file)
        {
            var result = _productImageService.Update(id, file);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _productImageService.Delete(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getAllByProductId")]
        public IActionResult GetAllByProductId(int productId)
        {
            var result = _productImageService.GetAllByProductId(productId);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _productImageService.GetAll();
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}
