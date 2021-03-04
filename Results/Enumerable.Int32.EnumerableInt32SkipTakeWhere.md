## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **1000** |    **10** |  **2.458 μs** | **0.0083 μs** | **0.0069 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |    10 |  2.692 μs | 0.0098 μs | 0.0087 μs |  1.10 |    0.00 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |    10 |  3.716 μs | 0.0191 μs | 0.0169 μs |  1.51 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | 1000 |    10 |  3.147 μs | 0.0136 μs | 0.0113 μs |  1.28 |    0.00 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |    10 |  2.810 μs | 0.0088 μs | 0.0078 μs |  1.14 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |    10 |  3.350 μs | 0.0190 μs | 0.0169 μs |  1.36 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |    10 |  2.569 μs | 0.0127 μs | 0.0113 μs |  1.04 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |      |       |           |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **1000** |  **1000** |  **5.356 μs** | **0.0128 μs** | **0.0100 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |  1000 | 15.735 μs | 0.0841 μs | 0.0746 μs |  2.94 |    0.02 | 0.0916 |     - |     - |     208 B |
|               LinqAF | 1000 |  1000 | 15.406 μs | 0.0493 μs | 0.0437 μs |  2.88 |    0.01 |      - |     - |     - |      40 B |
|           StructLinq | 1000 |  1000 | 11.129 μs | 0.0764 μs | 0.0678 μs |  2.08 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |  1000 |  9.178 μs | 0.0369 μs | 0.0327 μs |  1.71 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | 1000 |  1000 | 12.526 μs | 0.0607 μs | 0.0568 μs |  2.34 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |  1000 |  9.604 μs | 0.0368 μs | 0.0326 μs |  1.79 |    0.01 | 0.0153 |     - |     - |      40 B |
