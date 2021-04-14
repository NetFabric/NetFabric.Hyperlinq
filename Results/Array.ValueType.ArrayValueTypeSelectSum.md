## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |    668.4 ns |   1.85 ns |     1.54 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  1,793.3 ns |   7.52 ns |     6.66 ns |  2.68 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  6,479.5 ns | 111.94 ns |   153.23 ns |  9.78 |    0.25 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  3,484.1 ns |   7.61 ns |     6.75 ns |  5.21 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,517.5 ns | 149.80 ns |   166.50 ns | 11.20 |    0.28 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 39,634.6 ns | 339.83 ns |   317.88 ns | 59.25 |    0.47 | 9.0942 |     - |     - |  19,018 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  4,465.6 ns |  13.75 ns |    12.86 ns |  6.68 |    0.03 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  2,174.0 ns |  28.57 ns |    26.72 ns |  3.26 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    812.7 ns |  15.26 ns |    14.27 ns |  1.21 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  4,812.2 ns |  45.19 ns |    40.06 ns |  7.20 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,521.9 ns |   7.72 ns |     7.22 ns |  5.27 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |             |           |             |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    705.1 ns |   9.43 ns |     8.82 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,827.2 ns |   5.51 ns |     4.88 ns |  2.60 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  7,095.6 ns |  19.67 ns |    16.42 ns | 10.09 |    0.10 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  3,540.1 ns |  10.27 ns |     9.10 ns |  5.03 |    0.05 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  7,174.6 ns | 142.01 ns |   241.14 ns | 10.18 |    0.38 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 38,763.6 ns | 681.05 ns | 1,279.17 ns | 54.93 |    2.88 | 9.0332 |     - |     - |  18,962 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  4,228.8 ns |  48.98 ns |    43.42 ns |  6.01 |    0.06 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  2,025.1 ns |  13.33 ns |    12.47 ns |  2.87 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    829.0 ns |   2.02 ns |     1.79 ns |  1.18 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,812.8 ns |  14.91 ns |    13.22 ns |  6.84 |    0.09 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,507.1 ns |   9.09 ns |     8.06 ns |  4.98 |    0.05 |      - |     - |     - |         - |
