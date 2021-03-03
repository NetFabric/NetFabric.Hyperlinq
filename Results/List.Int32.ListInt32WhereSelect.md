## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **12.50 ns** |  **0.031 ns** |  **0.028 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     31.86 ns |  0.163 ns |  0.145 ns |  2.55 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    124.51 ns |  0.527 ns |  0.467 ns |  9.96 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |    10 |     50.34 ns |  0.307 ns |  0.272 ns |  4.03 |    0.03 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |    110.95 ns |  0.254 ns |  0.212 ns |  8.88 |    0.02 |      - |     - |     - |         - |
|           StructLinq |    10 |     56.82 ns |  0.115 ns |  0.102 ns |  4.55 |    0.01 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     51.92 ns |  0.075 ns |  0.062 ns |  4.15 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     50.95 ns |  0.089 ns |  0.075 ns |  4.08 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     48.04 ns |  0.059 ns |  0.052 ns |  3.84 |    0.01 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,327.30 ns** |  **5.324 ns** |  **4.719 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  3,854.54 ns | 12.026 ns | 10.660 ns |  2.90 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 11,529.14 ns | 20.228 ns | 17.931 ns |  8.69 |    0.03 | 0.0610 |     - |     - |     152 B |
|           LinqFaster |  1000 |  6,083.23 ns | 50.591 ns | 44.848 ns |  4.58 |    0.03 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF |  1000 | 11,763.91 ns | 19.231 ns | 17.048 ns |  8.86 |    0.03 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,162.01 ns | 17.748 ns | 15.733 ns |  3.89 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,481.66 ns |  6.127 ns |  5.116 ns |  1.12 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,514.00 ns | 17.310 ns | 14.455 ns |  4.15 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  1,929.14 ns |  5.830 ns |  5.168 ns |  1.45 |    0.01 |      - |     - |     - |         - |
