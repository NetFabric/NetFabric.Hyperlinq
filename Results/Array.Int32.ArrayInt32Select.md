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
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     60.65 ns |  0.052 ns |  0.048 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     61.37 ns |  0.098 ns |  0.087 ns |   1.01x slower |   0.00x |       - |         - |
|                     Linq |   100 |    436.92 ns |  0.480 ns |  0.449 ns |   7.20x slower |   0.01x |  0.0229 |      48 B |
|               LinqFaster |   100 |    310.85 ns |  0.420 ns |  0.372 ns |   5.12x slower |   0.01x |  0.2027 |     424 B |
|          LinqFaster_SIMD |   100 |    129.22 ns |  0.276 ns |  0.258 ns |   2.13x slower |   0.01x |  0.2027 |     424 B |
|             LinqFasterer |   100 |    440.81 ns |  0.894 ns |  0.747 ns |   7.27x slower |   0.01x |  0.2179 |     456 B |
|                   LinqAF |   100 |    311.25 ns |  1.224 ns |  1.085 ns |   5.13x slower |   0.02x |       - |         - |
|            LinqOptimizer |   100 | 35,160.68 ns | 78.049 ns | 60.935 ns | 579.70x slower |   1.09x | 13.0005 |  27,236 B |
|                 SpanLinq |   100 |    279.62 ns |  1.891 ns |  1.769 ns |   4.61x slower |   0.03x |       - |         - |
|                  Streams |   100 |  1,465.44 ns |  1.742 ns |  1.454 ns |  24.16x slower |   0.02x |  0.2785 |     584 B |
|               StructLinq |   100 |    250.94 ns |  1.191 ns |  1.114 ns |   4.14x slower |   0.02x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    193.11 ns |  0.072 ns |  0.060 ns |   3.18x slower |   0.00x |       - |         - |
|                Hyperlinq |   100 |    255.07 ns |  0.193 ns |  0.171 ns |   4.21x slower |   0.00x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    200.09 ns |  0.193 ns |  0.180 ns |   3.30x slower |   0.00x |       - |         - |
