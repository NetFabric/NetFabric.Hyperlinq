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
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop |   100 |    449.7 ns |   1.01 ns |   0.94 ns |       baseline |         |       - |      - |     - |         - |
|              ForeachLoop |   100 |    521.0 ns |   0.22 ns |   0.19 ns |   1.16x slower |   0.00x |       - |      - |     - |         - |
|                     Linq |   100 |    958.4 ns |   3.10 ns |   2.42 ns |   2.13x slower |   0.01x |  0.0496 |      - |     - |     104 B |
|               LinqFaster |   100 |  1,477.9 ns |   7.21 ns |   6.74 ns |   3.29x slower |   0.02x |  4.7264 |      - |     - |   9,904 B |
|             LinqFasterer |   100 |  2,056.6 ns |   1.42 ns |   1.26 ns |   4.57x slower |   0.01x |  3.0174 |      - |     - |   6,328 B |
|                   LinqAF |   100 |  1,174.2 ns |   4.41 ns |   4.12 ns |   2.61x slower |   0.01x |       - |      - |     - |         - |
|            LinqOptimizer |   100 | 48,630.2 ns | 264.77 ns | 247.66 ns | 108.14x slower |   0.58x | 70.8008 | 4.3945 |     - | 153,936 B |
|                 SpanLinq |   100 |    784.4 ns |   0.30 ns |   0.27 ns |   1.74x slower |   0.00x |       - |      - |     - |         - |
|                  Streams |   100 |  2,002.1 ns |   5.67 ns |   5.30 ns |   4.45x slower |   0.02x |  0.3929 |      - |     - |     824 B |
|               StructLinq |   100 |    634.2 ns |   0.32 ns |   0.30 ns |   1.41x slower |   0.00x |  0.0153 |      - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    567.8 ns |   0.36 ns |   0.32 ns |   1.26x slower |   0.00x |       - |      - |     - |         - |
|                Hyperlinq |   100 |    992.1 ns |   1.01 ns |   0.95 ns |   2.21x slower |   0.01x |       - |      - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    891.8 ns |   0.25 ns |   0.21 ns |   1.98x slower |   0.00x |       - |      - |     - |         - |
