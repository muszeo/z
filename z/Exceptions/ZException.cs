/*============================================================================

  Copyright (C) Martin Hunter, all rights reserved.

============================================================================*/

#region Usings
using System;
#endregion

namespace Z.Exceptions
{
	public class ZException : Exception
	{
        private static readonly string __TITLE__ = "ZException";

		public ZException ()
			: base (__TITLE__)
		{
		}

		public ZException (string message)
			: base (message)
		{
		}

        public ZException (string message, Exception exception)
            : base (message, exception)
		{
		}

        public ZException (Exception exception)
            : base (__TITLE__, exception)
		{
		}
	}
}