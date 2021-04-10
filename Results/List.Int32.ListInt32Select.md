## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **12.53 ns** |  **0.036 ns** |  **0.032 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    27.14 ns |  0.454 ns |  0.403 ns |  2.17 |    0.03 |      - |     - |     - |         - |
|                        Linq |    10 |   146.69 ns |  0.581 ns |  0.485 ns | 11.70 |    0.05 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |    10 |    50.54 ns |  0.184 ns |  0.144 ns |  4.03 |    0.02 | 0.0459 |     - |     - |      96 B |
|                      LinqAF |    10 |   117.68 ns |  0.484 ns |  0.453 ns |  9.39 |    0.05 |      - |     - |     - |         - |
|                  StructLinq |    10 |    45.25 ns |  0.933 ns |  1.367 ns |  3.54 |    0.12 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    38.17 ns |  0.170 ns |  0.159 ns |  3.05 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    43.31 ns |  0.158 ns |  0.148 ns |  3.45 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    42.86 ns |  0.227 ns |  0.212 ns |  3.42 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    33.78 ns |  0.235 ns |  0.220 ns |  2.70 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    25.86 ns |  0.090 ns |  0.075 ns |  2.06 |    0.01 |      - |     - |     - |         - |
|                             |       |             |           |           |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** | **1,331.11 ns** |  **5.962 ns** |  **5.577 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 2,452.29 ns | 32.380 ns | 30.288 ns |  1.84 |    0.02 |      - |     - |     - |         - |
|                        Linq |  1000 | 7,672.59 ns | 56.694 ns | 47.342 ns |  5.76 |    0.03 | 0.0305 |     - |     - |      72 B |
|                  LinqFaster |  1000 | 3,782.66 ns | 19.320 ns | 17.127 ns |  2.84 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|                      LinqAF |  1000 | 7,072.34 ns | 38.147 ns | 33.816 ns |  5.31 |    0.03 |      - |     - |     - |         - |
|                  StructLinq |  1000 | 1,930.29 ns | 20.662 ns | 18.316 ns |  1.45 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 1,508.78 ns |  8.373 ns |  7.423 ns |  1.13 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 1,898.23 ns |  9.179 ns |  7.665 ns |  1.42 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,684.76 ns |  6.192 ns |  5.792 ns |  1.27 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 1,894.71 ns |  8.975 ns |  7.007 ns |  1.42 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 | 1,595.73 ns |  7.814 ns |  7.309 ns |  1.20 |    0.01 |      - |     - |     - |         - |
