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
using Z.Logging;
using System.IO;
using System.Net;
using Z.Exceptions;
#endregion

namespace Z.IO.Http
{
    public class WebResourceProxy
    {
        #region Private Member Variables
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Modr.IO.Http.WebRequester"/> class.
        /// </summary>
        public WebResourceProxy ()
        {
        }
        #endregion

        #region Public Operations
        /// <summary>
        /// Performs GET method call.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="resource"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public Response Get (string baseUri, string resource, string authToken = null)
        {
            return __IssueRequest (
                method: "GET",
                baseUri: baseUri,
                resource: resource,
                authToken: authToken
            );
        }

        /// <summary>
        /// Performs POST method call.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="resource"></param>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <param name="expects"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public Response Post (string baseUri, string resource, string body = null, string type = "text/plain", string expects = null, string authToken = null)
        {
            return __IssueRequest (
                method: "POST",
                baseUri: baseUri,
                resource: resource,
                body: body,
                type: type,
                expects: expects,
                authToken: authToken
            );
        }

        /// <summary>
        /// Performs PUT method call.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="resource"></param>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <param name="expects"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public Response Put (string baseUri, string resource, string body = null, string type = "text/plain", string expects = null, string authToken = null)
        {
            return __IssueRequest (
                method: "PUT",
                baseUri: baseUri,
                resource: resource,
                body: body,
                type: type,
                expects: expects,
                authToken: authToken
            );
        }

        /// <summary>
        /// Performs DELETE method call.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="resource"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public Response Delete (string baseUri, string resource, string authToken = null)
        {
            return __IssueRequest (
                method: "DELETE",
                baseUri: baseUri,
                resource: resource,
                authToken: authToken
            );
        }
        #endregion

        #region Private Operations
        /// <summary>
        /// Performs HTTP method call.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="baseUri"></param>
        /// <param name="resource"></param>
        /// <param name="body">Optional body = null.</param>
        /// <param name="type"></param>
        /// <param name="expects"></param>
        /// <param name="authToken">Bearer token.</param>
        /// <returns></returns>
        private Response __IssueRequest (string method, string baseUri, string resource, string body = null, string type = null, string expects = null, string authToken = null)
        {
            Response _rtn = null;
            try {
                string _c = string.Empty;
                HttpWebRequest _q = HttpWebRequest.CreateHttp ($"{baseUri}/{resource}");
                _q.Method = method;
                _q.AllowAutoRedirect = true;
                _q.KeepAlive = false;
                if (type != null) {
                    _q.ContentType = type;
                }
                if (expects != null) {
                    _q.Expect = expects;
                }
                if (authToken != null) {
                    _q.Headers.Add (
                        HttpRequestHeader.Authorization,
                        authToken
                    );
                }
                if (body != null) {
                    _q.ContentLength = body.Length;
                    Stream _s = _q.GetRequestStream ();
                    _s.Write (__AsByteArray (body), 0, body.Length);
                    _s.Close ();
                }
                using (HttpWebResponse _r = _q.GetResponse () as HttpWebResponse) {
                    StreamReader _s = new StreamReader (
                        _r.GetResponseStream ()
                    );
                    _c = _s.ReadToEnd ();
                    _rtn = new Response ().From (_r, _c);
                    _s.Close ();
                    _r.Close ();
                }
            } catch (Exception __x) {
                throw new IoException (__x);
            }
            return _rtn;
        }

        /// <summary>
        /// Converts a string to a byte array.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private byte [] __AsByteArray (string text)
        {
            byte [] _rtn = new byte [text.Length];
            char [] _c = text.ToCharArray ();
            for (int _i = 0; _i < text.Length; _i++) {
                _rtn [_i] = Convert.ToByte (_c [_i]);
            }
            return _rtn;
        }
        #endregion
    }
}