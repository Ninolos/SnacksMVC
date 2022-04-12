using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SnackMVC.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Adress { get; set; }
        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Adress);
            output.Content.SetContent(Content);
        }
    }
}
