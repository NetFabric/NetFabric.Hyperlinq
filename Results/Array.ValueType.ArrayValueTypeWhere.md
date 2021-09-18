## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    449.9 ns |   0.94 ns |   0.79 ns |       baseline |         |       - |      - |         - |
|              ForeachLoop |   100 |    521.9 ns |   0.28 ns |   0.22 ns |   1.16x slower |   0.00x |       - |      - |         - |
|                     Linq |   100 |    965.9 ns |   8.67 ns |   7.69 ns |   2.15x slower |   0.02x |  0.0496 |      - |     104 B |
|               LinqFaster |   100 |  1,477.8 ns |   5.66 ns |   5.30 ns |   3.29x slower |   0.01x |  4.7264 |      - |   9,904 B |
|             LinqFasterer |   100 |  2,049.7 ns |   5.36 ns |   5.02 ns |   4.56x slower |   0.02x |  3.0174 |      - |   6,328 B |
|                   LinqAF |   100 |  1,172.3 ns |   3.85 ns |   3.60 ns |   2.61x slower |   0.01x |       - |      - |         - |
|            LinqOptimizer |   100 | 49,311.1 ns | 252.71 ns | 224.02 ns | 109.58x slower |   0.41x | 70.8008 | 4.3945 | 153,936 B |
|                 SpanLinq |   100 |    769.0 ns |   0.24 ns |   0.19 ns |   1.71x slower |   0.00x |       - |      - |         - |
|                  Streams |   100 |  1,978.9 ns |   4.21 ns |   3.94 ns |   4.40x slower |   0.01x |  0.3929 |      - |     824 B |
|               StructLinq |   100 |    645.9 ns |   2.60 ns |   2.43 ns |   1.44x slower |   0.01x |  0.0153 |      - |      32 B |
| StructLinq_ValueDelegate |   100 |    568.2 ns |   0.26 ns |   0.22 ns |   1.26x slower |   0.00x |       - |      - |         - |
|                Hyperlinq |   100 |  1,049.2 ns |   3.93 ns |   3.68 ns |   2.33x slower |   0.01x |       - |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |    888.9 ns |   1.27 ns |   1.13 ns |   1.98x slower |   0.00x |       - |      - |         - |
