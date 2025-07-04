using Application.DTO.Command;
using Application.Interfaces;
using AutoMapper;
using Billing.Domain.Entities;
using Billing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper; 
        public ProductServices(
            IProductRepository productRepository,
            IMapper mapper
            )
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductCommand>> GetAllAsync()
        {
            var result = await _productRepository.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<ProductCommand>>(result);
        }
        public async Task<ProductCommand> GetByIdAsync(Guid id)
        {
            var result = await _productRepository.GetByIdAsync(id).ConfigureAwait(false);
            return _mapper.Map<ProductCommand>(result);
        }
        public async Task AddAsync(ProductCommand product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var newProduct = _mapper.Map<Product>(product); 
            await _productRepository.AddAsync(newProduct).ConfigureAwait(false);
        }
        public async Task UpdateAsync(ProductCommand product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var newProduct = _mapper.Map<Product>(product);
            await _productRepository.UpdateAsync(newProduct).ConfigureAwait(false);
        }
        public async Task DeleteAsync(Guid id)
        {
            if (id.Equals(0)) throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            await _productRepository.DeleteAsync(id).ConfigureAwait(false);
        }
    }
}
