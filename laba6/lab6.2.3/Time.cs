namespace lab6._2._3
{
    public class Time
    {
        public byte Hours;
        public byte Minutes;
        public byte Seconds;

        public Time() { }

        public Time(int hours, int minutes, int seconds)
        {
            try
            {
                if (hours < 0 || hours > 23)
                {
                    throw new ArgumentOutOfRangeException("Часы должны быть в диапазоне от 0 до 23.");
                }
                if (minutes < 0 || minutes > 59)
                {
                    throw new ArgumentOutOfRangeException("Минуты должны быть в диапазоне от 0 до 59.");
                }
                if (seconds < 0 || seconds > 59)
                {
                    throw new ArgumentOutOfRangeException("Секунды должны быть в диапазоне от 0 до 59.");
                }

                Hours = (byte)hours;
                Minutes = (byte)minutes;
                Seconds = (byte)seconds;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Environment.Exit(1);
            }
        }

        public Time(Time other)
        {
            this.Hours = other.Hours;
            this.Minutes = other.Minutes;
            this.Seconds = other.Seconds;
        }

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        public Time Subtract(Time other)
        {
            int totalSeconds1 = Hours * 3600 + Minutes * 60 + Seconds;
            int totalSeconds2 = other.Hours * 3600 + other.Minutes * 60 + other.Seconds;

            int diffSeconds = totalSeconds1 - totalSeconds2;

            if (diffSeconds < 0)
            {
                diffSeconds += 24 * 3600;
            }

            return new Time(diffSeconds / 3600, (diffSeconds % 3600) / 60, diffSeconds % 60);


        }

        public static Time operator ++(Time time)
        {
            time.Minutes++;
            if (time.Minutes >= 60)
            {
                time.Minutes -= 60;
                time.Hours++;
                if (time.Hours >= 24)
                {
                    time.Hours -= 24;
                }
            }
            return time;
        }

        public static Time operator --(Time time)
        {
            Time newTime = new Time(time); 
            newTime.Minutes--;
            if (newTime.Minutes < 0)
            {
                newTime.Minutes += 60;
                newTime.Hours--;
                if (newTime.Hours < 0)
                {
                    newTime.Hours += 24;
                }
            }
            return newTime;
        }



        public static Time operator -(Time t1, Time t2)
        {
            return t1.Subtract(t2);
        }

        public static implicit operator int(Time time)
        {
            return time.Hours * 60 + time.Minutes;
        }

        public static explicit operator bool(Time time)
        {
            return time.Hours != 0 || time.Minutes != 0 || time.Seconds != 0;
        }

        public static bool operator <(Time t1, Time t2)
        {
            return (int)t1 < (int)t2;
        }

        public static bool operator >(Time t1, Time t2)
        {
            return (int)t1 > (int)t2;
        }
    }
}
