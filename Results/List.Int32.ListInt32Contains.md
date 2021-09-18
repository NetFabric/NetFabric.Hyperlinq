## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|                   Method | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 | 118.51 ns | 1.176 ns |  1.529 ns | 118.86 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 | 177.79 ns | 1.214 ns |  1.014 ns | 177.99 ns | 1.49x slower |   0.01x |      - |         - |
|                     Linq |   100 |  22.52 ns | 0.552 ns |  1.576 ns |  22.07 ns | 5.02x faster |   0.38x |      - |         - |
|               LinqFaster |   100 |  27.73 ns | 0.795 ns |  2.306 ns |  27.87 ns | 4.41x faster |   0.31x |      - |         - |
|             LinqFasterer |   100 |  89.30 ns | 3.279 ns |  9.141 ns |  87.83 ns | 1.24x faster |   0.11x | 0.2027 |     424 B |
|                   LinqAF |   100 |  30.21 ns | 1.301 ns |  3.732 ns |  29.61 ns | 3.76x faster |   0.28x |      - |         - |
|               StructLinq |   100 | 104.35 ns | 4.383 ns | 12.146 ns | 102.47 ns | 1.15x faster |   0.10x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  84.06 ns | 2.237 ns |  6.235 ns |  82.17 ns | 1.37x faster |   0.11x |      - |         - |
|                Hyperlinq |   100 |  44.92 ns | 1.436 ns |  3.980 ns |  44.55 ns | 2.62x faster |   0.18x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |   100 |  29.36 ns | 0.796 ns |  2.271 ns |  28.64 ns | 3.84x faster |   0.28x |      - |         - |
