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
using System.Diagnostics;
using System.Collections.Generic;
#endregion

namespace Z.Logging
{
    public abstract class AbstractLogEventListener : ILogEventListener
    {
        public abstract void Out (string message);
        public abstract void Debug (int i);
        public abstract void Debug (double f);
        public abstract void Debug (string message);
        public abstract void Debug (string message, LogEvent action);
        public abstract void Debug (Exception exception);
        public abstract void Debug (Action<ILogEventListener> action);
        public abstract void Info (string message);
        public abstract void Warning (string message);
        public abstract void Error (string message);
        public abstract void Error (Exception exception);
        public abstract void Assert (string message);
        public abstract bool AssertNotNull (object o0);
        public abstract bool AssertIsNull (object o0);
        public abstract bool AssertEquals (int i0, int i1);
        public abstract bool AssertEquals (double d0, double d1);
        public abstract bool AssertEquals (string s0, string s1, bool refEquals = false);

        protected string LogAction (LogEvent action)
        {
            string _rtn = string.Empty;
            switch (action) {
                case Logging.LogEvent.Enter:
                    _rtn = ">> Enter:";
                    break;
                case Logging.LogEvent.Exit:
                    _rtn = "<< Exit";
                    break;
            }
            return _rtn;
        }
    }
}