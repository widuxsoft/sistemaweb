//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace comerciales.Contexto
{
    using System;
    using System.Collections.Generic;
    
    public partial class tam_pedidos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tam_pedidos()
        {
            this.tar_pedidos_detall = new HashSet<tar_pedidos_detall>();
        }
    
        public Nullable<decimal> id_cliente { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fecha_finalizado { get; set; }
        public decimal id { get; set; }
        public string calle { get; set; }
        public Nullable<decimal> numero { get; set; }
        public string depto { get; set; }
        public string piso { get; set; }
        public string manzana { get; set; }
        public string lote { get; set; }
        public Nullable<decimal> cod_localidad { get; set; }
    
        public virtual tam_localidades tam_localidades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tar_pedidos_detall> tar_pedidos_detall { get; set; }
        public virtual tam_clientes tam_clientes { get; set; }
    }
}
