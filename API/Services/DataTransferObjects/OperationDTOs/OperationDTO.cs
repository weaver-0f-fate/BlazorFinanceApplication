using Services.DataTransferObjects.OperationTypesDTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace Services.DataTransferObjects.OperationDTOs {
    public class OperationDTO : AbstractDTO {
        public OperationTypeDTO OperationTypeDTO { get; set; }
        public DateTime Date { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Amount should be positive.")]
        public double Amount { get; set; }
    }
}
