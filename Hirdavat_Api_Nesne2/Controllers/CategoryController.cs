using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hirdavat.Core.Servisler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirdavat_Api_Nesne2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryServis _categoryServis;

        public CategoryController(ICategoryServis categoryServis)
        {
            _categoryServis = categoryServis;

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var categories = await _categoryServis.GetAllAsync();
            return Ok(categories);

        }



    }
}