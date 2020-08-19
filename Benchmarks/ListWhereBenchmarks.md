## ListWhereBenchmarks

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
|                     Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |------ |------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|                    **ForLoop** |     **0** |   **0.2955 ns** | **0.0121 ns** | **0.0107 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 Linq_Where |     0 |  40.8994 ns | 0.3981 ns | 0.3529 ns | 138.57 |    5.20 | 0.0344 |     - |     - |      72 B |
|           StructLinq_Where |     0 |  15.7470 ns | 0.0586 ns | 0.0548 ns |  53.35 |    1.92 |      - |     - |     - |         - |
| StructLinq_Where_IFunction |     0 |  15.8440 ns | 0.0556 ns | 0.0520 ns |  53.70 |    1.90 |      - |     - |     - |         - |
|            Hyperlinq_Where |     0 |  10.8830 ns | 0.0740 ns | 0.0656 ns |  36.87 |    1.37 |      - |     - |     - |         - |
|                            |       |             |           |           |        |         |        |       |       |           |
|                    **ForLoop** |     **1** |   **0.8788 ns** | **0.0108 ns** | **0.0090 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 Linq_Where |     1 |  54.4518 ns | 0.3770 ns | 0.3527 ns |  61.97 |    0.88 | 0.0344 |     - |     - |      72 B |
|           StructLinq_Where |     1 |  19.7296 ns | 0.1601 ns | 0.1498 ns |  22.49 |    0.26 |      - |     - |     - |         - |
| StructLinq_Where_IFunction |     1 |  18.9026 ns | 0.1059 ns | 0.0826 ns |  21.53 |    0.24 |      - |     - |     - |         - |
|            Hyperlinq_Where |     1 |  16.1697 ns | 0.1423 ns | 0.1331 ns |  18.42 |    0.25 |      - |     - |     - |         - |
|                            |       |             |           |           |        |         |        |       |       |           |
|                    **ForLoop** |    **10** |  **11.4211 ns** | **0.0415 ns** | **0.0368 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 Linq_Where |    10 | 102.2884 ns | 0.4998 ns | 0.4173 ns |   8.96 |    0.04 | 0.0343 |     - |     - |      72 B |
|           StructLinq_Where |    10 |  41.1160 ns | 0.2240 ns | 0.1986 ns |   3.60 |    0.01 |      - |     - |     - |         - |
| StructLinq_Where_IFunction |    10 |  31.6421 ns | 0.1369 ns | 0.1280 ns |   2.77 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq_Where |    10 |  53.7458 ns | 0.2854 ns | 0.2670 ns |   4.70 |    0.03 |      - |     - |     - |         - |
|                            |       |             |           |           |        |         |        |       |       |           |
|                    **ForLoop** |   **100** | **125.1985 ns** | **1.3677 ns** | **1.2793 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 Linq_Where |   100 | 632.3713 ns | 3.1994 ns | 2.8362 ns |   5.05 |    0.06 | 0.0343 |     - |     - |      72 B |
|           StructLinq_Where |   100 | 315.5355 ns | 1.8830 ns | 1.7613 ns |   2.52 |    0.03 |      - |     - |     - |         - |
| StructLinq_Where_IFunction |   100 | 166.7549 ns | 1.0642 ns | 0.9434 ns |   1.33 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq_Where |   100 | 346.7667 ns | 2.7493 ns | 2.5717 ns |   2.77 |    0.03 |      - |     - |     - |         - |
