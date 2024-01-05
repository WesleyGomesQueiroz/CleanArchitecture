using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        //private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(/*IProductRepository productRepository,*/ IMapper mapper, IMediator mediator)
        {
            //_productRepository = productRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);

        //    if (productByIdQuery == null)
        //        throw new Exception($"Entity could not be loaded.");

        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Add(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Delete(int? id)
        {
            var productRemoveCommand = new ProductDeleteCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
