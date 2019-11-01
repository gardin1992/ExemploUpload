using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ExemploUpload.Models;

namespace ExemploUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Produto produto)
        {
            try
            {
                string nomeArquivo = "";
                if(produto.Arquivo.ContentLength > 0)
                {
                    nomeArquivo = Path.GetFileName(produto.Arquivo.FileName);
                    var caminho = Path.Combine(Server.MapPath("~/Imagens"), nomeArquivo);
                    produto.Arquivo.SaveAs(caminho);
                }
                ViewBag.Mensagem = "Arquivo : " + nomeArquivo + ", enviado com sucesso";
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "Erro : " + ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase Arquivo)
        {
            string path = Server.MapPath("~/Imagens/" + Path.GetFileName(Arquivo.FileName));
            Arquivo.SaveAs(path); // saving file
            ViewBag.Path = path;
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}