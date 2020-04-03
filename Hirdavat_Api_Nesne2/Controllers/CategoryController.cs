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
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryServis _categoryServis;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryServis categoryServis, IMapper mapper)
        {
            _categoryServis = categoryServis;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var categories = await _categoryServis.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));

        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var category = await _categoryServis.GetByIdAsync(Id);
            return Ok(_mapper.Map<CategoryDto>(category));

        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var category = await _categoryServis.AddAsync(_mapper.Map<Category>(categoryDto));

            return Created(string.Empty, _mapper.Map<CategoryDto>(category));
            
        }


        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var category = _categoryServis.Update(_mapper.Map<Category>(categoryDto));
            return NoContent();

        }


        [HttpDelete("{Id}")]
        public   IActionResult Delete(int Id)
        {
            var category = _categoryServis.GetByIdAsync(Id).Result;
            _categoryServis.Remove(category);
      
            return NoContent();

        }


        [HttpGet("{Id}/Product")]
        public async Task<IActionResult> GetWithProductById(int Id)
        {
            var category = await _categoryServis.GetWithProductByIDAsync(Id);

            return Ok(_mapper.Map<CategoryWithProductDto>(category));
        }
        



    }
}