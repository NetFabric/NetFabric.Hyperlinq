## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                      Method |    Job |  Runtime | Skip | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |----- |------ |------------:|----------:|----------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,051.1 ns |   3.56 ns |   3.33 ns |  1,052.2 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  7,620.7 ns |  30.57 ns |  27.10 ns |  7,614.6 ns |  7.25 |    0.03 |  0.0153 |     - |     - |      40 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 10,373.9 ns |  60.03 ns |  53.22 ns | 10,361.5 ns |  9.87 |    0.06 |  0.0610 |     - |     - |     152 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  7,402.0 ns |  48.15 ns |  40.21 ns |  7,402.6 ns |  7.04 |    0.04 |  5.8136 |     - |     - |  12,168 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 13,550.9 ns |  95.47 ns |  84.63 ns | 13,537.7 ns | 12.89 |    0.08 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 83,523.8 ns | 668.71 ns | 522.08 ns | 83,431.8 ns | 79.41 |    0.60 | 17.3340 |     - |     - |  36,347 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 23,675.2 ns | 112.37 ns |  99.61 ns | 23,657.3 ns | 22.52 |    0.11 |  0.4272 |     - |     - |     936 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,927.7 ns |  15.59 ns |  14.59 ns |  1,925.8 ns |  1.83 |    0.02 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,513.2 ns |   4.59 ns |   4.07 ns |  1,512.9 ns |  1.44 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,145.8 ns |  11.97 ns |  11.20 ns |  2,148.7 ns |  2.04 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,717.9 ns |  17.02 ns |  15.09 ns |  1,721.9 ns |  1.63 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,133.4 ns |   9.09 ns |   8.05 ns |  2,133.4 ns |  2.03 |    0.01 |       - |     - |     - |         - |
|                             |        |          |      |       |             |           |           |             |       |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |    663.7 ns |   4.27 ns |   3.78 ns |    664.7 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  6,576.4 ns |  25.39 ns |  22.51 ns |  6,574.7 ns |  9.91 |    0.06 |  0.0153 |     - |     - |      40 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  5,854.8 ns |  37.64 ns |  31.43 ns |  5,846.5 ns |  8.82 |    0.07 |  0.0687 |     - |     - |     152 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  7,698.3 ns | 153.90 ns | 365.76 ns |  7,478.2 ns | 12.34 |    0.35 |  5.8136 |     - |     - |  12,168 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 14,391.0 ns |  52.23 ns |  46.30 ns | 14,388.8 ns | 21.69 |    0.15 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 64,504.9 ns | 435.75 ns | 340.21 ns | 64,404.4 ns | 97.18 |    0.59 | 17.0898 |     - |     - |  35,908 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 20,318.4 ns |  89.74 ns |  79.55 ns | 20,322.9 ns | 30.62 |    0.27 |  0.4272 |     - |     - |     936 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,903.2 ns |   4.56 ns |   3.81 ns |  1,904.1 ns |  2.87 |    0.02 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,534.7 ns |   6.02 ns |   5.03 ns |  1,532.7 ns |  2.31 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,878.3 ns |   7.59 ns |   6.73 ns |  1,877.4 ns |  2.83 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,695.0 ns |   7.50 ns |   7.01 ns |  1,694.3 ns |  2.55 |    0.02 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,147.0 ns |  23.74 ns |  18.54 ns |  2,144.4 ns |  3.23 |    0.04 |       - |     - |     - |         - |
