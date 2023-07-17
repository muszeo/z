/*============================================================================

  Copyright (C) Martin Hunter

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

                _h.Execute (_file);

                break;
            }
        }
    }

    // Write Footer.
    _h.Footer ();

} catch (Exception __x) {
    Console.WriteLine (
        $"{__x.Message}\n"
    );
}