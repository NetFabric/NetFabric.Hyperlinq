## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|               Method |    Job |  Runtime | Count |          Mean |       Error |      StdDev |        Median |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |--------------:|------------:|------------:|--------------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **5.679 ns** |   **0.0525 ns** |   **0.0491 ns** |      **5.687 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |      8.704 ns |   0.0474 ns |   0.0443 ns |      8.708 ns |     1.53 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     62.945 ns |   0.3142 ns |   0.2939 ns |     62.842 ns |    11.09 |    0.08 |  0.0229 |     - |     - |      48 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 45,345.771 ns | 214.6773 ns | 200.8092 ns | 45,411.255 ns | 7,985.72 |   53.94 | 14.0991 |     - |     - |  29,525 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    292.474 ns |   3.8009 ns |   2.9675 ns |    291.206 ns |    51.42 |    0.61 |  0.2904 |     - |     - |     608 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     58.572 ns |   0.2317 ns |   0.2054 ns |     58.574 ns |    10.31 |    0.07 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     46.596 ns |   0.1738 ns |   0.1541 ns |     46.600 ns |     8.20 |    0.07 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     42.175 ns |   0.5255 ns |   0.4388 ns |     42.047 ns |     7.41 |    0.09 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     43.194 ns |   0.0993 ns |   0.0929 ns |     43.201 ns |     7.61 |    0.07 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      6.446 ns |   0.0576 ns |   0.0511 ns |      6.427 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |      8.056 ns |   0.1212 ns |   0.1074 ns |      8.033 ns |     1.25 |    0.02 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     48.582 ns |   0.1949 ns |   0.1728 ns |     48.555 ns |     7.54 |    0.06 |  0.0229 |     - |     - |      48 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 41,000.325 ns | 226.4190 ns | 211.7925 ns | 41,006.769 ns | 6,360.51 |   67.93 | 13.8550 |     - |     - |  29,083 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    266.036 ns |   2.7247 ns |   2.2753 ns |    265.989 ns |    41.33 |    0.38 |  0.2904 |     - |     - |     608 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     38.697 ns |   0.6761 ns |   1.6328 ns |     37.950 ns |     6.42 |    0.28 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     37.048 ns |   0.1258 ns |   0.1176 ns |     37.028 ns |     5.75 |    0.06 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     42.872 ns |   0.1307 ns |   0.1223 ns |     42.848 ns |     6.65 |    0.06 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     39.399 ns |   0.1419 ns |   0.1327 ns |     39.346 ns |     6.11 |    0.05 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **618.295 ns** |   **4.2395 ns** |   **3.7582 ns** |    **617.960 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    912.018 ns |   4.2225 ns |   3.5259 ns |    911.323 ns |     1.47 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  6,395.906 ns |  27.2346 ns |  25.4752 ns |  6,394.786 ns |    10.35 |    0.07 |  0.0229 |     - |     - |      48 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 57,470.541 ns | 225.6370 ns | 211.0610 ns | 57,490.619 ns |    92.91 |    0.72 | 15.0757 |     - |     - |  31,536 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 18,576.054 ns | 228.2108 ns | 190.5664 ns | 18,504.886 ns |    30.02 |    0.38 |  0.2747 |     - |     - |     608 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  7,692.067 ns |  43.2649 ns |  40.4700 ns |  7,683.576 ns |    12.44 |    0.07 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5,260.246 ns |  22.4373 ns |  20.9878 ns |  5,265.728 ns |     8.51 |    0.06 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,619.743 ns |  18.3849 ns |  17.1972 ns |  5,620.684 ns |     9.09 |    0.06 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,055.829 ns |  11.5162 ns |   9.6165 ns |  2,058.763 ns |     3.32 |    0.03 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |               |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    735.185 ns |   3.0382 ns |   2.8420 ns |    734.812 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    817.071 ns |   3.3763 ns |   2.9930 ns |    817.194 ns |     1.11 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  6,837.371 ns |  23.4473 ns |  21.9326 ns |  6,835.535 ns |     9.30 |    0.04 |  0.0229 |     - |     - |      48 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 50,700.003 ns | 242.4648 ns | 214.9387 ns | 50,723.108 ns |    68.94 |    0.36 | 14.8315 |     - |     - |  31,093 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 15,839.384 ns |  91.2748 ns |  85.3785 ns | 15,837.787 ns |    21.55 |    0.14 |  0.2747 |     - |     - |     608 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  6,195.979 ns |  19.9745 ns |  18.6842 ns |  6,199.126 ns |     8.43 |    0.04 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,717.876 ns |   7.0254 ns |   6.5716 ns |  1,716.874 ns |     2.34 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  3,536.668 ns |  34.4368 ns |  26.8860 ns |  3,530.046 ns |     4.81 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,000.481 ns |   8.2430 ns |   7.7105 ns |  2,002.187 ns |     2.72 |    0.02 |       - |     - |     - |         - |
