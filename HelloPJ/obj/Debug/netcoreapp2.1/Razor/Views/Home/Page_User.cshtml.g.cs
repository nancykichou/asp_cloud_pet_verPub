#pragma checksum "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_User.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "140d8879b286be70c63e6f9a96eb2010a6f35c81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Page_User), @"mvc.1.0.view", @"/Views/Home/Page_User.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Page_User.cshtml", typeof(AspNetCore.Views_Home_Page_User))]
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
#line 1 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\_ViewImports.cshtml"
using HelloPJ;

#line default
#line hidden
#line 2 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\_ViewImports.cshtml"
using HelloPJ.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"140d8879b286be70c63e6f9a96eb2010a6f35c81", @"/Views/Home/Page_User.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eac916a491e926652c28678adc4231d99216f0e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Page_User : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_User.cshtml"
  
    ViewData["Title"] = "使用者資訊";

#line default
#line hidden
            BeginContext(41, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(46, 17, false);
#line 4 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_User.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(63, 11, true);
            WriteLiteral("</h2>\r\n<h3>");
            EndContext();
            BeginContext(75, 19, false);
#line 5 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_User.cshtml"
Write(ViewData["user_id"]);

#line default
#line hidden
            EndContext();
            BeginContext(94, 66, true);
            WriteLiteral("</h3>\r\n\r\n<p>Use this area to provide additional information.</p>\r\n");
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