using System;
namespace Weight.Util
{
    public class Random : IGenerator
    {
        ulong state0;
        ulong state1;
        ulong last;
        ulong divider;

        bool useNegative;

        object _lock_;

        public bool UseNegative
        {
            get => useNegative;
            set
            {
                useNegative = value;
                if (useNegative)
                {
                    this.divider = ulong.MaxValue / 2ul;
                }
                else
                {
                    this.divider = ulong.MaxValue;
                }
            }
        }
        public double Scale { get; set; }

        public double Current
        {
            get
            {
                double value = (double)last / divider;
                if (UseNegative)
                {
                    value -= 1.0d;
                }
                return value * Scale;
            }
        }

        public Random() : this((ulong)DateTime.Now.Ticks){}

        public Random(ulong seed) : this(seed, seed){}

        public Random(ulong seed0, ulong seed1)
        {
            this.state0 = seed0;
            this.state1 = seed1;
            this.last = 0ul;
            this.divider = ulong.MaxValue;

            UseNegative = false;
            Scale = 1.0;

            _lock_ = new object();
        }

        public double Next()
        {
            lock (_lock_)
            {
                var s1 = state0;
                var s0 = state1;
                s1 ^= s1 << 23;
                s1 ^= s1 >> 17;
                s1 ^= s0;
                s1 ^= s0 >> 26;
                (state0, state1) = (s0, s1);
                last = s0 + s1;
                return Current;
            }
        }
    }
}
