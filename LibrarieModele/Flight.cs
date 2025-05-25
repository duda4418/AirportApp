using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LibrarieModele
{
    // Enum that defines the possible flight types
    public enum FlightType
    {
        Departure,
        Arrival,
        Unknown
    }

    // Enum that defines the possible flight statuses with flags
    [Flags]
    public enum FlightStatus
    {
        None = 0,
        OnTime = 1,
        Delayed = 2,
        Boarding = 4,
        InAir = 8,
        Landed = 16,
        Cancelled = 32,
        Diverted = 64,
        CheckIn = 128
    }

    public class Flight
    {
        public string city { get; set; }
        public DateTime time { get; set; }
        public int gate
        {
            get; set;
        }
        public FlightStatus status { get; set; }  // Changed from string to FlightStatus enum
        public FlightType flightType { get; set; }
        public int flightId { get; set; }
        public const char SEPARATOR_PRINCIPAL = ';';

        public Flight(string linieFisier)
        {
            var parts = linieFisier.Split(SEPARATOR_PRINCIPAL);
            if (parts.Length >= 6)
            {
                flightId = int.Parse(parts[0]);
                city = parts[1];
                time = DateTime.ParseExact(parts[2], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture); gate = int.Parse(parts[3]);

                // Parse the string to FlightStatus enum
                status = ParseFlightStatus(parts[4]);

                // Parse the string to FlightType enum
                if (Enum.TryParse(parts[5], out FlightType type))
                {
                    flightType = type;
                }
                else
                {
                    flightType = FlightType.Unknown;
                }
            }
        }

        private FlightStatus ParseFlightStatus(string statusString)
        {
            // Try to parse directly as a single status
            if (Enum.TryParse(statusString, out FlightStatus parsedStatus))
            {
                return parsedStatus;
            }

            // If direct parsing fails, try to parse as a combination of flags
            FlightStatus combinedStatus = FlightStatus.None;

            // Split by comma or pipe if there are multiple statuses
            string[] statusParts = statusString.Split(new[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in statusParts)
            {
                string trimmedPart = part.Trim();
                if (Enum.TryParse(trimmedPart, out FlightStatus singleStatus))
                {
                    combinedStatus |= singleStatus;
                }
            }

            return combinedStatus != FlightStatus.None ? combinedStatus : FlightStatus.None;
        }

        public string ToStringFisier()
        {
            return $"{flightId}{SEPARATOR_PRINCIPAL}{city}{SEPARATOR_PRINCIPAL}{time:yyyy-MM-dd HH:mm}{SEPARATOR_PRINCIPAL}{gate}{SEPARATOR_PRINCIPAL}{status}{SEPARATOR_PRINCIPAL}{flightType}";
        }

        public Flight()
        {
            city = string.Empty;
            status = FlightStatus.None;
            flightType = FlightType.Unknown;
        }

        public Flight(string _city, DateTime _time, int _gate, FlightStatus _status, FlightType _flightType, int _flightId)
        {
            city = _city;
            time = _time;
            gate = _gate;
            status = _status;
            flightType = _flightType;
            flightId = _flightId;
        }

        // Overload constructor to handle string parameters for backward compatibility
        public Flight(string _city, DateTime _time, int _gate, string _status, string _flightType, int _flightId)
        {
            city = _city;
            time = _time;
            gate = _gate;

            // Parse the status string
            status = ParseFlightStatus(_status);

            // Parse the flight type string
            if (Enum.TryParse(_flightType, out FlightType type))
            {
                flightType = type;
            }
            else
            {
                flightType = FlightType.Unknown;
            }

            flightId = _flightId;
        }

        public string DisplayFlight()
        {
            return $"{flightType}: {city}, Time: {time}, Gate: {gate}, Status: {status}";
        }

        // Helper method to get a readable status string
        public string GetStatusString()
        {
            if (status == FlightStatus.None)
                return "Unknown";

            return status.ToString();
        }
    }
}