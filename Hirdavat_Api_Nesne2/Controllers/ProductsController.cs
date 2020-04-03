using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hirdavat.Core.Models;
using Hirdavat.Core.Servisler;
using Hirdavat_Api_Nesne2.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirdavat_Api_Nesne2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductServis _productServis;
        private readonly IMapper _mapper;

        public ProductsController(IProductServis productServis, IMapper mapper)
        {
            _productServis = productServis;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var product = await _productServis.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(product));


        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {

            var product = await _productServis.GetByIdAsync(Id);
            return Ok(_mapper.Map<ProductDto>(product));


        }
        [HttpGet("{Id}/Category")]
        public async Task<IActionResult> GetWithCategoryById(int Id)
        {
            var product = await _productServis.GetWithCategoryByIdAsync(Id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));

        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newproduct = await _productServis.AddAsync(_mapper.Map<Product>(productDto));
            return Created(string.Empty, _mapper.Map<ProductDto>(newproduct));

        }

        [HttpPut]

        public IActionResult Update(ProductDto productDto)
        {
            var product = _productServis.Update(_mapper.Map<Product>(productDto));


            return NoContent();


        }
          
        [HttpDelete("{Id}")]
        public IActionResult Remove(int Id)
        {
            var product = _productServis.GetByIdAsync(Id).Result;
            _productServis.Remove(product);

            return NoContent();

        }




    }
}