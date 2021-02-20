## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method | Duplicates | Count |        Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |    **374.6 ns** |     **1.78 ns** |     **1.57 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    374.9 ns |     1.45 ns |     1.13 ns |  1.00 |    0.01 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    834.3 ns |     8.98 ns |     8.40 ns |  2.23 |    0.03 |  0.2899 |     - |     - |     608 B |
|               LinqAF |          4 |    10 |  1,036.2 ns |     9.01 ns |     8.42 ns |  2.77 |    0.03 |  0.6180 |     - |     - |    1296 B |
|           StructLinq |          4 |    10 |    573.4 ns |    11.34 ns |    19.25 ns |  1.54 |    0.06 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    598.1 ns |    11.37 ns |    11.68 ns |  1.59 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    589.9 ns |    11.75 ns |    18.63 ns |  1.59 |    0.06 |       - |     - |     - |         - |
|                      |            |       |             |             |             |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **30,059.6 ns** |    **69.23 ns** |    **64.76 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |   **58672 B** |
|          ForeachLoop |          4 |  1000 | 30,080.0 ns |   131.14 ns |   109.51 ns |  1.00 |    0.00 | 27.7710 |     - |     - |   58672 B |
|                 Linq |          4 |  1000 | 74,501.5 ns | 1,481.48 ns | 1,977.74 ns |  2.49 |    0.06 | 15.7471 |     - |     - |   33104 B |
|               LinqAF |          4 |  1000 | 88,278.1 ns |   235.95 ns |   209.17 ns |  2.94 |    0.01 | 53.9551 |     - |     - |  113184 B |
|           StructLinq |          4 |  1000 | 37,288.2 ns |   735.26 ns | 1,659.61 ns |  1.24 |    0.07 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 37,960.2 ns |   756.61 ns |   983.81 ns |  1.26 |    0.04 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 47,066.5 ns |   930.86 ns |   955.92 ns |  1.57 |    0.03 |       - |     - |     - |         - |
