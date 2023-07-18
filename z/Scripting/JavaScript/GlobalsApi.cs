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
    public class GlobalsApi : ScriptApi
    {
        #region Private Member Variables
        private ScriptEngine theEngine = null;
        private Func<string, object> theGet = null;
        private Action<string, object> theSet = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for <see cref="T:Z.Scripting.JavaScript.GlobalsApi"/> class.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="set"></param>
        /// <param name="get"></param>
        public GlobalsApi (ScriptEngine engine, Action<string, object> set, Func<string, object> get)
            : base (engine)
        {
            theGet = get;
            theSet = set;
            theEngine = engine;
        }
        #endregion

        #region Public Operations
        /// <summary>
        /// Sets {key} {value}.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        [JSFunction (Name = "set")]
        public void Set (string key, object value)
        {
            if (theSet != null) {
                theSet (key, value);
            }
        }

        /// <summary>
        /// Gets {value} for {key}.
        /// </summary>
        [JSFunction (Name = "get")]
        public object Get (string key)
        {
            object _rtn = null;
            if (theGet != null) {
                _rtn = theGet (key);
            }
            return _rtn;
        }
        #endregion
    }
}