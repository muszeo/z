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
using System.Collections.Generic;
#endregion

namespace Z.IO.Http
{
    public class Response
    {
        private IDictionary<string, string> theHeaders;

        public Response ()
        {
            theHeaders = new Dictionary<string, string> ();
        }

        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string ContentType { get; set; }
        public string ContentEncoding { get; set; }
        public string ContentLength { get; set; }
        public string Protocol { get; set; }
        public string Body { get; set; }
        public string Raw { get; set; }

        public IDictionary<string, string> Headers
        {
            get {
                return theHeaders;
            }
        }
    }
}