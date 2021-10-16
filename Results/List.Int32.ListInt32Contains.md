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
|                   Method | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 | 117.76 ns | 0.073 ns | 0.057 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 | 120.02 ns | 1.016 ns | 0.900 ns | 1.02x slower |   0.01x |      - |         - |
|                     Linq |   100 |  24.59 ns | 0.058 ns | 0.054 ns | 4.79x faster |   0.01x |      - |         - |
|               LinqFaster |   100 |  21.04 ns | 0.122 ns | 0.207 ns | 5.61x faster |   0.01x |      - |         - |
|             LinqFasterer |   100 |  66.55 ns | 0.667 ns | 0.591 ns | 1.77x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |   100 |  21.66 ns | 0.042 ns | 0.060 ns | 5.44x faster |   0.01x |      - |         - |
|               StructLinq |   100 |  84.57 ns | 0.248 ns | 0.232 ns | 1.39x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  69.48 ns | 0.165 ns | 0.154 ns | 1.69x faster |   0.00x |      - |         - |
|                Hyperlinq |   100 |  36.60 ns | 0.157 ns | 0.140 ns | 3.22x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |   100 |  23.83 ns | 0.066 ns | 0.122 ns | 4.94x faster |   0.02x |      - |         - |
