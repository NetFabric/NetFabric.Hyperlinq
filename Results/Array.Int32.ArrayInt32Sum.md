## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **3.260 ns** |  **0.0216 ns** |  **0.0191 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.104 ns |  0.0172 ns |  0.0161 ns |  1.57 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    50.102 ns |  0.3356 ns |  0.2802 ns | 15.36 |    0.13 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     4.181 ns |  0.0104 ns |  0.0097 ns |  1.28 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     6.737 ns |  0.0346 ns |  0.0307 ns |  2.07 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    30.833 ns |  0.1431 ns |  0.1268 ns |  9.46 |    0.07 |      - |     - |     - |         - |
|           StructLinq |    10 |    17.528 ns |  0.0339 ns |  0.0317 ns |  5.38 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     4.801 ns |  0.0097 ns |  0.0076 ns |  1.47 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     9.163 ns |  0.0328 ns |  0.0290 ns |  2.81 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **384.276 ns** |  **0.7765 ns** |  **0.6883 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   523.632 ns |  1.3547 ns |  1.1313 ns |  1.36 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 4,159.271 ns | 11.4898 ns | 10.1854 ns | 10.82 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |   432.255 ns |  0.9365 ns |  0.8302 ns |  1.12 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    53.578 ns |  0.0681 ns |  0.0568 ns |  0.14 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 1,875.051 ns |  5.3520 ns |  4.7444 ns |  4.88 |    0.01 |      - |     - |     - |         - |
|           StructLinq |  1000 |   674.678 ns |  2.4960 ns |  2.2127 ns |  1.76 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   547.726 ns |  0.8685 ns |  0.6781 ns |  1.43 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    83.021 ns |  0.3120 ns |  0.2918 ns |  0.22 |    0.00 |      - |     - |     - |         - |
