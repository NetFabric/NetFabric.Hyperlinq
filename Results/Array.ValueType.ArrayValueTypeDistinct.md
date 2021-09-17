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
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |          4 |   100 | 11.744 μs | 0.0511 μs | 0.0478 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |          4 |   100 | 12.154 μs | 0.0526 μs | 0.0466 μs | 1.03x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq |          4 |   100 | 15.019 μs | 0.0655 μs | 0.0581 μs | 1.28x slower |   0.01x | 12.8174 |  26,848 B |
|             LinqFasterer |          4 |   100 | 15.591 μs | 0.1126 μs | 0.1053 μs | 1.33x slower |   0.01x | 22.6135 |  47,544 B |
|                   LinqAF |          4 |   100 | 36.196 μs | 0.2131 μs | 0.1889 μs | 3.08x slower |   0.02x | 21.8506 |  45,768 B |
|               StructLinq |          4 |   100 | 12.446 μs | 0.0465 μs | 0.0412 μs | 1.06x slower |   0.01x |  0.0153 |      56 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.140 μs | 0.0218 μs | 0.0204 μs | 2.28x faster |   0.01x |       - |         - |
|                Hyperlinq |          4 |   100 | 11.652 μs | 0.0437 μs | 0.0409 μs | 1.01x faster |   0.01x |       - |         - |
