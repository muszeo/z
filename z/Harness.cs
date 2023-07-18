/*============================================================================

  Copyright (C) Martin Hunter

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
                $"              (c) Martin Hunter, 2023, New Zealand                \n\n" +
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
                $"run <file>    => Runs the zapit test harness against the given\n" +
                $"                 <file> test plan in the current directory.\n" +
                $"run --all     => Runs the zapit test hardness against all js files\n" +
                $"                 in the current directory.\n" +
                $"help          => Show this help. For help on the zapit JavaScript\n" +
                $"                 api please run a simple test plan containing the\n" +
                $"                 following line of code: z.help();\n"
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
        #endregion
    }
}