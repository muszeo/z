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
using Jurassic;
using Z.Logging;
using Jurassic.Library;
#endregion

namespace Z.Scripting.JavaScript
{
    public class LoggerApi : ScriptApi
    {
        public LoggerApi (ScriptEngine engine)
            : base (engine)
        {
        }

        [JSFunction (Name = "out")]
        public static void Out (string message)
        {
            Logger.Out (message);
        }

        [JSFunction (Name = "info")]
        public static void Info (string message)
        {
            Logger.Info (message);
        }

        [JSFunction (Name = "warning")]
        public static void Warning (string message)
        {
            Logger.Warning (message);
        }

        [JSFunction (Name = "error")]
        public static void Error (string message)
        {
            Logger.Error (message);
        }
    }
}
