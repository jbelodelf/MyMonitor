#pragma checksum "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\MonitorAdmin\_MonitoAFazer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "848a47ebee27cb2a80d6064aaf3f9e3efda61ab9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MonitorAdmin__MonitoAFazer), @"mvc.1.0.view", @"/Views/MonitorAdmin/_MonitoAFazer.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MonitorAdmin/_MonitoAFazer.cshtml", typeof(AspNetCore.Views_MonitorAdmin__MonitoAFazer))]
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
#line 1 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\_ViewImports.cshtml"
using JBD.MonitorCozinha.WebAdmin;

#line default
#line hidden
#line 2 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\_ViewImports.cshtml"
using JBD.MonitorCozinha.WebAdmin.Models;

#line default
#line hidden
#line 1 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\MonitorAdmin\_MonitoAFazer.cshtml"
using JBD.MonitorCozinha.Domain.Enuns;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"848a47ebee27cb2a80d6064aaf3f9e3efda61ab9", @"/Views/MonitorAdmin/_MonitoAFazer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"060aecd92d5438e5f236708e2a1d922fed2c393a", @"/Views/_ViewImports.cshtml")]
    public class Views_MonitorAdmin__MonitoAFazer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<JBD.MonitorCozinha.WebAdmin.Models.NumeroPedidoViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(119, 43, true);
            WriteLiteral("\r\n<div class=\"table col-lg-12 col-sm-12\">\r\n");
            EndContext();
#line 5 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\MonitorAdmin\_MonitoAFazer.cshtml"
     foreach (var item in Model)
    {
        if (item.IdStatusPedido == StatusPedidoEnum.AFazer)
        {

#line default
#line hidden
            BeginContext(275, 140, true);
            WriteLiteral("            <div class=\"float-left p-2\">\r\n               <span id=\"b\">\r\n                   <button class=\"btn btn-outline-dark form-control\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 415, "\"", 443, 1);
#line 11 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\MonitorAdmin\_MonitoAFazer.cshtml"
WriteAttributeValue("", 423, item.IdStatusPedido, 423, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(444, 74, true);
            WriteLiteral(" style=\"font-size:40px\">\r\n                       <a href=\"#\" id=\"btDelete\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 518, "\"", 576, 3);
            WriteAttributeValue("", 528, "MonitorAdmin.DeletarNumero(", 528, 27, true);
#line 12 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\MonitorAdmin\_MonitoAFazer.cshtml"
WriteAttributeValue("", 555, item.IdNumeroPedido, 555, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 575, ")", 575, 1, true);
            EndWriteAttribute();
            BeginContext(577, 160, true);
            WriteLiteral(" title=\"Apagar esse número\">\r\n                           <i class=\"fa fa-trash\" aria-hidden=\"true\"></i>\r\n                       </a>\r\n                       <b>");
            EndContext();
            BeginContext(738, 17, false);
#line 15 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\MonitorAdmin\_MonitoAFazer.cshtml"
                     Write(item.NumeroPedido);

#line default
#line hidden
            EndContext();
            BeginContext(755, 55, true);
            WriteLiteral("</b>\r\n                       <a href=\"#\" id=\"btFazendo\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 810, "\"", 873, 4);
            WriteAttributeValue("", 820, "MonitorAdmin.AtualizarStatus(", 820, 29, true);
#line 16 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\MonitorAdmin\_MonitoAFazer.cshtml"
WriteAttributeValue("", 849, item.IdNumeroPedido, 849, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 869, ",", 869, 1, true);
            WriteAttributeValue(" ", 870, "2)", 871, 3, true);
            EndWriteAttribute();
            BeginContext(874, 215, true);
            WriteLiteral(" title=\"Mudar para Fazendo\">\r\n                           <i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>\r\n                       </a>\r\n                   </button>\r\n                </span>\r\n            </div>\r\n");
            EndContext();
#line 22 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\MonitorAdmin\_MonitoAFazer.cshtml"
        }
    }

#line default
#line hidden
            BeginContext(1107, 8, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<JBD.MonitorCozinha.WebAdmin.Models.NumeroPedidoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
