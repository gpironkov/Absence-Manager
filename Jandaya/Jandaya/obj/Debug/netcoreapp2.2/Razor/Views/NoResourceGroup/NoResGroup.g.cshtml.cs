#pragma checksum "C:\Users\gpironkov\Desktop\Georgi\proj2\Absence-Manager\Jandaya\Jandaya\Views\NoResourceGroup\NoResGroup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "178842c1a82a23888c09cb993c1508dbc611e7f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NoResourceGroup_NoResGroup), @"mvc.1.0.view", @"/Views/NoResourceGroup/NoResGroup.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/NoResourceGroup/NoResGroup.cshtml", typeof(AspNetCore.Views_NoResourceGroup_NoResGroup))]
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
#line 1 "C:\Users\gpironkov\Desktop\Georgi\proj2\Absence-Manager\Jandaya\Jandaya\Views\_ViewImports.cshtml"
using Jandaya;

#line default
#line hidden
#line 2 "C:\Users\gpironkov\Desktop\Georgi\proj2\Absence-Manager\Jandaya\Jandaya\Views\_ViewImports.cshtml"
using Jandaya.Models;

#line default
#line hidden
#line 1 "C:\Users\gpironkov\Desktop\Georgi\proj2\Absence-Manager\Jandaya\Jandaya\Views\NoResourceGroup\NoResGroup.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\gpironkov\Desktop\Georgi\proj2\Absence-Manager\Jandaya\Jandaya\Views\NoResourceGroup\NoResGroup.cshtml"
using Jandaya.Data.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"178842c1a82a23888c09cb993c1508dbc611e7f4", @"/Views/NoResourceGroup/NoResGroup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73823b391e7e6d035f06cb5e07b335051a8142a9", @"/Views/_ViewImports.cshtml")]
    public class Views_NoResourceGroup_NoResGroup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\gpironkov\Desktop\Georgi\proj2\Absence-Manager\Jandaya\Jandaya\Views\NoResourceGroup\NoResGroup.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "No Resource Group";

#line default
#line hidden
            BeginContext(166, 55, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h3 class=\"display-4\">");
            EndContext();
            BeginContext(222, 18, false);
#line 9 "C:\Users\gpironkov\Desktop\Georgi\proj2\Absence-Manager\Jandaya\Jandaya\Views\NoResourceGroup\NoResGroup.cshtml"
                     Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(240, 163, true);
            WriteLiteral(", you have no resource group (department) set in the system yet.</h3>\r\n    <br />\r\n    <h3 class=\"display-5\">The administrator will take care of it!</h3>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591