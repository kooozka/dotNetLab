#pragma checksum "C:\Users\ASUS\Desktop\infa\semestr5\dotNetLab\List8\List8\Views\Game\Game.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12f7af86dcc37a0b721fbd8d35994a5846ed4fa7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Game), @"mvc.1.0.view", @"/Views/Game/Game.cshtml")]
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
#line 1 "C:\Users\ASUS\Desktop\infa\semestr5\dotNetLab\List8\List8\Views\_ViewImports.cshtml"
using List8;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\infa\semestr5\dotNetLab\List8\List8\Views\_ViewImports.cshtml"
using List8.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12f7af86dcc37a0b721fbd8d35994a5846ed4fa7", @"/Views/Game/Game.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9afc5bb47f4ec886805ef397b9fd6bb60a0bffb", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Game : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ASUS\Desktop\infa\semestr5\dotNetLab\List8\List8\Views\Game\Game.cshtml"
  
    ViewBag.Title = "Game";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"header\">\r\n    SIMPLE GUESS GAME\r\n</div>\r\n<div");
            BeginWriteAttribute("class", " class=\"", 95, "\"", 120, 1);
#nullable restore
#line 8 "C:\Users\ASUS\Desktop\infa\semestr5\dotNetLab\List8\List8\Views\Game\Game.cshtml"
WriteAttributeValue("", 103, ViewBag.CssClass, 103, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 8 "C:\Users\ASUS\Desktop\infa\semestr5\dotNetLab\List8\List8\Views\Game\Game.cshtml"
                          Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
