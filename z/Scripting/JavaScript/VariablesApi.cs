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
using Z.IO.Http;
using System.Linq;
using Jurassic.Library;
using System.Collections.Generic;
#endregion

namespace Z.Scripting.JavaScript
{
    public class VariablesApi : ScriptApi
    {
        #region Private Member Variables
        private ScriptEngine theEngine = null;
        private IDictionary<string, object> theVariables = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for <see cref="T:Modr.Scripting.JavaScript.VariablesApi"/> class.
        /// </summary>
        /// <param name="engine"></param>
        public VariablesApi (ScriptEngine engine)
            : base (engine)
        {
            theEngine = engine;
            theVariables = new Dictionary<string, object> ();
        }
        #endregion

        #region Public Operations
        /// <summary>
        /// Sets {key} {value}.
        /// </summary>
        /// <param name="output"></param>
        [JSFunction (Name = "set")]
        public void Set (string key, object value)
        {
            if (!theVariables.ContainsKey (key)) {
                theVariables.Add (key, value);
            } else {
                theVariables [key] = value;
            }
        }

        /// <summary>
        /// Gets {value} for {key}.
        /// </summary>
        [JSFunction (Name = "get")]
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