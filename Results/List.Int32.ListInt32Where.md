## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **10.38 ns** |  **0.047 ns** |  **0.037 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     25.81 ns |  0.072 ns |  0.064 ns |  2.49 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     87.52 ns |  0.240 ns |  0.213 ns |  8.43 |    0.03 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |    10 |     48.56 ns |  0.270 ns |  0.225 ns |  4.68 |    0.02 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |     95.97 ns |  0.145 ns |  0.136 ns |  9.24 |    0.04 |      - |     - |     - |         - |
|           StructLinq |    10 |     39.03 ns |  0.180 ns |  0.169 ns |  3.75 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     36.88 ns |  0.055 ns |  0.046 ns |  3.55 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     35.25 ns |  0.116 ns |  0.097 ns |  3.40 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     31.34 ns |  0.064 ns |  0.056 ns |  3.02 |    0.01 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,458.23 ns** |  **5.046 ns** |  **4.213 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  3,936.19 ns | 25.685 ns | 22.769 ns |  2.70 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 |  9,841.65 ns | 25.726 ns | 21.483 ns |  6.75 |    0.02 | 0.0305 |     - |     - |      72 B |
|           LinqFaster |  1000 |  6,208.58 ns | 18.842 ns | 15.734 ns |  4.26 |    0.02 | 2.0523 |     - |     - |    4304 B |
|               LinqAF |  1000 | 11,546.48 ns | 41.570 ns | 36.851 ns |  7.92 |    0.04 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,167.02 ns | 14.337 ns | 12.709 ns |  3.54 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  1,502.50 ns | 14.360 ns | 12.729 ns |  1.03 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,955.29 ns | 13.240 ns | 11.056 ns |  4.08 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  5,220.67 ns |  8.180 ns |  7.652 ns |  3.58 |    0.01 |      - |     - |     - |         - |
