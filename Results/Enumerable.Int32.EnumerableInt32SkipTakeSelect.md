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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |  **2.922 μs** | **0.0061 μs** | **0.0051 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2.931 μs | 0.0138 μs | 0.0115 μs |  1.00 |    0.00 | 0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |    10 |  3.660 μs | 0.0194 μs | 0.0172 μs |  1.25 |    0.00 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2.799 μs | 0.0138 μs | 0.0122 μs |  0.96 |    0.00 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2.981 μs | 0.0084 μs | 0.0075 μs |  1.02 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2.799 μs | 0.0149 μs | 0.0132 μs |  0.96 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2.515 μs | 0.0102 μs | 0.0096 μs |  0.86 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |          |          |      |       |           |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2.764 μs | 0.0146 μs | 0.0129 μs |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |  3.445 μs | 0.0166 μs | 0.0139 μs |  1.25 |    0.01 | 0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |    10 |  3.627 μs | 0.0093 μs | 0.0078 μs |  1.31 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |  3.284 μs | 0.0133 μs | 0.0104 μs |  1.19 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2.994 μs | 0.0102 μs | 0.0079 μs |  1.08 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |  3.280 μs | 0.0091 μs | 0.0071 μs |  1.19 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2.491 μs | 0.0139 μs | 0.0123 μs |  0.90 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |          |          |      |       |           |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** |  **4.696 μs** | **0.0211 μs** | **0.0176 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 17.267 μs | 0.0705 μs | 0.0625 μs |  3.68 |    0.01 | 0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 15.612 μs | 0.1365 μs | 0.1140 μs |  3.32 |    0.03 |      - |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  9.108 μs | 0.0707 μs | 0.0627 μs |  1.94 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  7.913 μs | 0.0326 μs | 0.0289 μs |  1.69 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 10.157 μs | 0.0454 μs | 0.0403 μs |  2.16 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  8.722 μs | 0.0360 μs | 0.0301 μs |  1.86 |    0.01 | 0.0153 |     - |     - |      40 B |
|                      |          |          |      |       |           |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  4.592 μs | 0.0257 μs | 0.0228 μs |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 18.684 μs | 0.0954 μs | 0.0846 μs |  4.07 |    0.03 | 0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 16.043 μs | 0.0928 μs | 0.0868 μs |  3.49 |    0.02 |      - |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  9.523 μs | 0.0417 μs | 0.0348 μs |  2.07 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  7.949 μs | 0.0520 μs | 0.0487 μs |  1.73 |    0.02 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 10.513 μs | 0.0492 μs | 0.0436 μs |  2.29 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  8.537 μs | 0.0502 μs | 0.0470 μs |  1.86 |    0.02 | 0.0153 |     - |     - |      40 B |
