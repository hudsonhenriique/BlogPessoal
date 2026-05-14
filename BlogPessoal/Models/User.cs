using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PersonalBlog.Models
{
    public class  User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório!")]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "O email do usuário é inválido!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        [StringLength(5000)]
        public string? Photo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Post>? Posts { get; set; }
    }
}