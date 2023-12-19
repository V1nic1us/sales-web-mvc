namespace sales_web_mvc.Service.Exceptions
{
	public class DbConcurrencyException: ApplicationException
	{
		public DbConcurrencyException(string message) : base(message)
		{
		}
	}
}
