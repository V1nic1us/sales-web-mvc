namespace sales_web_mvc.Service.Exceptions
{
	public class IntegrityException: ApplicationException
	{
		public IntegrityException(string message) : base(message)
		{
		}
	}
}
