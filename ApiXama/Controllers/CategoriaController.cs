using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaDatos;
using CapaEntidad;
namespace ApiXama.Controllers
{
    public class CategoriaController : ApiController
    {
        public  List<CategoriaCLS> Get()
        {
            //llamamos a capa de datos
            CategoriaDAL oCategoriaDAL = new CategoriaDAL();
            return oCategoriaDAL.listarCategoria();
        }

        //DELETE
    //    public int Delete(int id)
     //   {
     //       CategoriaDAL oCategoriaDAL = new CategoriaDAL();
     //       return oCategoriaDAL.eliminarQueja(id);
    //    }


        //Post
        public int Post([FromBody] CategoriaCLS oCategoriaCLS)
        {
            CategoriaDAL oCategoriaDAL = new CategoriaDAL();
            return oCategoriaDAL.guardarQueja(oCategoriaCLS);
        } 


    }
}
