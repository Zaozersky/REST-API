using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trial.WebAPI.Data.Models;
using Trial.WebAPI.Services;
using Trial.WebAPI.Validators;
using Trial.WebAPI.ViewModels;

namespace Trial.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductController(IProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            IEnumerable<ProductViewModel> productsViewModel;

            try
            {
                var products = await _productsService.GetAllProductsData(cancellationToken);
                productsViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(productsViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            ProductViewModel productViewModel;

            try
            {
                var product = await _productsService.GetProduct(id, cancellationToken);
                productViewModel = _mapper.Map<ProductViewModel>(product);
            }
            catch (ArgumentException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductViewModel productViewModel, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new ProductValidator();
                await validator.ValidateAndThrowAsync(productViewModel, cancellationToken: cancellationToken);

                var product = _mapper.Map<Product>(productViewModel);

                await _productsService.CreateProduct(product, cancellationToken);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductViewModel productViewModel, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new ProductValidator();
                await validator.ValidateAndThrowAsync(productViewModel, cancellationToken: cancellationToken);

                var product = _mapper.Map<Product>(productViewModel);
                await _productsService.UpdateProduct(product, cancellationToken);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _productsService.DeleteProduct(id, cancellationToken);
            }
            catch (ArgumentException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }
    }
}