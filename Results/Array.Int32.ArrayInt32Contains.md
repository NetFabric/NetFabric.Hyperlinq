## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|                   Method | Count |     Mean |    Error |   StdDev |   Median |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 46.05 ns | 1.793 ns | 5.202 ns | 42.82 ns |     baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 | 42.89 ns | 0.621 ns | 1.401 ns | 42.49 ns | 1.12x faster |   0.13x |      - |     - |     - |         - |
|                     Linq |   100 | 23.37 ns | 0.046 ns | 0.043 ns | 23.38 ns | 2.29x faster |   0.11x |      - |     - |     - |         - |
|               LinqFaster |   100 | 22.11 ns | 0.058 ns | 0.051 ns | 22.11 ns | 2.41x faster |   0.10x |      - |     - |     - |         - |
|          LinqFaster_SIMD |   100 | 13.89 ns | 0.019 ns | 0.018 ns | 13.88 ns | 3.86x faster |   0.19x |      - |     - |     - |         - |
|             LinqFasterer |   100 | 22.76 ns | 0.089 ns | 0.083 ns | 22.75 ns | 2.36x faster |   0.11x |      - |     - |     - |         - |
|                   LinqAF |   100 | 28.53 ns | 0.388 ns | 0.462 ns | 28.74 ns | 1.87x faster |   0.14x |      - |     - |     - |         - |
|               StructLinq |   100 | 92.78 ns | 0.660 ns | 0.617 ns | 92.68 ns | 1.73x slower |   0.08x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 | 71.68 ns | 0.985 ns | 0.922 ns | 71.28 ns | 1.34x slower |   0.07x |      - |     - |     - |         - |
|                Hyperlinq |   100 | 32.48 ns | 0.494 ns | 0.964 ns | 32.23 ns | 1.52x faster |   0.19x |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 | 26.95 ns | 0.080 ns | 0.067 ns | 26.95 ns | 1.96x faster |   0.04x |      - |     - |     - |         - |
