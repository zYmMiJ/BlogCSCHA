#pragma checksum "C:\Users\Nassim\source\repos\BlogCSCHA\Blog\Views\Home\Post.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae5f93add6f390025d69399031e381ca673fe515"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Post), @"mvc.1.0.view", @"/Views/Home/Post.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Post.cshtml", typeof(AspNetCore.Views_Home_Post))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Nassim\source\repos\BlogCSCHA\Blog\Views\_ViewImports.cshtml"
using Blog.Models;

#line default
#line hidden
#line 2 "C:\Users\Nassim\source\repos\BlogCSCHA\Blog\Views\_ViewImports.cshtml"
using Blog.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae5f93add6f390025d69399031e381ca673fe515", @"/Views/Home/Post.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c1dd89ee945937e85fe2e65d1d46d865d868a6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Post : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Post>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 65, true);
            WriteLiteral("\r\n\r\n\r\n<div class=\"container\">\r\n    <div class=\"post no-shadow\">\r\n");
            EndContext();
#line 10 "C:\Users\Nassim\source\repos\BlogCSCHA\Blog\Views\Home\Post.cshtml"
         if (!String.IsNullOrEmpty(Model.Image))
        {
            var image_path = $"/Image/{Model.Image}";

#line default
#line hidden
            BeginContext(203, 16, true);
            WriteLiteral("            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 219, "\"", 236, 1);
#line 13 "C:\Users\Nassim\source\repos\BlogCSCHA\Blog\Views\Home\Post.cshtml"
WriteAttributeValue("", 225, image_path, 225, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(237, 37, true);
            WriteLiteral(" />\r\n            <span class=\"title\">");
            EndContext();
            BeginContext(275, 11, false);
#line 14 "C:\Users\Nassim\source\repos\BlogCSCHA\Blog\Views\Home\Post.cshtml"
                           Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(286, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 15 "C:\Users\Nassim\source\repos\BlogCSCHA\Blog\Views\Home\Post.cshtml"
        }

#line default
#line hidden
            BeginContext(306, 49, true);
            WriteLiteral("    </div>\r\n    <div class=\"post-body\">\r\n        ");
            EndContext();
            BeginContext(356, 10, false);
#line 18 "C:\Users\Nassim\source\repos\BlogCSCHA\Blog\Views\Home\Post.cshtml"
   Write(Model.Body);

#line default
#line hidden
            EndContext();
            BeginContext(366, 20, true);
            WriteLiteral("\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Post> Html { get; private set; }
    }
}
#pragma warning restore 1591
