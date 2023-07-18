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
using System.Collections.Generic;
#endregion

namespace Z.Scripting.JavaScript
{
    public class ResponseApiConstructor : ClrFunction
    {
        public ResponseApiConstructor (ScriptEngine engine)
            : base (
                  engine.Function.InstancePrototype,
                  "Response",
                  new ResponseApi (engine.Object.InstancePrototype))
        {
        }

        [JSConstructorFunction]
        public ResponseApi Construct ()
        {
            return new ResponseApi (InstancePrototype);
        }
    }

    public class ResponseApi : ObjectInstance
    {
        #region Private Member Variables
        private ScriptEngine theEngine = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for <see cref="T:Z.Scripting.JavaScript.ResponseApi"/> class.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="element"></param>
        public ResponseApi (ScriptEngine engine)
            : base (engine)
        {
            PopulateFunctions ();
            theEngine = engine;
        }

        /// <summary>
        /// Constructor for <see cref="T:Z.Scripting.JavaScript.ResponseApi"/> class.
        /// </summary>
        /// <param name="prototype"></param>
        public ResponseApi (ObjectInstance prototype)
            : base (prototype)
        {
            theEngine = prototype.Engine;
        }
        #endregion

        #region Public Properties -- NOT Exposed to ScriptEngine
        public IDictionary<string, string> Headers { get; set; }
        #endregion

        #region Public Properties -- Exposed to ScriptEngine
        [JSProperty (Name = "code")]
        public string StatusCode { get; set; }

        [JSProperty (Name = "status")]
        public string StatusDescription { get; set; }

        [JSProperty (Name = "body")]
        public string Body { get; set; }

        [JSProperty (Name = "json")]
        public object Json
        {
            get {
                return JSONObject.Parse (theEngine, Body);
            }
        }

        [JSProperty (Name = "type")]
        public string ContentType { get; set; }

        [JSProperty (Name = "encoding")]
        public string ContentEncoding { get; set; }

        [JSProperty (Name = "length")]
        public string ContentLength { get; set; }

        [JSProperty (Name = "protocol")]
        public string Protocol { get; set; }

        [JSProperty (Name = "raw")]
        public string Raw { get; set; }
        #endregion

        #region Public Operations
        [JSFunction (Name = "header")]
        public string Header (string name)
        {
            string _rtn = null;
            if (Headers != null && Headers.Count > 0) {
                if (Headers.ContainsKey (name)) {
                    _rtn = Headers [name];
                }
            }
            return _rtn;
        }
        #endregion
    }
}