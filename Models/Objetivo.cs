using System.ComponentModel.DataAnnotations;

namespace TODOList.Models
{
    public class Objetivo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        public bool Completo { get; set; }
    }
}
