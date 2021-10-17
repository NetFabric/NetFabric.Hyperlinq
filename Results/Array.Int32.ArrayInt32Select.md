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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    61.32 ns |  0.043 ns |  0.033 ns |      baseline |         |      - |         - |
|              ForeachLoop |   100 |    61.12 ns |  0.082 ns |  0.064 ns |  1.00x faster |   0.00x |      - |         - |
|                     Linq |   100 |   434.50 ns |  1.275 ns |  1.130 ns |  7.09x slower |   0.02x | 0.0229 |      48 B |
|               LinqFaster |   100 |   254.51 ns |  1.156 ns |  1.025 ns |  4.15x slower |   0.02x | 0.2027 |     424 B |
|          LinqFaster_SIMD |   100 |   127.61 ns |  0.838 ns |  0.700 ns |  2.08x slower |   0.01x | 0.2027 |     424 B |
|             LinqFasterer |   100 |   387.09 ns |  2.194 ns |  1.945 ns |  6.32x slower |   0.02x | 0.2179 |     456 B |
|                   LinqAF |   100 |   296.44 ns |  1.215 ns |  1.014 ns |  4.83x slower |   0.02x |      - |         - |
|            LinqOptimizer |   100 | 1,834.20 ns | 13.716 ns | 12.159 ns | 29.92x slower |   0.18x | 4.2362 |   8,866 B |
|                 SpanLinq |   100 |   276.27 ns |  0.333 ns |  0.260 ns |  4.51x slower |   0.00x |      - |         - |
|                  Streams |   100 | 1,470.35 ns |  7.887 ns |  7.378 ns | 23.98x slower |   0.13x | 0.2785 |     584 B |
|               StructLinq |   100 |   225.72 ns |  0.797 ns |  0.746 ns |  3.68x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |   176.37 ns |  0.368 ns |  0.287 ns |  2.88x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |   254.74 ns |  0.488 ns |  0.408 ns |  4.15x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |   201.03 ns |  0.741 ns |  0.657 ns |  3.28x slower |   0.01x |      - |         - |
