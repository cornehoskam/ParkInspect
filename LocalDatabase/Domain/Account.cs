//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LocalDatabase.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserGuid { get; set; }
        public long EmployeeId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateUpdated { get; set; }
        public int ExistsInCentral { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
