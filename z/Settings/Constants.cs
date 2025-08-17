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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
#endregion

namespace Z.Settings
{
    public static class Constants
    {
        public static readonly int Z_VERSION = 1;

        public static class Commands
        {
            public const string RUN = "run";
            public const string HELP = "help";
            public const string ALL = "--all";
            public const string PLAN = "--plan";
            public const string GLOBAL = "--global";

            public const string SPLIT = "=";
        }

        public static class Application
        {
            public static readonly string TITLE = "Z";

            public static class Version
            {
                public static readonly string FULL = "23.02";
                public static readonly string MAJOR = "23";
                public static readonly string MINOR = "02";
                public static readonly string REVISION = "2";
                public static readonly string COPYRIGHT = "Copyright (c) 2023-2025 Martin Hunter, New Zealand, All Rights Reserved.";
            }

            public static class Localisation
            {
                public static readonly string FLOAT_FORMAT = "0.0#";
            }
        }
    }
}