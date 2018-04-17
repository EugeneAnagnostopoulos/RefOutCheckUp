﻿using System;

using static System.Console;
using static RefOutCheckUp.ThatIsAllYouGot;
using static System.Threading.Tasks.Task;
using System.Threading;

namespace RefOutCheckUp
{
    class Program
    {
        public static void Main(string[] args)
        {
            awaitSpain();
            awaitItaly();

            ReadLine();
        }

        private protected static ThreadStart awaitSpain = async () => 
        {
            using (var spain = new Spain())
            {
                await Run(() =>
                {
                    spain.Madrid(ref x, ref y);
                    WriteLine($"{nameof(x)} has now become: {x}");
                    WriteLine($"{nameof(y)} has now become: {y}");
                });
            }

            using (var spain = new Spain())
            {
                await Run(() => {
                    spain.Barcelona(ref x, ref y);
                    WriteLine($"{nameof(x)} has now become: {x}");
                    WriteLine($"{nameof(y)} has now become: {y}");
                });
            }
        };

        private protected static ThreadStart awaitItaly = async () => 
        {
            using (var italy = new Italy())
            {
                await Run(() => {
                    italy.Rome(x, y);
                    WriteLine($"{nameof(x)} has now become: {x}");
                    WriteLine($"{nameof(y)} has now become: {y}");
                });
            }

            using (var italy = new Italy())
            {
                await Run(() => {
                    italy.Milan(x, y, out var cValue);
                    WriteLine($"{nameof(x)} has now become: {x}");
                    WriteLine($"{nameof(y)} has now become: {y}");
                });
            }

            using (var italy = new Italy())
            {
                await Run(() => {
                    italy.SanRemo(ref x, ref y, out var cValue);
                    WriteLine($"{nameof(x)} has now become: {x}");
                    WriteLine($"{nameof(y)} has now become: {y}");
                });
            }
        };
    }

    internal class Spain : IDisposable
    {
        protected internal void Madrid(ref short a, ref short b)
        {
            short? c = null;
            c = (short)((a + 15) + (b + 10));
            WriteLine($"\n{nameof(c)} value adds up to: {c}");
        }

        protected internal void Barcelona(ref short a, ref short b)
        {            
            a = (short)(a + 15);
            b = (short)(b + 10);
            short? c = null;
            
            c = (short)(a + b);
            WriteLine($"\n{nameof(c)} value adds up to: {c}");
        }

        public void Dispose() => (x, y) = (default, default);
    }

    internal class Italy : IDisposable
    {
        protected internal void Rome(int a, int b)
        {
            a = a + 15;
            b = b + 10;
            int? c = null;

            c = a + b;
            WriteLine($"\n{nameof(c)} value adds up to: {c}");
        }

        protected internal void Milan(int a, int b, out byte? c)
        {
            a += 100;
            b += 99;
            c = (byte)(a - b);
            WriteLine($"\n{nameof(c)} value adds up to: {c}");
        }

        protected internal void SanRemo(ref short a, ref short b, out byte? c)
        {
            a += 100;
            b += 99;
            c = (byte)(a - b);
            WriteLine($"\n{nameof(c)} value adds up to: {c}");
        }

        public void Dispose() => (x, y) = (default, default);
    }

    internal class ThatIsAllYouGot
    {
        public static short x = default;
        public static short y = default;
    }
}
