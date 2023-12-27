using Microsoft.EntityFrameworkCore;
using sales_web_mvc.Data;
using sales_web_mvc.Models;
using sales_web_mvc.Service.Exceptions;

namespace sales_web_mvc.Service
{
	public class SellerService
	{
		private readonly sales_web_mvcContext _context;

		public SellerService(sales_web_mvcContext context)
		{
			_context = context;
		}

		public async Task<List<Seller>> FindAllAsync()
		{
			return await _context.Seller.Include(s => s.Department).ToListAsync();
		}

		public async Task InsertAsync(Seller obj)
		{
			_context.Add(obj);
			await _context.SaveChangesAsync();
		}

		public async Task<Seller> FindByIdAsync(int id)
		{
			return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
		}

		public async Task RemoveAsync(int id)
		{
			var obj = await _context.Seller.FindAsync(id);
			_context.Seller.Remove(obj);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Seller obj)
		{
			bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
			if (!hasAny)
			{
				throw new NotFoundException("Id not found");
			}
			try
			{
				_context.Update(obj);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException e)
			{
				throw new DbConcurrencyException(e.Message);
			}
		}
	}
}
