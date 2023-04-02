using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace System
{
    public static class ObjetoToJson
    {
        public static string ConverterJson(this object objeto)
        {
            return JsonConvert.SerializeObject(objeto, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }


    }
}
