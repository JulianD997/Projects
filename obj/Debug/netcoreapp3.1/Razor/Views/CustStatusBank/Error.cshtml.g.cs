#pragma checksum "P:\Practice\DotNetCaseStudyTeam1\Views\CustStatusBank\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66325b468dfa78dbb9d17d0f0d8dd0c0d4a94843"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CustStatusBank_Error), @"mvc.1.0.view", @"/Views/CustStatusBank/Error.cshtml")]
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
#line 1 "P:\Practice\DotNetCaseStudyTeam1\Views\_ViewImports.cshtml"
using TCSBanking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "P:\Practice\DotNetCaseStudyTeam1\Views\_ViewImports.cshtml"
using TCSBanking.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66325b468dfa78dbb9d17d0f0d8dd0c0d4a94843", @"/Views/CustStatusBank/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a29cc7b31f0c9663cff1c40f7e13f6ccc396508", @"/Views/_ViewImports.cshtml")]
    public class Views_CustStatusBank_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "P:\Practice\DotNetCaseStudyTeam1\Views\CustStatusBank\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Customer Status</h1>

<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">SSN ID</th>
            <th scope=""col"">Status</th>
            <th scope=""col"">Message</th>
            <th scope=""col"">Last Updated</th>
        </tr>
    </thead>
    <tbody>
        <tr><td>No Records Found!</td></tr>
    </tbody>
</table>");
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
