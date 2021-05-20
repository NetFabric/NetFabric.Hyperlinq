## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.055 μs | 0.0051 μs | 0.0045 μs |  1.055 μs |      baseline |         |       - |       - |     - |         - |
|              ForeachLoop |   100 |  1.243 μs | 0.0042 μs | 0.0037 μs |  1.244 μs |  1.18x slower |   0.00x |       - |       - |     - |         - |
|                     Linq |   100 |  2.042 μs | 0.0173 μs | 0.0135 μs |  2.044 μs |  1.93x slower |   0.02x |  0.1793 |       - |     - |     376 B |
|               LinqFaster |   100 |  2.433 μs | 0.0227 μs | 0.0213 μs |  2.435 μs |  2.31x slower |   0.02x |  3.8605 |       - |     - |   8,088 B |
|             LinqFasterer |   100 |  2.614 μs | 0.0504 μs | 0.0447 μs |  2.607 μs |  2.48x slower |   0.05x |  6.4087 |       - |     - |  13,416 B |
|                   LinqAF |   100 |  2.833 μs | 0.0348 μs | 0.0326 μs |  2.826 μs |  2.68x slower |   0.03x |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 69.687 μs | 2.8803 μs | 8.2175 μs | 64.504 μs | 64.07x slower |   6.20x | 57.7393 | 19.1650 |     - | 157,299 B |
|                 SpanLinq |   100 |  1.645 μs | 0.0082 μs | 0.0077 μs |  1.645 μs |  1.56x slower |   0.01x |       - |       - |     - |         - |
|                  Streams |   100 | 11.245 μs | 0.0675 μs | 0.0599 μs | 11.238 μs | 10.66x slower |   0.08x |  0.4730 |       - |     - |   1,000 B |
|               StructLinq |   100 |  1.277 μs | 0.0023 μs | 0.0020 μs |  1.277 μs |  1.21x slower |   0.01x |  0.0343 |       - |     - |      72 B |
| StructLinq_ValueDelegate |   100 |  1.152 μs | 0.0081 μs | 0.0072 μs |  1.151 μs |  1.09x slower |   0.01x |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1.621 μs | 0.0143 μs | 0.0133 μs |  1.623 μs |  1.54x slower |   0.01x |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.330 μs | 0.0079 μs | 0.0066 μs |  1.329 μs |  1.26x slower |   0.01x |       - |       - |     - |         - |
