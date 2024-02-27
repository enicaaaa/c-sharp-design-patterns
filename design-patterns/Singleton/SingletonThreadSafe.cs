using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns.Singleton
{
    class SingletonThreadSafe
    {        
        // We'll use this property to prove that our Singleton really works.
        public string? Value { get; set; }
        private static SingletonThreadSafe? _instance;

        // We have a lock object that will be used to synchronize threads
        // during first access to the Singleton.
        private static readonly object _lock = new object();

        public static SingletonThreadSafe GetInstance(string value)
        {
            // This conditional is needed to prevent threads stumbling over the
            // lock once the instance is ready.
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonThreadSafe();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        static void TestSingleton(string value)
        {
            SingletonThreadSafe singleton = SingletonThreadSafe.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
        public static void CallSingleton()
        {
            Console.WriteLine(
                        "{0}\n{1}\n\n{2}\n",
                        "If you see the same value, then singleton was reused (yay!)",
                        "If you see different values, then 2 singletons were created (booo!!)",
                        "RESULT:"
                    );

            Thread process1 = new(() =>
            {
                TestSingleton("FOO");
            });
            Thread process2 = new(() =>
            {
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }
    }
}
