#pragma checksum "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d24817eaed41705a53155e53a95ea52f3198b2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d24817eaed41705a53155e53a95ea52f3198b2f", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"060d498455253c5b0433d2303c85a8644b65162d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Crowdfunding.Models.CustomUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/table_active.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4d24817eaed41705a53155e53a95ea52f3198b2f3999", async() => {
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
            WriteLiteral(@"
<h1>Admin</h1>

<table class=""table"" id=""table"">
    <tr>
        <th>
            <input type=""button"" class=""btn btn-sm btn-primary"" value=""Block"" id=""Block"" />
            <input type=""button"" class=""btn btn-sm btn-primary"" value=""Unblock"" id=""Unblock"" />
            <input type=""button"" class=""btn btn-sm btn-primary"" value=""Admin"" id=""SetAdmin"" />
            <input type=""button"" class=""btn btn-sm btn-primary"" value=""Remove Admin"" id=""RemoveAdmin"" />
            <input type=""button"" class=""btn btn-sm btn-primary"" value=""Delete"" id=""Delete"" />
        </th>
    </tr>
    <tr>
        <th><input type=""checkbox"" id=""mainCheckbox"">Login</th>
        <th>Email</th>
        <th>RegistrDate</th>
        <th>Role</th>
        <th>Lockout</th>

    </tr>
");
#nullable restore
#line 26 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
     foreach (var user in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr class=\"User\"");
            BeginWriteAttribute("value", " value=", 995, "", 1010, 1);
#nullable restore
#line 28 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
WriteAttributeValue("", 1002, user.Id, 1002, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <td> ");
#nullable restore
#line 29 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
            Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n            <td>");
#nullable restore
#line 30 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
           Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 31 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
           Write(user.RegistrDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 32 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
             if (ViewBag.Admin.IndexOf(user) != -1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>Admin</td>\r\n");
#nullable restore
#line 35 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>User</td>\r\n");
#nullable restore
#line 39 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
             if (user.LockoutEnd == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td> </td>\r\n");
#nullable restore
#line 43 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>BLOCKED </td>\r\n");
#nullable restore
#line 47 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 49 "C:\Users\Галицкая Ангелина\source\repos\Crowdfunding\Views\Admin\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        ""use strict"";

        let mainCheckbox = document.getElementById(""mainCheckbox"");
        mainCheckbox.addEventListener(""click"", function () {
            let rows = document.querySelectorAll(""tr.User"");
            for (let row of rows) {
                if (mainCheckbox.checked) {
                    row.classList.add(""selectedRow"");
                }
                else {
                    row.classList.remove(""selectedRow"");
                }
            }
        });

        function buttonAction(event) {
            let selectedUser = document.getElementsByClassName(""selectedRow"");
            let url = ""/Admin/"" + event.target.getAttribute(""Id"");
            for (let elem of selectedUser) {
                url += ""/"" + elem.getAttribute(""value"");
            }
            if (event.target.getAttribute(""Id"") == ""Delete"")
            {
                let isDelete = confirm(""Are you sure?"");
                if (isDelete == false) { return }
          ");
                WriteLiteral(@"  }
            window.location.href = url;
        }

        let buttonBlock = document.getElementById(""Block"");
        buttonBlock.addEventListener(""click"", buttonAction);

        let buttonUnblock = document.getElementById(""Unblock"");
        buttonUnblock.addEventListener(""click"", buttonAction);

        let buttonDelete = document.getElementById(""Delete"");
        buttonDelete.addEventListener(""click"", buttonAction);

        let buttonAdmin = document.getElementById(""SetAdmin"");
        buttonAdmin.addEventListener(""click"", buttonAction);

        let buttonRemoveAdmin = document.getElementById(""RemoveAdmin"");
        buttonRemoveAdmin.addEventListener(""click"", buttonAction);

       

        $(""#table td"").on(""click"", function () {
            $(this).parent().toggleClass(""selectedRow"");
        })

        


    </script>
    
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Crowdfunding.Models.CustomUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
