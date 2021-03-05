## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **3.276 ns** |  **0.0116 ns** |  **0.0109 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.176 ns |  0.0147 ns |  0.0130 ns |  1.58 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    53.017 ns |  0.2849 ns |  0.2224 ns | 16.18 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     5.570 ns |  0.0290 ns |  0.0242 ns |  1.70 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     6.848 ns |  0.0144 ns |  0.0120 ns |  2.09 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    30.165 ns |  0.1767 ns |  0.1379 ns |  9.21 |    0.06 |      - |     - |     - |         - |
|           StructLinq |    10 |    16.724 ns |  0.0446 ns |  0.0395 ns |  5.11 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     4.813 ns |  0.0177 ns |  0.0165 ns |  1.47 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    16.175 ns |  0.0309 ns |  0.0274 ns |  4.94 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **528.125 ns** |  **1.5404 ns** |  **1.3655 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   527.185 ns |  1.5759 ns |  1.4741 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 4,193.246 ns | 15.2917 ns | 13.5557 ns |  7.94 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |   526.329 ns |  1.1426 ns |  1.0129 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    52.499 ns |  0.0923 ns |  0.0771 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 1,976.222 ns |  2.7256 ns |  2.4162 ns |  3.74 |    0.01 |      - |     - |     - |         - |
|           StructLinq |  1000 |   677.494 ns |  1.9417 ns |  1.7213 ns |  1.28 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   549.512 ns |  0.8629 ns |  0.7205 ns |  1.04 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    84.828 ns |  0.2483 ns |  0.2323 ns |  0.16 |    0.00 |      - |     - |     - |         - |
