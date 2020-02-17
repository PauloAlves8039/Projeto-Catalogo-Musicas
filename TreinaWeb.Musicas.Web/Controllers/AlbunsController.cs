using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio.Dominio;

namespace TreinaWeb.Musicas.Web.Controllers
{
    /// <summary>
    /// Controlador responsável pela ações referentes a entidade Album.
    /// </summary>
    public class AlbunsController : Controller
    {
        private MusicasDbContext db = new MusicasDbContext();
        
        /// <summary>
        /// Action responsável pela listagem dos álbuns cadastrados.
        /// </summary>
        /// <returns>View com lista de álbuns inseridos.</returns>
        public ActionResult Index()
        {
            return View(db.Albuns.ToList());
        }

        /// <summary>
        /// Action responsável pela exibição dos detalhes de um álbum.
        /// </summary>
        /// <param name="id">Identifica o registro a ser detalhado.</param>
        /// <returns>View com detalhes do álbum.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        /// <summary>
        /// Action responsável por direcionar registro do Album inserido.
        /// </summary>
        /// <returns>View com lista de álbuns.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Action responsável pela criação de novos registros dos álbuns.
        /// </summary>
        /// <param name="album">Usado para referenciar a entidade Album.</param>
        /// <returns>View com novo registro criado na lista de álbuns.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ano,Email,Observacoes")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albuns.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        /// <summary>
        /// Action responsável por direcionar registro do álbum editado.
        /// </summary>
        /// <param name="id">Identifica o registro a ser editado.</param>
        /// <returns>View atualizada com lista de álbuns.</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        /// <summary>
        /// Action responsável pela edição de registro do álbum.
        /// </summary>
        /// <param name="album">Usado para referenciar a entidade Album.</param>
        /// <returns>View com registro editado na lista de álbuns.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ano,Email,Observacoes")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        /// <summary>
        /// Action responsável pela exclusão de álbum.
        /// </summary>
        /// <param name="id">Identifica o registro a ser excluído.</param>
        /// <returns>View com registro da lista de álbuns</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        /// <summary>
        /// Action responsável pela confirmação da exclusão de álbum.
        /// </summary>
        /// <param name="id">Identifica o registro a ser confirmada a exclusão.</param>
        /// <returns>View atualizada com lista de álbuns após a exclusão do álbum.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albuns.Find(id);
            db.Albuns.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Método sobrescrito para remoção do objeto da memória, visando o encerramento da conexão com o banco de dados.
        /// </summary>
        /// <param name="disposing">Usado para direcionar o encerramento do objeto.</param>
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
