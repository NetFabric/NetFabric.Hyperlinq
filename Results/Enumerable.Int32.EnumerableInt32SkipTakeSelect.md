## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** | **1000** |    **10** |  **2.398 μs** | **0.0062 μs** | **0.0055 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |    10 |  2.656 μs | 0.0280 μs | 0.0234 μs |  1.11 |    0.01 | 0.0992 |     - |     - |     208 B |
|                      LinqAF | 1000 |    10 |  3.630 μs | 0.0104 μs | 0.0086 μs |  1.51 |    0.00 | 0.0191 |     - |     - |      40 B |
|                  StructLinq | 1000 |    10 |  2.767 μs | 0.0053 μs | 0.0047 μs |  1.15 |    0.00 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |    10 |  2.953 μs | 0.0037 μs | 0.0033 μs |  1.23 |    0.00 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |    10 |  2.980 μs | 0.0063 μs | 0.0055 μs |  1.24 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |  2.482 μs | 0.0065 μs | 0.0054 μs |  1.03 |    0.00 | 0.0191 |     - |     - |      40 B |
|                             |      |       |           |           |           |       |         |        |       |       |           |
|                 **ForeachLoop** | **1000** |  **1000** |  **4.233 μs** | **0.0316 μs** | **0.0280 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |  1000 | 17.993 μs | 0.0514 μs | 0.0430 μs |  4.25 |    0.02 | 0.0916 |     - |     - |     208 B |
|                      LinqAF | 1000 |  1000 | 15.037 μs | 0.0390 μs | 0.0346 μs |  3.55 |    0.02 | 0.0153 |     - |     - |      40 B |
|                  StructLinq | 1000 |  1000 |  9.466 μs | 0.0265 μs | 0.0235 μs |  2.24 |    0.01 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |  1000 |  7.618 μs | 0.0316 μs | 0.0295 μs |  1.80 |    0.01 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |  1000 |  9.946 μs | 0.0340 μs | 0.0284 μs |  2.35 |    0.02 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  8.410 μs | 0.0312 μs | 0.0277 μs |  1.99 |    0.02 | 0.0153 |     - |     - |      40 B |
