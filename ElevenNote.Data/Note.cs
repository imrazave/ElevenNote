using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
    {
        // Primary Key
        [Key]
        public int NoteId { get; set; }

        //// Foreign Key
        //[ForeignKey(nameof(Category))]
        //public int Id { get; set; }

        // Navigation Property
        public virtual Categories Category { get; set; }
        
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
