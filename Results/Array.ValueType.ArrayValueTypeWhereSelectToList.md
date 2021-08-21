## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop |   100 |  1.182 μs | 0.0124 μs | 0.0110 μs |      baseline |         |  3.8605 |      - |     - |      8 KB |
|              ForeachLoop |   100 |  1.280 μs | 0.0044 μs | 0.0039 μs |  1.08x slower |   0.01x |  3.8605 |      - |     - |      8 KB |
|                     Linq |   100 |  1.735 μs | 0.0047 μs | 0.0044 μs |  1.47x slower |   0.01x |  3.9673 |      - |     - |      8 KB |
|               LinqFaster |   100 |  1.852 μs | 0.0129 μs | 0.0114 μs |  1.57x slower |   0.02x |  6.4087 |      - |     - |     13 KB |
|             LinqFasterer |   100 |  3.089 μs | 0.0286 μs | 0.0267 μs |  2.62x slower |   0.01x |  9.0332 |      - |     - |     18 KB |
|                   LinqAF |   100 |  2.494 μs | 0.0082 μs | 0.0073 μs |  2.11x slower |   0.02x |  3.8605 |      - |     - |      8 KB |
|            LinqOptimizer |   100 | 60.071 μs | 0.2367 μs | 0.2098 μs | 50.81x slower |   0.49x | 74.7070 | 5.7373 |     - |    157 KB |
|                 SpanLinq |   100 |  2.023 μs | 0.0083 μs | 0.0074 μs |  1.71x slower |   0.02x |  3.8605 |      - |     - |      8 KB |
|                  Streams |   100 |  2.758 μs | 0.0063 μs | 0.0059 μs |  2.33x slower |   0.02x |  4.1275 |      - |     - |      8 KB |
|               StructLinq |   100 |  1.545 μs | 0.0035 μs | 0.0027 μs |  1.30x slower |   0.00x |  1.7281 |      - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.121 μs | 0.0024 μs | 0.0020 μs |  1.06x faster |   0.00x |  1.6804 |      - |     - |      3 KB |
|                Hyperlinq |   100 |  1.860 μs | 0.0047 μs | 0.0040 μs |  1.57x slower |   0.00x |  1.6766 |      - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.445 μs | 0.0026 μs | 0.0024 μs |  1.22x slower |   0.01x |  1.6766 |      - |     - |      3 KB |
