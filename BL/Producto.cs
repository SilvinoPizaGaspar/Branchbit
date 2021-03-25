using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAllAPI()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:22140/api/");
                    var responseTask = client.GetAsync("Producto");
                    responseTask.Wait();
                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        result.Objects = new List<object>();
                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Producto producto = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetProductogetBySKUAPI(string SKU)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:22140/api/");
                    var responseTask = client.GetAsync("Producto/" + SKU);
                    responseTask.Wait();
                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        result.Objects = new List<object>();
                        
                        ML.Producto producto = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());
                        result.Object = producto;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result AddAPI(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:22140/api/");

                    var postTask = client.PostAsJsonAsync<ML.Producto>("Producto", producto);
                    postTask.Wait();

                    var resultAPI = postTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result UpdateAPI(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:22140/api/");

                    var putTask = client.PutAsJsonAsync<ML.Producto>("Producto", producto);
                    putTask.Wait();

                    var resultAPI = putTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result DeleteAPI(string SKU)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:22140/api/");
                    //HTTP POST
                    var deleteTask = client.DeleteAsync("Producto/" + SKU);

                    deleteTask.Wait();

                    var resultAPI = deleteTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAllProducto()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BranchbitEntities context = new DL.BranchbitEntities())
                {
                    var query = context.ProductosGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.SKU = obj.SKU;
                            producto.Fert = obj.Fert;
                            producto.Modelo = obj.Modelo;
                            producto.Tipo = obj.Tipo;
                            producto.NumeroDeSerie = obj.NumeroSerie;
                            producto.Fecha = (DateTime)obj.Fecha;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetBySKUProducto(string SKU)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BranchbitEntities context = new DL.BranchbitEntities())
                {
                    var query = context.ProductosGetProductogetBySKU(SKU).FirstOrDefault();

                    if (query != null)
                    {
                            ML.Producto producto = new ML.Producto();
                            producto.SKU = query.SKU;
                            producto.Fert = query.Fert;
                            producto.Modelo = query.Modelo;
                            producto.Tipo = query.Tipo;
                            producto.NumeroDeSerie = query.NumeroSerie;
                            producto.Fecha = (DateTime)query.Fecha;

                            result.Object = producto;
                        
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result AddProducto(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BranchbitEntities context = new DL.BranchbitEntities())
                {
                    var query = context.ProductoAdd(producto.SKU, producto.Fert, producto.Modelo, producto.Tipo, producto.NumeroDeSerie);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el producto correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result UpdateProducto(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BranchbitEntities context = new DL.BranchbitEntities())
                {
                    var query = context.ProductoUpdate(producto.SKU, producto.Fert, producto.Modelo, producto.Tipo, producto.NumeroDeSerie);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el producto correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result DeleteProducto(string SKU)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BranchbitEntities context = new DL.BranchbitEntities())
                {
                    var query = context.ProductoDelete(SKU);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el producto correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
