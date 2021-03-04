## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|              **ForLoop** |    **10** |     **5.346 ns** |  **0.0371 ns** |  **0.0347 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     3.409 ns |  0.0242 ns |  0.0214 ns |  0.64 |    0.00 |      - |     - |     - |         - |
|                 Linq |    10 |    54.738 ns |  0.2768 ns |  0.2454 ns | 10.23 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     6.161 ns |  0.0514 ns |  0.0481 ns |  1.15 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     7.043 ns |  0.0376 ns |  0.0352 ns |  1.32 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    30.596 ns |  0.1147 ns |  0.1017 ns |  5.72 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |    17.159 ns |  0.1031 ns |  0.0861 ns |  3.20 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     4.956 ns |  0.0231 ns |  0.0193 ns |  0.93 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    15.626 ns |  0.0712 ns |  0.0594 ns |  2.92 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **540.073 ns** |  **1.8652 ns** |  **1.5575 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   540.204 ns |  2.7150 ns |  2.2672 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 4,317.628 ns | 14.8925 ns | 13.9305 ns |  8.00 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |   537.613 ns |  1.6455 ns |  1.4587 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    53.270 ns |  0.2452 ns |  0.2174 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,010.766 ns |  7.3255 ns |  5.7193 ns |  3.72 |    0.02 |      - |     - |     - |         - |
|           StructLinq |  1000 |   694.832 ns |  2.8437 ns |  2.3746 ns |  1.29 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   559.763 ns |  1.8366 ns |  1.7180 ns |  1.04 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    89.085 ns |  0.4026 ns |  0.3569 ns |  0.16 |    0.00 |      - |     - |     - |         - |
