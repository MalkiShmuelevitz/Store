using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _icategoryService;
        IMapper _imapper;
        public CategoriesController(ICategoryService icategoryService, IMapper imapper)
        {
            _icategoryService = icategoryService;
            _imapper = imapper;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDTO>>> Get()
        {

            IEnumerable<Category>categories= await _icategoryService.Get();
            IEnumerable<GetCategoryDTO> categoriesDTO =_imapper.Map< IEnumerable <Category> ,IEnumerable <GetCategoryDTO>>(categories);
            if (categoriesDTO != null)
                 return Ok(categoriesDTO);
            else return NoContent();
               
        }

    }

     
}
