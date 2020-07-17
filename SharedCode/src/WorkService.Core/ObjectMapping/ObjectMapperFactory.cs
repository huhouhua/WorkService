using System;
using System.Collections.Generic;
using System.Text;

namespace WorkService.Core.ObjectMapping
{
    public class ObjectMapperFactory
    {
        private static IObjectMapper _objectMapper { get; set; }
        public static void SetObjectMapper(IObjectMapper objectMapper)
        {
            _objectMapper = objectMapper;
        }
        public static IObjectMapper GetObjectMapper()
        {
            return _objectMapper;
        }
    }
}
