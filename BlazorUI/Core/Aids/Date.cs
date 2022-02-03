using System;

namespace Core.Aids {
    public class Date {
        public DateTime CurrentDate { get; set; }

        public void AddDay() {
            CurrentDate = CurrentDate.AddDays(1);
        }

        public void ExtractDay() {
            CurrentDate = CurrentDate.AddDays(-1);
        }
    }
}
