## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **1000** |    **10** |  **2.890 μs** | **0.0117 μs** | **0.0103 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |    10 |  2.609 μs | 0.0045 μs | 0.0040 μs |  0.90 |    0.00 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |    10 |  3.527 μs | 0.0128 μs | 0.0114 μs |  1.22 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | 1000 |    10 |  2.774 μs | 0.0114 μs | 0.0101 μs |  0.96 |    0.00 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |    10 |  2.962 μs | 0.0071 μs | 0.0063 μs |  1.02 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |    10 |  3.248 μs | 0.0090 μs | 0.0070 μs |  1.12 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |    10 |  2.958 μs | 0.0135 μs | 0.0120 μs |  1.02 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |      |       |           |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **1000** |  **1000** |  **5.190 μs** | **0.0253 μs** | **0.0212 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |  1000 | 16.050 μs | 0.0547 μs | 0.0485 μs |  3.09 |    0.01 | 0.0916 |     - |     - |     208 B |
|               LinqAF | 1000 |  1000 | 14.999 μs | 0.0473 μs | 0.0419 μs |  2.89 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |  1000 |  9.822 μs | 0.0239 μs | 0.0211 μs |  1.89 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |  1000 |  9.026 μs | 0.0329 μs | 0.0292 μs |  1.74 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | 1000 |  1000 | 12.385 μs | 0.0436 μs | 0.0364 μs |  2.39 |    0.02 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |  1000 | 10.409 μs | 0.0297 μs | 0.0263 μs |  2.01 |    0.01 | 0.0153 |     - |     - |      40 B |
