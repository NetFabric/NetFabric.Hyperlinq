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
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |  1.787 μs | 0.0145 μs | 0.0129 μs |  1.788 μs |      baseline |         |  5.5237 |     - |     - |     11 KB |
|              ForeachLoop |   100 |  1.678 μs | 0.0160 μs | 0.0141 μs |  1.681 μs |  1.06x faster |   0.01x |  5.5237 |     - |     - |     11 KB |
|                     Linq |   100 |  1.790 μs | 0.0166 μs | 0.0139 μs |  1.789 μs |  1.00x slower |   0.01x |  3.9291 |     - |     - |      8 KB |
|               LinqFaster |   100 |  1.424 μs | 0.0218 μs | 0.0193 μs |  1.421 μs |  1.26x faster |   0.02x |  4.7264 |     - |     - |     10 KB |
|             LinqFasterer |   100 |  3.005 μs | 0.0429 μs | 0.0380 μs |  2.997 μs |  1.68x slower |   0.02x |  6.0043 |     - |     - |     12 KB |
|                   LinqAF |   100 |  2.866 μs | 0.0324 μs | 0.0304 μs |  2.874 μs |  1.60x slower |   0.02x |  5.5084 |     - |     - |     11 KB |
|            LinqOptimizer |   100 | 57.143 μs | 0.5761 μs | 1.2025 μs | 56.893 μs | 32.12x slower |   0.95x | 74.0356 |     - |     - |    154 KB |
|                 SpanLinq |   100 |  2.392 μs | 0.0594 μs | 0.1752 μs |  2.287 μs |  1.45x slower |   0.07x |  5.5237 |     - |     - |     11 KB |
|                  Streams |   100 |  7.895 μs | 0.1653 μs | 0.4743 μs |  7.615 μs |  4.78x slower |   0.21x |  5.7678 |     - |     - |     12 KB |
|               StructLinq |   100 |  1.564 μs | 0.0337 μs | 0.0994 μs |  1.500 μs |  1.14x faster |   0.06x |  1.7052 |     - |     - |      3 KB |
| StructLinq_ValueDelegate |   100 |  1.215 μs | 0.0200 μs | 0.0299 μs |  1.211 μs |  1.45x faster |   0.04x |  1.6556 |     - |     - |      3 KB |
|                Hyperlinq |   100 |  1.894 μs | 0.0425 μs | 0.1252 μs |  1.828 μs |  1.04x slower |   0.05x |  1.6632 |     - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.454 μs | 0.0159 μs | 0.0149 μs |  1.451 μs |  1.23x faster |   0.02x |  1.6632 |     - |     - |      3 KB |
