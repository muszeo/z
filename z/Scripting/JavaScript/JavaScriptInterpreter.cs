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
using System.Collections.Generic;
#endregion

namespace Z.Scripting.JavaScript
{
    public class JavaScriptInterpreter : ScriptInterpreter
    {
        #region Private Member Variables
        private ScriptEngine theJurassicEngine = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for <see cref="T:Z.Scripting.JavaScript.JavaScriptInterpreter"/> class.
        /// </summary>
        internal JavaScriptInterpreter ()
            : base ()
        {
            theJurassicEngine = new ScriptEngine ();

            theJurassicEngine.SetGlobalValue (
                "info",
                new AppInfoApi (theJurassicEngine)
            );

            theJurassicEngine.SetGlobalValue (
                "logger",
                new LoggerApi (theJurassicEngine)
            );

            theJurassicEngine.SetGlobalValue (
                "z",
                new ZApi (theJurassicEngine, Set, Get)
            );

        }
        #endregion

        #region Public Overide Operations
        /// <summary>
        /// Executes given {script}.
        /// </summary>
        /// <param name="script"></param>
        public override void Execute (string script)
        {
            theJurassicEngine.Execute (script);
        }
        #endregion
    }
}