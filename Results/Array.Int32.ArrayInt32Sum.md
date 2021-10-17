## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|                   Method | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |  48.37 ns | 0.136 ns | 0.127 ns |      baseline |         |      - |         - |
|              ForeachLoop |   100 |  48.47 ns | 0.145 ns | 0.136 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq |   100 | 273.73 ns | 1.597 ns | 1.494 ns |  5.66x slower |   0.03x | 0.0153 |      32 B |
|               LinqFaster |   100 |  54.80 ns | 0.203 ns | 0.190 ns |  1.13x slower |   0.01x |      - |         - |
|          LinqFaster_SIMD |   100 |  13.53 ns | 0.105 ns | 0.088 ns |  3.58x faster |   0.02x |      - |         - |
|             LinqFasterer |   100 |  66.71 ns | 0.065 ns | 0.051 ns |  1.38x slower |   0.00x |      - |         - |
|                   LinqAF |   100 |  93.22 ns | 1.334 ns | 1.041 ns |  1.93x slower |   0.02x |      - |         - |
|            LinqOptimizer |   100 | 601.39 ns | 4.244 ns | 3.969 ns | 12.43x slower |   0.09x | 0.0114 |      24 B |
|                  Streams |   100 | 197.57 ns | 0.741 ns | 0.693 ns |  4.08x slower |   0.02x | 0.0994 |     208 B |
|               StructLinq |   100 |  80.57 ns | 0.262 ns | 0.218 ns |  1.67x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  67.29 ns | 0.188 ns | 0.167 ns |  1.39x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |  18.54 ns | 0.046 ns | 0.084 ns |  2.61x faster |   0.01x |      - |         - |
