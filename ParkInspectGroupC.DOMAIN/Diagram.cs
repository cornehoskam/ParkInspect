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
    
    public partial class Diagram
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int ReportSectionId { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual ReportSection ReportSection { get; set; }
    }
}