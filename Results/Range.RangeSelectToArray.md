## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                                Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **103.287 ns** |  **0.4799 ns** |  **0.4007 ns** | **10.91** |    **0.05** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |     0 |    10 |    88.457 ns |  0.1809 ns |  0.1604 ns |  9.34 |    0.05 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   299.510 ns |  0.5244 ns |  0.4649 ns | 31.64 |    0.14 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   207.510 ns |  0.3496 ns |  0.3099 ns | 21.92 |    0.08 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |    92.454 ns |  0.3507 ns |  0.3281 ns |  9.76 |    0.04 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |    73.254 ns |  0.1795 ns |  0.1591 ns |  7.74 |    0.03 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   222.754 ns |  0.6393 ns |  0.5338 ns | 23.52 |    0.10 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   201.299 ns |  0.4850 ns |  0.4299 ns | 21.26 |    0.11 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |     0 |    10 |     9.469 ns |  0.0382 ns |  0.0358 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                                  Linq |     0 |    10 |    60.531 ns |  0.2735 ns |  0.2284 ns |  6.39 |    0.04 | 0.0726 |     - |     - |     152 B |
|                            LinqFaster |     0 |    10 |    34.367 ns |  0.1855 ns |  0.1549 ns |  3.63 |    0.02 | 0.0612 |     - |     - |     128 B |
|                       LinqFaster_SIMD |     0 |    10 |    28.731 ns |  0.1238 ns |  0.1098 ns |  3.03 |    0.02 | 0.0612 |     - |     - |     128 B |
|                                LinqAF |     0 |    10 |   147.217 ns |  0.4552 ns |  0.4035 ns | 15.55 |    0.08 | 0.1183 |     - |     - |     248 B |
|                            StructLinq |     0 |    10 |    45.683 ns |  0.1105 ns |  0.0923 ns |  4.82 |    0.02 | 0.0573 |     - |     - |     120 B |
|                  StructLinq_IFunction |     0 |    10 |    26.135 ns |  0.0707 ns |  0.0590 ns |  2.76 |    0.01 | 0.0306 |     - |     - |      64 B |
|                             Hyperlinq |     0 |    10 |    39.694 ns |  0.1389 ns |  0.1160 ns |  4.19 |    0.02 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |     0 |    10 |    30.367 ns |  0.2001 ns |  0.1774 ns |  3.21 |    0.02 | 0.0305 |     - |     - |      64 B |
|                        Hyperlinq_SIMD |     0 |    10 |    38.416 ns |  0.1657 ns |  0.1383 ns |  4.06 |    0.02 | 0.0306 |     - |     - |      64 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    27.631 ns |  0.0716 ns |  0.0635 ns |  2.92 |    0.01 | 0.0306 |     - |     - |      64 B |
|                                       |       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **1,870.307 ns** |  **3.4204 ns** |  **2.8562 ns** |  **2.31** |    **0.02** | **1.9226** |     **-** |     **-** |    **4024 B** |
|                       ValueLinq_Stack |     0 |  1000 | 3,784.145 ns | 11.2773 ns |  9.9970 ns |  4.68 |    0.03 | 3.9177 |     - |     - |    8200 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,211.735 ns | 22.2763 ns | 19.7474 ns |  3.97 |    0.04 | 1.9226 |     - |     - |    4024 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 3,596.020 ns | 26.0123 ns | 23.0592 ns |  4.45 |    0.04 | 1.9226 |     - |     - |    4024 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 1,848.395 ns |  7.3815 ns |  6.9047 ns |  2.28 |    0.02 | 1.9226 |     - |     - |    4024 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,417.986 ns | 12.3683 ns | 11.5693 ns |  2.99 |    0.03 | 3.9177 |     - |     - |    8200 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,395.133 ns |  8.1881 ns |  7.2585 ns |  2.96 |    0.02 | 1.9226 |     - |     - |    4024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,151.744 ns |  7.9317 ns |  6.6233 ns |  2.66 |    0.02 | 1.9226 |     - |     - |    4024 B |
|                               ForLoop |     0 |  1000 |   808.997 ns |  6.6304 ns |  6.2021 ns |  1.00 |    0.00 | 1.9226 |     - |     - |    4024 B |
|                                  Linq |     0 |  1000 | 2,050.054 ns |  9.9889 ns |  9.3436 ns |  2.53 |    0.02 | 1.9646 |     - |     - |    4112 B |
|                            LinqFaster |     0 |  1000 | 2,598.667 ns | 10.5890 ns |  8.8423 ns |  3.21 |    0.03 | 3.8452 |     - |     - |    8048 B |
|                       LinqFaster_SIMD |     0 |  1000 |   752.227 ns |  4.7386 ns |  4.2007 ns |  0.93 |    0.01 | 3.8452 |     - |     - |    8048 B |
|                                LinqAF |     0 |  1000 | 5,429.986 ns | 30.0742 ns | 26.6600 ns |  6.72 |    0.07 | 5.9280 |     - |     - |   12416 B |
|                            StructLinq |     0 |  1000 | 2,286.822 ns |  7.9982 ns |  7.4816 ns |  2.83 |    0.02 | 1.9493 |     - |     - |    4080 B |
|                  StructLinq_IFunction |     0 |  1000 |   719.234 ns |  1.9527 ns |  1.7310 ns |  0.89 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                             Hyperlinq |     0 |  1000 | 2,047.572 ns |  6.1759 ns |  5.4748 ns |  2.53 |    0.02 | 1.9226 |     - |     - |    4024 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,233.377 ns |  4.7166 ns |  4.1811 ns |  1.53 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   475.716 ns |  1.7473 ns |  1.6344 ns |  0.59 |    0.01 | 1.9150 |     - |     - |    4024 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   255.814 ns |  5.0073 ns |  5.1421 ns |  0.32 |    0.01 | 1.9155 |     - |     - |    4024 B |
