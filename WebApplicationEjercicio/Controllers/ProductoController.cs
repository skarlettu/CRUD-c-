﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationEjercicio.Data;
using WebApplicationEjercicio.Models;

namespace WebApplicationEjercicio.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/<controller>
        public List<Producto> Get()
        {
            return ProductoData.Listar();
        }

        // GET api/<controller>/5
        public Producto Get(int id)
        {
            return ProductoData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Producto oProducto)
        {
            return ProductoData.Registrar(oProducto);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Producto oProducto)
        {
            return ProductoData.Modificar(oProducto);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ProductoData.Eliminar(id);
        }
    }
}