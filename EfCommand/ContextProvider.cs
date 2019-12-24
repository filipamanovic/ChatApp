using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommand
{
    public abstract class ContextProvider
    {
        protected readonly Context Context;

        protected ContextProvider(Context context)
        {
            Context = context;
        }
    }
}
