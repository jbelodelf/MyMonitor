#pragma checksum "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18f94102d060ba379c11707873117109a02e8998"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Empresa_Index), @"mvc.1.0.view", @"/Views/Empresa/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Empresa/Index.cshtml", typeof(AspNetCore.Views_Empresa_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18f94102d060ba379c11707873117109a02e8998", @"/Views/Empresa/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"060aecd92d5438e5f236708e2a1d922fed2c393a", @"/Views/_ViewImports.cshtml")]
    public class Views_Empresa_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JBD.MonitorCozinha.WebAdmin.Models.EmpresaViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(66, 113, true);
            WriteLiteral("    <style type=\"text/css\">\r\n        label {\r\n            text-align: left !important;\r\n        }\r\n    </style>\r\n");
            EndContext();
            BeginContext(182, 725, true);
            WriteLiteral(@"

<div id=""mensagem"" name=""mensagem"" style=""display: none; background-color: #ff2d296b; text-align:center; height: 40px; padding-top: 5px; font-size: 20px;""><b>mensagem</b></div>
<div class=""jumbotron row topJumboTrom"" id=""TopoPesquisa"">
    <div class=""col-md-12 form-group row"">
        <div class=""col-md-2"" style=""text-align:right ; padding-top: 5px;"">
            <lable style=""font-size:18px ;"">Nome Fantasia</lable>
        </div>
        <div class=""col-md-5"">
            <input type=""text"" class=""form-control"" id=""EmpresaPesquisar"" name=""EmpresaPesquisar"" />
        </div>
        <div class=""col-md-1"">
            <button class=""btn btn-primary"" id=""btPesquisar"">Pesquisar</button>
        </div>
");
            EndContext();
            BeginContext(1046, 184, true);
            WriteLiteral("        <div class=\"col-md-1\">\r\n            <button class=\"btn btn-primary\" id=\"btNovo\">Cadastrar</button>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n<div id=\"divListarEmpresas\"></div>\r\n\r\n");
            EndContext();
            BeginContext(1289, 1029, true);
            WriteLiteral(@"
<!-- Modal para cadastrar cliente -->
<div class=""modal fade"" id=""ModalCadastrarEmpresa"" tabindex=""-1"" role=""dialog"" aria-labelledby=""fatorFModalLabel"" aria-hidden=""true"" data-backdrop=""static"" data-keyboard=""false"">
    <div class=""modal-dialog border-dark"">
        <div class=""modal-content"" style=""width: 200%; margin-left: -50%;"">
            <!-- Modal Header -->
            <div id=""mensagemModal"" name=""mensagem"" style=""display: none; background-color: #ff2d296b; text-align:center; height: 40px; padding-top: 5px; font-size: 20px;""><b>mensagem</b></div>

            <div class=""modal-header"">
                <div class=""col-md-11"">
                    <h3 class=""modal-title"">Cadastrar Empresa</h3>
                </div>
                <div class=""col-md-1"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                </div>
            </div>
            <!-- Modal body -->
            <!---------------------------------------------------");
            WriteLiteral(">\r\n\r\n");
            EndContext();
#line 55 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
             using (Html.BeginForm("Salvar", "Empresa", FormMethod.Post, new { name = "frmCliente", id = "frmCliente" }))
            {
                

#line default
#line hidden
            BeginContext(2473, 23, false);
#line 57 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(2498, 134, true);
            WriteLiteral("                <input type=\"hidden\" id=\"IdEmpresa\" value=\"\" />\r\n                <input type=\"hidden\" id=\"CNPJ_ORIGINAL\" value=\"\" />\r\n");
            EndContext();
            BeginContext(2634, 56, true);
            WriteLiteral("                <fieldset>\r\n                    <legend>");
            EndContext();
            BeginContext(2691, 13, false);
#line 62 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                       Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2704, 86, true);
            WriteLiteral("</legend>\r\n                    <div class=\"form-horizontal\">\r\n                        ");
            EndContext();
            BeginContext(2791, 64, false);
#line 64 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(2855, 163, true);
            WriteLiteral("\r\n\r\n                        <div class=\"form-group row col-md-12\">\r\n                            <div class=\"form-group col-md-3\">\r\n                                ");
            EndContext();
            BeginContext(3019, 93, false);
#line 68 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                           Write(Html.LabelFor(model => model.CNPJ, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(3112, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-12\">\r\n                                    ");
            EndContext();
            BeginContext(3208, 138, false);
#line 70 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.EditorFor(model => model.CNPJ, new { htmlAttributes = new { @class = "form-control", @maxlength = "14", @autofocus = "autofocus" } }));

#line default
#line hidden
            EndContext();
            BeginContext(3346, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(3385, 82, false);
#line 71 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.ValidationMessageFor(model => model.CNPJ, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(3467, 173, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"form-group col-md-9\">\r\n                                ");
            EndContext();
            BeginContext(3641, 100, false);
#line 75 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                           Write(Html.LabelFor(model => model.RazaoSocial, htmlAttributes: new { @class = "control-label col-md-5" }));

#line default
#line hidden
            EndContext();
            BeginContext(3741, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-12\">\r\n                                    ");
            EndContext();
            BeginContext(3837, 119, false);
#line 77 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.EditorFor(model => model.RazaoSocial, new { htmlAttributes = new { @class = "form-control", @maxlength = "60" } }));

#line default
#line hidden
            EndContext();
            BeginContext(3956, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(3995, 89, false);
#line 78 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.ValidationMessageFor(model => model.RazaoSocial, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(4084, 269, true);
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                        <div class=""form-group row col-md-12"">
                            <div class=""form-group col-md-6"">
                                ");
            EndContext();
            BeginContext(4354, 101, false);
#line 84 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                           Write(Html.LabelFor(model => model.NomeFantasia, htmlAttributes: new { @class = "control-label col-md-5" }));

#line default
#line hidden
            EndContext();
            BeginContext(4455, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-12\">\r\n                                    ");
            EndContext();
            BeginContext(4551, 120, false);
#line 86 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.EditorFor(model => model.NomeFantasia, new { htmlAttributes = new { @class = "form-control", @maxlength = "60" } }));

#line default
#line hidden
            EndContext();
            BeginContext(4671, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(4710, 90, false);
#line 87 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.ValidationMessageFor(model => model.NomeFantasia, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(4800, 173, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"form-group col-md-3\">\r\n                                ");
            EndContext();
            BeginContext(4974, 107, false);
#line 91 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                           Write(Html.LabelFor(model => model.InscricaoEstadual, htmlAttributes: new { @class = "control-label col-md-12" }));

#line default
#line hidden
            EndContext();
            BeginContext(5081, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-12\">\r\n                                    ");
            EndContext();
            BeginContext(5177, 125, false);
#line 93 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.EditorFor(model => model.InscricaoEstadual, new { htmlAttributes = new { @class = "form-control", @maxlength = "60" } }));

#line default
#line hidden
            EndContext();
            BeginContext(5302, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(5341, 95, false);
#line 94 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.ValidationMessageFor(model => model.InscricaoEstadual, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(5436, 78, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
            BeginContext(5614, 95, true);
            WriteLiteral("                            <div class=\"form-group col-md-3\">\r\n                                ");
            EndContext();
            BeginContext(5710, 108, false);
#line 100 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                           Write(Html.LabelFor(model => model.InscricaoMunicipal, htmlAttributes: new { @class = "control-label col-md-12" }));

#line default
#line hidden
            EndContext();
            BeginContext(5818, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-12\">\r\n                                    ");
            EndContext();
            BeginContext(5914, 126, false);
#line 102 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.EditorFor(model => model.InscricaoMunicipal, new { htmlAttributes = new { @class = "form-control", @maxlength = "60" } }));

#line default
#line hidden
            EndContext();
            BeginContext(6040, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(6079, 96, false);
#line 103 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.ValidationMessageFor(model => model.InscricaoMunicipal, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(6175, 271, true);
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>

                        <div class=""form-group row col-md-12"">
                            <div class=""form-group col-md-8"">
                                ");
            EndContext();
            BeginContext(6447, 100, false);
#line 110 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                           Write(Html.LabelFor(model => model.NomeContato, htmlAttributes: new { @class = "control-label col-md-5" }));

#line default
#line hidden
            EndContext();
            BeginContext(6547, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-12\">\r\n                                    ");
            EndContext();
            BeginContext(6643, 119, false);
#line 112 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.EditorFor(model => model.NomeContato, new { htmlAttributes = new { @class = "form-control", @maxlength = "60" } }));

#line default
#line hidden
            EndContext();
            BeginContext(6762, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(6801, 89, false);
#line 113 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.ValidationMessageFor(model => model.NomeContato, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(6890, 173, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"form-group col-md-4\">\r\n                                ");
            EndContext();
            BeginContext(7064, 97, false);
#line 117 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                           Write(Html.LabelFor(model => model.Telefone, htmlAttributes: new { @class = "control-label col-md-8" }));

#line default
#line hidden
            EndContext();
            BeginContext(7161, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-12\">\r\n                                    ");
            EndContext();
            BeginContext(7257, 116, false);
#line 119 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.EditorFor(model => model.Telefone, new { htmlAttributes = new { @class = "form-control", @maxlength = "15" } }));

#line default
#line hidden
            EndContext();
            BeginContext(7373, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(7412, 86, false);
#line 120 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.ValidationMessageFor(model => model.Telefone, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(7498, 272, true);
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>

                        <div class=""form-group row col-md-12"">
                            <div class=""form-group col-md-12"">
                                ");
            EndContext();
            BeginContext(7771, 94, false);
#line 127 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                           Write(Html.LabelFor(model => model.Email, htmlAttributes: new { @class = "control-label col-md-8" }));

#line default
#line hidden
            EndContext();
            BeginContext(7865, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-12\">\r\n                                    ");
            EndContext();
            BeginContext(7961, 113, false);
#line 129 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.EditorFor(model => model.Email, new { htmlAttributes = new { @class = "form-control", @maxlength = "60" } }));

#line default
#line hidden
            EndContext();
            BeginContext(8074, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(8113, 83, false);
#line 130 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
                               Write(Html.ValidationMessageFor(model => model.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(8196, 174, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n\r\n                        <input type=\"hidden\" id=\"DataCadastro\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 8370, "\"", 8391, 1);
#line 135 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
WriteAttributeValue("", 8378, DateTime.Now, 8378, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8392, 134, true);
            WriteLiteral(" />\r\n                        <input type=\"hidden\" id=\"IdStatus\" value=\"\" />\r\n                    </div>\r\n                </fieldset>\r\n");
            EndContext();
#line 139 "D:\Projetos\MyMonitor\MyMonitor\JBD.MonitorCozinha.WebAdmin\Views\Empresa\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(8541, 612, true);
            WriteLiteral(@"
            <!--------------------------------------------------->
            <!-- Modal footer -->
            <div class=""modal-footer"" style=""display:grid"">
                <div class=""col-md-12"" style=""align-content: flex-end"">
                    <button id=""btnFecharEmpresa"" type=""button"" class=""btn btn-danger"">&nbsp;&nbsp;&nbsp;Fechar&nbsp;&nbsp;&nbsp;</button>
                    <button id=""btnSalvarEmpresa"" type=""button"" class=""btn btn-outline-success"">&nbsp;&nbsp;&nbsp;Salvar&nbsp;&nbsp;&nbsp;</button>

                </div>
            </div>

        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JBD.MonitorCozinha.WebAdmin.Models.EmpresaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
