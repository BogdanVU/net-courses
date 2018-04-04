﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Core.Abstractions
{
    public interface IProcessUserInput
    {
        IDrawingObject InputObject();
        void DeleteObjectFromBoard(IBoard board);
    }
}
