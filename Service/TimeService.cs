namespace LR3.Service
{
    public interface ITimeService
    {
        string GetTimeOfDay();
    }
    public class TimeService : ITimeService
    {
        public string GetTimeOfDay()
        {
            var currentTime = DateTime.Now;
            if (currentTime.Hour >=6 && currentTime.Hour < 12)
            {
                return "Зараз ранок";
            }
            if (currentTime.Hour >= 12 && currentTime.Hour < 18)
            {
                return "Зараз день";
            }
            else if (currentTime.Hour >= 18 && currentTime.Hour < 24)
            {
                return "Зараз вечір";
            }
            else if (currentTime.Hour >= 0 && currentTime.Hour < 6)
            {
                return "Зараз ніч";
            }
            else
            {
                return "Зараз ранок";
            }
        }
    }
}
