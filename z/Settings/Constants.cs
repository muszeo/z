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

        public static class Messages
        {
            public const string COMPLETED = "Installation Completed.";
            public const string CANCELLED = "Cancelled";
            public const string DOWNLOADED = "Download completed";
            public const string BREW_CHECK = "Checking Homebrew installation...";
            public const string BREW_UPDATE = "Updating Homebrew...";
            public const string DOWNLOADING = "Downloading ...";
            public const string DECOMPRESSED = "Unpack completed";
            public const string DECOMPRESSING = "Unpacking ...";
            public const string UPDATING_GTK3 = "Updating GTK+3 installation now...";
            public const string NO_INSTALL_PATH = "No install path provided.";
            public const string INSTALLING_GTK3 = "Installing GTK+3 prerequisites now...";
            public const string BREW_NOT_INSTALLED = "Homebrew is not installed, installing now...";
            public const string BREW_NOT_INSTALL_FAILED = "Install of Homebrew failed. Please install Brew and GTK+3.";
        }

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
                public static readonly string COPYRIGHT = "Copyright (c) 2023 Martin Hunter, New Zealand, All Rights Reserved.";
            }

            public static class Localisation
            {
                public static readonly string FLOAT_FORMAT = "0.0#";
            }
        }
    }
}