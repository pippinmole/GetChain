#pragma checksum "C:\Users\icond\Documents\Coding\.NET Projects\GetChain\GetChain\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d51a49cb28a94e782c59b55a6072aec1e8dd60f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GetChain.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace GetChain.Pages
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
#line 1 "C:\Users\icond\Documents\Coding\.NET Projects\GetChain\GetChain\Pages\_ViewImports.cshtml"
using GetChain;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d51a49cb28a94e782c59b55a6072aec1e8dd60f", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b0c7536f55f1491e56fd972e435ee2a8bc9e58a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\icond\Documents\Coding\.NET Projects\GetChain\GetChain\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\" xmlns=\"http://www.w3.org/1999/html\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d51a49cb28a94e782c59b55a6072aec1e8dd60f3327", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 12 "C:\Users\icond\Documents\Coding\.NET Projects\GetChain\GetChain\Pages\Index.cshtml"
Write(await Html.PartialAsync("Partials/_TopIncludes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <title>.</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d51a49cb28a94e782c59b55a6072aec1e8dd60f4586", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 18 "C:\Users\icond\Documents\Coding\.NET Projects\GetChain\GetChain\Pages\Index.cshtml"
Write(await Html.PartialAsync("Partials/_Navbar"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

<div class=""w-100"" style=""background-color:#0047FF; height: 500px; opacity: 77%; color: white"">
    <div class=""w-50 m-auto text-center"" style=""padding-top: 150px"">
        <h2 class=""font-weight-bold"">Bringing together your portfolio</h2>
            
        <p class=""lead mb-5"">Track your tokens on the Binance Smart Chain, Ethereum Network any many more with this easy-to-use website!</p>
        
        <a href=""/signup""><button class=""btn btn-light font-weight-bold"" style=""color:#0047FF; padding: 11px 35px"">Get Started</button></a>
    </div>
</div>

<div class=""w-100"">
    <div class=""text-center py-5"" style=""box-shadow: inset 0 4px 4px rgba(0, 0, 0, 0.25);""> ");
                WriteLiteral("\r\n        <img src=\"https://www.peacockcoin.finance/assets/images/binance-smart.png\" width=\"200px\" style=\"margin: 20px;\"");
                BeginWriteAttribute("alt", " alt=\"", 1167, "\"", 1173, 0);
                EndWriteAttribute();
                WriteLiteral("/>\r\n        <img src=\"https://www.drupal.org/files/styles/grid-3-2x/public/project-images/ETHEREUM-LOGO_PORTRAIT_Black_small.png?itok=E8Qrv5WR\" width=\"200px\" style=\"margin: 20px\"");
                BeginWriteAttribute("alt", " alt=\"", 1352, "\"", 1358, 0);
                EndWriteAttribute();
                WriteLiteral("/>\r\n    </div>\r\n</div>\r\n\r\n");
                WriteLiteral("\r\n");
#nullable restore
#line 41 "C:\Users\icond\Documents\Coding\.NET Projects\GetChain\GetChain\Pages\Index.cshtml"
Write(await Html.PartialAsync("Partials/_Footer"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 42 "C:\Users\icond\Documents\Coding\.NET Projects\GetChain\GetChain\Pages\Index.cshtml"
Write(await Html.PartialAsync("Partials/_BottomIncludes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 43 "C:\Users\icond\Documents\Coding\.NET Projects\GetChain\GetChain\Pages\Index.cshtml"
  
    //await RenderSectionAsync("Scripts", required: false)

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
