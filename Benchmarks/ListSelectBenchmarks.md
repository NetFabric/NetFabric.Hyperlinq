## ListSelectBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |     **0** |   **0.2325 ns** | **0.0116 ns** | **0.0103 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 Linq_Select |     0 |  42.8013 ns | 0.3199 ns | 0.2993 ns | 184.40 |    8.29 | 0.0344 |     - |     - |      72 B |
|           StructLinq_Select |     0 |  15.7536 ns | 0.1074 ns | 0.1004 ns |  67.88 |    3.33 |      - |     - |     - |         - |
| StructLinq_Select_IFunction |     0 |  15.5667 ns | 0.1457 ns | 0.1291 ns |  67.06 |    3.01 |      - |     - |     - |         - |
|            Hyperlinq_Select |     0 |   8.7595 ns | 0.1176 ns | 0.1100 ns |  37.77 |    1.55 |      - |     - |     - |         - |
|                             |       |             |           |           |        |         |        |       |       |           |
|                     **ForLoop** |     **1** |   **1.3654 ns** | **0.0244 ns** | **0.0229 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 Linq_Select |     1 |  54.2252 ns | 0.2895 ns | 0.2708 ns |  39.72 |    0.66 | 0.0344 |     - |     - |      72 B |
|           StructLinq_Select |     1 |  18.8754 ns | 0.0804 ns | 0.0752 ns |  13.83 |    0.24 |      - |     - |     - |         - |
| StructLinq_Select_IFunction |     1 |  18.0758 ns | 0.1026 ns | 0.0960 ns |  13.24 |    0.22 |      - |     - |     - |         - |
|            Hyperlinq_Select |     1 |  11.0822 ns | 0.0749 ns | 0.0701 ns |   8.12 |    0.10 |      - |     - |     - |         - |
|                             |       |             |           |           |        |         |        |       |       |           |
|                     **ForLoop** |    **10** |  **10.6196 ns** | **0.0636 ns** | **0.0496 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 Linq_Select |    10 | 128.2891 ns | 0.7718 ns | 0.7220 ns |  12.08 |    0.09 | 0.0343 |     - |     - |      72 B |
|           StructLinq_Select |    10 |  35.9907 ns | 0.3381 ns | 0.2997 ns |   3.39 |    0.03 |      - |     - |     - |         - |
| StructLinq_Select_IFunction |    10 |  31.9794 ns | 0.3508 ns | 0.3282 ns |   3.02 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq_Select |    10 |  33.1477 ns | 0.1009 ns | 0.0843 ns |   3.12 |    0.01 |      - |     - |     - |         - |
|                             |       |             |           |           |        |         |        |       |       |           |
|                     **ForLoop** |   **100** | **105.7037 ns** | **0.4353 ns** | **0.3859 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 Linq_Select |   100 | 799.9057 ns | 7.1268 ns | 6.6664 ns |   7.57 |    0.07 | 0.0343 |     - |     - |      72 B |
|           StructLinq_Select |   100 | 279.8216 ns | 5.1823 ns | 4.5940 ns |   2.65 |    0.04 |      - |     - |     - |         - |
| StructLinq_Select_IFunction |   100 | 161.4922 ns | 0.6150 ns | 0.5136 ns |   1.53 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq_Select |   100 | 275.5350 ns | 1.6825 ns | 1.4915 ns |   2.61 |    0.02 |      - |     - |     - |         - |
