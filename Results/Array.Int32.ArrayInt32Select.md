## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                      Method |    Job |  Runtime | Count |         Mean |        Error |       StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |------ |-------------:|-------------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | .NET 5 | .NET 5.0 |  1000 |     550.2 ns |      4.85 ns |      4.54 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 5 | .NET 5.0 |  1000 |     537.5 ns |      4.12 ns |      3.44 ns |   0.98 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |  1000 |   6,369.4 ns |     53.15 ns |     44.38 ns |  11.57 |    0.09 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |  1000 |   2,878.5 ns |     15.45 ns |     14.45 ns |   5.23 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD | .NET 5 | .NET 5.0 |  1000 |     923.1 ns |      7.70 ns |     11.04 ns |   1.69 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                      LinqAF | .NET 5 | .NET 5.0 |  1000 |   5,180.3 ns |     38.34 ns |     35.87 ns |   9.42 |    0.09 |      - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 270,023.9 ns | 24,529.20 ns | 69,185.06 ns | 514.67 |  142.47 |      - |     - |     - |  31,936 B |
|                     Streams | .NET 5 | .NET 5.0 |  1000 |  14,013.9 ns |     66.78 ns |     59.20 ns |  25.45 |    0.16 | 0.2747 |     - |     - |     584 B |
|                  StructLinq | .NET 5 | .NET 5.0 |  1000 |   1,879.1 ns |     20.79 ns |     18.43 ns |   3.41 |    0.05 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |   1,446.8 ns |      8.59 ns |      7.61 ns |   2.63 |    0.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |  1000 |   1,856.2 ns |      4.77 ns |      3.99 ns |   3.37 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 | .NET 5.0 |  1000 |   1,638.2 ns |     13.61 ns |     12.06 ns |   2.97 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |  1000 |   2,161.3 ns |     42.56 ns |     52.26 ns |   3.93 |    0.10 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 | .NET 5.0 |  1000 |     827.9 ns |      9.98 ns |      8.85 ns |   1.50 |    0.02 |      - |     - |     - |         - |
|                             |        |          |       |              |              |              |        |         |        |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |  1000 |     555.4 ns |      9.80 ns |      9.16 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |  1000 |     554.1 ns |      5.79 ns |      5.13 ns |   1.00 |    0.02 |      - |     - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |  1000 |   4,333.9 ns |     74.68 ns |     66.20 ns |   7.80 |    0.17 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |  1000 |   2,370.6 ns |     46.50 ns |     57.11 ns |   4.28 |    0.12 | 1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD | .NET 6 | .NET 6.0 |  1000 |   2,856.6 ns |     42.32 ns |     39.58 ns |   5.15 |    0.13 | 1.9226 |     - |     - |   4,024 B |
|                      LinqAF | .NET 6 | .NET 6.0 |  1000 |   5,670.0 ns |    111.67 ns |    104.45 ns |  10.21 |    0.29 |      - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 274,087.6 ns | 20,197.31 ns | 55,966.65 ns | 505.47 |   95.80 |      - |     - |     - |  31,688 B |
|                     Streams | .NET 6 | .NET 6.0 |  1000 |  12,096.4 ns |    152.61 ns |    135.28 ns |  21.77 |    0.54 | 0.2747 |     - |     - |     584 B |
|                  StructLinq | .NET 6 | .NET 6.0 |  1000 |   1,882.5 ns |     15.96 ns |     13.32 ns |   3.39 |    0.07 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |   1,600.9 ns |     15.98 ns |     14.94 ns |   2.88 |    0.06 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |  1000 |   1,895.9 ns |     15.40 ns |     13.65 ns |   3.41 |    0.06 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | .NET 6.0 |  1000 |   1,629.2 ns |     13.18 ns |     11.68 ns |   2.93 |    0.05 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |  1000 |   2,140.5 ns |     34.62 ns |     30.69 ns |   3.85 |    0.06 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | .NET 6.0 |  1000 |     812.8 ns |      3.01 ns |      2.35 ns |   1.47 |    0.02 |      - |     - |     - |         - |
