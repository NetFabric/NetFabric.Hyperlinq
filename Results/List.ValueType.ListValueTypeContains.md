## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|                   Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 593.7 ns |  2.99 ns |  2.79 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 | 746.6 ns | 11.95 ns |  9.98 ns |  1.26 |    0.02 |      - |     - |     - |         - |
|                     Linq |   100 | 194.3 ns |  0.64 ns |  0.57 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|               LinqFaster |   100 | 178.1 ns |  1.05 ns |  0.98 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|             LinqFasterer |   100 | 596.3 ns | 11.89 ns | 15.04 ns |  1.01 |    0.02 | 3.0670 |     - |     - |   6,424 B |
|                   LinqAF |   100 | 194.6 ns |  1.00 ns |  0.89 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|               StructLinq |   100 | 453.5 ns |  8.69 ns | 10.34 ns |  0.76 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 | 440.3 ns |  1.29 ns |  1.08 ns |  0.74 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 | 196.6 ns |  0.98 ns |  0.87 ns |  0.33 |    0.00 |      - |     - |     - |         - |
