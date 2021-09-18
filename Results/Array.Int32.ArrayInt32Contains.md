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
|                   Method | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |  48.32 ns | 0.062 ns | 0.052 ns |  48.31 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 |  48.62 ns | 0.030 ns | 0.025 ns |  48.61 ns | 1.01x slower |   0.00x |      - |         - |
|                     Linq |   100 |  22.16 ns | 0.519 ns | 0.922 ns |  21.69 ns | 2.10x faster |   0.06x |      - |         - |
|               LinqFaster |   100 |  22.07 ns | 0.060 ns | 0.050 ns |  22.07 ns | 2.19x faster |   0.01x |      - |         - |
|          LinqFaster_SIMD |   100 |  13.84 ns | 0.031 ns | 0.028 ns |  13.84 ns | 3.49x faster |   0.01x |      - |         - |
|             LinqFasterer |   100 |  22.52 ns | 0.020 ns | 0.016 ns |  22.52 ns | 2.15x faster |   0.00x |      - |         - |
|                   LinqAF |   100 |  28.50 ns | 0.035 ns | 0.030 ns |  28.51 ns | 1.70x faster |   0.00x |      - |         - |
|               StructLinq |   100 | 162.30 ns | 0.463 ns | 0.410 ns | 162.27 ns | 3.36x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  71.08 ns | 0.078 ns | 0.073 ns |  71.05 ns | 1.47x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |  35.93 ns | 0.753 ns | 0.629 ns |  35.72 ns | 1.35x faster |   0.02x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |   100 |  23.84 ns | 0.553 ns | 0.828 ns |  24.01 ns | 1.96x faster |   0.01x |      - |         - |
