
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
    
public partial class WorkingHours
{

    public int EmployeeId { get; set; }

    public System.DateTime Date { get; set; }

    public Nullable<System.TimeSpan> StartTime { get; set; }

    public Nullable<System.TimeSpan> EndTime { get; set; }

    public System.DateTime DateCreated { get; set; }

    public System.DateTime DateUpdated { get; set; }



    public virtual Employee Employee { get; set; }

}

}
