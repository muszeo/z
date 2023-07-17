/*============================================================================

  Copyright (C) Martin Hunter, all rights reserved.

============================================================================*/

#region Usings
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
#endregion

namespace Z.Exceptions
{
	public class IoException : ZException
    {
		private static readonly string __TITLE__ = "IoException";

		public IoException ()
			: base (__TITLE__)
		{
		}

		public IoException (string message)
			: base (message)
		{
		}

		public IoException (string message, Exception exception)
			: base (message, exception)
		{
		}

		public IoException (Exception exception)
			: base (__TITLE__, exception)
		{
		}
	}
}