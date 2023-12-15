using Microsoft.EntityFrameworkCore;
using sales_web_mvc.Data;
using sales_web_mvc.Models;

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
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
