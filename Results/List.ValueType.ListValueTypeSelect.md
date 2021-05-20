## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                  ForLoop |   100 |  1.817 μs | 0.0106 μs | 0.0099 μs |  1.815 μs |      baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |  1.977 μs | 0.0096 μs | 0.0080 μs |  1.978 μs |  1.09x slower |   0.01x |       - |     - |     - |         - |
|                     Linq |   100 |  2.685 μs | 0.0143 μs | 0.0133 μs |  2.678 μs |  1.48x slower |   0.01x |  0.0877 |     - |     - |     184 B |
|               LinqFaster |   100 |  3.228 μs | 0.0292 μs | 0.0243 μs |  3.223 μs |  1.78x slower |   0.02x |  3.0861 |     - |     - |   6,456 B |
|             LinqFasterer |   100 |  4.217 μs | 0.0837 μs | 0.2114 μs |  4.293 μs |  2.16x slower |   0.15x |  6.1531 |     - |     - |  12,880 B |
|                   LinqAF |   100 |  4.567 μs | 0.0243 μs | 0.0215 μs |  4.565 μs |  2.51x slower |   0.02x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 56.399 μs | 1.8794 μs | 5.5413 μs | 52.766 μs | 34.64x slower |   0.73x | 74.0356 |     - |     - | 157,634 B |
|                 SpanLinq |   100 |  2.255 μs | 0.0127 μs | 0.0119 μs |  2.253 μs |  1.24x slower |   0.01x |       - |     - |     - |         - |
|                  Streams |   100 | 12.676 μs | 0.1312 μs | 0.1096 μs | 12.661 μs |  6.98x slower |   0.07x |  0.3967 |     - |     - |     848 B |
|               StructLinq |   100 |  1.943 μs | 0.0158 μs | 0.0148 μs |  1.941 μs |  1.07x slower |   0.01x |  0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |  1.898 μs | 0.0067 μs | 0.0063 μs |  1.898 μs |  1.04x slower |   0.01x |       - |     - |     - |         - |
|                Hyperlinq |   100 |  2.031 μs | 0.0143 μs | 0.0134 μs |  2.027 μs |  1.12x slower |   0.01x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.795 μs | 0.0148 μs | 0.0138 μs |  1.793 μs |  1.01x faster |   0.01x |       - |     - |     - |         - |
