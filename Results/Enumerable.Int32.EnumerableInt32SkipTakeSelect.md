## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** | **1000** |    **10** |  **2.481 μs** | **0.0184 μs** | **0.0154 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |    10 |  2.762 μs | 0.0130 μs | 0.0115 μs |  1.11 |    0.01 | 0.0992 |     - |     - |     208 B |
|                      LinqAF | 1000 |    10 |  3.739 μs | 0.0114 μs | 0.0095 μs |  1.51 |    0.01 | 0.0191 |     - |     - |      40 B |
|                  StructLinq | 1000 |    10 |  2.876 μs | 0.0120 μs | 0.0094 μs |  1.16 |    0.01 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |    10 |  3.041 μs | 0.0182 μs | 0.0152 μs |  1.23 |    0.01 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |    10 |  3.361 μs | 0.0116 μs | 0.0097 μs |  1.35 |    0.01 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |  3.335 μs | 0.0168 μs | 0.0149 μs |  1.34 |    0.01 | 0.0191 |     - |     - |      40 B |
|                             |      |       |           |           |           |       |         |        |       |       |           |
|                 **ForeachLoop** | **1000** |  **1000** |  **5.151 μs** | **0.0375 μs** | **0.0332 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |  1000 | 17.884 μs | 0.0800 μs | 0.0625 μs |  3.47 |    0.03 | 0.0916 |     - |     - |     208 B |
|                      LinqAF | 1000 |  1000 | 14.973 μs | 0.1292 μs | 0.1208 μs |  2.90 |    0.03 | 0.0153 |     - |     - |      40 B |
|                  StructLinq | 1000 |  1000 |  9.770 μs | 0.0519 μs | 0.0433 μs |  1.90 |    0.01 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |  1000 |  7.804 μs | 0.0265 μs | 0.0248 μs |  1.51 |    0.01 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |  1000 | 10.101 μs | 0.0548 μs | 0.0486 μs |  1.96 |    0.01 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  8.840 μs | 0.0620 μs | 0.0580 μs |  1.72 |    0.02 | 0.0153 |     - |     - |      40 B |
