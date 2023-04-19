using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketDbContext _context;
        public ProductRepository(MarketDbContext context)
        {
            _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(tm => tm.TraderMark)
                .Include(c => c.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(tm => tm.TraderMark)
                .Include(c => c.Category).ToListAsync();
        }
    }
}
