using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        ManagerApiContext _managerApiContext;

        public RatingRepository(ManagerApiContext managerApiContext)
        {
            _managerApiContext = managerApiContext;
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            await _managerApiContext.Ratings.AddAsync(rating);
            await _managerApiContext.SaveChangesAsync();
            return rating;
        }
    }
}
