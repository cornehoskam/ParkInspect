
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
    
public partial class Message
{

    public int Id { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public string Content { get; set; }

    public bool Read { get; set; }

    public System.DateTime DateCreated { get; set; }



    public virtual Employee Reciever { get; set; }

    public virtual Employee Sender { get; set; }

}

}
