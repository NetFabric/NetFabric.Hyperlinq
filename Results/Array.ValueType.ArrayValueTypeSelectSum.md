## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |         Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **4.851 ns** |   **0.0132 ns** |   **0.0103 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    14.490 ns |   0.0773 ns |   0.0723 ns |  2.99 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |    85.879 ns |   0.2417 ns |   0.2142 ns | 17.71 |    0.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    34.361 ns |   0.0883 ns |   0.0826 ns |  7.08 |    0.03 |      - |     - |     - |         - |
|               LinqAF |    10 |    90.513 ns |   1.7568 ns |   1.7254 ns | 18.55 |    0.29 |      - |     - |     - |         - |
|           StructLinq |    10 |    30.400 ns |   0.1404 ns |   0.1096 ns |  6.27 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     6.734 ns |   0.0349 ns |   0.0327 ns |  1.39 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    67.625 ns |   0.2209 ns |   0.1959 ns | 13.95 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    50.837 ns |   0.1730 ns |   0.1619 ns | 10.48 |    0.04 |      - |     - |     - |         - |
|                      |       |              |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **630.663 ns** |   **2.2498 ns** |   **1.9943 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,827.309 ns |   3.9922 ns |   3.3337 ns |  2.90 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,283.604 ns |  34.6167 ns |  30.6868 ns |  9.96 |    0.06 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,990.510 ns |  12.2482 ns |  10.2278 ns |  6.33 |    0.02 |      - |     - |     - |         - |
|               LinqAF |  1000 | 7,850.533 ns | 152.7422 ns | 237.8012 ns | 12.29 |    0.36 |      - |     - |     - |         - |
|           StructLinq |  1000 | 2,000.936 ns |   6.5516 ns |   6.1284 ns |  3.17 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   730.198 ns |   1.7748 ns |   1.5733 ns |  1.16 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,025.141 ns |  16.4248 ns |  13.7154 ns |  7.97 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 3,809.196 ns |  10.6925 ns |  10.0018 ns |  6.04 |    0.02 |      - |     - |     - |         - |
