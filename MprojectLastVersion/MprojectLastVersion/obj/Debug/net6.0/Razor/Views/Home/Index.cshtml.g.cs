#pragma checksum "C:\Users\deniz\OneDrive\Masaüstü\MprojectLastVersion\MprojectLastVersion\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11e3f0165c10c0f980798ed713d399400abc3512"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\deniz\OneDrive\Masaüstü\MprojectLastVersion\MprojectLastVersion\Views\_ViewImports.cshtml"
using MprojectLastVersion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\deniz\OneDrive\Masaüstü\MprojectLastVersion\MprojectLastVersion\Views\_ViewImports.cshtml"
using MprojectLastVersion.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11e3f0165c10c0f980798ed713d399400abc3512", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fae1bf054f9abdbb8481f5e0c8f07e46c1335699", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\deniz\OneDrive\Masaüstü\MprojectLastVersion\MprojectLastVersion\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n   ");
#nullable restore
#line 7 "C:\Users\deniz\OneDrive\Masaüstü\MprojectLastVersion\MprojectLastVersion\Views\Home\Index.cshtml"
Write(Html.ActionLink("MainPage", "MainPage"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n   ");
#nullable restore
#line 8 "C:\Users\deniz\OneDrive\Masaüstü\MprojectLastVersion\MprojectLastVersion\Views\Home\Index.cshtml"
Write(Html.ActionLink("LogIn", "LogIn"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n   ");
#nullable restore
#line 9 "C:\Users\deniz\OneDrive\Masaüstü\MprojectLastVersion\MprojectLastVersion\Views\Home\Index.cshtml"
Write(Html.ActionLink("KayitOl", "KayitOl"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
