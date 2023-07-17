/*============================================================================

  Copyright (C) Martin Hunter

============================================================================*/

#region Usings
using System;
using Z.Settings;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
#endregion

namespace Z
{
	public class ConsoleTarget : IProgressTarget
	{
		/// <summary>
		/// Write New Line
		/// </summary>
		public void NewLine ()
		{
			Console.WriteLine (string.Empty);
		}

		/// <summary>
		/// Write Status
		/// </summary>
		/// <param name="message"></param>
        public void Report (string message)
		{
			Console.WriteLine (message);
		}
    }
}