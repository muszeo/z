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
using Z;
using System;
using Z.Settings;
#endregion

try {

    // Create Harness.
    Harness _h = new Harness ();

    // Setup Cancel handler.
    Console.CancelKeyPress += new ConsoleCancelEventHandler (
        (_o, _a) => {
            _h.Cancel ();
        }
    );

    // Write Console Header.
    _h.Header ();

    // If no arguments, display help.
    if (args.Length == 0 || args.Contains (Constants.Commands.HELP)) {
        _h.Help ();
    }

    // Run Command.
    else if (args.Contains (Constants.Commands.RUN)) {

        for (int _j = 0; _j < args.Length; _j++) {

            if (args [_j].Equals (Constants.Commands.RUN)) {

                string _file = string.Empty;

                if (args.Length > _j + 1) {
                    _file = args [_j + 1];
                }

                if (args.Length > _j + 2 && args.Contains (Constants.Commands.GLOBAL)) {
                    _h.Globals (args);
                }

                if (_file.Equals (Constants.Commands.ALL)) {
                    _h.Execute ();
                } else {
                    _h.Execute (_file);
                }

                break;
            }
        }
    }

    // Spit out Help.
    else {
        _h.Help ();
    }

    // Write Footer.
    _h.Footer ();

    // Exit Code 0.
    Environment.Exit (0);

} catch (Exception __x) {
    Console.WriteLine (
        $"{__x.Message}\n"
    );

    // Exit Code 1.
    Environment.Exit (1);
}