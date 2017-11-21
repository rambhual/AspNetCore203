using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNet_core_203.Models {
    [Table ("Talk", Schema = "dbo")]
    public class Talk {
        [Key]
        public Guid TalkId { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public string Prerequisites { get; set; }
        public DateTime StartingTime { get; set; } = DateTime.Now;
        public string Room { get; set; }

        public Speaker Speaker { get; set; }

        public byte[] RowVersion { get; set; }
    }
}