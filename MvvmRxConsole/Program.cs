using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmRx.Messaging;
using System.Threading;

namespace MvvmRxConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger.Default.OfType<FooMessage>().Where(fm => fm.Bar.Length == 4).Subscribe(Receive);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Messenger.Default.Send(new FooMessage { Bar = "BAR!" });
            }
        }

        static void Receive(FooMessage foo)
        {
            Console.WriteLine(foo.Bar);
        }
    }

    class FooMessage : IMessage
    {
        public string Bar { get; set; }
    }
}
