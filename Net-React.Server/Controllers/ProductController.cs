﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net_React.Server.DTOs;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Net_React.Server.Controllers
{

    [Route("api/products")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productsDto = await _productService.GetAllProductsAsync();
            return Ok(productsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var productDto = await _productService.GetProductByIdAsync(id);
            return productDto != null ? Ok(productDto) : NotFound();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var productDto = await _productService.GetProductByNameAsync(name);
            return productDto == null ? NotFound() : Ok(productDto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] ProductDTO productDto)
        {
            await _productService.AddProductAsync(productDto);
            return CreatedAtAction("GetByIdAsync", new { id = productDto.Id }, productDto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] ProductDTO productDto)
        {
            await _productService.UpdateProductAsync(productDto);
            return Ok(productDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _productService.GetProductByIdAsync(id);
            return NoContent();
        }
    }


}
