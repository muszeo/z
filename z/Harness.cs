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
using Z.IO;
using System;
using System.IO;
using RestSharp;
using Z.Logging;
using Z.Settings;
using System.Net;
using System.Linq;
using System.Text;
using Z.Scripting;
using Z.Exceptions;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;
#endregion

namespace Z
{
    public class Harness
    {
        #region Private Member Variables
        private ScriptInterpreter theJsEngine = null;
        private bool theCancelled = false;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructors
        /// </summary>
        public Harness ()
        {
            theJsEngine = ScriptInterpreter
                .New (
                    Language.JavaScript
                );
        }
        #endregion

        #region Public Operations
        /// <summary>
        /// Prepares Global Variables from given string [] {args}.
        /// </summary>
        /// <param name="args"></param>
        public void Globals (string [] args)
        {
            if (args != null && args.Length > 0 && args.Contains (Constants.Commands.GLOBAL)) {
                for (int _i = 0; _i < args.Length; _i++) {
                    if (args [_i].Equals (Constants.Commands.GLOBAL)) {
                        if (args.Length > _i + 1) {
                            __AddGlobal (args [_i + 1]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Execte the script file at the given {path}.
        /// </summary>
        /// <param name="path"></param>
        public void Execute (string path = null)
        {
            try {

                if (path != null && path.Length > 0) {

                    Logger.Out ($"\nExecuting plan '{path}'");

                    theJsEngine.Execute (
                        File.ReadAllText (
                            Path.Combine (
                                Directory.GetCurrentDirectory (),
                                path
                            )
                        )
                    );

                } else {

                    Logger.Out ("\nLooking for test plans to execute...");

                    string [] _files =
                        Directory
                            .GetFiles (
                                Directory.GetCurrentDirectory (),
                                "*.js",
                                SearchOption.TopDirectoryOnly
                            )
                            .OrderBy (_f => _f)
                            .ToArray ();

                    Logger.Out ($"\nFound {_files.Length} plans to execute.");

                    foreach (string _f in _files) {
                        Logger.Out ($"\nExecuting plan '{_f}'...");
                        theJsEngine.Execute (
                            File.ReadAllText (_f)
                        );
                    }

                    Logger.Out ($"\nFinished executing {_files.Length} plans.");

                }

            } catch (Exception __x) {
                Logger.Error (__x);
            }
        }

        /// <summary>
        /// Write the CVM Header
        /// </summary>
        public void Header ()
        {
            Logger.Out (
                $"==================================================================\n" +
                $"                                                                  \n" +
                $"      zzzzzzzzzzzzzz zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz z z  z   z  \n" +
                $"     zz          zz                                               \n" +
                $"    zz          zz  aaaa     ppppp  iiii  tttttttttt              \n" +
                $"  zzzzzzzz     zz  aa   a    pp  pp  ii       tt                  \n" +
                $"        zz    zz  aa  a  a   pp  pp  ii       tt                  \n" +
                $"       zz    zz  aa  aaa  a  ppppp   ii       tt                  \n" +
                $"      Zz    zzzzzazzaaaaazza pp zzzzziizzzzzz tt zzzz z z  z   z  \n" +
                $"     zz        aa  a    aa  app      ii       tt                  \n" +
                $"    Zzzzzzzzzzzzzzzzzzzzzzzz pp zzzzzzzzzzzzz tt zzzz z z  z   z  \n" +
                $"             aa  a        aa pp     iiii      tt                  \n" +
                $"                                                                  \n" +
                $"==================================================================\n\n" +
                $"                  Z-API-Test Harness version {Constants.Z_VERSION}\n\n" +
                $"              (c) Martin Hunter, 2023-2025, New Zealand           \n\n" +
                $"==================================================================\n"
            );
        }

        /// <summary>
        /// Write the CVM Footer
        /// </summary>
        public void Footer ()
        {
            Logger.Out (
                $"==================================================================\n\n"
            );
        }

        /// <summary>
        /// Write CVM Help
        /// </summary>
        public void Help ()
        {
            Logger.Out (
                $"Usage:                                                            \n" +
                $"                                                                  \n" +
                $"  zapit [run] [<file>|--all] [--global <key>=<value> ...]         \n" +
                $"                                                                  \n" +
                $"run <file>    => Runs the zapit test harness against the given    \n" +
                $"                 <file> test plan in the current directory.       \n" +
                $"run --all     => Runs the zapit test hardness against all js files\n" +
                $"                 in the current directory.                        \n" +
                $"    --global  => Set a global variable value, in the form         \n" +
                $"                 <key>=<value> for example, --global id=1         \n" +
                $"help          => Show this help. For help on the zapit JavaScript \n" +
                $"                 api please run a simple test plan containing the \n" +
                $"                 following line of code: z.help();                \n"
            );
        }

        /// <summary>
        /// Write Error Message
        /// </summary>
        /// <param name="message"></param>
        public void Error (string message)
        {
            Logger.Error (message);
        }

        /// <summary>
        /// Cancel installation process.
        /// </summary>
        public void Cancel ()
        {
            theCancelled = true;
        }
        #endregion

        #region Private Operations
        /// <summary>
        /// Adds a Global Variable to the JS Script Interpreter.
        /// </summary>
        /// <param name="global"></param>
        private void __AddGlobal (string global)
        {
            if (theJsEngine != null && global != null && global.Length > 0) {
                string [] _g = global.Split (Constants.Commands.SPLIT);
                if (_g != null && _g.Length >= 2) {
                    theJsEngine.Set (_g [0], _g [1]);
                }
            }
        }
        #endregion
    }
}