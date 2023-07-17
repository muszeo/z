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
        public void Execute (string path)
        {
            try {

                if (path != null && path.Length > 0) {
                    theJsEngine.Execute (
                        File.ReadAllText (
                            Path.Combine (
                                Directory.GetCurrentDirectory (),
                                path
                            )
                        )
                    );
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
                $"==================================================================\n\n" +
                $" Welcome to Z API Test Harness v{Constants.Z_VERSION}\n\n" +
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
                $"run <file>    => runs the z test harness against the given <file> plan in the current path.\n" +
                $"help          => show this help."
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