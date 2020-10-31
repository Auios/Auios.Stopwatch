using System;

namespace Auios.Stopwatch
{
    public class Stopwatch
    {
        private DateTime start;
        private DateTime end;
        private TimeSpan time = TimeSpan.Zero;
        private TimeSpan highest = TimeSpan.Zero;
        private bool isRunning;

        public Stopwatch()
        {
            Reset();
        }

        public void Start()
        {
            if(!isRunning)
            {
                start = DateTime.Now;
                isRunning = true;
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                isRunning = false;
                end = DateTime.Now;
                time = end - start;
                if (time > highest) highest = time;
            }
        }

        public void Reset()
        {
            time = TimeSpan.Zero;
            highest = TimeSpan.Zero;
            isRunning = false;
        }

        // Time
        public float Ms() => (float)time.TotalMilliseconds;
        public float Seconds() => (float)time.TotalSeconds;
        public float Minutes() => (float)time.TotalMinutes;
        public long Ticks() => time.Ticks;

        // Highest time
        public float HighestMs() => (float)highest.TotalMilliseconds;
        public float HighestSeconds() => (float)highest.TotalSeconds;
        public float HighestMinutes() => (float)highest.TotalMinutes;
        public long HighestTicks() => highest.Ticks;
    }
}
