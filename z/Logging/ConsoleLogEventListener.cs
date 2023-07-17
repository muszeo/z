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
using System.Globalization;
#endregion

namespace Z.Logging
{
    internal class ConsoleLogEventListener : AbstractLogEventListener, ILogEventListener
    {
        /// <summary>
        /// Debug the specified message.
        /// </summary>
        /// <param name="message">Message.</param>
        public override void Out (string message)
        {
            Console.WriteLine (message);
        }

        /// <summary>
        /// Debug the specified i.
        /// </summary>
        /// <param name="i">The index.</param>
        public override void Debug (int i)
        {
            Debug ($"Integer: {i}");
        }

        /// <summary>
        /// Debug the specified f.
        /// </summary>
        /// <param name="f">F.</param>
        public override void Debug (double f)
        {
            Debug ($"Float: {f.ToString (Constants.Application.Localisation.FLOAT_FORMAT, CultureInfo.InvariantCulture)}");
        }

        /// <summary>
        /// Debug the specified message.
        /// </summary>
        /// <param name="message">Message.</param>
        public override void Debug (string message)
        {
            Console.WriteLine ($"DEBUG: {message}");
        }

        /// <summary>
        /// Debug the specified message.
        /// </summary>
        /// <param name="message">Message.</param>
        public override void Debug (string message, LogEvent action)
        {
            Console.WriteLine ($"DEBUG: {LogAction (action)} {message}");
        }

        /// <summary>
        /// Debug the specified exception.
        /// </summary>
        /// <param name="exception">Exception.</param>
        public override void Debug (Exception exception)
        {
            Debug ($"Exception: {exception.Message}, {exception.StackTrace}");
        }

        /// <summary>
        /// Debug the specified action.
        /// </summary>
        /// <param name="action">Action.</param>
        public override void Debug (Action<ILogEventListener> action)
        {
            action (this);
        }

        /// <summary>
        /// Info the specified message.
        /// </summary>
        /// <param name="message">Message.</param>
        public override void Info (string message)
        {
            Console.WriteLine ($"INFO: {message}");
        }

        /// <summary>
        /// Warning the specified message.
        /// </summary>
        /// <param name="message">Message.</param>
        public override void Warning (string message)
        {
            Console.WriteLine ($"WARNING: {message}");
        }

        /// <summary>
        /// Error the specified message.
        /// </summary>
        /// <param name="message">Message.</param>
        public override void Error (string message)
        {
            Console.WriteLine ($"ERROR: {message}");
        }

        /// <summary>
        /// Assert message.
        /// </summary>
        /// <param name="message">Message.</param>
        public override void Assert (string message)
        {
            Console.WriteLine ($"ASSERT: {message}");
        }

        /// <summary>
        /// Error the specified exception.
        /// </summary>
        /// <param name="exception">Exception.</param>
        public override void Error (Exception exception)
        {
            Error (
                $"Exception:" +
                $"\n\tType: {exception.GetType().ToString()}" +
                $"\n\tSource: {exception.Source}" +
                $"\n\tMessage: {exception.Message}," +
                $"\n\tTrace: {exception.StackTrace}"
            );
        }

        /// <summary>
        /// Asserts the not null.
        /// </summary>
        /// <returns><c>true</c>, if not null was asserted, <c>false</c> otherwise.</returns>
        /// <param name="o0">O0.</param>
        public override bool AssertNotNull (object o0)
        {
            bool _rtn = (o0 != null);
            if (!_rtn) {
                Console.WriteLine (
                    "ASSERT: Assertion Failed 'Not Null', object reference is null."
                );
            }
            return _rtn;
        }

        /// <summary>
        /// Asserts the is null.
        /// </summary>
        /// <returns><c>true</c>, if is null was asserted, <c>false</c> otherwise.</returns>
        /// <param name="o0">O0.</param>
        public override bool AssertIsNull (object o0)
        {
            bool _rtn = (o0 == null);
            if (!_rtn) {
                Console.WriteLine (
                    "ASSERT: Assertion Failed 'Is Null', object reference is not null."
                );
            }
            return _rtn;
        }

        /// <summary>
        /// Asserts the equals.
        /// </summary>
        /// <returns><c>true</c>, if equals was asserted, <c>false</c> otherwise.</returns>
        /// <param name="i0">I0.</param>
        /// <param name="i1">I1.</param>
        public override bool AssertEquals (int i0, int i1)
        {
            bool _rtn = (i0 == i1);
            if (!_rtn) {
                Console.WriteLine (
                    "ASSERT: Assertion Failed 'Equals', integer primitives do not equal."
                );
            }
            return _rtn;
        }

        /// <summary>
        /// Asserts the equals.
        /// </summary>
        /// <returns><c>true</c>, if equals was asserted, <c>false</c> otherwise.</returns>
        /// <param name="d0">D0.</param>
        /// <param name="d1">D1.</param>
        public override bool AssertEquals (double d0, double d1)
        {
            bool _rtn = d0.Equals (d1); // Use 'Equals ()' opertion to avoid issue of comparing doubles with differing precisions.
            if (!_rtn) {
                Console.WriteLine (
                    "ASSERT: Assertion Failed 'Equals', double precision floating point primitives do not equal."
                );
            }
            return _rtn;
        }

        /// <summary>
        /// Asserts the equals.
        /// </summary>
        /// <returns><c>true</c>, if equals was asserted, <c>false</c> otherwise.</returns>
        /// <param name="s0">S0.</param>
        /// <param name="s1">S1.</param>
        /// <param name="refEquals">If set to <c>true</c> reference equals.</param>
        public override bool AssertEquals (string s0, string s1, bool refEquals = false)
        {
            bool _rtn = (refEquals) ?
                s0 == s1 :
                s0.Equals (s1);
            if (!_rtn) {
                if (refEquals) {
                    Console.WriteLine (
                        "ASSERT: Assertion Failed 'Equals', string object references do not equal."
                    );
                } else {
                    Console.WriteLine (
                        "ASSERT: Assertion Failed 'Equals', string object content does not equal."
                    );
                }
            }
            return _rtn;
        }
    }
}