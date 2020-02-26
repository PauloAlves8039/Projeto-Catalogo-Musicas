using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio.Dominio;
using TreinaWeb.Musicas.Repositorios.Entity.Entidades;
using TreinaWeb.Musicas.Web.ViewModels.Album;
using TreinaWeb.Musicas.Web.ViewModels.Musica;
using TreinaWeb.Repositorios.Comum.Interface;

namespace TreinaWeb.Musicas.Web.Controllers
{
    /// <summary>
    /// Controlador responsável pela ações referentes a entidade Musica.
    /// </summary>
    [Authorize]
    public class MusicasController : Controller
    {
        /// <value>Propriedade de referência para os repositórios.</value>
        private IRepositorioGenerico<Musica, long> repositorioMusicas = new MusicasRepositorio(new MusicasDbContext());

        /// <value>Propriedade de referência para o repositório Album.</value>
        private IRepositorioGenerico<Album, int> repositorioAlbuns = new AlbunsRepositorio(new MusicasDbContext());

        /// <summary>
        /// Action responsável pela listagem das músicas cadastrados.
        /// </summary>
        /// <returns>View com lista de músicas inseridas.</returns>
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Musica>, List<MusicaIndexViewModel>>(repositorioMusicas.Selecionar()));
        }

        /// <summary>
        /// Action responsável por filtrar pesquisa de música por nome.
        /// </summary>
        /// <param name="pesquisa">Parâmetro de pesquisa de resgistro.</param>
        /// <returns>Informação convertida de objeto Musica no formato JSON.</returns>
        public ActionResult FiltrarPorNome(string pesquisa)
        {
            List<Musica> musicas = repositorioMusicas.Selecionar().Where(a => a.Nome.Contains(pesquisa)).ToList();
            List<MusicaIndexViewModel> viewModel = Mapper.Map<List<Musica>, List<MusicaIndexViewModel>>(musicas);
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Action responsável pela exibição dos detalhes de uma música.
        /// </summary>
        /// <param name="id">Identifica o registro da música a ser detalhada.</param>
        /// <returns>View com detalhes da música.</returns>
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaIndexViewModel>(musica));
        }

        /// <summary>
        /// Action responsável por direcionar registro da Musica inserida em Album.
        /// </summary>
        /// <returns>View com lista de músicas.</returns>
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            List<AlbumIndexViewModel> albuns = Mapper.Map<List<Album>, List<AlbumIndexViewModel>>(repositorioAlbuns.Selecionar());
            SelectList dropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View();
        }

        /// <summary>
        /// Action responsável pela criação de novos registros das músicas.
        /// </summary>
        /// <param name="musica">Usado para referenciar a entidade Musica.</param>
        /// <returns>View com novo registro criado na lista de músicas.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusicas.Inserir(musica);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        /// <summary>
        /// Action responsável por direcionar registro da música editada.
        /// </summary>
        /// <param name="id">Identifica o registro da música a ser editada.</param>
        /// <returns>View atualizada com lista de músicas.</returns>
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            List<AlbumIndexViewModel> albuns = Mapper.Map<List<Album>, List<AlbumIndexViewModel>>(repositorioAlbuns.Selecionar());
            SelectList dropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View(Mapper.Map<Musica, MusicaViewModel>(musica));
        }

        /// <summary>
        /// Action responsável pela edição de registro da música.
        /// </summary>
        /// <param name="musica">Usado para referenciar a entidade Musica.</param>
        /// <returns>View com registro editado na lista de músicas.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusicas.Alterar(musica);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        /// <summary>
        /// Action responsável pela exclusão da música.
        /// </summary>
        /// <param name="id">Identifica o registro da música a ser excluído.</param>
        /// <returns>View atualizada com lista de músicas após a exclusão do música.</returns>
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaIndexViewModel>(musica));
        }

        /// <summary>
        /// Action responsável pela confirmação da exclusão da música.
        /// </summary>
        /// <param name="id">Identifica o registro da música a ser confirmada para a exclusão.</param>
        /// <returns>View atualizada com lista de músicas após a exclusão da música.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioMusicas.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

    }
}
