//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecordShack.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUserRole
    {
        public int UserRoleID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
    
        public virtual tblRole tblRole { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
