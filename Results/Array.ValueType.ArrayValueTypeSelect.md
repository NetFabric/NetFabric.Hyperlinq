## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                      Method |    Job |  Runtime | Count |         Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |------ |-------------:|----------:|----------:|-------:|--------:|--------:|--------:|------:|----------:|
|                     **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **161.9 ns** |   **0.53 ns** |   **0.47 ns** |   **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 |    10 |     175.7 ns |   0.33 ns |   0.31 ns |   1.08 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |    10 |     260.9 ns |   1.20 ns |   1.12 ns |   1.61 |    0.01 |  0.0496 |       - |     - |     104 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |    10 |     232.3 ns |   1.28 ns |   1.13 ns |   1.43 |    0.01 |  0.3173 |       - |     - |     664 B |
|                      LinqAF | .NET 5 | .NET 5.0 |    10 |     342.9 ns |   1.28 ns |   1.20 ns |   2.12 |    0.01 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |    10 |  42,719.8 ns | 171.67 ns | 134.03 ns | 263.74 |    1.19 | 64.5752 | 15.9302 |     - | 151,129 B |
|                     Streams | .NET 5 | .NET 5.0 |    10 |   1,235.1 ns |   8.12 ns |   6.34 ns |   7.63 |    0.04 |  0.3929 |       - |     - |     824 B |
|                  StructLinq | .NET 5 | .NET 5.0 |    10 |     207.1 ns |   1.14 ns |   1.01 ns |   1.28 |    0.01 |  0.0153 |       - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     199.5 ns |   0.40 ns |   0.31 ns |   1.23 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |    10 |     223.1 ns |   0.58 ns |   0.51 ns |   1.38 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 |    10 |     201.3 ns |   0.76 ns |   0.71 ns |   1.24 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |    10 |     214.9 ns |   0.77 ns |   0.72 ns |   1.33 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 |    10 |     189.4 ns |   0.57 ns |   0.54 ns |   1.17 |    0.00 |       - |       - |     - |         - |
|                             |        |          |       |              |           |           |        |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |    10 |     162.1 ns |   0.55 ns |   0.49 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |    10 |     176.0 ns |   0.64 ns |   0.60 ns |   1.09 |    0.01 |       - |       - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |    10 |     242.1 ns |   0.81 ns |   0.72 ns |   1.49 |    0.01 |  0.0496 |       - |     - |     104 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |    10 |     229.5 ns |   1.11 ns |   1.04 ns |   1.42 |    0.01 |  0.3173 |       - |     - |     664 B |
|                      LinqAF | .NET 6 | .NET 6.0 |    10 |     341.2 ns |   1.51 ns |   1.41 ns |   2.11 |    0.01 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |    10 |  40,913.6 ns | 183.18 ns | 171.34 ns | 252.50 |    1.16 | 70.0073 |  3.2349 |     - | 150,886 B |
|                     Streams | .NET 6 | .NET 6.0 |    10 |   1,225.3 ns |   7.19 ns |   6.37 ns |   7.56 |    0.05 |  0.3929 |       - |     - |     824 B |
|                  StructLinq | .NET 6 | .NET 6.0 |    10 |     208.1 ns |   0.63 ns |   0.52 ns |   1.28 |    0.00 |  0.0153 |       - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     280.4 ns |   0.37 ns |   0.31 ns |   1.73 |    0.01 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |    10 |     223.9 ns |   0.77 ns |   0.65 ns |   1.38 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 |    10 |     199.8 ns |   0.76 ns |   0.71 ns |   1.23 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |    10 |     214.4 ns |   0.26 ns |   0.22 ns |   1.32 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 |    10 |     189.8 ns |   0.85 ns |   0.71 ns |   1.17 |    0.01 |       - |       - |     - |         - |
|                             |        |          |       |              |           |           |        |         |         |         |       |           |
|                     **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **16,255.6 ns** |  **67.56 ns** |  **63.19 ns** |   **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  17,555.9 ns |  77.84 ns |  72.81 ns |   1.08 |    0.01 |       - |       - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |  1000 |  22,440.6 ns | 110.51 ns |  92.28 ns |   1.38 |    0.01 |  0.0305 |       - |     - |     104 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |  1000 |  22,950.7 ns | 154.41 ns | 144.43 ns |   1.41 |    0.01 | 30.2734 |       - |     - |  64,024 B |
|                      LinqAF | .NET 5 | .NET 5.0 |  1000 |  29,864.7 ns | 142.07 ns | 118.64 ns |   1.84 |    0.01 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |  1000 |  78,564.2 ns | 424.85 ns | 376.62 ns |   4.83 |    0.03 | 99.9756 |       - |     - | 214,521 B |
|                     Streams | .NET 5 | .NET 5.0 |  1000 | 104,235.8 ns | 436.97 ns | 408.74 ns |   6.41 |    0.03 |  0.3662 |       - |     - |     824 B |
|                  StructLinq | .NET 5 | .NET 5.0 |  1000 |  18,378.3 ns |  63.73 ns |  59.61 ns |   1.13 |    0.01 |       - |       - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  17,416.0 ns | 132.02 ns | 117.03 ns |   1.07 |    0.01 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |  1000 |  19,470.8 ns |  59.22 ns |  46.24 ns |   1.20 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 |  1000 |  17,086.6 ns |  64.82 ns |  60.63 ns |   1.05 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |  1000 |  19,390.9 ns |  37.39 ns |  31.22 ns |   1.19 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 |  1000 |  17,314.8 ns |  69.62 ns |  65.13 ns |   1.07 |    0.01 |       - |       - |     - |         - |
|                             |        |          |       |              |           |           |        |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |  1000 |  16,267.1 ns | 120.57 ns | 106.88 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  17,842.6 ns |  76.54 ns |  71.60 ns |   1.10 |    0.01 |       - |       - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |  1000 |  21,357.4 ns |  78.00 ns |  72.96 ns |   1.31 |    0.01 |  0.0305 |       - |     - |     104 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |  1000 |  23,304.9 ns | 138.99 ns | 130.01 ns |   1.43 |    0.01 | 30.2734 |       - |     - |  64,024 B |
|                      LinqAF | .NET 6 | .NET 6.0 |  1000 |  29,936.7 ns | 302.93 ns | 283.36 ns |   1.84 |    0.03 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |  1000 |  79,166.9 ns | 538.15 ns | 503.39 ns |   4.87 |    0.05 | 99.9756 |       - |     - | 214,273 B |
|                     Streams | .NET 6 | .NET 6.0 |  1000 | 103,925.7 ns | 675.20 ns | 598.55 ns |   6.39 |    0.05 |  0.3662 |       - |     - |     824 B |
|                  StructLinq | .NET 6 | .NET 6.0 |  1000 |  18,421.7 ns | 111.72 ns |  93.30 ns |   1.13 |    0.01 |       - |       - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  17,898.7 ns |  64.04 ns |  59.91 ns |   1.10 |    0.01 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |  1000 |  19,408.5 ns |  34.53 ns |  32.30 ns |   1.19 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 |  1000 |  17,083.5 ns |  50.27 ns |  44.57 ns |   1.05 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |  1000 |  26,430.2 ns |  65.81 ns |  61.56 ns |   1.62 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 |  1000 |  17,290.3 ns |  72.21 ns |  67.55 ns |   1.06 |    0.01 |       - |       - |     - |         - |
