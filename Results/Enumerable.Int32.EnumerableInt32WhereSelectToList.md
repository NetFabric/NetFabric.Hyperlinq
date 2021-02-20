## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **227.67 ns** |   **0.508 ns** |   **0.451 ns** |  **2.34** |    **0.01** | **0.0801** |     **-** |     **-** |     **168 B** |
|                       ValueLinq_Stack |    10 |   229.12 ns |   0.605 ns |   0.472 ns |  2.35 |    0.01 | 0.0570 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Push |    10 |   467.93 ns |   0.887 ns |   0.786 ns |  4.80 |    0.01 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Pull |    10 |   364.83 ns |   1.305 ns |   1.157 ns |  3.74 |    0.01 | 0.0572 |     - |     - |     120 B |
|        ValueLinq_ValueLambda_Standard |    10 |   211.04 ns |   0.483 ns |   0.452 ns |  2.17 |    0.01 | 0.0801 |     - |     - |     168 B |
|           ValueLinq_ValueLambda_Stack |    10 |   193.42 ns |   0.491 ns |   0.435 ns |  1.98 |    0.01 | 0.0570 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   373.74 ns |   1.014 ns |   0.899 ns |  3.83 |    0.01 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   329.01 ns |   1.208 ns |   1.071 ns |  3.38 |    0.02 | 0.0572 |     - |     - |     120 B |
|                           ForeachLoop |    10 |    97.47 ns |   0.268 ns |   0.238 ns |  1.00 |    0.00 | 0.0802 |     - |     - |     168 B |
|                                  Linq |    10 |   177.24 ns |   0.596 ns |   0.529 ns |  1.82 |    0.01 | 0.1376 |     - |     - |     288 B |
|                                LinqAF |    10 |   202.93 ns |   1.011 ns |   0.789 ns |  2.08 |    0.01 | 0.0801 |     - |     - |     168 B |
|                            StructLinq |    10 |   213.18 ns |   0.792 ns |   0.662 ns |  2.19 |    0.01 | 0.0994 |     - |     - |     208 B |
|                  StructLinq_IFunction |    10 |   162.64 ns |   0.355 ns |   0.297 ns |  1.67 |    0.01 | 0.0572 |     - |     - |     120 B |
|                             Hyperlinq |    10 |   175.80 ns |   0.306 ns |   0.256 ns |  1.80 |    0.00 | 0.0572 |     - |     - |     120 B |
|                   Hyperlinq_IFunction |    10 |   144.71 ns |   0.554 ns |   0.491 ns |  1.48 |    0.01 | 0.0572 |     - |     - |     120 B |
|                                       |       |             |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **8,129.07 ns** |  **64.888 ns** |  **54.185 ns** |  **1.43** |    **0.01** | **2.0752** |     **-** |     **-** |    **4344 B** |
|                       ValueLinq_Stack |  1000 | 8,635.96 ns |  22.484 ns |  19.932 ns |  1.52 |    0.01 | 1.9989 |     - |     - |    4200 B |
|             ValueLinq_SharedPool_Push |  1000 | 8,271.40 ns |  32.647 ns |  28.941 ns |  1.46 |    0.01 | 0.9918 |     - |     - |    2096 B |
|             ValueLinq_SharedPool_Pull |  1000 | 8,024.70 ns | 147.674 ns | 170.062 ns |  1.42 |    0.03 | 0.9918 |     - |     - |    2096 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 5,285.49 ns |  31.146 ns |  26.008 ns |  0.93 |    0.00 | 2.0752 |     - |     - |    4344 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,177.65 ns |  14.684 ns |  13.017 ns |  1.09 |    0.00 | 2.0065 |     - |     - |    4200 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 5,655.73 ns |  17.354 ns |  15.384 ns |  1.00 |    0.00 | 0.9995 |     - |     - |    2096 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 6,149.01 ns |  12.329 ns |  10.929 ns |  1.09 |    0.00 | 0.9995 |     - |     - |    2096 B |
|                           ForeachLoop |  1000 | 5,666.00 ns |  16.014 ns |  14.196 ns |  1.00 |    0.00 | 2.0752 |     - |     - |    4344 B |
|                                  Linq |  1000 | 8,193.73 ns |  25.116 ns |  22.265 ns |  1.45 |    0.00 | 2.1210 |     - |     - |    4464 B |
|                                LinqAF |  1000 | 9,148.72 ns |  22.755 ns |  21.285 ns |  1.62 |    0.01 | 2.0752 |     - |     - |    4344 B |
|                            StructLinq |  1000 | 8,222.16 ns |  14.430 ns |  12.050 ns |  1.45 |    0.00 | 1.0376 |     - |     - |    2184 B |
|                  StructLinq_IFunction |  1000 | 6,125.63 ns |  13.720 ns |  12.163 ns |  1.08 |    0.00 | 0.9995 |     - |     - |    2096 B |
|                             Hyperlinq |  1000 | 7,373.61 ns |  18.065 ns |  16.014 ns |  1.30 |    0.00 | 0.9995 |     - |     - |    2096 B |
|                   Hyperlinq_IFunction |  1000 | 5,564.41 ns |  13.749 ns |  12.189 ns |  0.98 |    0.00 | 0.9995 |     - |     - |    2096 B |
