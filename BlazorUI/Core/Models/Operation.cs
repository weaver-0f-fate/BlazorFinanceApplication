using System;

namespace Core.Models {
    public class Operation : AbstractModel {
        public string OperationTypeName { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }

    }
}
