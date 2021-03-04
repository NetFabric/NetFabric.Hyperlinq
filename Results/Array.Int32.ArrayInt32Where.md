## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **7.798 ns** |  **0.0319 ns** |  **0.0283 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.002 ns |  0.0393 ns |  0.0348 ns |  0.90 |    0.00 |      - |     - |     - |         - |
|                 Linq |    10 |    61.721 ns |  0.4931 ns |  0.4371 ns |  7.91 |    0.06 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |    10 |    39.550 ns |  0.3133 ns |  0.2930 ns |  5.07 |    0.04 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    50.664 ns |  0.1685 ns |  0.1407 ns |  6.50 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |    44.072 ns |  0.2082 ns |  0.1947 ns |  5.65 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    36.763 ns |  0.1159 ns |  0.1028 ns |  4.71 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    42.020 ns |  0.1801 ns |  0.1597 ns |  5.39 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    38.345 ns |  0.1011 ns |  0.0946 ns |  4.92 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,438.074 ns** | **18.0413 ns** | **16.8758 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   784.774 ns | 11.9034 ns | 11.1345 ns |  0.55 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,163.098 ns | 30.8574 ns | 27.3543 ns |  4.29 |    0.06 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |  1000 | 4,463.240 ns | 31.9019 ns | 28.2802 ns |  3.10 |    0.05 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF |  1000 | 6,105.560 ns | 14.3641 ns | 11.2145 ns |  4.25 |    0.05 |      - |     - |     - |         - |
|           StructLinq |  1000 | 6,179.961 ns | 27.1875 ns | 21.2262 ns |  4.30 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,855.969 ns |  9.1642 ns |  7.1548 ns |  1.29 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,112.532 ns | 18.6972 ns | 16.5745 ns |  3.56 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 2,021.439 ns | 34.5685 ns | 32.3354 ns |  1.41 |    0.02 |      - |     - |     - |         - |
