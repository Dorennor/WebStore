#pragma checksum "D:\Documents\Visual Studio Projects\WebStore\PracticeShop\Views\Store\ShowTransactions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23327d720768abbc6782cf67343a52177a89f96f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Store_ShowTransactions), @"mvc.1.0.view", @"/Views/Store/ShowTransactions.cshtml")]
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
#line 1 "D:\Documents\Visual Studio Projects\WebStore\PracticeShop\Views\_ViewImports.cshtml"
using WebStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Documents\Visual Studio Projects\WebStore\PracticeShop\Views\_ViewImports.cshtml"
using WebStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23327d720768abbc6782cf67343a52177a89f96f", @"/Views/Store/ShowTransactions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82605dd9048b6e19a34fbc4d71121408894274c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Store_ShowTransactions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebStore.Models.Transaction>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div>
    <div>
        <p class=""TitleText"">New items</p>
    </div>
    <table class=""table"">
        <tr>
            <td>
                <p>UserName</p>
            </td>
            <td>
                <p>Date</p>
            </td>
            <td>
                <p>SerialNumbers</p>
            </td>
            <td>
                <p>Prices</p>
            </td>
        </tr>
");
#nullable restore
#line 22 "D:\Documents\Visual Studio Projects\WebStore\PracticeShop\Views\Store\ShowTransactions.cshtml"
         foreach (var device in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <p>");
#nullable restore
#line 26 "D:\Documents\Visual Studio Projects\WebStore\PracticeShop\Views\Store\ShowTransactions.cshtml"
                  Write(device.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </td>\r\n                <td>\r\n                    <p>");
#nullable restore
#line 29 "D:\Documents\Visual Studio Projects\WebStore\PracticeShop\Views\Store\ShowTransactions.cshtml"
                  Write(device.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </td>\r\n                <td>\r\n                    <p>");
#nullable restore
#line 32 "D:\Documents\Visual Studio Projects\WebStore\PracticeShop\Views\Store\ShowTransactions.cshtml"
                  Write(device.SerialNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </td>\r\n                <td>\r\n                    <p>");
#nullable restore
#line 35 "D:\Documents\Visual Studio Projects\WebStore\PracticeShop\Views\Store\ShowTransactions.cshtml"
                  Write(device.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 38 "D:\Documents\Visual Studio Projects\WebStore\PracticeShop\Views\Store\ShowTransactions.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n   \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebStore.Models.Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
