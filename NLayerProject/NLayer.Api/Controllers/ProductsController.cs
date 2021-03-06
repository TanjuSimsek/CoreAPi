using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Api.Filters;
using NLayer.Core.DTOS;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductsController : CustomBaseController
    {
        
        private readonly IMapper _mapper;
        //private readonly IService<Product> _service;
        private readonly IProductService _service;

        public ProductsController( IMapper mapper, IProductService productService)
        {
            _service = productService;
            _mapper = mapper;
            
        }

        //[HttpGet("GetProductsWithCategory")]
        [HttpGet("[action]")]
        public async  Task<IActionResult> GetProductsWithCategory()
        {

            return CreateActionResult(await _service.GetProductsWithCategory());


        }




        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();

            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));

        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            var productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));

        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));

            var productsDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));

        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
             await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            //if (product == null)
            //{
            //    return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,"Bu id'ye sahip ürün bulunmaadı"));

            //}

            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
    }
}
