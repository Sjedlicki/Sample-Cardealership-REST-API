using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCRestApi.DataTransferObjects
{
    public class CarCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Make { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Model { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string Year { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Color { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; }
    }
}
