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
using Z.Scripting.JavaScript;
using System.Collections.Generic;
#endregion

namespace Z.Scripting
{
    public enum AppActions
    {
        Console = 0,
        Clear = 1
    }

    public abstract class ScriptInterpreter
    {
        #region Private Member Variables
        private static IDictionary<Language, ScriptInterpreter> theInterpreters = null;
        #endregion

        #region Public Static Operations
        public static IDictionary<Language, ScriptInterpreter> Interpreters
        {
            get {
                if (theInterpreters == null) {
                    theInterpreters = new Dictionary<Language, ScriptInterpreter> ();
                }
                return theInterpreters;
            }
        }

        public static ScriptInterpreter New (Language lang)
        {
            ScriptInterpreter _rtn = null;
            if (lang == Language.JavaScript) {
                _rtn = new JavaScriptInterpreter ();
            }
            return _rtn;
        }
        #endregion

        #region Public Abstract Operations
        public abstract void Execute (string script);
        #endregion
    }
}