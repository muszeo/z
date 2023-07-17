/*============================================================================

  Copyright (C) Martin Hunter

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
    public class Platform
    {
        /// <summary>
        /// Gets the current runtime platform Operating System (OS).
        /// </summary>
        /// <value>The os.</value>
		public static PlatformID OS
        {
            get {
                return System.Environment.OSVersion.Platform;
            }
        }

        /// <summary>
        /// Identifies whether this current runtime platform OS is Microsoft Windows or not.
        /// </summary>
        /// <returns><c>true</c>, if windows was ised, <c>false</c> otherwise.</returns>
		public static bool IsWindows ()
        {
            return (
                OS == PlatformID.Win32NT
                || OS == PlatformID.Win32S
                || OS == PlatformID.Win32Windows
                || OS == PlatformID.WinCE
            );
        }

        /// <summary>
        /// Identifies whether this current runtime platform is a *nix OS or not (i.e. Unix, Linux, Mac OS X etc.)
        /// </summary>
        /// <returns><c>true</c>, if nix was ised, <c>false</c> otherwise.</returns>
		public static bool IsNix ()
        {
            return (
                (OS == PlatformID.Unix) || (OS == PlatformID.MacOSX)
            );
        }

        /// <summary>
        /// Identifies whether this current runtime platform OS is Apple Mac OS or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsMacOS ()
        {
            return OS == PlatformID.MacOSX;
        }

        /// <summary>
        /// Identifies whether this current runtime platform OS is Unix or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsUnix ()
        {
            return OS == PlatformID.Unix;
        }

        /// <summary>
        /// Identifies whether this current runtime platform OS is "other" or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsOther ()
        {
            return OS == PlatformID.Other;
        }
    }
}