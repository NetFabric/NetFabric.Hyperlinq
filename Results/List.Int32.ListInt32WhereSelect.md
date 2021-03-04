## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **12.90 ns** |  **0.061 ns** |  **0.054 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     30.34 ns |  0.221 ns |  0.207 ns |  2.35 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |    127.97 ns |  0.444 ns |  0.416 ns |  9.93 |    0.06 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |    10 |     50.46 ns |  0.524 ns |  0.490 ns |  3.91 |    0.05 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |    111.92 ns |  0.801 ns |  0.749 ns |  8.68 |    0.06 |      - |     - |     - |         - |
|           StructLinq |    10 |     58.75 ns |  0.135 ns |  0.126 ns |  4.56 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     53.09 ns |  0.164 ns |  0.145 ns |  4.12 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     52.96 ns |  0.256 ns |  0.240 ns |  4.11 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     47.92 ns |  0.146 ns |  0.129 ns |  3.72 |    0.02 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,407.39 ns** | **21.188 ns** | **19.819 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  3,930.39 ns | 37.780 ns | 35.339 ns |  2.79 |    0.04 |      - |     - |     - |         - |
|                 Linq |  1000 | 11,783.28 ns | 30.271 ns | 25.278 ns |  8.37 |    0.12 | 0.0610 |     - |     - |     152 B |
|           LinqFaster |  1000 |  6,317.24 ns | 25.871 ns | 22.934 ns |  4.49 |    0.06 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF |  1000 | 12,157.50 ns | 33.138 ns | 30.997 ns |  8.64 |    0.12 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,350.94 ns | 25.442 ns | 22.553 ns |  3.80 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,568.74 ns | 24.807 ns | 23.205 ns |  1.11 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,679.35 ns | 30.034 ns | 28.094 ns |  4.04 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  1,984.55 ns | 20.077 ns | 18.780 ns |  1.41 |    0.02 |      - |     - |     - |         - |
