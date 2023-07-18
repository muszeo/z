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
    public class RandomApi : ScriptApi
    {
        #region Private Member Variables
        private ScriptEngine theEngine = null;
        private Random theGenerator = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for <see cref="T:Z.Scripting.JavaScript.VariablesApi"/> class.
        /// </summary>
        /// <param name="engine"></param>
        public RandomApi (ScriptEngine engine)
            : base (engine)
        {
            theEngine = engine;
        }
        #endregion

        #region Public Operations
        /// <summary>
        /// Get Random Number
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        [JSFunction (Name = "number")]
        public int Number (int min = 0, int max = 1000)
        {
            if (theGenerator == null) {
                theGenerator = new Random ();
            }
            return theGenerator.Next (min, max);
        }

        /// <summary>
        /// Get Random Text
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        [JSFunction (Name = "text")]
        public string Text (int min = 4, int max = 16)
        {
            if (theGenerator == null) {
                theGenerator = new Random ();
            }

            string _rtn = string.Empty;

            int _l = theGenerator.Next (min, max);
            int _v; char _t;

            for (int i = 0; i < _l; i++) {
                _v = theGenerator.Next (0, 26);
                _t = Convert.ToChar (_v + 65);
                _rtn = $"{_rtn}{_t}";
            }

            return _rtn;
        }

        /// <summary>
        /// Get Random Date
        /// </summary>
        [JSFunction (Name = "date")]
        public string Date ()
        {
            return System.DateTime.Now.StringifyANSIDateOnly ();
        }

        /// <summary>
        /// Get Random DateTime
        /// </summary>
        [JSFunction (Name = "datetime")]
        public string DateTime ()
        {
            return System.DateTime.Now.StringifyANSI ();
        }

        /// <summary>
        /// Get Random ISO DateTime
        /// </summary>
        [JSFunction (Name = "isodatetime")]
        public string IsoDateTime ()
        {
            return System.DateTime.Now.StringifyISO8601 ();
        }
        #endregion
    }
}