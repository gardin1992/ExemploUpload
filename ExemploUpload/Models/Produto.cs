using System.Web;

namespace ExemploUpload.Models
{
    public class Produto
    {
        public HttpPostedFileBase Arquivo { get; set; }
    }
}