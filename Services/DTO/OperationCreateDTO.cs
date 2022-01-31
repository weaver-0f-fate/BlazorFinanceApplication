using System;

namespace Services.DTO {
    public class OperationCreateDTO {
        public string Name { get; set; }
        public Guid OperationTypeId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }

        public OperationCreateDTO() {
            Date = DateTime.Now;
        }
    }
}
