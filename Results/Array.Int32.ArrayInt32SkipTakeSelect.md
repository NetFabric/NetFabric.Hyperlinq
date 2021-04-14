## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method |    Job |  Runtime | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |----- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |    784.8 ns |   2.65 ns |   2.34 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  4,700.6 ns |  47.01 ns |  41.68 ns |  5.99 |    0.06 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 10,460.6 ns | 121.35 ns | 113.51 ns | 13.31 |    0.14 |  0.0610 |     - |     - |     152 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  3,014.6 ns |  38.41 ns |  35.93 ns |  3.84 |    0.05 |  5.7678 |     - |     - |  12,072 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 10,250.2 ns |  47.42 ns |  42.04 ns | 13.06 |    0.07 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 54,449.5 ns | 309.40 ns | 472.49 ns | 69.51 |    0.60 | 16.7236 |     - |     - |  35,071 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 22,142.0 ns | 190.03 ns | 168.45 ns | 28.21 |    0.24 |  0.4272 |     - |     - |     912 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,922.5 ns |   9.50 ns |   8.89 ns |  2.45 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,535.5 ns |   7.06 ns |   6.25 ns |  1.96 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,163.6 ns |  10.81 ns |   9.58 ns |  2.76 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,704.9 ns |   7.23 ns |   6.41 ns |  2.17 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,153.6 ns |  13.55 ns |  11.31 ns |  2.74 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |    831.1 ns |   2.94 ns |   2.46 ns |  1.06 |    0.00 |       - |     - |     - |         - |
|                             |        |          |      |       |             |           |           |       |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |    562.6 ns |   3.79 ns |   3.36 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,600.8 ns |   5.83 ns |   4.87 ns |  4.62 |    0.02 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  8,887.1 ns |  37.49 ns |  31.30 ns | 15.78 |    0.08 |  0.0610 |     - |     - |     152 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  3,055.2 ns |  34.86 ns |  32.61 ns |  5.43 |    0.08 |  5.7678 |     - |     - |  12,072 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 10,389.3 ns |  72.05 ns |  60.17 ns | 18.44 |    0.12 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 47,176.2 ns | 165.51 ns | 162.55 ns | 83.85 |    0.51 | 16.6016 |     - |     - |  34,822 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 19,229.5 ns |  77.29 ns |  60.34 ns | 34.13 |    0.21 |  0.4272 |     - |     - |     912 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,229.7 ns |  16.16 ns |  13.49 ns |  3.96 |    0.03 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,559.1 ns |  12.46 ns |  11.66 ns |  2.77 |    0.03 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,148.9 ns |  13.25 ns |  11.07 ns |  3.81 |    0.03 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,673.8 ns |   4.29 ns |   3.58 ns |  2.97 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,130.7 ns |   8.40 ns |   7.86 ns |  3.79 |    0.03 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,336.9 ns |   4.57 ns |   4.27 ns |  2.38 |    0.01 |       - |     - |     - |         - |
