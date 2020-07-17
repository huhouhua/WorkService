using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Xunit;

namespace WorkService.Core.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var me = typeof(DA).GetMethod("Das");
            ParameterInfo[] parameters = me.GetParameters();

            foreach (var item in parameters)
            {
                var da = item;

            }

            me.Invoke(Activator.CreateInstance(typeof(DA)), new string[] {"dadad" });
        

        }
    }


    public class DA 
    {

        public void Da() 
        {
            
        }

        public string Das(out string name, DA a,List<DA>? listD,int da,string www,object wwa)
        {
            name = "dada";

            return name;
        }

    }
}
