using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Helpers_DataPassing.Helper
{
    [HtmlTargetElement(Attributes = "asp-active-route")]
    public class ActiveRouteTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var controller = ViewContext.RouteData.Values["Controller"].ToString();
            var action = ViewContext.RouteData.Values["Action"].ToString();

            var tagController = context.AllAttributes.FirstOrDefault(a => a.Name == "asp-controller").Value.ToString();
            var tagAction = context.AllAttributes.FirstOrDefault(a => a.Name == "asp-action").Value.ToString();

            if (controller == tagController && action == tagAction)
            {
                var existingclasses = context.AllAttributes.FirstOrDefault(a => a.Name == "class").Value.ToString();
                var activeClass = context.AllAttributes.FirstOrDefault(a => a.Name == "asp-active-route").Value.ToString();

                //output.Attributes.SetAttribute("class", existingclasses + " " + activeClass);
                output.Attributes.SetAttribute("class", $"{existingclasses} {activeClass}");
            }
        }
    }
}
