#pragma checksum "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0cec3b75052c8ec4574b9bb42087e61edaba9320"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\_ViewImports.cshtml"
using Crowdfunding;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\_ViewImports.cshtml"
using Crowdfunding.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cec3b75052c8ec4574b9bb42087e61edaba9320", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"060d498455253c5b0433d2303c85a8644b65162d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Crowdfunding.Controllers.ViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/main_page.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0cec3b75052c8ec4574b9bb42087e61edaba93203985", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-3\">Welcome</h1>        \r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <div class=\"text-center\">\r\n            <h1 class=\"display-4\"> The newest </h1>\r\n        </div>\r\n");
#nullable restore
#line 15 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
         foreach(var comp in Model.topNew)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"container border company\" data-request-url=\"");
#nullable restore
#line 17 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                                                               Write(Url.Action("Details", "Companies", new { id=comp.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <div class=\"row\"  >\r\n                    <div class=\"col-md-6\">\r\n                        <img");
            BeginWriteAttribute("src", " src=", 668, "", 707, 1);
#nullable restore
#line 20 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
WriteAttributeValue("", 673, comp.Images.FirstOrDefault().Link, 673, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"max-width:250px;height:140px; margin-bottom:1rem; margin-top:1rem;\">\r\n                    </div>\r\n                    <div class=\"col-md-6\">\r\n                        <p>");
#nullable restore
#line 23 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                      Write(comp.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p>");
#nullable restore
#line 24 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                      Write(comp.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p>");
#nullable restore
#line 25 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                      Write(comp.CurrentMoney);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 25 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                                           Write(comp.TargetMoney);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 26 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                         foreach(var tag in @comp.CompanyTags.ToList())
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span> ");
#nullable restore
#line 28 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                              Write(tag.Tag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 29 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                        }                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>            \r\n");
#nullable restore
#line 33 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"col-md-6\">\r\n        <div class=\"text-center\">\r\n            <h1 class=\"display-4\"> The best </h1>\r\n        </div>\r\n");
#nullable restore
#line 39 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
         foreach (var comp in Model.topRate)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"container border company\" data-request-url=\"");
#nullable restore
#line 41 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                                                               Write(Url.Action("Details", "Companies", new { id=comp.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-6\">\r\n");
            WriteLiteral("                    </div>\r\n                    <div class=\"col-md-6\">\r\n                        <p>");
#nullable restore
#line 47 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                      Write(comp.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p>");
#nullable restore
#line 48 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                      Write(comp.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p>");
#nullable restore
#line 49 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                      Write(comp.CurrentMoney);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 49 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                                           Write(comp.TargetMoney);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 50 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                         foreach (var tag in @comp.CompanyTags.ToList())
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span> ");
#nullable restore
#line 52 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                              Write(tag.Tag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 53 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 57 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(" \r\n\r\n<script>\r\n    $(\".company\").on(\"click\", function () {\r\n        window.location.href = $(this).attr(\"data-request-url\");\r\n    })\r\n</script>\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Crowdfunding.Controllers.ViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
