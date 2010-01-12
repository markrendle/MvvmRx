using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq
{
    public static class IObservableExtensions
    {
        // Filter an IObservable for the specified type or derivatives
        public static IObservable<TResult> OfType<TResult>(this IObservable<object> source)
        {
            return OfType<TResult>(source, o => o is TResult);
        }

        // Filter an IObservable for the specified type not including derivatives
        public static IObservable<TResult> OfTypeExact<TResult>(this IObservable<object> source)
        {
            return OfType<TResult>(source, o => o.GetType() == typeof(TResult));
        }

        // Filter an IObservable using the  
        private static IObservable<TResult> OfType<TResult>(IObservable<object> source, Func<object, bool> typeCheck)
        {
            var subj = new Subject<TResult>();

            source.Subscribe(
                o => { if (typeCheck(o)) subj.OnNext((TResult)o); },
                ex => subj.OnError(ex),
                () => subj.OnCompleted()
                );

            return subj.Hide();
        }
    }
}
