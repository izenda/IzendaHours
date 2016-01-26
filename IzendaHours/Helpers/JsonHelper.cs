using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IzendaHours.Helpers
{
    public static class JsonHelper
    {
        public static IHtmlString ToJson(this HtmlHelper helper, object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            settings.Converters.Add(new JavaScriptDateTimeConverter());
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var helpmefixit = helper.Raw(JsonConvert.SerializeObject(obj, settings));
            return helper.Raw(JsonConvert.SerializeObject(obj, settings));
        }
    }
}