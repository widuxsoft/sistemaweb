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
    
    public partial class tap_tablas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tap_tablas()
        {
            this.tam_productos = new HashSet<tam_productos>();
            this.tam_productos1 = new HashSet<tam_productos>();
        }
    
        public decimal cod_tabla { get; set; }
        public string codigo { get; set; }
        public string valor { get; set; }
        public decimal id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tam_productos> tam_productos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tam_productos> tam_productos1 { get; set; }
    }
}
