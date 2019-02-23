using System;
using System.Text.RegularExpressions;

namespace WorkshopCsharp
{
    public struct Moment : IEquatable<Moment>, IComparable<Moment>
    {
        private readonly byte hours;
        private readonly byte minutes;
        private readonly byte seconds;

        /// <summary>
        /// Return hour part of time
        /// </summary>
        public byte Hours => hours;

        /// <summary>
        /// Return minute part of time
        /// </summary>
        public byte Minutes => minutes;

        /// <summary>
        /// Return second part of time
        /// </summary>
        public byte Seconds => seconds;

        /// <summary>
        /// Return whole seconds of time
        /// </summary>
        public long FullSeconds => hours * 3600 + minutes * 60 + seconds;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="_hours">Hour part of time</param>
        /// <param name="_minutes">Minute part of time</param>
        /// <param name="_seconds">Seconds part of time</param>
        public Moment(byte _hours, byte _minutes, byte _seconds)
        {
            if (_hours > 23)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_minutes > 59)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_seconds > 59)
            {
                throw new ArgumentOutOfRangeException();
            }
            hours = _hours;
            minutes = _minutes;
            seconds = _seconds;
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="_hours">Hour part of time</param>
        /// <param name="_minutes">Minute part of time</param>
        public Moment(byte _hours, byte _minutes)
        {
            if (_hours > 23)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_minutes > 59)
            {
                throw new ArgumentOutOfRangeException();
            }
            hours = _hours;
            minutes = _minutes;
            seconds = 00;
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="_hours">Hour part of time</param>
        public Moment(byte _hours)
        {
            if (_hours > 23)
            {
                throw new ArgumentOutOfRangeException();
            }
            hours = _hours;
            minutes = 0;
            seconds = 0;
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="_time">Whole time in HH:MM:SS format</param>
        public Moment(string _time)
        {
            Regex regTime = new Regex("^([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
            if (!regTime.IsMatch(_time))
            {
                throw new FormatException();
            }

            string[] time = _time.Split(':');

            hours = Byte.Parse(time[0]);
            minutes = Byte.Parse(time[1]);
            seconds = Byte.Parse(time[2]);
        }

        /// <summary>
        /// Returns time in HH:MM:SS format
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string
                h = Hours.ToString(),
                m = Minutes.ToString(),
                s = Seconds.ToString();

            if (Hours < 10)
            {
                h = "0" + h;
            }

            if (Minutes < 10)
            {
                m = "0" + m;
            }

            if (Seconds < 10)
            {
                s = "0" + s;
            }

            return $"{h}:{m}:{s}";
        }

        /// <summary>
        /// Retruns hash of class instance
        /// </summary>
        /// <returns>int</returns>
        public override int GetHashCode()
        {
            var hashCode = 348691324;
            hashCode = hashCode * -1521134295 + hours.GetHashCode();
            hashCode = hashCode * -1521134295 + minutes.GetHashCode();
            hashCode = hashCode * -1521134295 + seconds.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Checks if two time classes are equal
        /// </summary>
        /// <param name="other">Another time instance</param>
        /// <returns>bool</returns>
        public bool Equals(Moment other)
        {
            if ((object)other == null) throw new ArgumentNullException();

            return hours == other.Hours && minutes == other.Minutes && seconds == other.Seconds;
        }

        /// <summary>
        /// Checks if two time classes are equal
        /// </summary>
        /// <param name="other">Another time instance</param>
        /// <returns>bool</returns>
        public override bool Equals(object other)
        {
            if (other == null) throw new ArgumentNullException();

            return this.Equals((Moment)other);
        }

        /// <summary>
        /// Comparing two time class instances if them are equal or not.
        /// Returns 0 if equal, 1 if first is greater, -1 if first is lesser
        /// </summary>
        /// <param name="other">Another time instance</param>
        /// <returns>int</returns>
        public int CompareTo(Moment other)
        {
            if (hours > other.Hours)
                return 1;

            if (hours < other.Hours)
                return -1;

            if (minutes > other.Minutes)
                return 1;

            if (minutes < other.Minutes)
                return -1;

            if (seconds > other.Seconds)
                return 1;

            if (seconds < other.Seconds)
                return -1;

            return 0;
        }

        /// <summary>
        /// Checks if two time classes are equal
        /// </summary>
        /// <param name="t1">First time instance</param>
        /// <param name="t2">Second time instance</param>
        /// <returns>bool</returns>
        public static bool operator ==(Moment t1, Moment t2)
        {
            return t1.Equals(t2);
        }

        /// <summary>
        /// Checks if two time classes are not equal
        /// </summary>
        /// <param name="t1">First time instance</param>
        /// <param name="t2">Second time instance</param>
        /// <returns>bool</returns>
        public static bool operator !=(Moment t1, Moment t2)
        {
            return !t1.Equals(t2);
        }

        /// <summary>
        /// Check if first instance is greater than second instance
        /// </summary>
        /// <param name="t1">First time instance</param>
        /// <param name="t2">Second time instance</param>
        /// <returns>bool</returns>
        public static bool operator >(Moment t1, Moment t2)
        {
            return t1.CompareTo(t2) == 1;
        }

        /// <summary>
        /// Check if first instance is lesser than second instance
        /// </summary>
        /// <param name="t1">First time instance</param>
        /// <param name="t2">Second time instance</param>
        /// <returns>bool</returns>
        public static bool operator <(Moment t1, Moment t2)
        {
            return t1.CompareTo(t2) == -1;
        }

        /// <summary>
        /// Check if first instance is greater than or equal to second instance
        /// </summary>
        /// <param name="t1">First time instance</param>
        /// <param name="t2">Second time instance</param>
        /// <returns>bool</returns>
        public static bool operator >=(Moment t1, Moment t2)
        {
            return t1.CompareTo(t2) != -1;
        }

        /// <summary>
        /// Check if first instance is lesser than or equal to second instance
        /// </summary>
        /// <param name="t1">First time instance</param>
        /// <param name="t2">Second time instance</param>
        /// <returns>bool</returns>
        public static bool operator <=(Moment t1, Moment t2)
        {
            return t1.CompareTo(t2) != 1;
        }
    }
}
