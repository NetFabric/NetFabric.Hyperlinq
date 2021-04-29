## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |  1.787 μs | 0.0059 μs | 0.0055 μs |  1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |  1.969 μs | 0.0090 μs | 0.0080 μs |  1.10 |    0.00 |       - |     - |     - |         - |
|                     Linq |   100 |  2.636 μs | 0.0131 μs | 0.0102 μs |  1.48 |    0.01 |  0.0877 |     - |     - |     184 B |
|               LinqFaster |   100 |  3.143 μs | 0.0210 μs | 0.0197 μs |  1.76 |    0.01 |  3.0861 |     - |     - |   6,456 B |
|             LinqFasterer |   100 |  3.131 μs | 0.0179 μs | 0.0168 μs |  1.75 |    0.01 |  6.1531 |     - |     - |  12,880 B |
|                   LinqAF |   100 |  3.583 μs | 0.0279 μs | 0.0233 μs |  2.01 |    0.01 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 47.312 μs | 0.2046 μs | 0.1814 μs | 26.47 |    0.12 | 74.0356 |     - |     - | 157,635 B |
|                  Streams |   100 | 10.908 μs | 0.0636 μs | 0.0595 μs |  6.10 |    0.03 |  0.3967 |     - |     - |     848 B |
|               StructLinq |   100 |  1.905 μs | 0.0053 μs | 0.0049 μs |  1.07 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |  1.832 μs | 0.0068 μs | 0.0063 μs |  1.03 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |  2.008 μs | 0.0051 μs | 0.0045 μs |  1.12 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.761 μs | 0.0087 μs | 0.0082 μs |  0.99 |    0.01 |       - |     - |     - |         - |
