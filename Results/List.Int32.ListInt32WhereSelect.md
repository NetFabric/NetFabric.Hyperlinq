## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **12.54 ns** |  **0.037 ns** |  **0.033 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     33.37 ns |  0.150 ns |  0.133 ns |  2.66 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    124.39 ns |  0.401 ns |  0.335 ns |  9.91 |    0.04 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |    10 |     48.52 ns |  0.267 ns |  0.223 ns |  3.87 |    0.02 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |    109.42 ns |  0.259 ns |  0.230 ns |  8.72 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |     56.81 ns |  0.186 ns |  0.165 ns |  4.53 |    0.01 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     51.97 ns |  0.096 ns |  0.085 ns |  4.14 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     51.34 ns |  0.105 ns |  0.087 ns |  4.09 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     46.89 ns |  0.129 ns |  0.114 ns |  3.74 |    0.02 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,324.00 ns** |  **4.034 ns** |  **3.576 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  7,354.79 ns | 12.900 ns | 10.772 ns |  5.56 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 11,517.11 ns | 22.869 ns | 21.392 ns |  8.70 |    0.03 | 0.0610 |     - |     - |     152 B |
|           LinqFaster |  1000 |  6,146.77 ns | 18.078 ns | 15.096 ns |  4.64 |    0.02 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF |  1000 | 12,206.19 ns | 36.546 ns | 32.397 ns |  9.22 |    0.04 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,146.00 ns | 20.785 ns | 19.442 ns |  3.89 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,511.72 ns |  5.805 ns |  5.430 ns |  1.14 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,532.74 ns | 11.740 ns |  9.803 ns |  4.18 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  1,908.08 ns |  8.882 ns |  7.417 ns |  1.44 |    0.01 |      - |     - |     - |         - |
