/*============================================================================

  Copyright (C) Martin Hunter, all rights reserved.

  --------------------------------------------------------------------------

  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <https://www.gnu.org/licenses/>.

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