using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        ManagerApiContext _managerApiContext;

        public CategoryRepository(ManagerApiContext managerApiContext)
        {
            _managerApiContext = managerApiContext;
        }

        public async Task<List<Category>> Get()
        {
            return await _managerApiContext.Categories.ToListAsync();

        }


      
    }
}
