using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAllAPI();
            ML.Producto producto = new ML.Producto();
            producto.Productos = result.Objects;
            return View(producto);
        }
        [HttpGet]//Mostrar el formulario
        public ActionResult Form(string SKU) //Add , Update
        {
            ML.Producto producto = new ML.Producto();
            if (SKU == null)//Add
            {
                producto.Accion = "Add";
                return View(producto);
            }
            else //Update
            {
                producto.Accion = "Update";
                ML.Result result = BL.Producto.GetProductogetBySKUAPI(SKU);

                if (result.Correct)
                {
                    producto.SKU = ((ML.Producto)result.Object).SKU;
                    producto.Fert = ((ML.Producto)result.Object).Fert;
                    producto.Modelo = ((ML.Producto)result.Object).Modelo;
                    producto.Tipo = ((ML.Producto)result.Object).Tipo;
                    producto.NumeroDeSerie = ((ML.Producto)result.Object).NumeroDeSerie;
                    producto.Fecha = ((ML.Producto)result.Object).Fecha;


                    return View(producto);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }


        }

        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            if (producto.Accion == "Add")//Add
            {
                result = BL.Producto.AddAPI(producto);
                ViewBag.Message = "El producto se agregó correctamente ";
            }
            else //Update
            {
                
                result = new ML.Result();
                result = BL.Producto.UpdateAPI(producto);
                ViewBag.Message = "El producto se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente la materia " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(string SKU)
        {
            ML.Result result = BL.Producto.DeleteAPI(SKU);
            return RedirectToAction("GetAll");
        }
    }
}