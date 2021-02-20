## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **187.71 ns** |  **0.505 ns** |  **0.448 ns** |  **7.19** |    **0.02** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |    10 |   151.61 ns |  0.411 ns |  0.364 ns |  5.81 |    0.02 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |    10 |   363.09 ns |  0.599 ns |  0.500 ns | 13.91 |    0.03 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |    10 |   261.42 ns |  0.503 ns |  0.471 ns | 10.02 |    0.03 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |    10 |   168.62 ns |  0.428 ns |  0.400 ns |  6.46 |    0.02 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |    10 |   132.49 ns |  0.450 ns |  0.399 ns |  5.08 |    0.02 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   282.96 ns |  0.734 ns |  0.686 ns | 10.84 |    0.04 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   254.77 ns |  0.561 ns |  0.525 ns |  9.76 |    0.03 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |    10 |    26.10 ns |  0.065 ns |  0.058 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                           ForeachLoop |    10 |    25.19 ns |  0.088 ns |  0.078 ns |  0.97 |    0.00 | 0.0344 |     - |     - |      72 B |
|                                  Linq |    10 |    90.06 ns |  0.326 ns |  0.289 ns |  3.45 |    0.01 | 0.0842 |     - |     - |     176 B |
|                            LinqFaster |    10 |    73.21 ns |  0.280 ns |  0.249 ns |  2.80 |    0.01 | 0.0764 |     - |     - |     160 B |
|                                LinqAF |    10 |    98.30 ns |  0.266 ns |  0.236 ns |  3.77 |    0.01 | 0.0342 |     - |     - |      72 B |
|                            StructLinq |    10 |   135.47 ns |  0.520 ns |  0.461 ns |  5.19 |    0.02 | 0.0763 |     - |     - |     160 B |
|                  StructLinq_IFunction |    10 |    99.11 ns |  0.225 ns |  0.176 ns |  3.80 |    0.01 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |    10 |   103.47 ns |  0.279 ns |  0.248 ns |  3.96 |    0.01 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |    10 |    82.45 ns |  0.225 ns |  0.211 ns |  3.16 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **5,387.34 ns** | **16.984 ns** | **15.887 ns** |  **1.54** |    **0.01** | **2.0523** |     **-** |     **-** |    **4304 B** |
|                       ValueLinq_Stack |  1000 | 6,022.58 ns | 18.923 ns | 16.774 ns |  1.73 |    0.01 | 1.9913 |     - |     - |    4176 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,335.56 ns | 20.642 ns | 17.237 ns |  1.53 |    0.01 | 0.9842 |     - |     - |    2072 B |
|             ValueLinq_SharedPool_Pull |  1000 | 6,935.73 ns | 19.575 ns | 17.353 ns |  1.99 |    0.01 | 0.9842 |     - |     - |    2072 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,660.75 ns |  7.851 ns |  7.344 ns |  0.76 |    0.00 | 2.0561 |     - |     - |    4304 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,659.68 ns | 15.331 ns | 14.341 ns |  0.76 |    0.00 | 1.9951 |     - |     - |    4176 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 2,947.09 ns | 16.796 ns | 14.889 ns |  0.84 |    0.00 | 0.9880 |     - |     - |    2072 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,839.89 ns | 16.741 ns | 15.659 ns |  0.81 |    0.01 | 0.9880 |     - |     - |    2072 B |
|                               ForLoop |  1000 | 3,489.33 ns | 13.280 ns | 11.772 ns |  1.00 |    0.00 | 2.0561 |     - |     - |    4304 B |
|                           ForeachLoop |  1000 | 2,237.65 ns | 22.641 ns | 21.179 ns |  0.64 |    0.01 | 2.0561 |     - |     - |    4304 B |
|                                  Linq |  1000 | 4,726.43 ns | 23.424 ns | 20.765 ns |  1.35 |    0.01 | 2.1057 |     - |     - |    4408 B |
|                            LinqFaster |  1000 | 4,867.09 ns | 10.940 ns |  9.698 ns |  1.39 |    0.01 | 3.8834 |     - |     - |    8136 B |
|                                LinqAF |  1000 | 7,428.69 ns | 25.537 ns | 22.638 ns |  2.13 |    0.01 | 2.0523 |     - |     - |    4304 B |
|                            StructLinq |  1000 | 5,817.34 ns | 33.835 ns | 28.254 ns |  1.67 |    0.01 | 1.0300 |     - |     - |    2168 B |
|                  StructLinq_IFunction |  1000 | 2,821.35 ns | 12.396 ns | 11.595 ns |  0.81 |    0.00 | 0.9880 |     - |     - |    2072 B |
|                             Hyperlinq |  1000 | 5,008.47 ns | 18.729 ns | 17.519 ns |  1.44 |    0.01 | 0.9842 |     - |     - |    2072 B |
|                   Hyperlinq_IFunction |  1000 | 3,222.98 ns | 63.642 ns | 80.486 ns |  0.93 |    0.03 | 0.9880 |     - |     - |    2072 B |
