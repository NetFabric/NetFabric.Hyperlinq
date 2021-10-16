## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |          4 |   100 | 11.889 μs | 0.0231 μs | 0.0180 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |          4 |   100 | 12.041 μs | 0.0191 μs | 0.0169 μs | 1.01x slower |   0.00x | 12.8784 |  26,976 B |
|                     Linq |          4 |   100 | 14.873 μs | 0.0396 μs | 0.0351 μs | 1.25x slower |   0.00x | 12.8174 |  26,848 B |
|             LinqFasterer |          4 |   100 | 15.106 μs | 0.0202 μs | 0.0179 μs | 1.27x slower |   0.00x | 22.6135 |  47,544 B |
|                   LinqAF |          4 |   100 | 78.576 μs | 0.1185 μs | 0.1050 μs | 6.61x slower |   0.01x | 20.0195 |  42,024 B |
|               StructLinq |          4 |   100 | 13.221 μs | 0.0118 μs | 0.0099 μs | 1.11x slower |   0.00x |  0.0153 |      56 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.139 μs | 0.0180 μs | 0.0169 μs | 2.31x faster |   0.01x |       - |         - |
|                Hyperlinq |          4 |   100 | 11.797 μs | 0.0096 μs | 0.0080 μs | 1.01x faster |   0.00x |       - |         - |
