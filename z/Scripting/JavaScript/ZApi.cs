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
using Z.Logging;
using Z.IO.Http;
using System.Linq;
using Jurassic.Library;
using System.Collections.Generic;
#endregion

namespace Z.Scripting.JavaScript
{
    public class ZApi : ScriptApi
    {
        #region Private Enums
        private enum HttpMethod
        {
            Get = 0,
            Post = 1,
            Put = 2,
            Delete = 3
        }
        #endregion

        #region Private Member Variables
        private ScriptEngine theEngine = null;
        private AssertApi theAssert = null;
        private RandomApi theRandom = null;
        private LoggerApi theLogger = null;
        private VariablesApi theVariables = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for <see cref="T:Modr.Scripting.JavaScript.ZApi"/> class.
        /// </summary>
        /// <param name="engine"></param>
        public ZApi (ScriptEngine engine)
            : base (engine)
        {
            theEngine = engine;
        }
        #endregion

        #region Public Operations
        /// <summary>
        /// Writes the given {message} text to the Console.
        /// </summary>
        /// <param name="message"></param>
        [JSFunction (Name = "out")]
        public void Out (string message)
        {
            Logger.Out (message);
        }

        /// <summary>
        /// Writes help text to the Console.
        /// </summary>
        /// <param name="output"></param>
        [JSFunction (Name = "help")]
        public void Help ()
        {
            Logger.Out ("Z Api Methods Help:");
            Logger.Out ("z.clear()");
            Logger.Out ("z.out(string text)");
            Logger.Out ("z.help()");
            Logger.Out ("z.assert.true(bool condition, string message = null)");
            Logger.Out ("z.assert.false(bool condition, string message = null)");
            Logger.Out ("z.assert.ok(Response response, string message = null)");
            Logger.Out ("z.assert.error(Response response, string message = null)");
            Logger.Out ("z.assert.notfound(Response response, string message = null)");
            Logger.Out ("z.vars.set(string name, object value)");
            Logger.Out ("z.vars.get(string name) : object");
            Logger.Out ("z.random.number(int min = 0, int max = 1000) : integer");
            Logger.Out ("z.random.text(int min = 4, int max = 16) : string");
            Logger.Out ("z.get(string uri, string resource, string token = null) : response");
            Logger.Out ("z.post(string uri, string resource, string body, string contentType = null, string expects = null, string token = null) : response");
            Logger.Out ("z.put(string uri, string resource, string body, string contentType = null, string expects = null, string token = null) : response");
            Logger.Out ("z.delete(string uri, string resource, string token = null) : response");
        }

        /// <summary>
        /// Gets handle to internal variables dictionary.
        /// </summary>
        [JSProperty (Name = "vars")]
        public VariablesApi Variables
        {
            get {
                if (theVariables == null) {
                    theVariables = new VariablesApi (theEngine);
                }
                return theVariables;
            }
        }

        /// <summary>
        /// Gets handle to internal assert object.
        /// </summary>
        [JSProperty (Name = "assert")]
        public AssertApi Assert
        {
            get {
                if (theAssert == null) {
                    theAssert = new AssertApi (theEngine);
                }
                return theAssert;
            }
        }

        /// <summary>
        /// Gets handle to internal random object.
        /// </summary>
        [JSProperty (Name = "random")]
        public RandomApi Random
        {
            get {
                if (theRandom == null) {
                    theRandom = new RandomApi (theEngine);
                }
                return theRandom;
            }
        }

        /// <summary>
        /// Gets handle to internal logger object.
        /// </summary>
        [JSProperty (Name = "logger")]
        public LoggerApi LoggerApi
        {
            get {
                if (theLogger == null) {
                    theLogger = new LoggerApi (theEngine);
                }
                return theLogger;
            }
        }

        #region Http Methods
        /// <summary>
        /// Generates a GET HTTP Request and returns the Response.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="resource"></param>
        /// <param name="token"></param>
        /// <returns>Response</returns>
        [JSFunction (Name = "get")]
        public ResponseApi Get (string baseUri, string resource, string token = null)
        {
            return __Request (
                method: HttpMethod.Get,
                baseUri: baseUri,
                resource: resource,
                token: token
            );
        }

        /// <summary>
        /// Generates a POST HTTP Request and returns the Response.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="resource"></param>
        /// <param name="body"></param>
        /// <param name="contentType"></param>
        /// <param name="expects"></param>
        /// <param name="token"></param>
        /// <returns>Response</returns>
        [JSFunction (Name = "post")]
        public ResponseApi Post (string baseUri, string resource, string body, string contentType = null, string expects = null, string token = null)
        {
            return __Request (
                method: HttpMethod.Post,
                baseUri: baseUri,
                resource: resource,
                body: body,
                contentType: contentType,
                expects: expects,
                token: token
            );
        }

        /// <summary>
        /// Generates a PUT HTTP Request and returns the Response.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="resource"></param>
        /// <param name="body"></param>
        /// <param name="contentType"></param>
        /// <param name="expects"></param>
        /// <param name="token"></param>
        /// <returns>Response</returns>
        [JSFunction (Name = "put")]
        public ResponseApi Put (string baseUri, string resource, string body, string contentType = null, string expects = null, string token = null)
        {
            return __Request (
                method: HttpMethod.Put,
                baseUri: baseUri,
                resource: resource,
                body: body,
                contentType: contentType,
                expects: expects,
                token: token
            );
        }

        /// <summary>
        /// Generates a DELETE HTTP Request and returns the Response.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="resource"></param>
        /// <param name="token"></param>
        /// <returns>Response</returns>
        [JSFunction (Name = "delete")]
        public ResponseApi Delete (string baseUri, string resource, string token = null)
        {
            return __Request (
                method: HttpMethod.Delete,
                baseUri: baseUri,
                resource: resource,
                token: token
            );
        }
        #endregion
        #endregion

        #region Private Operations
        /// <summary>
        /// Generates an HTTP Request and return the Response.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="baseUri"></param>
        /// <param name="resource"></param>
        /// <param name="body"></param>
        /// <param name="contentType"></param>
        /// <param name="expects"></param>
        /// <param name="token">Bearer Token.</param>
        /// <returns></returns>
        private ResponseApi __Request (HttpMethod method, string baseUri, string resource, string body = null, string contentType = null, string expects = null, string token = null)
        {
            ResponseApi _rtn = null;
            WebResourceProxy _p = new WebResourceProxy ();
            Response _r = null;
            switch (method) {
                case HttpMethod.Get:
                    _r = _p.Get (baseUri, resource, token);
                    break;
                case HttpMethod.Post:
                    _r = _p.Post (baseUri, resource, body, contentType, expects, token);
                    break;
                case HttpMethod.Put:
                    _r = _p.Put (baseUri, resource, body, contentType, expects, token);
                    break;
                case HttpMethod.Delete:
                    _r = _p.Delete (baseUri, resource, token);
                    break;
            }
            if (_r != null) {
                _rtn = new ResponseApi (theEngine).From (_r);
            }
            return _rtn;
        }
        #endregion
    }
}