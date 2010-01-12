using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmRx.Messaging
{
public class Messenger : IMessenger
{
    private readonly Subject<IMessage> _subject = new Subject<IMessage>();

    public IDisposable Subscribe(IObserver<IMessage> observer)
    {
        return _subject.Subscribe(observer);
    }

    public void Send(IMessage message)
    {
        _subject.OnNext(message);
    }

    private static readonly Messenger _default = new Messenger();

    public static Messenger Default
    {
        get { return _default; }
    }
}
}
