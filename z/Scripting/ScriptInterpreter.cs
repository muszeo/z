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
using Jurassic;
using Z.Logging;
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
        private IDictionary<string, object> theVariables = null;
        #endregion

        #region Private Static Member Variables
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

        #region Constructors
        /// <summary>
        /// Constructor for <see cref="T:Z.Scripting.ScriptInterpreter"/> class.
        /// </summary>
        internal ScriptInterpreter ()
        {
            theVariables = new Dictionary<string, object> ();
        }
        #endregion


        #region Public Abstract Operations
        public abstract void Execute (string script);
        #endregion

        #region Public Operations
        /// <summary>
        /// Sets {key} {value}.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set (string key, object value)
        {
            if (!theVariables.ContainsKey (key)) {
                Logger.Info ($"Adding Global '{key}' with value '{value}'");
                theVariables.Add (key, value);
            } else {
                Logger.Info ($"Updating Global '{key}' with value '{value}'");
                theVariables [key] = value;
            }
        }

        /// <summary>
        /// Gets {value} for {key}.
        /// </summary>
        public object Get (string key)
        {
            object _rtn = null;
            if (theVariables.ContainsKey (key)) {
                _rtn = theVariables [key];
            }
            return _rtn;
        }
        #endregion
    }
}