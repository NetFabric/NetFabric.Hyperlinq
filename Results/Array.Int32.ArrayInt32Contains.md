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
|                   Method | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |  48.86 ns | 0.104 ns | 0.092 ns |  48.83 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 |  49.04 ns | 0.045 ns | 0.040 ns |  49.04 ns | 1.00x slower |   0.00x |      - |         - |
|                     Linq |   100 |  22.92 ns | 0.310 ns | 0.290 ns |  22.98 ns | 2.12x faster |   0.01x |      - |         - |
|               LinqFaster |   100 |  17.80 ns | 0.153 ns | 0.284 ns |  17.74 ns | 2.76x faster |   0.00x |      - |         - |
|          LinqFaster_SIMD |   100 |  10.93 ns | 0.054 ns | 0.096 ns |  10.91 ns | 4.48x faster |   0.02x |      - |         - |
|             LinqFasterer |   100 |  23.42 ns | 0.029 ns | 0.024 ns |  23.41 ns | 2.09x faster |   0.00x |      - |         - |
|                   LinqAF |   100 |  29.14 ns | 0.217 ns | 0.170 ns |  29.19 ns | 1.68x faster |   0.01x |      - |         - |
|               StructLinq |   100 | 163.59 ns | 0.268 ns | 0.238 ns | 163.58 ns | 3.35x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  72.15 ns | 0.042 ns | 0.037 ns |  72.14 ns | 1.48x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |  34.82 ns | 0.756 ns | 1.221 ns |  33.97 ns | 1.35x faster |   0.04x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |   100 |  25.55 ns | 0.012 ns | 0.011 ns |  25.55 ns | 1.91x faster |   0.00x |      - |         - |
