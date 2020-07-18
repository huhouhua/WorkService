using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WorkService.Core.ObjectMapping;
using WorkService.Core.PlugIns;
using IObjectMapper = WorkService.Core.ObjectMapping.IObjectMapper;

namespace WorkService.Core
{
    public class BootstrapperOptions
    {
        public PlugInSourceList PlugInSources { get; }

        internal IObjectMapper ObjectMapper { get; set; }

        public BootstrapperOptions() 
        {
            PlugInSources = new PlugInSourceList();
        }

        public IObjectMapper SetObjectMapper<TObjectMapper>(TObjectMapper objectMapper) where TObjectMapper : IObjectMapper
        {
            return ObjectMapper = objectMapper;
        }


       
    }
}
