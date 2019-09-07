using AutoMapper;
using JBD.MonitorCozinha.WebAdmin.Models;
using JBD.MonitorCozinha.WebAdmin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JBD.MonitorCozinha.WebAdmin.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly PessoaServiceWeb _pessoaServiceWeb;

        public PessoaController(IMapper mapper)
        {
            _mapper = mapper;
            _pessoaServiceWeb = new PessoaServiceWeb(_mapper);
        }


        // GET: Pessoa
        public ActionResult Index(int IdUnidade = 0)
        {
            var pessoaViewModel = new PessoaViewModel();
            pessoaViewModel.IdUnidade = IdUnidade;

            //Recuperando Nome da Unidade
            var nomeUnidade = new PessoaViewModel();
            UnidadeServiceWeb unidadeService = new UnidadeServiceWeb(_mapper);
            var nome = unidadeService.ObterUnidade(IdUnidade).Nome;
            var empresa = unidadeService.ObterUnidade(IdUnidade).IdEmpresa;

            pessoaViewModel.NomeUnidade = nome;
            pessoaViewModel.IdEmpresa = empresa;


            return View(pessoaViewModel);
        }

        public ActionResult ListarPessoas(string nomePessoa, int IdUnidade)
        {
            var unidadeViewModel = new UnidadeViewModel();

            if(IdUnidade > 0)
            {
                unidadeViewModel = ObterListaPessoas(IdUnidade);
            }

            return PartialView("~/Views/Pessoa/_listarPessoas.cshtml", unidadeViewModel);
        }



        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SalvarPessoa(PessoaViewModel pessoa)
        {
            try
            {
                pessoa.TipoUsuarios = null;
                _pessoaServiceWeb.CadastrarPessoa(pessoa);

                return Json (new { mensagem = "Registro salvo com sucesso", retorno = "200" });
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult EditarPessoa(int id)
        {

            PessoaViewModel pessoaVM = new PessoaViewModel();
            pessoaVM = _pessoaServiceWeb.ObterPessoa(id);

            return Json (new {retorno = 200, data = pessoaVM });
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditarPessoa(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #region Methods

        private UnidadeViewModel ObterListaPessoas(int IdUnidade)
        {
            UnidadeServiceWeb pessoaServiceWeb = new UnidadeServiceWeb(_mapper);

            UnidadeViewModel pessoasViewModel = new UnidadeViewModel();
            var pessoaDTO = pessoaServiceWeb.ObterUnidade(IdUnidade);

            pessoasViewModel = _mapper.Map<UnidadeViewModel>(pessoaDTO);


            return pessoasViewModel;
        }

        #endregion


    }

}