## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|              **ForLoop** |    **10** |     **3.351 ns** | **0.0183 ns** | **0.0162 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     3.357 ns | 0.0247 ns | 0.0206 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    15.218 ns | 0.0768 ns | 0.0718 ns |  4.54 |    0.03 |      - |     - |     - |         - |
|           LinqFaster |    10 |     8.793 ns | 0.0426 ns | 0.0398 ns |  2.62 |    0.02 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     4.960 ns | 0.0375 ns | 0.0313 ns |  1.48 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |     9.872 ns | 0.0413 ns | 0.0386 ns |  2.95 |    0.02 |      - |     - |     - |         - |
|           StructLinq |    10 |    15.309 ns | 0.1055 ns | 0.0987 ns |  4.57 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    11.940 ns | 0.0832 ns | 0.0778 ns |  3.56 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    13.709 ns | 0.0381 ns | 0.0356 ns |  4.09 |    0.02 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    17.207 ns | 0.0506 ns | 0.0448 ns |  5.14 |    0.03 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **536.183 ns** | **2.5228 ns** | **2.3599 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   536.824 ns | 4.2346 ns | 4.1590 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   241.639 ns | 1.0450 ns | 0.9264 ns |  0.45 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   232.519 ns | 0.5689 ns | 0.5043 ns |  0.43 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    83.530 ns | 1.2456 ns | 1.1042 ns |  0.16 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 |   245.097 ns | 1.1349 ns | 1.0616 ns |  0.46 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 |   551.820 ns | 1.9303 ns | 1.7111 ns |  1.03 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,056.578 ns | 8.6345 ns | 7.6543 ns |  1.97 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   237.466 ns | 0.9861 ns | 0.8234 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   111.095 ns | 0.3703 ns | 0.3283 ns |  0.21 |    0.00 |      - |     - |     - |         - |
