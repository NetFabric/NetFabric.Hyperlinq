## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |     **3.190 ns** |  **0.0216 ns** |  **0.0202 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     7.500 ns |  0.0261 ns |  0.0231 ns |  2.35 |    0.02 |      - |     - |     - |         - |
|                        Linq |    10 |   111.101 ns |  0.5771 ns |  0.5116 ns | 34.81 |    0.30 | 0.0229 |     - |     - |      48 B |
|                  StructLinq |    10 |    53.952 ns |  0.1944 ns |  0.1723 ns | 16.90 |    0.12 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    43.928 ns |  0.1657 ns |  0.1469 ns | 13.76 |    0.11 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    56.896 ns |  0.1445 ns |  0.1207 ns | 17.84 |    0.13 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    44.430 ns |  0.0985 ns |  0.0873 ns | 13.92 |    0.10 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    49.084 ns |  0.1276 ns |  0.1132 ns | 15.38 |    0.09 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    32.483 ns |  0.0901 ns |  0.0799 ns | 10.18 |    0.07 |      - |     - |     - |         - |
|                             |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |   **399.627 ns** |  **0.7942 ns** |  **0.7041 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |   799.335 ns |  2.6340 ns |  2.3350 ns |  2.00 |    0.01 |      - |     - |     - |         - |
|                        Linq |  1000 | 6,187.911 ns | 20.9368 ns | 18.5600 ns | 15.48 |    0.06 | 0.0229 |     - |     - |      48 B |
|                  StructLinq |  1000 | 3,612.332 ns | 27.4156 ns | 24.3032 ns |  9.04 |    0.06 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 2,152.841 ns |  6.2541 ns |  5.8501 ns |  5.39 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 3,911.322 ns | 13.9369 ns | 11.6379 ns |  9.79 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 2,690.614 ns | 19.4157 ns | 17.2115 ns |  6.73 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 3,216.064 ns | 13.6995 ns | 12.8145 ns |  8.05 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 | 2,148.391 ns |  7.9780 ns |  7.4627 ns |  5.38 |    0.02 |      - |     - |     - |         - |
