using System;
using NUnit.Framework;

namespace poker.tests
{
	public class ExpectedArgumentNullException : ExpectedExceptionAttribute
	{
		public ExpectedArgumentNullException(string parameterName)
			: base(typeof(ArgumentNullException))
		{
			ExpectedMessage = string.Format("Value cannot be null.\r\nParameter name: {0}", parameterName);
		}
	}
}