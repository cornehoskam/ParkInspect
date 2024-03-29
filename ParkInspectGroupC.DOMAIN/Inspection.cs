//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkInspectGroupC.DOMAIN
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inspection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inspection()
        {
            this.Coordinate = new HashSet<Coordinate>();
            this.InspectionImage = new HashSet<InspectionImage>();
            this.Questionnaire = new HashSet<Questionnaire>();
        }
    
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int RegionId { get; set; }
        public string Location { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public Nullable<int> InspectorId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateUpdated { get; set; }
    
        public virtual Assignment Assignment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coordinate> Coordinate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual InspectionStatus InspectionStatus { get; set; }
        public virtual Region Region { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InspectionImage> InspectionImage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questionnaire> Questionnaire { get; set; }
    }
}
