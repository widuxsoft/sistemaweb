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
    
    public partial class tam_localidades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tam_localidades()
        {
            this.tam_sucursales = new HashSet<tam_sucursales>();
        }
    
        public Nullable<decimal> cod_provincia { get; set; }
        public decimal cod_localidad { get; set; }
        public string descripcion { get; set; }
    
        public virtual tam_provincias tam_provincias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tam_sucursales> tam_sucursales { get; set; }
    }
}
