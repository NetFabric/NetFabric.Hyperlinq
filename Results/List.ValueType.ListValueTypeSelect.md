## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |  1.768 μs | 0.0040 μs | 0.0035 μs |  1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |  1.933 μs | 0.0084 μs | 0.0079 μs |  1.09 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |  2.613 μs | 0.0064 μs | 0.0050 μs |  1.48 |    0.00 |  0.0877 |     - |     - |     184 B |
|               LinqFaster |   100 |  3.444 μs | 0.0405 μs | 0.0379 μs |  1.95 |    0.02 |  3.0823 |     - |     - |   6,456 B |
|             LinqFasterer |   100 |  3.141 μs | 0.0357 μs | 0.0317 μs |  1.78 |    0.02 |  6.1531 |     - |     - |  12,880 B |
|                   LinqAF |   100 |  3.485 μs | 0.0459 μs | 0.0429 μs |  1.97 |    0.02 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 49.227 μs | 0.9413 μs | 0.7860 μs | 27.84 |    0.43 | 74.0356 |     - |     - | 157,634 B |
|                  Streams |   100 | 11.526 μs | 0.1080 μs | 0.0957 μs |  6.52 |    0.06 |  0.3967 |     - |     - |     848 B |
|               StructLinq |   100 |  1.871 μs | 0.0070 μs | 0.0066 μs |  1.06 |    0.00 |  0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |  1.825 μs | 0.0063 μs | 0.0059 μs |  1.03 |    0.00 |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1.990 μs | 0.0116 μs | 0.0109 μs |  1.13 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.737 μs | 0.0079 μs | 0.0070 μs |  0.98 |    0.00 |       - |     - |     - |         - |
