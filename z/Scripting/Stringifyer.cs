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
using Z.Exceptions;
using System.Collections.Generic;
#endregion

namespace Z.Scripting
{
    public static class Stringifyer
    {
        #region Public Operations
        /// <summary>
        /// Gets the given {dateTime} as a string in ISO8601 format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyISO8601 (this DateTime? dateTime)
        {
            if (dateTime == null || !dateTime.HasValue) {
                dateTime = DateTime.MinValue;
            }
            return $"{dateTime.Value.Year}-{__Prepend (dateTime.Value.Month)}-{__Prepend (dateTime.Value.Day)}"
                    + $"T{__Prepend (dateTime.Value.Hour)}:{__Prepend (dateTime.Value.Minute)}:{__Prepend (dateTime.Value.Second)}";
        }

        /// <summary>
        /// Gets the given {dateTime} as a string in ISO8601 format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyDateOnlyHuman (this DateTime? dateTime)
        {
            string _rtn = string.Empty;
            if (dateTime.HasValue) {
                _rtn = $"{dateTime.Value.Day}/{__Prepend (dateTime.Value.Month)}/{__Prepend (dateTime.Value.Year)}";
            }
            return _rtn;
        }

        /// <summary>
        /// Gets the given {dateTime} as a string in Human Readable format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyDateOnlyHumanText (this DateTime? dateTime)
        {
            string _rtn = string.Empty;
            if (dateTime.HasValue) {
                _rtn = $"{dateTime.Value:dd MMM yyyy}";
            }
            return _rtn;
        }

        /// <summary>
        /// Gets the given {dateTime} as a string in ISO8601 format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyISO8601 (this DateTime dateTime)
        {
            return $"{dateTime.Year}-{__Prepend (dateTime.Month)}-{__Prepend (dateTime.Day)}"
                 + $"T{__Prepend (dateTime.Hour)}:{__Prepend (dateTime.Minute)}:{__Prepend (dateTime.Second)}";
        }

        /// <summary>
        /// Gets the given {dateTime} as a string in SQL format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyANSI (this DateTime dateTime)
        {
            return $"{dateTime.Year}-{__Prepend (dateTime.Month)}-{__Prepend (dateTime.Day)} "
                 + $"{__Prepend (dateTime.Hour)}:{__Prepend (dateTime.Minute)}:{__Prepend (dateTime.Second)}";
        }

        /// <summary>
        /// Gets the Date component of the given {dateTime} as a string in SQL format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyANSIDateOnly (this DateTime dateTime)
        {
            return $"{dateTime.Year}-{__Prepend (dateTime.Month)}-{__Prepend (dateTime.Day)}";
        }
        #endregion

        #region Private Operations
        /// <summary>
        /// Converts int to string with a prepended "0" ahead of any value 0 <= {value} <= 9.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string __Prepend (int value)
        {
            if (value < 0) {
                throw new ZException ("Time component value cannot be less than 0");
            }
            string _v = value <= 9 ? "0" : string.Empty;
            return $"{_v}{value}";
        }
        #endregion
    }
}