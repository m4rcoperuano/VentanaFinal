using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentanaFinal.Infrastructure.Models.Cards
{
    public class CardModel
    {
        public int IdCard { get; set; }
        [Required]
        [Display(Name = "Card Name")]
        public string CardName { get; set; }
        public string FeaturedImage { get; set; }
        public string FrontImage { get; set; }
        public string BackImage { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int CreatedBy { get; set; }

        public List<WordingTemplateModel> WordingTemplates { get; set; }
    }
}
