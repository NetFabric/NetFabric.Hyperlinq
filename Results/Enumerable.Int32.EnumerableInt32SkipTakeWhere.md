## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **1000** |    **10** |  **2.389 μs** | **0.0051 μs** | **0.0043 μs** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |    10 |  2.610 μs | 0.0076 μs | 0.0063 μs |  1.09 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |    10 |  3.599 μs | 0.0087 μs | 0.0072 μs |  1.51 | 0.0191 |     - |     - |      40 B |
|           StructLinq | 1000 |    10 |  3.272 μs | 0.0062 μs | 0.0055 μs |  1.37 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |    10 |  2.728 μs | 0.0075 μs | 0.0073 μs |  1.14 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |    10 |  2.966 μs | 0.0136 μs | 0.0121 μs |  1.24 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |    10 |  2.481 μs | 0.0074 μs | 0.0069 μs |  1.04 | 0.0191 |     - |     - |      40 B |
|                      |      |       |           |           |           |       |        |       |       |           |
|          **ForeachLoop** | **1000** |  **1000** |  **5.213 μs** | **0.0196 μs** | **0.0164 μs** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |  1000 | 15.261 μs | 0.0298 μs | 0.0249 μs |  2.93 | 0.0916 |     - |     - |     208 B |
|               LinqAF | 1000 |  1000 | 14.884 μs | 0.0439 μs | 0.0366 μs |  2.86 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |  1000 | 10.815 μs | 0.0245 μs | 0.0217 μs |  2.07 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |  1000 |  8.926 μs | 0.0282 μs | 0.0250 μs |  1.71 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | 1000 |  1000 | 11.476 μs | 0.0458 μs | 0.0406 μs |  2.20 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |  1000 |  9.384 μs | 0.0330 μs | 0.0275 μs |  1.80 | 0.0153 |     - |     - |      40 B |
