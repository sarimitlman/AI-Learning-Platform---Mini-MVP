﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLAI
    {
        Task<string> GetResponseFromAI(string prompt);
    }

}
