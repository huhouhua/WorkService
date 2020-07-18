using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using WorkService.Core.ObjectMapping;
using WorkService.Core.PlugIns;

namespace WorkService.Core
{
    public class Bootstrapper
    {
        public PlugInSourceList PlugInSources { get; }

        internal IObjectMapper ObjectMapper { get; set; }

        private Bootstrapper([CanBeNull] Action<BootstrapperOptions> optionsAction = null)
        {
            var options = new BootstrapperOptions();

            optionsAction?.Invoke(options);

            PlugInSources = options.PlugInSources;

            ObjectMapper = options.ObjectMapper;

        }

        public static Bootstrapper Create([CanBeNull] Action<BootstrapperOptions> optionsAction = null)
        {
            return new Bootstrapper(optionsAction);
        }


    }
}
