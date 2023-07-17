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
using Jurassic.Library;
#endregion

namespace Z.Scripting.JavaScript
{
    public abstract class ScriptApi : ObjectInstance
    {
        #region Constructors
        /// <summary>
        /// Constructor for <see cref="T:Modr.Scripting.JavaScript.ScriptApi"/> class.
        /// </summary>
        /// <param name="engine"></param>
        public ScriptApi (ScriptEngine engine)
            : base (engine)
        {
            PopulateFunctions ();
        }
        #endregion

        #region Protected Operations
        /// <summary>
        /// Adds a Sealed Property that is exposed into Jurassic.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected void AddSealedProperty (string name, string value)
        {
            DefineProperty (
                name,
                new PropertyDescriptor (
                    value,
                    PropertyAttributes.Sealed
                ),
                true
            );
        }
        #endregion
    }
}