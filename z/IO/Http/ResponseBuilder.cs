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
using System.Net;
using System.Text;
#endregion

namespace Z.IO.Http
{
    public static class ResponseBuilder
    {
        public static Response From (this Response dto, HttpWebResponse model, string raw)
        {
            if (model != null) {
                dto.StatusCode = model.StatusCode.ToString ();
                dto.StatusDescription = model.StatusDescription;
                dto.Body = raw;
                dto.ContentType = model.ContentType;
                dto.ContentEncoding = model.ContentEncoding;
                dto.ContentLength = model.ContentLength.ToString ();
                dto.Protocol = model.ProtocolVersion.ToString ();
                dto.Raw = raw;
                foreach (string _k in model.Headers.AllKeys) {
                    dto.Headers.Add (
                        _k,
                        model.Headers [_k]
                    );
                }

            } else {
                dto = null;
            }
            return dto;
        }
    }
}