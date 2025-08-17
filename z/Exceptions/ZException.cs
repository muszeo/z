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