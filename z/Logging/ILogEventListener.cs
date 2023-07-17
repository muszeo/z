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

namespace Z.Logging
{
    #region Public Enums
    public enum LogEvent
    {
        None = 0,
        Enter = 1,
        Exit = 2
    }
    #endregion

    public interface ILogEventListener
    {
        void Out (string message);
        void Debug (int i);
        void Debug (double f);
        void Debug (string message);
        void Debug (string message, LogEvent action);
        void Debug (Exception exception);
        void Debug (Action<ILogEventListener> action);
        void Info (string message);
        void Warning (string message);
        void Error (string message);
        void Error (Exception exception);
        void Assert (string message);
        bool AssertNotNull (object o0);
        bool AssertIsNull (object o0);
        bool AssertEquals (int i0, int i1);
        bool AssertEquals (double d0, double d1);
        bool AssertEquals (string s0, string s1, bool refEquals = false);
    }
}