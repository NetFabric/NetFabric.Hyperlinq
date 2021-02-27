## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **1000** |    **10** |  **2.480 μs** | **0.0116 μs** | **0.0090 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |    10 |  2.725 μs | 0.0080 μs | 0.0067 μs |  1.10 |    0.00 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |    10 |  4.012 μs | 0.0173 μs | 0.0154 μs |  1.62 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |    10 |  3.395 μs | 0.0254 μs | 0.0212 μs |  1.37 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |    10 |  2.836 μs | 0.0132 μs | 0.0110 μs |  1.14 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |    10 |  2.999 μs | 0.0136 μs | 0.0121 μs |  1.21 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |    10 |  3.347 μs | 0.0115 μs | 0.0102 μs |  1.35 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |      |       |           |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **1000** |  **1000** |  **5.417 μs** | **0.0249 μs** | **0.0194 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |  1000 | 15.450 μs | 0.0868 μs | 0.0769 μs |  2.85 |    0.02 | 0.0916 |     - |     - |     208 B |
|               LinqAF | 1000 |  1000 | 16.251 μs | 0.1309 μs | 0.1160 μs |  3.00 |    0.02 |      - |     - |     - |      40 B |
|           StructLinq | 1000 |  1000 | 11.238 μs | 0.1025 μs | 0.0856 μs |  2.07 |    0.02 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |  1000 |  9.280 μs | 0.0501 μs | 0.0444 μs |  1.71 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | 1000 |  1000 | 11.317 μs | 0.0281 μs | 0.0234 μs |  2.09 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |  1000 | 10.225 μs | 0.0392 μs | 0.0347 μs |  1.89 |    0.01 | 0.0153 |     - |     - |      40 B |
