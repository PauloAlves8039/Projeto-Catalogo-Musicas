using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio.Dominio;
using TreinaWeb.Musicas.Web.ViewModels.Musica;

namespace TreinaWeb.Musicas.Web.Controllers
{
    /// <summary>
    /// Controlador responsável pela ações referentes a entidade Musica.
    /// </summary>
    public class MusicasController : Controller
    {
        private MusicasDbContext db = new MusicasDbContext();

        /// <summary>
        /// Action responsável pela listagem das músicas cadastrados.
        /// </summary>
        /// <returns>View com lista de músicas inseridas.</returns>
        public ActionResult Index()
        {
            var musicas = db.Musicas.Include(m => m.Album);
            return View(Mapper.Map<List<Musica>, List<MusicaIndexViewModel>>(db.Musicas.ToList()));
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
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        /// <summary>
        /// Action responsável por direcionar registro da Musica inserida.
        /// </summary>
        /// <returns>View com lista de músicas.</returns>
        public ActionResult Create()
        {
            ViewBag.IdAlbum = new SelectList(db.Albuns, "Id", "Nome");
            return View();
        }

        /// <summary>
        /// Action responsável pela criação de novos registros das músicas.
        /// </summary>
        /// <param name="musica">Usado para referenciar a entidade Musica.</param>
        /// <returns>View com novo registro criado na lista de músicas.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                db.Musicas.Add(musica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAlbum = new SelectList(db.Albuns, "Id", "Nome", viewModel.IdAlbum);
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
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAlbum = new SelectList(db.Albuns, "Id", "Nome", musica.IdAlbum);
            return View(musica);
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
                db.Entry(musica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAlbum = new SelectList(db.Albuns, "Id", "Nome", viewModel.IdAlbum);
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
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
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
            Musica musica = db.Musicas.Find(id);
            db.Musicas.Remove(musica);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Método sobrescrito para remoção do objeto Musica da memória, visando o encerramento da conexão com o banco de dados.
        /// </summary>
        /// <param name="disposing">Usado para direcionar o encerramento do objeto Musica.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
