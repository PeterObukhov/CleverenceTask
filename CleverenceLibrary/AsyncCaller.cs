using System;
using System.Threading.Tasks;

namespace Cleverence
{
    public class AsyncCaller
    {
        private EventHandler _handler;
        public AsyncCaller(EventHandler h)
        {
            _handler = h;
        }
        public bool Invoke(int ms, object sender, EventArgs args)
        {
            var task = Task.Factory.StartNew(() => _handler(sender, args));
            return task.Wait(ms);
        }
    }
}
