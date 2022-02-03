using System;
using System.ComponentModel.DataAnnotations;

namespace Services.DTO {
    public class OperationCreateDTO {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public Guid OperationTypeId { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        
        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }
    }
}
