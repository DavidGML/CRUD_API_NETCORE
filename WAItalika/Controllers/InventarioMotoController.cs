using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAItalika.Models;

namespace WAItalika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioMotoController : ControllerBase
    {
        //Obtener todos datos 
        [HttpGet]
        public IActionResult Get()
        {
            Response oResponse = new Response();
            try
            {
                using (Italika_DBContext db = new Italika_DBContext())
                {
                    var lst = db.InventarioMotos.ToList();
                    oResponse.Success = true;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }

        //Obtener datos por SKU
        [Route("getbysku")]
        [HttpGet]
        public IActionResult GetbySku(InventarioMotoRequest oInventarioMotoRequest)
        {
            Response oResponse = new Response();
            try
            {
                using (Italika_DBContext db = new Italika_DBContext())
                {
                    var lst = from consulta in db.InventarioMotos.ToList()
                              where consulta.Sku == oInventarioMotoRequest.Sku
                              select new InventarioMotolst
                              {
                                  Sku = consulta.Sku,
                                  Fert = consulta.Fert,
                                  Modelo = consulta.Modelo,
                                  Tipo = consulta.Tipo,
                                  NumeroSerie = consulta.NumeroSerie,
                                  Fecha = consulta.Fecha
                              };
                    oResponse.Success = true;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }

        //Obtener datos por modelo
        [Route("getbymodelo")]
        [HttpGet]
        public IActionResult GetbyModelo(InventarioMotoRequest oInventarioMotoRequest)
        {
            Response oResponse = new Response();
            try
            {
                using (Italika_DBContext db = new Italika_DBContext())
                {
                    var lst = from consulta in db.InventarioMotos.ToList()
                              where consulta.Modelo == oInventarioMotoRequest.Modelo
                              select new InventarioMotolst
                              {
                                  Sku = consulta.Sku,
                                  Fert = consulta.Fert,
                                  Modelo = consulta.Modelo,
                                  Tipo = consulta.Tipo,
                                  NumeroSerie = consulta.NumeroSerie,
                                  Fecha = consulta.Fecha
                              };
                    oResponse.Success = true;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }

        public class InventarioMotolst
        {
            public string Sku { get; set; }
            public string Fert { get; set; }
            public string Modelo { get; set; }
            public string Tipo { get; set; }
            public string NumeroSerie { get; set; }
            public DateTime Fecha { get; set; }
        }

        //agregar datos
        [HttpPost]
        public IActionResult Add(InventarioMotoRequest oInventarioMotoRequest)
        {
            Response oResponse = new Response();

            try
            {
                using (Italika_DBContext db = new Italika_DBContext())
                {
                    InventarioMoto oIngrediente = new InventarioMoto();
                    oIngrediente.Sku = oInventarioMotoRequest.Sku;
                    oIngrediente.Fert = oInventarioMotoRequest.Fert;
                    oIngrediente.Modelo = oInventarioMotoRequest.Modelo;
                    oIngrediente.Tipo = oInventarioMotoRequest.Tipo;
                    oIngrediente.NumeroSerie = oInventarioMotoRequest.NumeroSerie;
                    oIngrediente.Fecha = DateTime.Today;
                    db.Add(oIngrediente);
                    db.SaveChanges();

                    oResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }

        //editar datos
        [HttpPut]
        public IActionResult Edit(InventarioMotoRequest oInventarioMotoRequest)
        {
            Response oResponse = new Response();

            try
            {
                using (Italika_DBContext db = new Italika_DBContext())
                {
                    InventarioMoto oIngrediente = new InventarioMoto();
                    oIngrediente.Fert = oInventarioMotoRequest.Fert;
                    oIngrediente.Modelo = oInventarioMotoRequest.Modelo;
                    oIngrediente.Tipo = oInventarioMotoRequest.Tipo;
                    oIngrediente.NumeroSerie = oInventarioMotoRequest.NumeroSerie;
                    db.Entry(oIngrediente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }

        //elimiar datos
        [HttpDelete("{sku}")]
        public IActionResult Delete(string sku)
        {
            Response oResponse = new Response();

            try
            {
                using (Italika_DBContext db = new Italika_DBContext())
                {
                    InventarioMoto oInventarioMoto = db.InventarioMotos.Find(sku);
                    db.Remove(oInventarioMoto);
                    db.SaveChanges();

                    oResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }
    }
}
