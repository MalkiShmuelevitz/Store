using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingService : IRatingService
    {
        IRatingRepository _iratingRepository;

        public RatingService(IRatingRepository iratingRepository)
        {
            _iratingRepository = iratingRepository;
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            return await _iratingRepository.AddRating(rating);
        }
    }
}
