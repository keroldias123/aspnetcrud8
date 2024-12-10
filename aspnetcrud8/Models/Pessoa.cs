using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aspnetcrud8.Models
{
    public class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Marca o campo como auto-incremento
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
