## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|              **ForLoop** |    **10** |     **6.653 ns** |  **0.0576 ns** |  **0.0539 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.635 ns |  0.0562 ns |  0.0499 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    59.126 ns |  0.1697 ns |  0.1505 ns |  8.88 |    0.08 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |    10 |    38.956 ns |  0.2585 ns |  0.2418 ns |  5.86 |    0.06 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    49.777 ns |  0.0921 ns |  0.0769 ns |  7.48 |    0.06 |      - |     - |     - |         - |
|           StructLinq |    10 |    40.486 ns |  0.1065 ns |  0.0944 ns |  6.08 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    36.110 ns |  0.0818 ns |  0.0765 ns |  5.43 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    35.767 ns |  0.1370 ns |  0.1215 ns |  5.37 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    31.047 ns |  0.0794 ns |  0.0704 ns |  4.66 |    0.04 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **840.339 ns** |  **5.1876 ns** |  **4.5986 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   742.391 ns |  1.7597 ns |  1.5599 ns |  0.88 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,342.341 ns | 18.8493 ns | 17.6317 ns |  7.55 |    0.05 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |  1000 | 3,843.097 ns | 14.1628 ns | 12.5549 ns |  4.57 |    0.03 | 2.8915 |     - |     - |    6064 B |
|               LinqAF |  1000 | 6,748.755 ns | 12.5512 ns | 11.1263 ns |  8.03 |    0.05 |      - |     - |     - |         - |
|           StructLinq |  1000 | 6,045.480 ns | 21.0669 ns | 18.6752 ns |  7.19 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,501.784 ns |  6.0040 ns |  5.3224 ns |  1.79 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,470.623 ns | 11.2880 ns | 10.0065 ns |  6.51 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 1,908.317 ns |  7.7257 ns |  6.4513 ns |  2.27 |    0.02 |      - |     - |     - |         - |
