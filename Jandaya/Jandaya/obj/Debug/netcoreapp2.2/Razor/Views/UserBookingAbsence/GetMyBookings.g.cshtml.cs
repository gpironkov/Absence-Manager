#pragma checksum "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "700851ff710f6d033e564c097e886606aeb494c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserBookingAbsence_GetMyBookings), @"mvc.1.0.view", @"/Views/UserBookingAbsence/GetMyBookings.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UserBookingAbsence/GetMyBookings.cshtml", typeof(AspNetCore.Views_UserBookingAbsence_GetMyBookings))]
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
#line 1 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\_ViewImports.cshtml"
using Jandaya;

#line default
#line hidden
#line 2 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\_ViewImports.cshtml"
using Jandaya.Models;

#line default
#line hidden
#line 1 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml"
using Jandaya.Common;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"700851ff710f6d033e564c097e886606aeb494c8", @"/Views/UserBookingAbsence/GetMyBookings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73823b391e7e6d035f06cb5e07b335051a8142a9", @"/Views/_ViewImports.cshtml")]
    public class Views_UserBookingAbsence_GetMyBookings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Jandaya.Models.BookingsAllViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/paging.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/search.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bootstrap-sortable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 3 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(127, 668, true);
            WriteLiteral(@"
<div class=""text-center"">
    <h1 id=""title"" class=""text-center"">My Bookings</h1>
    <div class=""table-responsive"">
        <table class=""table table-striped table-bordered sortable"" cellspacing=""0"" width=""100%"" id=""table-id"">
            <thead>
                <tr>
                    <th scope=""col"">Username</th>
                    <th scope=""col"">Booking Type</th>
                    <th scope=""col"">Start Date</th>
                    <th scope=""col"">End Date</th>
                    <th scope=""col"">Duration</th>
                    <th scope=""col"">Status</th>
                </tr>
            </thead>
            <tbody id=""userTable"">
");
            EndContext();
#line 22 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml"
                 for (int i = 0; i < Model.Count; i++)
                {

#line default
#line hidden
            BeginContext(870, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(925, 17, false);
#line 25 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml"
                       Write(Model[i].UserName);

#line default
#line hidden
            EndContext();
            BeginContext(942, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(978, 20, false);
#line 26 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml"
                       Write(Model[i].BookingType);

#line default
#line hidden
            EndContext();
            BeginContext(998, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1034, 41, false);
#line 27 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml"
                       Write(Model[i].StartDate.ToString("dd.MM.yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1075, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1111, 39, false);
#line 28 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml"
                       Write(Model[i].EndDate.ToString("dd.MM.yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1150, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1186, 17, false);
#line 29 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml"
                       Write(Model[i].Duration);

#line default
#line hidden
            EndContext();
            BeginContext(1203, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1239, 15, false);
#line 30 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml"
                       Write(Model[i].Status);

#line default
#line hidden
            EndContext();
            BeginContext(1254, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 32 "C:\Users\Lenovo\Desktop\Georgi\Jandaya 3\Absence-Manager\Jandaya\Jandaya\Views\UserBookingAbsence\GetMyBookings.cshtml"
                }

#line default
#line hidden
            BeginContext(1307, 62, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1386, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1392, 61, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "700851ff710f6d033e564c097e886606aeb494c89445", async() => {
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
                EndContext();
                BeginContext(1453, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1459, 61, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "700851ff710f6d033e564c097e886606aeb494c810787", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1520, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1526, 73, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "700851ff710f6d033e564c097e886606aeb494c812130", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1599, 2, true);
                WriteLiteral("\r\n");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Jandaya.Models.BookingsAllViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
