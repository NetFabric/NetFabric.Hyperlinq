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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop |   100 |  1.238 μs | 0.0086 μs | 0.0189 μs |  1.233 μs |      baseline |         |  3.8605 |      - |     - |      8 KB |
|              ForeachLoop |   100 |  1.416 μs | 0.0312 μs | 0.0920 μs |  1.371 μs |  1.17x slower |   0.08x |  3.8605 |      - |     - |      8 KB |
|                     Linq |   100 |  1.995 μs | 0.0346 μs | 0.0324 μs |  1.999 μs |  1.61x slower |   0.04x |  3.9673 |      - |     - |      8 KB |
|               LinqFaster |   100 |  1.719 μs | 0.0338 μs | 0.0316 μs |  1.713 μs |  1.39x slower |   0.02x |  6.4087 |      - |     - |     13 KB |
|             LinqFasterer |   100 |  3.168 μs | 0.0389 μs | 0.0364 μs |  3.160 μs |  2.56x slower |   0.05x |  9.0332 |      - |     - |     18 KB |
|                   LinqAF |   100 |  2.668 μs | 0.0510 μs | 0.0477 μs |  2.660 μs |  2.15x slower |   0.04x |  3.8605 |      - |     - |      8 KB |
|            LinqOptimizer |   100 | 59.836 μs | 0.4695 μs | 0.8346 μs | 59.657 μs | 48.27x slower |   0.94x | 72.2656 | 6.5918 |     - |    157 KB |
|                 SpanLinq |   100 |  2.355 μs | 0.0388 μs | 0.0363 μs |  2.347 μs |  1.90x slower |   0.04x |  3.8605 |      - |     - |      8 KB |
|                  Streams |   100 |  7.602 μs | 0.1065 μs | 0.1458 μs |  7.566 μs |  6.13x slower |   0.16x |  4.1199 |      - |     - |      8 KB |
|               StructLinq |   100 |  1.607 μs | 0.0365 μs | 0.1077 μs |  1.558 μs |  1.29x slower |   0.09x |  1.7223 |      - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.269 μs | 0.0076 μs | 0.0067 μs |  1.269 μs |  1.02x slower |   0.02x |  1.6766 |      - |     - |      3 KB |
|                Hyperlinq |   100 |  2.338 μs | 0.0236 μs | 0.0209 μs |  2.335 μs |  1.89x slower |   0.03x |  1.6747 |      - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.979 μs | 0.0740 μs | 0.2182 μs |  1.980 μs |  1.55x slower |   0.21x |  1.6766 |      - |     - |      3 KB |
