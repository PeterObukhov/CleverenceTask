using System.Threading;

namespace Cleverence
{
    public class Server
    {
        private static int _count;
        public static int GetCount()
        {
            return Interlocked.CompareExchange(ref _count, 0, 0);
        }
        public static void AddToCount(int value)
        {
            Interlocked.Add(ref _count, value);
        }
    }
}
