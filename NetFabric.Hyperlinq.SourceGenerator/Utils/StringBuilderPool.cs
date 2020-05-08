using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace NetFabric.Hyperlinq.SourceGenerator.Utils
{
    static class StringBuilderPool
    {
        const int maximumBuilderSize = 0x100000; // 1 MB

        readonly static ObjectPool<StringBuilder> pool;

        static StringBuilderPool()
        {
            var provider = new DefaultObjectPoolProvider();
            var policy = new StringBuilderPooledObjectPolicy
            {
                MaximumRetainedCapacity = maximumBuilderSize,
            };

            pool = provider.Create(policy);
        }

        public static StringBuilder Get()
            => pool.Get();

        public static void Return(StringBuilder builder)
            => pool.Return(builder);
    }
}
