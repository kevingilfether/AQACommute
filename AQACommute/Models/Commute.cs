//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AQACommute.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Commute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commute()
        {
            this.CommuteLocations = new HashSet<CommuteLocation>();
        }
    
        public int CommuteID { get; set; }

        [Display(Name = "Commute Time")]
        public string CommuteTime { get; set; }

        [Display(Name = "Start Point")]
        public string StartPoint { get; set; }

        [Display(Name = "End Point")]
        public string EndPoint { get; set; }

        [Display(Name = "Total Miles")]
        public Nullable<double> TotalMiles { get; set; }

        [Display(Name = "CO2 Generated Lbs")]
        public double CO2GeneratedLbs { get; set; }

        [Display(Name = "Transport Method")]
        public int TransportMethodID { get; set; }
        public virtual TransportMethod TransportMethod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [Display(Name = "Commute Locations")]
        public virtual ICollection<CommuteLocation> CommuteLocations { get; set; }
    }
}
