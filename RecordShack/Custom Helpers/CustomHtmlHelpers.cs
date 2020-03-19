using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecordShack.Custom_Helpers
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlString Image(this HtmlHelper helper, string src, string alt, string width, string height, string cssclass)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            tb.Attributes.Add("width", width);
            tb.Attributes.Add("height", height);
            tb.Attributes.Add("class", cssclass);
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}