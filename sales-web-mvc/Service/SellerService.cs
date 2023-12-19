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

		public List<Seller> FindAll()
		{
			return _context.Seller.Include(s => s.Department).ToList();
		}

		public void Insert(Seller obj)
		{
			_context.Add(obj);
			_context.SaveChanges();
		}

		public Seller FindById(int id)
		{
			return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
		}

		public void Remove(int id)
		{
			var obj = _context.Seller.Find(id);
			_context.Seller.Remove(obj);
			_context.SaveChanges();
		}

		public void Update(Seller obj)
		{
			if (!_context.Seller.Any(x => x.Id == obj.Id))
			{
				throw new NotFoundException("Id not found");
			}
			try
			{
				_context.Update(obj);
				_context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException e)
			{
				throw new DbConcurrencyException(e.Message);
			}
		}
	}
}
