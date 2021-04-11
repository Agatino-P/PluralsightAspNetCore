using System.ComponentModel.DataAnnotations;

namespace Psapnetcore.Core
{
    public partial class Restaurant
    {

        public int Id { get; set; }
        
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
