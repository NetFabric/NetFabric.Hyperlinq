## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |     **5.237 ns** |  **0.0332 ns** |  **0.0310 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     5.228 ns |  0.0133 ns |  0.0124 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                        Linq |    10 |   110.780 ns |  0.4139 ns |  0.3872 ns | 21.15 |    0.16 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |    10 |    33.928 ns |  0.0708 ns |  0.0628 ns |  6.48 |    0.04 | 0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD |    10 |    20.031 ns |  0.0839 ns |  0.0785 ns |  3.83 |    0.03 | 0.0306 |     - |     - |      64 B |
|                      LinqAF |    10 |    64.037 ns |  0.6827 ns |  0.5330 ns | 12.24 |    0.11 |      - |     - |     - |         - |
|                  StructLinq |    10 |    41.533 ns |  0.1432 ns |  0.1270 ns |  7.93 |    0.05 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    37.240 ns |  0.0840 ns |  0.0786 ns |  7.11 |    0.05 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    43.292 ns |  0.2444 ns |  0.2041 ns |  8.27 |    0.05 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    40.861 ns |  0.1278 ns |  0.1133 ns |  7.81 |    0.05 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    32.632 ns |  0.1384 ns |  0.1295 ns |  6.23 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    22.671 ns |  0.1220 ns |  0.1081 ns |  4.33 |    0.03 |      - |     - |     - |         - |
|                             |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |   **536.048 ns** |  **1.4677 ns** |  **1.3729 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |   397.317 ns |  1.4207 ns |  1.3289 ns |  0.74 |    0.00 |      - |     - |     - |         - |
|                        Linq |  1000 | 6,116.887 ns | 42.8048 ns | 35.7440 ns | 11.41 |    0.08 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |  1000 | 2,740.892 ns |  8.9595 ns |  8.3807 ns |  5.11 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD |  1000 |   915.668 ns |  4.8828 ns |  4.5673 ns |  1.71 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                      LinqAF |  1000 | 4,007.923 ns | 17.0761 ns | 15.9730 ns |  7.48 |    0.04 |      - |     - |     - |         - |
|                  StructLinq |  1000 | 2,132.203 ns |  5.1236 ns |  4.2785 ns |  3.98 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 1,416.806 ns |  4.4141 ns |  4.1289 ns |  2.64 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 2,156.985 ns |  7.0956 ns |  6.6373 ns |  4.02 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,478.098 ns |  5.1281 ns |  4.2822 ns |  2.76 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 2,127.134 ns |  8.0410 ns |  7.1281 ns |  3.97 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |   804.985 ns |  2.4018 ns |  2.2467 ns |  1.50 |    0.01 |      - |     - |     - |         - |
