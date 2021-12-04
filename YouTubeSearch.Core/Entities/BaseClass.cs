using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Core.Entities
{
    public class BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
