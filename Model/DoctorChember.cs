//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DoctorChember
    {
        public int Id { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public string ChemberName { get; set; }
        public string ChembeAddress { get; set; }
        public string ChembeCity { get; set; }
        public string ChembeCountry { get; set; }
        public string ChembeMobileNo { get; set; }
        public string ChembeEmail { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> NotDeletable { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UserId { get; set; }
        public Nullable<int> CompanyId { get; set; }
    
        public virtual Doctor Doctor { get; set; }
    }
}
