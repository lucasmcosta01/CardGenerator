using System.ComponentModel.DataAnnotations.Schema;

namespace CardGenerator.Models.Domains
{
    public class Card
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Number { get; set; }
    }
}