#pragma checksum "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af162774a82928d130f46894f3f30a632fd45397"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Home), @"mvc.1.0.view", @"/Views/Login/Home.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Login/Home.cshtml", typeof(AspNetCore.Views_Login_Home))]
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
#line 1 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
using JBD.MonitorCozinha.Domain.Enuns;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af162774a82928d130f46894f3f30a632fd45397", @"/Views/Login/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"060aecd92d5438e5f236708e2a1d922fed2c393a", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Views/Usuario/Usuario.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(68, 42, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html lang=\"pt-br\">\r\n");
            EndContext();
            BeginContext(110, 332, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af162774a82928d130f46894f3f30a632fd453975729", async() => {
                BeginContext(116, 121, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>");
                EndContext();
                BeginContext(238, 17, false);
#line 12 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(255, 30, true);
                WriteLiteral(" - Monitor Cozinha</title>\r\n\r\n");
                EndContext();
                BeginContext(330, 8, true);
                WriteLiteral("        ");
                EndContext();
                BeginContext(338, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "af162774a82928d130f46894f3f30a632fd453976744", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(409, 2, true);
                WriteLiteral("\r\n");
                EndContext();
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
            EndContext();
            BeginContext(442, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(444, 3859, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af162774a82928d130f46894f3f30a632fd453978873", async() => {
                BeginContext(450, 583, true);
                WriteLiteral(@"
    <header>
        <div class=""container-fluid p-4"" id=""divTop"" style=""width: 90%;"">
            <div class=""jumbotron row"" id=""TopoPesquisa"" style=""background-color: #FF7175;"">
                <div class=""col-md-12"" style=""text-align:center; padding-top: 5px; font-size:40px; color: white;"">
                    <b>SEJA BEM VINDO AO MONITOR DE COZINHA</b>
                </div>
            </div>
        </div>
    </header>
    <content>
        <div class=""container-fluid p-4"" id=""divTop"" style=""width: 90%;"">
            <div class=""col-md-12 form-group row"">
");
                EndContext();
#line 31 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
                 if (Controle.ControleAcesso.IdTipo == TipoUsuarioEnum.Operacional || Controle.ControleAcesso.IdTipo == TipoUsuarioEnum.Admin)
                {

#line default
#line hidden
                BeginContext(1196, 380, true);
                WriteLiteral(@"                    <div class=""col-md-3"" style=""text-align:center; padding-top: 5px; font-size:50px;"">
                        <button class=""btn btn-outline-danger col-sm-10 p-md-1"" onclick=""Usuario.UnidadeAdmin('MONITOR TV')"" id=""btTV_old"" style=""height:200px; text-align:center; font-size:35px; background-color: #FF7175;"">Monitor de TV</button>
                    </div>
");
                EndContext();
#line 36 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
                }

#line default
#line hidden
                BeginContext(1595, 16, true);
                WriteLiteral("                ");
                EndContext();
#line 37 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
                 if (Controle.ControleAcesso.IdTipo == TipoUsuarioEnum.Operacional || Controle.ControleAcesso.IdTipo == TipoUsuarioEnum.Admin)
                {

#line default
#line hidden
                BeginContext(1758, 375, true);
                WriteLiteral(@"                    <div class=""col-md-3"" style=""text-align:center; padding-top: 5px; font-size:50px;"">
                        <button class=""btn btn-outline-danger col-sm-10 p-md-1"" onclick=""Usuario.UnidadeAdmin('CADASTRAR SENHAS')"" id=""btTVAdmin_old"" style=""height:200px; font-size:35px; background-color: #FF7175;"">Cadastrar senhas</button>
                    </div>
");
                EndContext();
#line 42 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
                }

#line default
#line hidden
                BeginContext(2152, 16, true);
                WriteLiteral("                ");
                EndContext();
#line 43 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
                 if (Controle.ControleAcesso.IdTipo == TipoUsuarioEnum.Operacional || Controle.ControleAcesso.IdTipo == TipoUsuarioEnum.Admin)
                {

#line default
#line hidden
                BeginContext(2315, 376, true);
                WriteLiteral(@"                    <div class=""col-md-3"" style=""text-align:center; padding-top: 5px; font-size:50px;"">
                        <button class=""btn btn-outline-danger col-sm-10 p-md-1"" onclick=""Usuario.UnidadeAdmin('CADASTRAR SENHAS - MOTOBOY')"" id=""btTVAdmin_old"" style=""height:200px; font-size:35px; background-color: #FF7175;"">MOTOBOY</button>
                    </div>
");
                EndContext();
#line 48 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
                }

#line default
#line hidden
                BeginContext(2710, 16, true);
                WriteLiteral("                ");
                EndContext();
#line 49 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
                 if (Controle.ControleAcesso.IdTipo == TipoUsuarioEnum.Cozinha || Controle.ControleAcesso.IdTipo == TipoUsuarioEnum.Operacional || Controle.ControleAcesso.IdTipo == TipoUsuarioEnum.Admin)
                {

#line default
#line hidden
                BeginContext(2934, 359, true);
                WriteLiteral(@"                    <div class=""col-md-3"" style=""text-align:center; padding-top: 5px;"">
                        <button class=""btn btn-outline-danger col-sm-10 p-md-1"" onclick=""Usuario.UnidadeAdmin('MONITOR ADMINISTRATIVO')"" id=""btAdmin_old"" style=""height:200px; font-size:35px; background-color: #FF7175;"">Monitor Adm.</button>
                    </div>
");
                EndContext();
#line 54 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
                }

#line default
#line hidden
                BeginContext(3312, 16, true);
                WriteLiteral("                ");
                EndContext();
#line 55 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
                 if (Controle.ControleAcesso.IdTipo == TipoUsuarioEnum.Admin)
                {

#line default
#line hidden
                BeginContext(3410, 278, true);
                WriteLiteral(@"                    <div class=""col-md-3"" style=""text-align:center; padding-top: 5px;"">
                        <button class=""btn btn-outline-danger col-sm-10 p-md-1"" id=""btGestao"" style=""height:200px; font-size:35px;"">Gestão de cadastro</button>
                    </div>
");
                EndContext();
#line 60 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Login\Home.cshtml"
                }

#line default
#line hidden
                BeginContext(3707, 211, true);
                WriteLiteral("            </div>\r\n        </div>\r\n    </content>\r\n    <footer class=\"border-top footer text-muted\">\r\n        <div class=\"container-fluid\" style=\"text-align:center\">\r\n            &copy; 2019 - Mymonitor.com.br ");
                EndContext();
                BeginContext(3991, 35, true);
                WriteLiteral("\r\n        </div>\r\n    </footer>\r\n\r\n");
                EndContext();
                BeginContext(4071, 8, true);
                WriteLiteral("        ");
                EndContext();
                BeginContext(4079, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af162774a82928d130f46894f3f30a632fd4539715571", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4130, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(4140, 67, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af162774a82928d130f46894f3f30a632fd4539716832", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4207, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(4217, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af162774a82928d130f46894f3f30a632fd4539718093", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4270, 2, true);
                WriteLiteral("\r\n");
                EndContext();
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
            EndContext();
            BeginContext(4303, 36, true);
            WriteLiteral("\r\n</html>\r\n<div id=\"rodape\"></div>\r\n");
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
