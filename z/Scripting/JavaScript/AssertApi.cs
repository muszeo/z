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
using Z.IO.Http;
using System.Linq;
using Jurassic.Library;
using System.Collections.Generic;
#endregion

namespace Z.Scripting.JavaScript
{
    public class AssertApi : ScriptApi
    {
        #region Private Member Variables
        private ScriptEngine theEngine = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for <see cref="T:Modr.Scripting.JavaScript.VariablesApi"/> class.
        /// </summary>
        /// <param name="engine"></param>
        public AssertApi (ScriptEngine engine)
            : base (engine)
        {
            theEngine = engine;
        }
        #endregion

        #region Public Operations
        /// <summary>
        /// Assert True {condition}.
        /// </summary>
        /// <param name="output"></param>
        [JSFunction (Name = "true")]
        public void True (bool condition, string message = null)
        {
            string _m = condition.ToString ();
            if (message != null) {
                _m = $"{message}: {_m}";
            }
            Logger.Assert (_m);
        }

        /// <summary>
        /// Assert True {condition}.
        /// </summary>
        /// <param name="output"></param>
        [JSFunction (Name = "false")]
        public void False (bool condition, string message = null)
        {
            string _m = (!condition).ToString ();
            if (message != null) {
                _m = $"{message}: {_m}";
            }
            Logger.Assert (_m);
        }

        /// <summary>
        /// Assert {response} is HTTP 200 OK.
        /// </summary>
        /// <param name="output"></param>
        [JSFunction (Name = "ok")]
        public void Ok (ResponseApi response, string message = null)
        {
            string _m = (response.StatusCode.Contains ("OK")).ToString();
            if (message != null) {
                _m = $"{message}: {_m}";
            } else {
                _m = $"OK: {_m}";
            }
            Logger.Assert (_m);
        }

        /// <summary>
        /// Assert {response} is HTTP 500 Internal Server Error.
        /// </summary>
        /// <param name="output"></param>
        [JSFunction (Name = "error")]
        public void Error (ResponseApi response, string message = null)
        {
            string _m = (response.StatusCode.Contains ("Error")).ToString ();
            if (message != null) {
                _m = $"{message}: {_m}";
            } else {
                _m = $"Error: {_m}";
            }
            Logger.Assert (_m);
        }

        /// <summary>
        /// Assert {response} is HTTP 404 Not Found.
        /// </summary>
        /// <param name="output"></param>
        [JSFunction (Name = "notfound")]
        public void NotFound (ResponseApi response, string message = null)
        {
            string _m = (response.StatusCode.Contains ("Not Found")).ToString ();
            if (message != null) {
                _m = $"{message}: {_m}";
            } else {
                _m = $"Not Found: {_m}";
            }
            Logger.Assert (_m);
        }
        #endregion
    }
}