## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.506 μs | 0.0068 μs | 0.0064 μs |      baseline |         |  5.5237 |     11 KB |
|              ForeachLoop |   100 |  1.619 μs | 0.0179 μs | 0.0140 μs |  1.07x slower |   0.01x |  5.5237 |     11 KB |
|                     Linq |   100 |  1.836 μs | 0.0067 μs | 0.0063 μs |  1.22x slower |   0.01x |  3.9291 |      8 KB |
|               LinqFaster |   100 |  1.536 μs | 0.0032 μs | 0.0026 μs |  1.02x slower |   0.00x |  4.7264 |     10 KB |
|             LinqFasterer |   100 |  2.592 μs | 0.0094 μs | 0.0088 μs |  1.72x slower |   0.01x |  6.0043 |     12 KB |
|                   LinqAF |   100 |  2.879 μs | 0.0140 μs | 0.0117 μs |  1.91x slower |   0.01x |  5.5122 |     11 KB |
|            LinqOptimizer |   100 | 57.747 μs | 0.2210 μs | 0.1959 μs | 38.32x slower |   0.20x | 74.0356 |    153 KB |
|                 SpanLinq |   100 |  2.366 μs | 0.0075 μs | 0.0070 μs |  1.57x slower |   0.01x |  5.5237 |     11 KB |
|                  Streams |   100 |  2.574 μs | 0.0074 μs | 0.0066 μs |  1.71x slower |   0.01x |  5.7716 |     12 KB |
|               StructLinq |   100 |  1.534 μs | 0.0021 μs | 0.0019 μs |  1.02x slower |   0.00x |  1.7052 |      3 KB |
| StructLinq_ValueDelegate |   100 |  1.080 μs | 0.0014 μs | 0.0012 μs |  1.40x faster |   0.01x |  1.6575 |      3 KB |
|                Hyperlinq |   100 |  1.821 μs | 0.0108 μs | 0.0101 μs |  1.21x slower |   0.01x |  1.6575 |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.363 μs | 0.0098 μs | 0.0082 μs |  1.11x faster |   0.01x |  1.6575 |      3 KB |
