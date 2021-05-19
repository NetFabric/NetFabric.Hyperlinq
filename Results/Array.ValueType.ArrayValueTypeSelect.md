## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.603 μs | 0.0044 μs | 0.0037 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop |   100 |  1.734 μs | 0.0072 μs | 0.0064 μs |  1.08 |    0.01 |       - |       - |     - |         - |
|                     Linq |   100 |  2.176 μs | 0.0182 μs | 0.0161 μs |  1.36 |    0.01 |  0.0496 |       - |     - |     104 B |
|               LinqFaster |   100 |  2.668 μs | 0.0456 μs | 0.0426 μs |  1.67 |    0.01 |  3.0670 |       - |     - |   6,424 B |
|             LinqFasterer |   100 |  2.659 μs | 0.0234 μs | 0.0207 μs |  1.66 |    0.01 |  3.0861 |       - |     - |   6,456 B |
|                   LinqAF |   100 |  3.003 μs | 0.0156 μs | 0.0145 μs |  1.87 |    0.01 |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 46.868 μs | 0.5045 μs | 0.4719 μs | 29.26 |    0.34 | 57.6782 | 19.1650 |     - | 156,604 B |
|                 SpanLinq |   100 |  2.221 μs | 0.0093 μs | 0.0082 μs |  1.38 |    0.01 |       - |       - |     - |         - |
|                  Streams |   100 | 10.832 μs | 0.0547 μs | 0.0512 μs |  6.75 |    0.03 |  0.3815 |       - |     - |     824 B |
|               StructLinq |   100 |  1.882 μs | 0.0040 μs | 0.0033 μs |  1.17 |    0.00 |  0.0153 |       - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |  1.815 μs | 0.0066 μs | 0.0059 μs |  1.13 |    0.00 |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1.982 μs | 0.0094 μs | 0.0084 μs |  1.24 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.739 μs | 0.0068 μs | 0.0064 μs |  1.09 |    0.01 |       - |       - |     - |         - |
