namespace sales_web_mvc.Service.Exceptions
{
	public class NotFoundException: ApplicationException
	{
		public NotFoundException(string message) : base(message)
		{
		}
	}
}
