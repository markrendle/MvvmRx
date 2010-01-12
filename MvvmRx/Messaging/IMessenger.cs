using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmRx.Messaging
{
public interface IMessenger : IObservable<IMessage>
{
    void Send(IMessage message);
}
}
