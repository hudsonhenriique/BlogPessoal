using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalBlog.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O título do post é obrigatório!")]
        [StringLength(100,MinimumLength = 5,ErrorMessage = "O título deve ter entre 5 e 100 caracteres")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "O texto do Post é obrigatório!")]
        [StringLength(5000, MinimumLength = 10, ErrorMessage = "O texto deve ter entre 10 e 5000 caracteres")]
        public string Content { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Now;

        public string? AiSummary { get; set; }
        public string? AiTags { get; set; }
        public string? AiCategory { get; set; }

        public long ThemeId { get; set; }
        public virtual Theme? Theme { get; set; }

        public long UserId { get; set; }
        public virtual User? User { get; set; }
    }
}