using System;

namespace Core.Models {
    public class Operation : AbstractModel {
        public OperationType OperationTypeDTO { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }

        public Operation() {
            Id = Guid.Empty;
            Date = DateTime.Now;
        }
    }
}
