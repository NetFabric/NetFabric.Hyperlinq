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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **1000** |    **10** |  **2.984 μs** | **0.0107 μs** | **0.0100 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |    10 |  3.045 μs | 0.0165 μs | 0.0154 μs |  1.02 |    0.01 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |    10 |  3.621 μs | 0.0167 μs | 0.0156 μs |  1.21 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |    10 |  2.928 μs | 0.0197 μs | 0.0174 μs |  0.98 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |    10 |  3.058 μs | 0.0199 μs | 0.0176 μs |  1.02 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |    10 |  2.886 μs | 0.0308 μs | 0.0257 μs |  0.97 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |    10 |  3.016 μs | 0.0174 μs | 0.0154 μs |  1.01 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |      |       |           |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **1000** |  **1000** |  **4.743 μs** | **0.0202 μs** | **0.0179 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |  1000 | 17.483 μs | 0.0991 μs | 0.0878 μs |  3.69 |    0.02 | 0.0916 |     - |     - |     208 B |
|               LinqAF | 1000 |  1000 | 15.226 μs | 0.1251 μs | 0.1044 μs |  3.21 |    0.03 |      - |     - |     - |      40 B |
|           StructLinq | 1000 |  1000 |  9.587 μs | 0.0609 μs | 0.0540 μs |  2.02 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |  1000 |  8.138 μs | 0.0440 μs | 0.0390 μs |  1.72 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | 1000 |  1000 | 11.439 μs | 0.0458 μs | 0.0428 μs |  2.41 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |  1000 |  8.927 μs | 0.0478 μs | 0.0400 μs |  1.88 |    0.01 | 0.0153 |     - |     - |      40 B |
