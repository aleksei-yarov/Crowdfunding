#pragma checksum "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "385fead994230f78222f3032c0a698d3ef4b3787"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bonus_MyBonuses), @"mvc.1.0.view", @"/Views/Bonus/MyBonuses.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"385fead994230f78222f3032c0a698d3ef4b3787", @"/Views/Bonus/MyBonuses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"060d498455253c5b0433d2303c85a8644b65162d", @"/Views/_ViewImports.cshtml")]
    public class Views_Bonus_MyBonuses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CustomUserBonus>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Companies", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
  
    ViewData["Title"] = "My Bonuses";    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
           Write(Html.DisplayNameFor(model => model.Bonus.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
           Write(Html.DisplayNameFor(model => model.Bonus.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
           Write(Html.DisplayNameFor(model => model.Bonus.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
           Write(Html.DisplayNameFor(model => model.Bonus.Company.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n");
#nullable restore
#line 29 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
         foreach (var item in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
             for (int i = 0; i < item.Count; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 35 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Bonus.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 38 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Bonus.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 41 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Bonus.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 44 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
                         if (item.Bonus.Company != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "385fead994230f78222f3032c0a698d3ef4b37877321", async() => {
                WriteLiteral(" ");
#nullable restore
#line 46 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
                                                                                                                Write(item.Bonus.Company.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
                                                                                 WriteLiteral(item.Bonus.CompanyId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 47 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
                        }
                        else
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>company removed</span>\r\n");
#nullable restore
#line 52 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 56 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Bonus\MyBonuses.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CustomUserBonus>> Html { get; private set; }
    }
}
#pragma warning restore 1591
