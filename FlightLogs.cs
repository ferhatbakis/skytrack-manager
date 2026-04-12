using System;

namespace AviationLogbook.Models
{
    public class FlightLogs
    {
        public int LogId { get; set; }
        public DateTime FlightDate { get; set; }
        public string OriginICAO { get; set; }
        public string DestinationICAO { get; set; }
        public int DurationMinutes { get; set; }
        public double DayHours { get; set; }
        public double NightHours { get; set; }
        public int Takeoffs { get; set; }
        public int Landings { get; set; }
        public int AircraftId { get; set; }
        public string Notes { get; set; }

        // Toplam süreyi saat cinsinden döndüren yardımcı metot
        public double TotalHours => DurationMinutes / 60.0;
    }
}