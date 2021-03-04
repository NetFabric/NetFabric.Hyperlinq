## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** | **1000** |    **10** |  **2.461 μs** | **0.0106 μs** | **0.0099 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |    10 |  3.488 μs | 0.0099 μs | 0.0083 μs |  1.42 |    0.01 | 0.0992 |     - |     - |     208 B |
|                      LinqAF | 1000 |    10 |  3.707 μs | 0.0099 μs | 0.0083 μs |  1.51 |    0.00 | 0.0191 |     - |     - |      40 B |
|                  StructLinq | 1000 |    10 |  2.894 μs | 0.0093 μs | 0.0082 μs |  1.18 |    0.01 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |    10 |  3.027 μs | 0.0132 μs | 0.0110 μs |  1.23 |    0.01 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |    10 |  3.039 μs | 0.0154 μs | 0.0129 μs |  1.24 |    0.01 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |  2.550 μs | 0.0149 μs | 0.0139 μs |  1.04 |    0.01 | 0.0191 |     - |     - |      40 B |
|                             |      |       |           |           |           |       |         |        |       |       |           |
|                 **ForeachLoop** | **1000** |  **1000** |  **4.316 μs** | **0.0110 μs** | **0.0097 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |  1000 | 18.699 μs | 0.0758 μs | 0.0672 μs |  4.33 |    0.02 | 0.0916 |     - |     - |     208 B |
|                      LinqAF | 1000 |  1000 | 15.770 μs | 0.0396 μs | 0.0309 μs |  3.65 |    0.01 |      - |     - |     - |      40 B |
|                  StructLinq | 1000 |  1000 |  9.349 μs | 0.0207 μs | 0.0173 μs |  2.17 |    0.01 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |  1000 |  7.744 μs | 0.0227 μs | 0.0190 μs |  1.79 |    0.00 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |  1000 | 10.568 μs | 0.0330 μs | 0.0276 μs |  2.45 |    0.01 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  9.425 μs | 0.0335 μs | 0.0280 μs |  2.18 |    0.01 | 0.0153 |     - |     - |      40 B |
