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
using Z.Settings;
using Z.Scripting.JavaScript;
#endregion

namespace Z.Scripting.JavaScript
{
    public class AppInfoApi : ScriptApi
    {
        public AppInfoApi (ScriptEngine engine)
            : base (engine)
        {
            AddSealedProperty ("name", Constants.Application.TITLE);
            AddSealedProperty ("version", Constants.Application.Version.FULL);
            AddSealedProperty ("major", Constants.Application.Version.MAJOR);
            AddSealedProperty ("minor", Constants.Application.Version.MINOR);
            AddSealedProperty ("revision", Constants.Application.Version.REVISION);
            AddSealedProperty ("copyright", Constants.Application.Version.COPYRIGHT);
        }
    }
}