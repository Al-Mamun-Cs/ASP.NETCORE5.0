#pragma checksum "E:\11.01.21Core_Final_Project\coreFinalProject\TestProjectIsDB\TestProjectIsDB\Views\AccountType\AccountList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0fa69e08b622e16da755ee24047a6225803b13b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AccountType_AccountList), @"mvc.1.0.view", @"/Views/AccountType/AccountList.cshtml")]
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
#line 1 "E:\11.01.21Core_Final_Project\coreFinalProject\TestProjectIsDB\TestProjectIsDB\Views\_ViewImports.cshtml"
using TestProjectIsDB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\11.01.21Core_Final_Project\coreFinalProject\TestProjectIsDB\TestProjectIsDB\Views\_ViewImports.cshtml"
using TestProjectIsDB.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fa69e08b622e16da755ee24047a6225803b13b8", @"/Views/AccountType/AccountList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdd576d6fcae38d29f7e64c1db1f9acdea07afe4", @"/Views/_ViewImports.cshtml")]
    public class Views_AccountType_AccountList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TestProjectIsDB.Models.Classes.AccountType>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-family:Arial;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\11.01.21Core_Final_Project\coreFinalProject\TestProjectIsDB\TestProjectIsDB\Views\AccountType\AccountList.cshtml"
  
    ViewData["Title"] = "Account List";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 style=\"font-family:Algerian; text-align:center; color:cornflowerblue;\">Account List</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fa69e08b622e16da755ee24047a6225803b13b84313", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\" style=\"background-color:lavenderblush\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                AccountType Id ");
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Account Name\r\n");
            WriteLiteral("            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 27 "E:\11.01.21Core_Final_Project\coreFinalProject\TestProjectIsDB\TestProjectIsDB\Views\AccountType\AccountList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 31 "E:\11.01.21Core_Final_Project\coreFinalProject\TestProjectIsDB\TestProjectIsDB\Views\AccountType\AccountList.cshtml"
               Write(Html.DisplayFor(modelItem => item.AccountTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "E:\11.01.21Core_Final_Project\coreFinalProject\TestProjectIsDB\TestProjectIsDB\Views\AccountType\AccountList.cshtml"
               Write(Html.DisplayFor(modelItem => item.AccountName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 37 "E:\11.01.21Core_Final_Project\coreFinalProject\TestProjectIsDB\TestProjectIsDB\Views\AccountType\AccountList.cshtml"
               Write(Html.ActionLink("Edit", "EditAccount", new { id = item.AccountTypeId }, htmlAttributes: new { @class = "btn btn-primary", @role = "button" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 38 "E:\11.01.21Core_Final_Project\coreFinalProject\TestProjectIsDB\TestProjectIsDB\Views\AccountType\AccountList.cshtml"
               Write(Html.ActionLink("Delete", "DeleteAccount", new { id = item.AccountTypeId }, htmlAttributes: new { @class = "btn btn-danger", @role = "button" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 41 "E:\11.01.21Core_Final_Project\coreFinalProject\TestProjectIsDB\TestProjectIsDB\Views\AccountType\AccountList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TestProjectIsDB.Models.Classes.AccountType>> Html { get; private set; }
    }
}
#pragma warning restore 1591
