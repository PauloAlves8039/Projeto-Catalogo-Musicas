using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio.Dominio;
using TreinaWeb.Musicas.Repositorios.Entity.Entidades;
using TreinaWeb.Musicas.Web.ViewModels.Album;
using TreinaWeb.Repositorios.Comum.Interface;

namespace TreinaWeb.Musicas.Web.Controllers
{
    /// <summary>
    /// Controlador responsável pela ações referentes a entidade Album.
    /// </summary>
    public class AlbunsController : Controller
    {
        /// <value>Propriedade de referência para os repositórios.</value>
        private IRepositorioGenerico<Album, int> repositorioAlbuns = new AlbunsRepositorio(new MusicasDbContext());

        /// <summary>
        /// Action responsável pela listagem dos álbuns cadastrados.
        /// </summary>
        /// <returns>View com lista de álbuns inseridos.</returns>
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Album>, List<AlbumIndexViewModel>>(repositorioAlbuns.Selecionar()));
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
            Album album = repositorioAlbuns.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album, AlbumIndexViewModel>(album));
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
        public ActionResult Create([Bind(Include = "Id,Nome,Ano,Email,Observacoes")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Album album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                repositorioAlbuns.Inserir(album);
                return RedirectToAction("Index");
            }

            return View(viewModel);
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
            Album album = repositorioAlbuns.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album, AlbumViewModel>(album));
        }

        /// <summary>
        /// Action responsável pela edição de registro do álbum.
        /// </summary>
        /// <param name="album">Usado para referenciar a entidade Album.</param>
        /// <returns>View com registro editado na lista de álbuns.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ano,Email,Observacoes")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Album album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                repositorioAlbuns.Alterar(album);
                return RedirectToAction("Index");
            }
            return View(viewModel);
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
            Album album = repositorioAlbuns.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album, AlbumIndexViewModel>(album));
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
            repositorioAlbuns.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
