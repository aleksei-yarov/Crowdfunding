#pragma checksum "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\GetRoles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c30f640ba2586c93c0adadb9e30f7416145227ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_GetRoles), @"mvc.1.0.view", @"/Views/Admin/GetRoles.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c30f640ba2586c93c0adadb9e30f7416145227ff", @"/Views/Admin/GetRoles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"060d498455253c5b0433d2303c85a8644b65162d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_GetRoles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\GetRoles.cshtml"
  
    ViewData["Title"] = "GetRoles";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>GetRoles</h1>\r\n<p>");
#nullable restore
#line 7 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\GetRoles.cshtml"
Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" get role Admin</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
