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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **12.91 ns** |   **0.055 ns** |   **0.046 ns** |     **12.91 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     29.85 ns |   0.282 ns |   0.264 ns |     29.79 ns |  2.31 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |    126.43 ns |   1.623 ns |   1.737 ns |    126.01 ns |  9.82 |    0.14 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |    10 |     52.10 ns |   1.067 ns |   2.342 ns |     50.69 ns |  3.97 |    0.14 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |    114.26 ns |   0.758 ns |   0.672 ns |    114.17 ns |  8.84 |    0.06 |      - |     - |     - |         - |
|           StructLinq |    10 |     64.72 ns |   1.323 ns |   1.173 ns |     65.04 ns |  5.04 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     53.35 ns |   0.254 ns |   0.237 ns |     53.30 ns |  4.13 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     53.96 ns |   0.439 ns |   0.366 ns |     53.91 ns |  4.18 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     50.95 ns |   0.340 ns |   0.301 ns |     51.02 ns |  3.95 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,038.91 ns** |  **11.943 ns** |  **10.587 ns** |  **1,038.76 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  3,715.71 ns |  35.862 ns |  31.790 ns |  3,703.06 ns |  3.58 |    0.05 |      - |     - |     - |         - |
|                 Linq |  1000 | 11,595.50 ns | 149.425 ns | 132.462 ns | 11,552.76 ns | 11.16 |    0.18 | 0.0610 |     - |     - |     152 B |
|           LinqFaster |  1000 |  5,996.03 ns | 116.987 ns | 192.213 ns |  5,904.77 ns |  5.93 |    0.19 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF |  1000 | 12,410.61 ns |  43.111 ns |  38.217 ns | 12,408.38 ns | 11.95 |    0.12 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,707.56 ns |  50.973 ns |  45.187 ns |  5,710.74 ns |  5.49 |    0.07 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,604.54 ns |  26.821 ns |  23.776 ns |  1,603.09 ns |  1.54 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,529.78 ns |  36.796 ns |  32.619 ns |  5,517.08 ns |  5.32 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  5,329.75 ns |  19.661 ns |  16.418 ns |  5,333.31 ns |  5.13 |    0.05 |      - |     - |     - |         - |
