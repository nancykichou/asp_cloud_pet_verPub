#pragma checksum "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b18c0e6b7fb3013a76209a60eb676bb49546a8e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index_Registration), @"mvc.1.0.view", @"/Views/Home/Index_Registration.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index_Registration.cshtml", typeof(AspNetCore.Views_Home_Index_Registration))]
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
#line 1 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\_ViewImports.cshtml"
using HelloPJ;

#line default
#line hidden
#line 2 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\_ViewImports.cshtml"
using HelloPJ.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b18c0e6b7fb3013a76209a60eb676bb49546a8e4", @"/Views/Home/Index_Registration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eac916a491e926652c28678adc4231d99216f0e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index_Registration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HelloPJ.Models.Account>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
  
    ViewData["Title"] = "註冊頁";

#line default
#line hidden
            BeginContext(70, 182, true);
            WriteLiteral("<div class=\"text-center main-context\">\r\n    <h1 style=\"color: #3caa1e;padding:1rem;font-weight:500 ;font-size: 1.5rem; font-family: Noto Sans TC;\" class=\"display-4\">除了撸貓，還要註冊喔</h1>\r\n");
            EndContext();
#line 7 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
     using (Html.BeginForm("Index_Registration", "Home", FormMethod.Post, new { @style = "float:right;margin:5rem;margin-top:3rem;margin-right:15rem;" ,enctype = "multipart/form-data"}))
    {
        

#line default
#line hidden
            BeginContext(456, 23, false);
#line 9 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(490, 41, false);
#line 10 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
   Write(Html.ValidationSummary(true, "", new { }));

#line default
#line hidden
            EndContext();
            BeginContext(535, 31, true);
            WriteLiteral("<table>\r\n    <tr>\r\n        <td>");
            EndContext();
            BeginContext(567, 164, false);
#line 14 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
       Write(Html.LabelFor(model => model.user_name, new { @style = "margin:1rem;line-height:2rem;color:#3caa1e;font-weight:500 ;font-size: 1.5rem;font-family: Noto Sans TC;" }));

#line default
#line hidden
            EndContext();
            BeginContext(731, 33, true);
            WriteLiteral("</td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(765, 114, false);
#line 16 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
       Write(Html.TextBoxFor(model => model.user_name, new { @style = "margin-top:1rem;margin-bottom:1rem;line-height:2rem;" }));

#line default
#line hidden
            EndContext();
            BeginContext(879, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(894, 128, false);
#line 17 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
       Write(Html.ValidationMessageFor(model => model.user_name, "", new { @style = "margin-top:1rem;margin-bottom:1rem;line-height:2rem;" }));

#line default
#line hidden
            EndContext();
            BeginContext(1022, 50, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n    <tr>\r\n        <td>");
            EndContext();
            BeginContext(1073, 166, false);
#line 21 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
       Write(Html.LabelFor(model => model.user_passwd, new { @style = "margin:1rem;line-height:2rem;color:#3caa1e;font-weight:500 ;font-size: 1.5rem;font-family: Noto Sans TC;" }));

#line default
#line hidden
            EndContext();
            BeginContext(1239, 33, true);
            WriteLiteral("</td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1273, 135, false);
#line 23 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
       Write(Html.TextBoxFor(model => model.user_passwd, new { @style = "margin-top:1rem;margin-bottom:1rem;line-height:2rem;", Type = "password" }));

#line default
#line hidden
            EndContext();
            BeginContext(1408, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1423, 129, false);
#line 24 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
       Write(Html.ValidationMessageFor(model => model.user_passwd, "", new { @style = "margin-top:1rem;margin-bottom:1rem;line-height:2rem;"}));

#line default
#line hidden
            EndContext();
            BeginContext(1552, 50, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n    <tr>\r\n        <td>");
            EndContext();
            BeginContext(1603, 167, false);
#line 28 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
       Write(Html.LabelFor(model => model.account_name, new { @style = "margin:1rem;line-height:2rem;color:#3caa1e;font-weight:500 ;font-size: 1.5rem;font-family: Noto Sans TC;" }));

#line default
#line hidden
            EndContext();
            BeginContext(1770, 33, true);
            WriteLiteral("</td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1804, 117, false);
#line 30 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
       Write(Html.TextBoxFor(model => model.account_name, new { @style = "margin-top:1rem;margin-bottom:1rem;line-height:2rem;" }));

#line default
#line hidden
            EndContext();
            BeginContext(1921, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1936, 131, false);
#line 31 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
       Write(Html.ValidationMessageFor(model => model.account_name, "", new { @style = "margin-top:1rem;margin-bottom:1rem;line-height:2rem;" }));

#line default
#line hidden
            EndContext();
            BeginContext(2067, 526, true);
            WriteLiteral(@"
        </td>
    </tr>
    <tr>
        <td colspan=""2"">
            <input style=""padding:.5rem;margin-top:1rem;margin-bottom:1rem;line-height:2rem;width:15rem;margin-left:2rem;background-color: transparent;color:#3caa1e;font-weight:500 ;font-size: 1.5rem;font-family: Noto Sans TC;border:2px #3caa1e solid;border-radius:1rem;"" type=""submit"" value=""資料送出"">
        </td>
    </tr>
    <tr>
        <td colspan=""2"">
            <p style=""color:#ED1E79;font-weight:500 ;font-size: 1.5rem;font-family: Noto Sans TC;"">");
            EndContext();
            BeginContext(2594, 25, false);
#line 41 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
                                                                                              Write(ViewData["index_message"]);

#line default
#line hidden
            EndContext();
            BeginContext(2619, 42, true);
            WriteLiteral("</p>\r\n        </td>\r\n    </tr>\r\n</table>\r\n");
            EndContext();
#line 45 "C:\Users\user\Desktop\HelloCat\HelloPJ\Views\Home\Index_Registration.cshtml"
    }

#line default
#line hidden
            BeginContext(2668, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HelloPJ.Models.Account> Html { get; private set; }
    }
}
#pragma warning restore 1591
