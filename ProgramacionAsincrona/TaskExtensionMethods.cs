using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramacionAsincrona
{
    public static class TaskExtensionMethods
    {
        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken ct)
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            using (ct.Register(state =>
            {
                ((TaskCompletionSource<object>)state).TrySetResult(null);
            }, tcs))
            {
                var resultado = await Task.WhenAny(task, tcs.Task);

                if (resultado == tcs.Task)
                {
                    throw new OperationCanceledException(ct);
                }

                return await task;
            }
        }
    }
}
