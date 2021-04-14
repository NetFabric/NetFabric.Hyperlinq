## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Count |        Mean |     Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  2,342.0 ns |  13.34 ns |    10.41 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4,139.0 ns |  65.30 ns |    57.88 ns |  1.77 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  9,140.2 ns |  31.75 ns |    29.70 ns |  3.90 |    0.02 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  4,543.1 ns |  13.57 ns |    12.69 ns |  1.94 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 11,338.7 ns | 222.97 ns |   424.22 ns |  4.81 |    0.20 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 48,704.6 ns | 938.71 ns | 1,043.37 ns | 20.78 |    0.58 | 9.5825 |     - |     - |  20,140 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  5,629.3 ns |  72.54 ns |    64.30 ns |  2.40 |    0.02 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  2,138.9 ns |   6.47 ns |     5.40 ns |  0.91 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    834.5 ns |   3.99 ns |     3.54 ns |  0.36 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  4,761.9 ns |  21.07 ns |    17.59 ns |  2.03 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,702.6 ns |  14.85 ns |    12.40 ns |  1.58 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |             |           |             |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  2,280.3 ns |   7.51 ns |     6.66 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  4,046.8 ns |  80.92 ns |    79.47 ns |  1.77 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  9,598.1 ns |  62.83 ns |    58.77 ns |  4.21 |    0.03 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  4,357.7 ns |  12.34 ns |    11.55 ns |  1.91 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 10,760.3 ns | 210.42 ns |   384.77 ns |  4.68 |    0.13 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 45,119.0 ns | 339.08 ns |   486.30 ns | 19.76 |    0.23 | 9.4604 |     - |     - |  19,892 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  5,624.9 ns | 110.41 ns |   118.13 ns |  2.46 |    0.06 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  2,169.5 ns |  37.55 ns |    55.05 ns |  0.97 |    0.03 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    821.6 ns |  13.28 ns |    11.78 ns |  0.36 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,740.6 ns |  24.79 ns |    20.70 ns |  2.08 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,548.9 ns |   8.47 ns |     7.51 ns |  1.56 |    0.00 |      - |     - |     - |         - |
