#pragma checksum "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "008ae5792bae0222be12dea0af79c6c4f699a3fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Collection_ItemsList), @"mvc.1.0.view", @"/Views/Collection/ItemsList.cshtml")]
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
#line 1 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\_ViewImports.cshtml"
using WebAppChernyavskiy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\_ViewImports.cshtml"
using WebAppChernyavskiy.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"008ae5792bae0222be12dea0af79c6c4f699a3fd", @"/Views/Collection/ItemsList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09237fe101e68646d4ed8790aa504a381dcb46f7", @"/Views/_ViewImports.cshtml")]
    public class Views_Collection_ItemsList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebAppChernyavskiy.Models.Collections.Item>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
  
    ViewData["Title"] = "ItemsList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Список айтеймов</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.DisplayNameFor(model => model.CollectionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.DisplayFor(modelItem => item.CollectionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.ActionLink("Редактировать", "Edit", "Item", new { item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 50 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 51 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
           Write(Html.ActionLink("Удалить", "Delete" ,"Item", new { item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 54 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\ItemsList.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebAppChernyavskiy.Models.Collections.Item>> Html { get; private set; }
    }
}
#pragma warning restore 1591
