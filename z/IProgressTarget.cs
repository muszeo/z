/*============================================================================

  Copyright (C) Martin Hunter

============================================================================*/

#region Usings
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
#endregion

namespace Z
{
    public interface IProgressTarget
    {
        void NewLine ();
        void Report (string message);
    }
}