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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **1000** |    **10** |  **2.903 μs** | **0.0082 μs** | **0.0073 μs** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |    10 |  2.626 μs | 0.0098 μs | 0.0092 μs |  0.90 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |    10 |  3.615 μs | 0.0037 μs | 0.0033 μs |  1.25 | 0.0191 |     - |     - |      40 B |
|           StructLinq | 1000 |    10 |  3.070 μs | 0.0096 μs | 0.0085 μs |  1.06 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |    10 |  2.738 μs | 0.0065 μs | 0.0054 μs |  0.94 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |    10 |  3.264 μs | 0.0040 μs | 0.0033 μs |  1.12 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |    10 |  3.243 μs | 0.0109 μs | 0.0097 μs |  1.12 | 0.0191 |     - |     - |      40 B |
|                      |      |       |           |           |           |       |        |       |       |           |
|          **ForeachLoop** | **1000** |  **1000** |  **4.635 μs** | **0.0135 μs** | **0.0127 μs** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |  1000 | 14.859 μs | 0.0363 μs | 0.0322 μs |  3.21 | 0.0916 |     - |     - |     208 B |
|               LinqAF | 1000 |  1000 | 15.085 μs | 0.0378 μs | 0.0335 μs |  3.25 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |  1000 | 10.825 μs | 0.0339 μs | 0.0317 μs |  2.34 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |  1000 |  8.952 μs | 0.0253 μs | 0.0225 μs |  1.93 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | 1000 |  1000 | 12.249 μs | 0.0373 μs | 0.0331 μs |  2.64 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |  1000 | 10.692 μs | 0.0316 μs | 0.0280 μs |  2.31 | 0.0153 |     - |     - |      40 B |
