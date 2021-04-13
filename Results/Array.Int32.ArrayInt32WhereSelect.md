## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|               Method |    Job |  Runtime | Count |          Mean |       Error |      StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |--------------:|------------:|------------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |      **6.573 ns** |   **0.1753 ns** |   **0.1639 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |      8.223 ns |   0.0433 ns |   0.0405 ns |     1.25 |    0.03 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     87.447 ns |   0.5092 ns |   0.4514 ns |    13.29 |    0.35 |  0.0497 |     - |     - |     104 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     40.431 ns |   0.2613 ns |   0.2445 ns |     6.15 |    0.16 |  0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     58.845 ns |   0.2765 ns |   0.2586 ns |     8.96 |    0.23 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 46,280.953 ns | 197.4856 ns | 175.0659 ns | 7,034.20 |  181.60 | 14.2212 |     - |     - |  29,857 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    268.477 ns |   1.2347 ns |   1.1549 ns |    40.86 |    0.93 |  0.3519 |     - |     - |     736 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     56.978 ns |   0.2083 ns |   0.1948 ns |     8.67 |    0.22 |  0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     50.519 ns |   0.6440 ns |   0.6024 ns |     7.69 |    0.19 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     53.794 ns |   0.1992 ns |   0.1863 ns |     8.19 |    0.21 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     49.178 ns |   0.1596 ns |   0.1493 ns |     7.49 |    0.18 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |      7.365 ns |   0.0309 ns |   0.0289 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |      5.474 ns |   0.0395 ns |   0.0369 ns |     0.74 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     75.533 ns |   0.6684 ns |   0.6252 ns |    10.26 |    0.10 |  0.0497 |     - |     - |     104 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     40.833 ns |   0.3105 ns |   0.2904 ns |     5.54 |    0.05 |  0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     62.266 ns |   0.2424 ns |   0.2267 ns |     8.45 |    0.05 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 42,517.460 ns | 201.8765 ns | 178.9583 ns | 5,774.38 |   35.80 | 14.0991 |     - |     - |  29,599 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    258.889 ns |   2.1241 ns |   1.6584 ns |    35.19 |    0.23 |  0.3519 |     - |     - |     736 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     55.230 ns |   0.2153 ns |   0.1909 ns |     7.50 |    0.04 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     51.425 ns |   0.1641 ns |   0.1535 ns |     6.98 |    0.04 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     52.886 ns |   0.7204 ns |   0.6386 ns |     7.18 |    0.10 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     48.858 ns |   0.1435 ns |   0.1342 ns |     6.63 |    0.03 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |    **602.274 ns** |   **4.4156 ns** |   **4.1304 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    605.134 ns |   6.2555 ns |   5.5453 ns |     1.00 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  8,005.578 ns |  37.6256 ns |  35.1950 ns |    13.29 |    0.10 |  0.0458 |     - |     - |     104 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  4,736.535 ns |  18.1190 ns |  16.0621 ns |     7.86 |    0.06 |  2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  6,960.036 ns |  26.2010 ns |  23.2265 ns |    11.56 |    0.09 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 51,340.751 ns | 173.8074 ns | 162.5795 ns |    85.25 |    0.65 | 15.0757 |     - |     - |  31,867 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 15,563.806 ns |  64.0478 ns |  59.9104 ns |    25.84 |    0.19 |  0.3357 |     - |     - |     736 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,329.890 ns |  13.3825 ns |  10.4482 ns |     8.85 |    0.06 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,400.668 ns |  21.4331 ns |  20.0485 ns |     3.99 |    0.05 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,373.688 ns |  27.8772 ns |  26.0763 ns |     8.92 |    0.07 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5,534.391 ns |  25.6716 ns |  22.7572 ns |     9.19 |    0.07 |       - |     - |     - |         - |
|                      |        |          |       |               |             |             |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    816.314 ns |   7.6407 ns |   6.3803 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    810.892 ns |   4.2989 ns |   4.0212 ns |     0.99 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  6,399.913 ns |  35.2954 ns |  33.0153 ns |     7.84 |    0.06 |  0.0458 |     - |     - |     104 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  4,618.351 ns |  69.0732 ns |  61.2316 ns |     5.66 |    0.09 |  2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  6,544.632 ns |  26.7713 ns |  22.3553 ns |     8.02 |    0.06 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 46,708.394 ns | 259.2507 ns | 242.5032 ns |    57.18 |    0.47 | 15.0757 |     - |     - |  31,608 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 14,061.805 ns |  39.0172 ns |  36.4967 ns |    17.23 |    0.14 |  0.3510 |     - |     - |     736 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5,124.007 ns |  35.5790 ns |  33.2806 ns |     6.27 |    0.06 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,172.495 ns |  14.6124 ns |  12.9535 ns |     3.89 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,618.417 ns |  17.1716 ns |  16.0623 ns |     5.66 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  4,216.331 ns |  20.3939 ns |  19.0764 ns |     5.17 |    0.04 |       - |     - |     - |         - |
