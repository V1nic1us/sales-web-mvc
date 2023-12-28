using sales_web_mvc.Data;
using sales_web_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace sales_web_mvc.Service
{
    public class SalesRecordService
    {
        private readonly sales_web_mvcContext _context;

        public SalesRecordService(sales_web_mvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            // LINQ query
            var result = from obj in _context.SalesRecord select obj;
            // if minDate is not null, add a restriction to the query
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            // if maxDate is not null, add a restriction to the query
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            // return the query result
            return await result
                .Include(x => x.Seller) // join with Seller table
                .Include(x => x.Seller.Department) // join with Department table
                .OrderByDescending(x => x.Date) // order by Date descending
                .ToListAsync(); // convert to list
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            // LINQ query
            var result = from obj in _context.SalesRecord select obj;
            // if minDate is not null, add a restriction to the query
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            // if maxDate is not null, add a restriction to the query
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            // return the query result
            return await result
                .Include(x => x.Seller) // join with Seller table
                .Include(x => x.Seller.Department) // join with Department table
                .OrderByDescending(x => x.Date) // order by Date descending
                .GroupBy(x => x.Seller.Department) // group by Department
                .ToListAsync(); // convert to list
        }
    }
}
