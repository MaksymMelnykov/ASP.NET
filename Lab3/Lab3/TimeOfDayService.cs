namespace Lab3
{
    public class TimeOfDayService
    {
        public string GetTimeOfDay()
        {
            DateTime currentTime = DateTime.Now;
            int hours = currentTime.Hour;

            if (hours >= 12 && hours < 18) 
            {
                return "Зараз день!";
            }
            else if (hours >= 18 || hours < 0)
            {
                return "Зараз вечір!";
            }
            else if (hours >= 6 && hours < 12)
            {
                return "Зараз ранок!";
            }
            else
            {
                return "Зараз ніч!";
            }

        }
    }
}
