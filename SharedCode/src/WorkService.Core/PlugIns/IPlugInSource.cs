using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WorkService.Core.PlugIns
{
    public interface IPlugInSource
    {
        IList<Assembly> GetAssemblies();

    }
}
