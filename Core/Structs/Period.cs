using System;

namespace Core.Structs {
    public class Period {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void AddMonth() {
            StartDate = StartDate.AddMonths(1);
            EndDate = EndDate.AddMonths(1);
        }
        public void ExtractMonth() {
            StartDate = StartDate.AddMonths(-1);
            EndDate = EndDate.AddMonths(-1);
        }
    }
}
