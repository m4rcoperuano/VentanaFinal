//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentanaFinal.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class Card_WordingTemplates
    {
        public Card_WordingTemplates()
        {
            this.Card_WordingTemplates_TemplateFields = new HashSet<Card_WordingTemplates_TemplateFields>();
        }
    
        public int id_wording_template { get; set; }
        public string TemplateName { get; set; }
        public int fk_card { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
    
        public virtual Card Card { get; set; }
        public virtual ICollection<Card_WordingTemplates_TemplateFields> Card_WordingTemplates_TemplateFields { get; set; }
    }
}
