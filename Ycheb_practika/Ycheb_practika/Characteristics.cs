//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ycheb_practika
{
    using System;
    using System.Collections.Generic;
    
    public partial class Characteristics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Characteristics()
        {
            this.Storage = new HashSet<Storage>();
        }
    
        public int ID_Characteristics { get; set; }
        public string Dimensions { get; set; }
        public Nullable<int> Wheels { get; set; }
        public Nullable<int> Frame { get; set; }
        public Nullable<int> Gearbox { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Storage> Storage { get; set; }
    }
}
