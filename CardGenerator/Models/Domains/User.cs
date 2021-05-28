using DataAnnotationsExtensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardGenerator.Models.Domains
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Email]
        public string Email { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
