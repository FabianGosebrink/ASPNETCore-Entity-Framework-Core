using System.ComponentModel.DataAnnotations;

namespace AspnetCoreEFCoreExample.Models
{
    public class MyModelViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
