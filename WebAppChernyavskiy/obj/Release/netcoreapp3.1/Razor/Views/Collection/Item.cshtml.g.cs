#pragma checksum "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\Item.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f68f0a3af1b632c592d4a680311a9cb33547d6ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Collection_Item), @"mvc.1.0.view", @"/Views/Collection/Item.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f68f0a3af1b632c592d4a680311a9cb33547d6ac", @"/Views/Collection/Item.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09237fe101e68646d4ed8790aa504a381dcb46f7", @"/Views/_ViewImports.cshtml")]
    public class Views_Collection_Item : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebAppChernyavskiy.Models.Collections.Collection>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\Item.cshtml"
  
    ViewData["Title"] = "Item";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Страница коллекции</h1>\r\n\r\n<div>\r\n    <h4>Коллекция</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\Item.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\Item.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 22 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\Item.cshtml"
Write(Html.ActionLink("Добавить айтем", "AddItem", new { CollectionId = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 23 "C:\Users\Vlad Chernyavskiy\source\repos\WebAppChernyavskiy\WebAppChernyavskiy\Views\Collection\Item.cshtml"
Write(Html.ActionLink("Список айтеймов", "ItemsList", new { Model.Id }));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebAppChernyavskiy.Models.Collections.Collection> Html { get; private set; }
    }
}
#pragma warning restore 1591