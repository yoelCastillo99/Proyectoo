//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODELS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accesos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accesos()
        {
            this.Tipo_Trabajador = new HashSet<Tipo_Trabajador>();
        }
    
        public int Accesos_Id { get; set; }
        public string Descripcion { get; set; }
        public bool Ventas { get; set; }
        public bool Productos { get; set; }
        public bool Reportes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tipo_Trabajador> Tipo_Trabajador { get; set; }
    }
}
