﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BranchbitEntities : DbContext
    {
        public BranchbitEntities()
            : base("name=BranchbitEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ProductoItalika> ProductoItalikas { get; set; }
    
        public virtual int ProductoAdd(string sKU, string fert, string modelo, string tipo, string numeroSerie)
        {
            var sKUParameter = sKU != null ?
                new ObjectParameter("SKU", sKU) :
                new ObjectParameter("SKU", typeof(string));
    
            var fertParameter = fert != null ?
                new ObjectParameter("Fert", fert) :
                new ObjectParameter("Fert", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            var numeroSerieParameter = numeroSerie != null ?
                new ObjectParameter("NumeroSerie", numeroSerie) :
                new ObjectParameter("NumeroSerie", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoAdd", sKUParameter, fertParameter, modeloParameter, tipoParameter, numeroSerieParameter);
        }
    
        public virtual int ProductoDelete(string sKU)
        {
            var sKUParameter = sKU != null ?
                new ObjectParameter("SKU", sKU) :
                new ObjectParameter("SKU", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoDelete", sKUParameter);
        }
    
        public virtual int ProductoUpdate(string sKU, string fert, string modelo, string tipo, string numeroSerie)
        {
            var sKUParameter = sKU != null ?
                new ObjectParameter("SKU", sKU) :
                new ObjectParameter("SKU", typeof(string));
    
            var fertParameter = fert != null ?
                new ObjectParameter("Fert", fert) :
                new ObjectParameter("Fert", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            var numeroSerieParameter = numeroSerie != null ?
                new ObjectParameter("NumeroSerie", numeroSerie) :
                new ObjectParameter("NumeroSerie", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoUpdate", sKUParameter, fertParameter, modeloParameter, tipoParameter, numeroSerieParameter);
        }
    
        public virtual int UsuarioGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioGetAll");
        }
    
        public virtual ObjectResult<ProductosGetAll_Result> ProductosGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductosGetAll_Result>("ProductosGetAll");
        }
    
        public virtual ObjectResult<ProductosGetProductogetBySKU_Result> ProductosGetProductogetBySKU(string sKU)
        {
            var sKUParameter = sKU != null ?
                new ObjectParameter("SKU", sKU) :
                new ObjectParameter("SKU", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductosGetProductogetBySKU_Result>("ProductosGetProductogetBySKU", sKUParameter);
        }
    }
}
