#pragma checksum "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21c7508c44b1e1eb0032e791f21d6eedc6cc3227"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Lastadded), @"mvc.1.0.view", @"/Views/Home/Lastadded.cshtml")]
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
#nullable restore
#line 1 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\_ViewImports.cshtml"
using web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\_ViewImports.cshtml"
using web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\_ViewImports.cshtml"
using data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\_ViewImports.cshtml"
using web.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21c7508c44b1e1eb0032e791f21d6eedc6cc3227", @"/Views/Home/Lastadded.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e319c1abdc92a5528feb15d2fa33000e4f410bef", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Lastadded : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Post>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "postlist", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
  
    ViewData["Title"] = "Son eklenenler";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"col-12 m-0 text-center p-5 \">\r\n    <h1 class=\"fw-light\">Son eklenenler</h1>\r\n</section>\r\n<section class=\"col-12 bg-white py-3\">\r\n    <div class=\"album\">\r\n        <div class=\"row row-cols-4 g-3\">\r\n");
#nullable restore
#line 12 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
             foreach (var post in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col\">\r\n                    <div class=\"card h-100 shadow-sm\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 457, "\"", 505, 4);
            WriteAttributeValue("", 464, "/", 464, 1, true);
#nullable restore
#line 16 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
WriteAttributeValue("", 465, post.Category.CategoryUrl, 465, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 491, "/", 491, 1, true);
#nullable restore
#line 16 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
WriteAttributeValue("", 492, post.PostUrl, 492, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "21c7508c44b1e1eb0032e791f21d6eedc6cc32276944", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 547, "~/images/post/", 547, 14, true);
#nullable restore
#line 17 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
AddHtmlAttributeValue("", 561, post.PostImg, 561, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </a>\r\n                        <div class=\"card-body text-black\">\r\n                            <h6 class=\"card-title fw-bold\">");
#nullable restore
#line 20 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
                                                      Write(post.PostTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                            <p class=\"card-text\">\r\n                                <small>\r\n                                    ");
#nullable restore
#line 23 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
                                Write(post.PostSummary.Count()>100?post.PostSummary.Substring(0,100)+"...":post.PostSummary);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </small>\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"card-footer d-flex justify-content-between\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21c7508c44b1e1eb0032e791f21d6eedc6cc32279602", async() => {
                WriteLiteral("\r\n                                <small>");
#nullable restore
#line 30 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
                                  Write(post.Category.CategoryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</small>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-categoryurl", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
                                       WriteLiteral(post.Category.CategoryUrl);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["categoryurl"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-categoryurl", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["categoryurl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <small class=\"text-muted\">");
#nullable restore
#line 32 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
                                                 Write(post.PostDate.ToString("dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                        </div>\r\n\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 37 "C:\Users\selçuk\Desktop\Mvc\SözlerWeb\web\Views\Home\Lastadded.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Post>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591