## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |  **2.920 μs** | **0.0086 μs** | **0.0076 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |  3.412 μs | 0.0089 μs | 0.0079 μs |  1.17 |    0.00 | 0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |    10 |  3.674 μs | 0.0322 μs | 0.0285 μs |  1.26 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2.810 μs | 0.0134 μs | 0.0125 μs |  0.96 |    0.00 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2.780 μs | 0.0083 μs | 0.0078 μs |  0.95 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2.932 μs | 0.0265 μs | 0.0235 μs |  1.00 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2.992 μs | 0.0087 μs | 0.0073 μs |  1.02 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |          |          |      |       |           |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2.927 μs | 0.0086 μs | 0.0072 μs |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2.624 μs | 0.0092 μs | 0.0077 μs |  0.90 |    0.00 | 0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |    10 |  3.529 μs | 0.0177 μs | 0.0157 μs |  1.21 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2.807 μs | 0.0196 μs | 0.0174 μs |  0.96 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |  3.020 μs | 0.0092 μs | 0.0072 μs |  1.03 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2.529 μs | 0.0099 μs | 0.0093 μs |  0.86 |    0.00 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2.500 μs | 0.0095 μs | 0.0084 μs |  0.85 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |          |          |      |       |           |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** |  **5.307 μs** | **0.0180 μs** | **0.0150 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 16.310 μs | 0.0859 μs | 0.0762 μs |  3.07 |    0.02 | 0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 16.387 μs | 0.0300 μs | 0.0250 μs |  3.09 |    0.01 |      - |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 10.011 μs | 0.0438 μs | 0.0388 μs |  1.89 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  9.129 μs | 0.0321 μs | 0.0268 μs |  1.72 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 12.731 μs | 0.0444 μs | 0.0394 μs |  2.40 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  9.464 μs | 0.0373 μs | 0.0349 μs |  1.78 |    0.01 | 0.0153 |     - |     - |      40 B |
|                      |          |          |      |       |           |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  5.206 μs | 0.0224 μs | 0.0199 μs |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 15.523 μs | 0.0791 μs | 0.0701 μs |  2.98 |    0.01 | 0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 14.884 μs | 0.0623 μs | 0.0583 μs |  2.86 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 10.582 μs | 0.0390 μs | 0.0345 μs |  2.03 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  9.078 μs | 0.0434 μs | 0.0406 μs |  1.74 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 11.400 μs | 0.0383 μs | 0.0320 μs |  2.19 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  9.721 μs | 0.0335 μs | 0.0314 μs |  1.87 |    0.01 | 0.0153 |     - |     - |      40 B |
