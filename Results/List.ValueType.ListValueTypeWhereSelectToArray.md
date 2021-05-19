## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |  1.631 μs | 0.0323 μs | 0.0317 μs |  1.633 μs |  1.00 |    0.00 |  5.5237 |     - |     - |     11 KB |
|              ForeachLoop |   100 |  1.821 μs | 0.0406 μs | 0.1197 μs |  1.763 μs |  1.17 |    0.08 |  5.5237 |     - |     - |     11 KB |
|                     Linq |   100 |  1.718 μs | 0.0221 μs | 0.0246 μs |  1.713 μs |  1.06 |    0.02 |  4.0035 |     - |     - |      8 KB |
|               LinqFaster |   100 |  2.190 μs | 0.0220 μs | 0.0195 μs |  2.191 μs |  1.35 |    0.03 |  5.5237 |     - |     - |     11 KB |
|             LinqFasterer |   100 |  1.958 μs | 0.0357 μs | 0.0524 μs |  1.959 μs |  1.21 |    0.03 |  6.3934 |     - |     - |     13 KB |
|                   LinqAF |   100 |  3.445 μs | 0.0842 μs | 0.2469 μs |  3.301 μs |  2.30 |    0.22 |  5.5084 |     - |     - |     11 KB |
|            LinqOptimizer |   100 | 68.567 μs | 0.6276 μs | 0.5240 μs | 68.805 μs | 42.22 |    0.70 | 74.0356 |     - |     - |    155 KB |
|                  Streams |   100 |  7.438 μs | 0.0457 μs | 0.0381 μs |  7.444 μs |  4.58 |    0.09 |  5.7678 |     - |     - |     12 KB |
|               StructLinq |   100 |  1.615 μs | 0.0071 μs | 0.0063 μs |  1.614 μs |  0.99 |    0.02 |  1.7109 |     - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.162 μs | 0.0082 μs | 0.0072 μs |  1.163 μs |  0.71 |    0.01 |  1.6575 |     - |     - |      3 KB |
|                Hyperlinq |   100 |  1.728 μs | 0.0229 μs | 0.0214 μs |  1.722 μs |  1.06 |    0.02 |  1.6632 |     - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.431 μs | 0.0285 μs | 0.0776 μs |  1.384 μs |  0.88 |    0.05 |  1.6632 |     - |     - |      3 KB |
