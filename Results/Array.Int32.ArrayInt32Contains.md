## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Count |         Mean |      Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **5.244 ns** |  **0.1048 ns** | **0.0929 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     5.245 ns |  0.0494 ns | 0.0412 ns |  1.00 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    15.751 ns |  0.1682 ns | 0.1491 ns |  3.00 |    0.07 |      - |     - |     - |         - |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     9.218 ns |  0.1367 ns | 0.1278 ns |  1.76 |    0.03 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |    10 |     6.667 ns |  0.0855 ns | 0.0714 ns |  1.27 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |     9.329 ns |  0.0609 ns | 0.0509 ns |  1.78 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    17.626 ns |  0.1033 ns | 0.0862 ns |  3.37 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    11.549 ns |  0.1556 ns | 0.1379 ns |  2.20 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    15.144 ns |  0.1044 ns | 0.0976 ns |  2.89 |    0.06 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |    10 |    20.450 ns |  0.0768 ns | 0.0719 ns |  3.90 |    0.07 |      - |     - |     - |         - |
|                      |          |          |       |              |            |           |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     3.235 ns |  0.0930 ns | 0.1210 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     3.172 ns |  0.0721 ns | 0.0675 ns |  0.98 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    15.779 ns |  0.2943 ns | 0.2753 ns |  4.88 |    0.20 |      - |     - |     - |         - |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     9.942 ns |  0.1375 ns | 0.1219 ns |  3.07 |    0.09 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |    10 |     3.604 ns |  0.0212 ns | 0.0188 ns |  1.11 |    0.04 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    12.336 ns |  0.0446 ns | 0.0395 ns |  3.81 |    0.14 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    17.758 ns |  0.2088 ns | 0.1953 ns |  5.49 |    0.20 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     6.541 ns |  0.0367 ns | 0.0344 ns |  2.02 |    0.07 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    14.675 ns |  0.0659 ns | 0.0616 ns |  4.54 |    0.17 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |    10 |    16.768 ns |  0.1280 ns | 0.1069 ns |  5.17 |    0.20 |      - |     - |     - |         - |
|                      |          |          |       |              |            |           |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **528.644 ns** | **10.0074 ns** | **8.8713 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |   525.217 ns |  2.4905 ns | 2.2078 ns |  0.99 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 |   245.192 ns |  0.8010 ns | 0.7101 ns |  0.46 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 |   237.828 ns |  1.2574 ns | 0.9817 ns |  0.45 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |  1000 |    85.217 ns |  0.4720 ns | 0.4415 ns |  0.16 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 |   232.427 ns |  0.7686 ns | 0.7190 ns |  0.44 |    0.01 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |   561.086 ns |  2.2574 ns | 1.7624 ns |  1.06 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 1,033.580 ns |  2.7382 ns | 2.5613 ns |  1.96 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |   232.501 ns |  0.7512 ns | 0.6273 ns |  0.44 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |  1000 |   114.813 ns |  0.9318 ns | 0.7781 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|                      |          |          |       |              |            |           |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   353.090 ns |  1.8360 ns | 1.5331 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |   353.111 ns |  1.7547 ns | 1.5555 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 |   280.359 ns |  0.9089 ns | 0.8502 ns |  0.79 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 |   273.144 ns |  1.3917 ns | 1.2337 ns |  0.77 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |  1000 |    88.245 ns |  0.2262 ns | 0.1889 ns |  0.25 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 |   275.958 ns |  1.0494 ns | 0.9302 ns |  0.78 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |   545.707 ns |  1.8468 ns | 1.5421 ns |  1.55 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   528.871 ns |  1.9693 ns | 1.8421 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |   273.908 ns |  0.7142 ns | 0.6331 ns |  0.78 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |  1000 |   111.369 ns |  0.7079 ns | 0.6275 ns |  0.32 |    0.00 |      - |     - |     - |         - |
