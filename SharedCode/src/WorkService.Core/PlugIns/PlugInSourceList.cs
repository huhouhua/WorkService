using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WorkService.Core.PlugIns
{
    public class PlugInSourceList : List<IPlugInSource>
    {
        public List<Assembly> GetAllAssemblies()
        {
            return this
                .SelectMany(pluginSource => pluginSource.GetAssemblies())
                .Distinct()
                .ToList();
        }
    }
}
