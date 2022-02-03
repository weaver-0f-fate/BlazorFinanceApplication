using System;

namespace Core.Models {
    public class Operation : AbstractModel {
        public OperationType OperationTypeDTO { get; set; }
        public Guid OperationTypeId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public Operation() {
            Id = Guid.Empty;
            Date = DateTime.Now;
            OperationTypeId = new Guid();
        }
    }
}
