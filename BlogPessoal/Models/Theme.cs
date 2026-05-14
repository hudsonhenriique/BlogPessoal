using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PersonalBlog.Models
{
    public class Theme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "A descrição do tema é obrigatória!")]
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Post>? Posts { get; set; }
    }
}
