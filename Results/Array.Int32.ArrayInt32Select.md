## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                   Method | Count |         Mean |     Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     65.55 ns |  0.546 ns |   0.484 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     65.16 ns |  0.094 ns |   0.083 ns |   1.01x faster |   0.01x |       - |     - |     - |         - |
|                     Linq |   100 |    508.38 ns |  9.683 ns |   9.058 ns |   7.76x slower |   0.15x |  0.0229 |     - |     - |      48 B |
|               LinqFaster |   100 |    308.23 ns |  1.931 ns |   1.613 ns |   4.70x slower |   0.04x |  0.2027 |     - |     - |     424 B |
|          LinqFaster_SIMD |   100 |    126.41 ns |  0.400 ns |   0.374 ns |   1.93x slower |   0.01x |  0.2027 |     - |     - |     424 B |
|             LinqFasterer |   100 |    409.50 ns |  0.946 ns |   0.739 ns |   6.25x slower |   0.05x |  0.2179 |     - |     - |     456 B |
|                   LinqAF |   100 |    347.70 ns |  0.984 ns |   0.920 ns |   5.30x slower |   0.05x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 34,011.49 ns | 96.421 ns |  80.516 ns | 518.86x slower |   4.39x | 13.0005 |     - |     - |  27,235 B |
|                 SpanLinq |   100 |    276.27 ns |  0.101 ns |   0.079 ns |   4.21x slower |   0.03x |       - |     - |     - |         - |
|                  Streams |   100 |  1,647.41 ns | 48.058 ns | 134.760 ns |  25.42x slower |   2.26x |  0.2785 |     - |     - |     584 B |
|               StructLinq |   100 |    224.58 ns |  0.878 ns |   0.733 ns |   3.43x slower |   0.03x |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    176.91 ns |  0.105 ns |   0.093 ns |   2.70x slower |   0.02x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    234.18 ns |  0.774 ns |   0.646 ns |   3.57x slower |   0.03x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    200.13 ns |  1.203 ns |   1.067 ns |   3.05x slower |   0.03x |       - |     - |     - |         - |
