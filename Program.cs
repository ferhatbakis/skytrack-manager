using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQLite kullanıyorsan System.Data.SQLite
using AviationLogbook.Models;

namespace AviationLogbook.Data
{
    public class DatabaseHelper
    {
        private string connectionString = "Server=YOUR_SERVER;Database=AviationLogbook;Trusted_Connection=True;";

        // Yeni bir uçuş kaydı ekleme metodu
        public void AddFlightLog(FlightLog log)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO FlightLogs (FlightDate, OriginICAO, DestinationICAO, DurationMinutes, Takeoffs, Landings, Notes) 
                                VALUES (@date, @origin, @dest, @duration, @takeoff, @landing, @notes)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", log.FlightDate);
                cmd.Parameters.AddWithValue("@origin", log.OriginICAO);
                cmd.Parameters.AddWithValue("@dest", log.DestinationICAO);
                cmd.Parameters.AddWithValue("@duration", log.DurationMinutes);
                cmd.Parameters.AddWithValue("@takeoff", log.Takeoffs);
                cmd.Parameters.AddWithValue("@landing", log.Landings);
                cmd.Parameters.AddWithValue("@notes", log.Notes ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Tüm uçuşları listeleme metodu
        public List<FlightLog> GetAllLogs()
        {
            List<FlightLog> logs = new List<FlightLog>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM FlightLogs ORDER BY FlightDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    logs.Add(new FlightLog
                    {
                        LogId = (int)reader["LogId"],
                        OriginICAO = reader["OriginICAO"].ToString(),
                        DestinationICAO = reader["DestinationICAO"].ToString(),
                        DurationMinutes = (int)reader["DurationMinutes"],
                        FlightDate = (DateTime)reader["FlightDate"]
                    });
                }
            }
            return logs;
        }
    }
}
