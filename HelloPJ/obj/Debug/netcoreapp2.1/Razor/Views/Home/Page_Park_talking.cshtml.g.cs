#pragma checksum "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b617b6f6bba5e44486d04a1ab0b086c2de0c8b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Page_Park_talking), @"mvc.1.0.view", @"/Views/Home/Page_Park_talking.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Page_Park_talking.cshtml", typeof(AspNetCore.Views_Home_Page_Park_talking))]
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
#line 1 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml"
using HelloPJ.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b617b6f6bba5e44486d04a1ab0b086c2de0c8b0", @"/Views/Home/Page_Park_talking.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eac916a491e926652c28678adc4231d99216f0e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Page_Park_talking : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HelloPJ.Models.Message>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml"
  
    ViewData["Title"] = "ParkTalking";
    Message mm = new Message();
    string main_user = ViewData["user_id"].ToString();
    string userName = ViewData["account_name"].ToString();
    List<Message> message_list = (List<Message>)ViewData["message_list"];

#line default
#line hidden
            BeginContext(325, 23, true);
            WriteLiteral("<ul class=\"messages\">\r\n");
            EndContext();
#line 11 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml"
     if (message_list != null)
    {
        foreach (var user in message_list)
        {
            if (user.user_id.ToString() == main_user)
            {

#line default
#line hidden
            BeginContext(512, 93, true);
            WriteLiteral("                <li class=\"message right appeared\">\r\n                    <div class=\"avatar\">");
            EndContext();
            BeginContext(606, 17, false);
#line 18 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml"
                                   Write(user.account_name);

#line default
#line hidden
            EndContext();
            BeginContext(623, 98, true);
            WriteLiteral("</div>\r\n                    <div class=\"text_wrapper\">\r\n                        <div class=\"text\">");
            EndContext();
            BeginContext(722, 12, false);
#line 20 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml"
                                     Write(user.message);

#line default
#line hidden
            EndContext();
            BeginContext(734, 59, true);
            WriteLiteral("</div>\r\n                    </div>\r\n                </li>\r\n");
            EndContext();
#line 23 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(841, 92, true);
            WriteLiteral("                <li class=\"message left appeared\">\r\n                    <div class=\"avatar\">");
            EndContext();
            BeginContext(934, 17, false);
#line 27 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml"
                                   Write(user.account_name);

#line default
#line hidden
            EndContext();
            BeginContext(951, 98, true);
            WriteLiteral("</div>\r\n                    <div class=\"text_wrapper\">\r\n                        <div class=\"text\">");
            EndContext();
            BeginContext(1050, 12, false);
#line 29 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml"
                                     Write(user.message);

#line default
#line hidden
            EndContext();
            BeginContext(1062, 59, true);
            WriteLiteral("</div>\r\n                    </div>\r\n                </li>\r\n");
            EndContext();
#line 32 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml"
            }
        }
    }
    else
    {

#line default
#line hidden
            BeginContext(1171, 142, true);
            WriteLiteral("        <li>\r\n            <div class=\"text_wrapper\">\r\n                <div class=\"text\">目前還沒有任何訊息!!</div>\r\n            </div>\r\n        </li>\r\n");
            EndContext();
#line 42 "D:\DOWNLOAD\HelloPJ_23nancy\HelloPJ\Views\Home\Page_Park_talking.cshtml"
    }

#line default
#line hidden
            BeginContext(1320, 7, true);
            WriteLiteral("</ul>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HelloPJ.Models.Message> Html { get; private set; }
    }
}
#pragma warning restore 1591