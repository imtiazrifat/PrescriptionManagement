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
    
    public partial class PrescriptionDrug
    {
        public int Id { get; set; }
        public Nullable<int> PrescriptionId { get; set; }
        public Nullable<int> DrugId { get; set; }
        public string SpecialInstruction { get; set; }
        public string BeforeOrAfter { get; set; }
        public string TakingProcedure { get; set; }
        public string DrugQuantity { get; set; }
        public string Note { get; set; }
        public string Extra { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> NotDeletable { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UserId { get; set; }
        public Nullable<int> CompanyId { get; set; }
    
        public virtual Drug_Details Drug_Details { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}