using Services.DataTransferObjects.OperationTypesDTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace Services.DataTransferObjects.OperationDTOs {
    public class OperationDTO : AbstractDTO {
        public OperationTypeDTO OperationTypeDTO { get; set; }
        public DateTime Date { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be positive.")]
        public int Amount { get; set; }
    }
}
