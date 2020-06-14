using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Abc.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-category")]
        public int CurrentCategoryId { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='pagination'>");

            for (int i = 1; i <= PageCount; i++)
            {
                sb.AppendFormat("<li class='{0}'>", i == CurrentPage ? "active" : "");
                sb.AppendFormat("<a href='/product/index?page={0}&category={1}'>{2}</a>", i, CurrentCategoryId, i);
                sb.Append("</li>");           
            }
            output.Content.SetHtmlContent(sb.ToString());
            base.Process(context, output);
        }
    }
}
