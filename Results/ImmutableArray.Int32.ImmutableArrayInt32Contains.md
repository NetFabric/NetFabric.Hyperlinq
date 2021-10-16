## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|                  ForLoop |   100 |  48.83 ns | 0.104 ns | 0.097 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 |  49.46 ns | 0.083 ns | 0.074 ns | 1.01x slower |   0.00x |      - |         - |
|                     Linq |   100 |  21.90 ns | 0.060 ns | 0.111 ns | 2.23x faster |   0.01x |      - |         - |
|             LinqFasterer |   100 |  72.36 ns | 0.492 ns | 0.436 ns | 1.48x slower |   0.01x | 0.2142 |     448 B |
|               StructLinq |   100 | 106.17 ns | 0.244 ns | 0.228 ns | 2.17x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  87.42 ns | 0.302 ns | 0.268 ns | 1.79x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 |  35.75 ns | 0.145 ns | 0.113 ns | 1.37x faster |   0.01x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |   100 |  25.26 ns | 0.477 ns | 0.398 ns | 1.93x faster |   0.03x |      - |         - |
