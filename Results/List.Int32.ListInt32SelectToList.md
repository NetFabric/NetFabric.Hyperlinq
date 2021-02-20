## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |    **10** |    **68.12 ns** |  **0.367 ns** |  **0.325 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    79.97 ns |  0.508 ns |  0.424 ns |  1.17 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    66.54 ns |  0.221 ns |  0.195 ns |  0.98 |    0.00 | 0.0802 |     - |     - |     168 B |
|               LinqFaster |    10 |    61.53 ns |  0.243 ns |  0.227 ns |  0.90 |    0.01 | 0.0917 |     - |     - |     192 B |
|                   LinqAF |    10 |   190.17 ns |  0.703 ns |  0.658 ns |  2.79 |    0.02 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    59.46 ns |  0.489 ns |  0.434 ns |  0.87 |    0.01 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    41.47 ns |  0.164 ns |  0.145 ns |  0.61 |    0.00 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    42.01 ns |  0.150 ns |  0.133 ns |  0.62 |    0.00 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    27.38 ns |  0.091 ns |  0.081 ns |  0.40 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    44.01 ns |  0.085 ns |  0.071 ns |  0.65 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    27.67 ns |  0.099 ns |  0.083 ns |  0.41 |    0.00 | 0.0458 |     - |     - |      96 B |
|                          |       |             |           |           |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,459.52 ns** | **20.946 ns** | **18.568 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |    **8424 B** |
|              ForeachLoop |  1000 | 3,293.95 ns | 15.108 ns | 13.393 ns |  1.34 |    0.01 | 4.0207 |     - |     - |    8424 B |
|                     Linq |  1000 | 2,508.45 ns |  6.940 ns |  6.492 ns |  1.02 |    0.01 | 1.9722 |     - |     - |    4128 B |
|               LinqFaster |  1000 | 3,016.26 ns | 10.661 ns |  8.903 ns |  1.23 |    0.01 | 3.8757 |     - |     - |    8112 B |
|                   LinqAF |  1000 | 8,512.09 ns | 22.496 ns | 19.942 ns |  3.46 |    0.03 | 4.0131 |     - |     - |    8424 B |
|               StructLinq |  1000 | 2,048.86 ns |  4.592 ns |  4.071 ns |  0.83 |    0.01 | 1.9684 |     - |     - |    4120 B |
|     StructLinq_IFunction |  1000 |   940.32 ns |  5.192 ns |  4.857 ns |  0.38 |    0.00 | 1.9569 |     - |     - |    4096 B |
|                Hyperlinq |  1000 | 2,039.48 ns |  7.319 ns |  6.488 ns |  0.83 |    0.01 | 1.9341 |     - |     - |    4056 B |
|      Hyperlinq_IFunction |  1000 |   820.07 ns |  2.508 ns |  1.958 ns |  0.33 |    0.00 | 1.9341 |     - |     - |    4056 B |
|           Hyperlinq_SIMD |  1000 |   537.53 ns |  1.948 ns |  1.822 ns |  0.22 |    0.00 | 1.9341 |     - |     - |    4056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   310.47 ns |  1.225 ns |  1.023 ns |  0.13 |    0.00 | 1.9341 |     - |     - |    4056 B |
