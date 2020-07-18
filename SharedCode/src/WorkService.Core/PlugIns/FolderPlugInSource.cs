using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using WorkService.Core.Reflection;

namespace WorkService.Core.PlugIns
{
    public class FolderPlugInSource : IPlugInSource
    {
        public string Folder { get; }

        public SearchOption SearchOption { get; set; }

        private readonly Lazy<List<Assembly>> _assemblies;

        public FolderPlugInSource(string folder, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            Folder = folder;
            SearchOption = searchOption;

            _assemblies = new Lazy<List<Assembly>>(LoadAssemblies, true);
        }

        public IList<Assembly> GetAssemblies()
        {
            return _assemblies.Value;
        }

       

        private List<Assembly> LoadAssemblies()
        {
            return AssemblyHelper.GetDLLAssemblys(Folder, SearchOption).ToList();
        }


    }
}
