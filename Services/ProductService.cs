using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {

        IProductRpository _iproductRpository;

        public ProductService(IProductRpository iproductRpository)
        {
            _iproductRpository = iproductRpository;
        }

        public async Task<List<Product>> Get(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _iproductRpository.Get( position,  skip, desc,  minPrice,  maxPrice, categoryIds);

        }

       
    }
}
