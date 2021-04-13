## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |        Error |     StdDev |    Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-------------:|-----------:|---------:|--------:|--------:|--------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **39.54 ns** |     **0.142 ns** |   **0.126 ns** |     **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     51.65 ns |     0.158 ns |   0.148 ns |     1.31 |    0.00 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    136.61 ns |     0.831 ns |   0.777 ns |     3.45 |    0.02 |  0.1032 |       - |     - |     216 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |    104.37 ns |     0.860 ns |   0.805 ns |     2.64 |    0.02 |  0.3901 |       - |     - |     816 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    187.95 ns |     3.671 ns |   4.227 ns |     4.74 |    0.11 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 52,663.71 ns |   269.881 ns | 252.447 ns | 1,331.93 |    7.47 | 71.4111 |       - |     - | 153,308 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    510.38 ns |     2.242 ns |   2.097 ns |    12.91 |    0.08 |  0.4663 |       - |     - |     976 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     90.66 ns |     0.254 ns |   0.238 ns |     2.29 |    0.01 |  0.0305 |       - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     93.03 ns |     0.327 ns |   0.306 ns |     2.35 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    134.61 ns |     0.454 ns |   0.424 ns |     3.40 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |    110.63 ns |     0.908 ns |   0.758 ns |     2.80 |    0.02 |       - |       - |     - |         - |
|                      |        |          |       |              |              |            |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     39.49 ns |     0.106 ns |   0.099 ns |     1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     50.00 ns |     0.235 ns |   0.197 ns |     1.27 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    120.49 ns |     1.386 ns |   1.297 ns |     3.05 |    0.03 |  0.1032 |       - |     - |     216 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |    104.94 ns |     0.924 ns |   0.864 ns |     2.66 |    0.02 |  0.3901 |       - |     - |     816 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    188.76 ns |     3.765 ns |   4.482 ns |     4.80 |    0.12 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 50,340.34 ns |   334.438 ns | 312.834 ns | 1,274.91 |    8.12 | 71.4111 |       - |     - | 153,052 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    494.63 ns |     2.782 ns |   2.602 ns |    12.53 |    0.07 |  0.4663 |       - |     - |     976 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     91.58 ns |     0.349 ns |   0.292 ns |     2.32 |    0.01 |  0.0305 |       - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     90.45 ns |     0.396 ns |   0.370 ns |     2.29 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    129.15 ns |     0.732 ns |   0.684 ns |     3.27 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |    106.68 ns |     0.885 ns |   0.739 ns |     2.70 |    0.02 |       - |       - |     - |         - |
|                      |        |          |       |              |              |            |          |         |         |         |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **8,825.56 ns** |    **28.615 ns** |  **25.366 ns** |     **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  9,984.56 ns |    33.395 ns |  31.237 ns |     1.13 |    0.00 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 15,844.95 ns |   118.684 ns | 111.017 ns |     1.80 |    0.01 |  0.0916 |       - |     - |     216 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 17,344.38 ns |   222.799 ns | 218.818 ns |     1.97 |    0.03 | 45.4407 |       - |     - |  96,240 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 30,847.97 ns |   260.106 ns | 243.303 ns |     3.50 |    0.03 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 75,460.86 ns |   494.844 ns | 413.217 ns |     8.55 |    0.05 | 68.1152 | 22.7051 |     - | 185,369 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 64,036.47 ns | 1,073.305 ns | 837.966 ns |     7.25 |    0.10 |  0.3662 |       - |     - |     976 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 12,780.22 ns |    24.061 ns |  22.506 ns |     1.45 |    0.00 |  0.0305 |       - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 10,887.34 ns |    56.128 ns |  52.502 ns |     1.23 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 17,532.79 ns |    73.689 ns |  68.929 ns |     1.99 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 12,717.71 ns |    51.329 ns |  48.013 ns |     1.44 |    0.01 |       - |       - |     - |         - |
|                      |        |          |       |              |              |            |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  8,815.54 ns |    29.150 ns |  27.267 ns |     1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 10,018.06 ns |    50.643 ns |  47.372 ns |     1.14 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 16,155.69 ns |   201.511 ns | 178.634 ns |     1.83 |    0.02 |  0.0916 |       - |     - |     216 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 17,097.29 ns |   113.197 ns | 105.884 ns |     1.94 |    0.01 | 45.4407 |       - |     - |  96,240 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 23,255.77 ns |   209.531 ns | 185.744 ns |     2.64 |    0.02 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 72,420.55 ns |   345.828 ns | 323.488 ns |     8.22 |    0.05 | 68.1152 | 22.7051 |     - | 185,113 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 65,073.38 ns |   344.141 ns | 321.910 ns |     7.38 |    0.04 |  0.3662 |       - |     - |     976 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 11,706.00 ns |    43.759 ns |  38.791 ns |     1.33 |    0.01 |  0.0305 |       - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 10,128.51 ns |    47.199 ns |  44.150 ns |     1.15 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 17,451.66 ns |   145.326 ns | 121.354 ns |     1.98 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 12,714.39 ns |    30.551 ns |  27.083 ns |     1.44 |    0.00 |       - |       - |     - |         - |
