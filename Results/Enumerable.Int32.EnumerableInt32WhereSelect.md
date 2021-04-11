## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method |      Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **57.00 ns** |  **0.418 ns** |  **0.370 ns** |    **56.91 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |   179.67 ns |  0.572 ns |  0.507 ns |   179.66 ns |  3.15 |    0.03 | 0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |   146.94 ns |  1.781 ns |  1.579 ns |   147.37 ns |  2.58 |    0.04 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |   127.86 ns |  2.588 ns |  4.395 ns |   125.33 ns |  2.32 |    0.07 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    84.57 ns |  0.541 ns |  0.480 ns |    84.39 ns |  1.48 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |   114.73 ns |  0.596 ns |  0.528 ns |   114.62 ns |  2.01 |    0.02 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    82.04 ns |  0.412 ns |  0.365 ns |    82.03 ns |  1.44 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |             |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    56.08 ns |  0.406 ns |  0.339 ns |    55.95 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |   176.14 ns |  1.031 ns |  0.965 ns |   176.06 ns |  3.14 |    0.03 | 0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |   143.98 ns |  2.591 ns |  2.424 ns |   144.74 ns |  2.56 |    0.05 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |   131.02 ns |  2.643 ns |  4.900 ns |   128.15 ns |  2.45 |    0.05 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    76.73 ns |  0.400 ns |  0.374 ns |    76.64 ns |  1.37 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |   102.98 ns |  0.484 ns |  0.429 ns |   102.97 ns |  1.84 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    83.15 ns |  0.422 ns |  0.395 ns |    83.06 ns |  1.48 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |             |       |         |        |       |       |           |
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **4,187.01 ns** | **15.508 ns** | **14.506 ns** | **4,184.95 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 9,141.68 ns | 29.331 ns | 27.436 ns | 9,143.32 ns |  2.18 |    0.01 | 0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 8,344.43 ns | 55.941 ns | 49.591 ns | 8,349.53 ns |  1.99 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 7,581.18 ns | 43.829 ns | 34.219 ns | 7,590.67 ns |  1.81 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 5,581.99 ns | 30.621 ns | 27.145 ns | 5,586.72 ns |  1.33 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 7,981.80 ns | 25.519 ns | 19.924 ns | 7,981.91 ns |  1.91 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 4,929.86 ns | 36.915 ns | 32.724 ns | 4,919.55 ns |  1.18 |    0.01 | 0.0153 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |             |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 4,570.48 ns | 27.276 ns | 22.776 ns | 4,579.02 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 9,910.35 ns | 40.037 ns | 35.492 ns | 9,908.88 ns |  2.17 |    0.01 | 0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 8,265.65 ns | 35.571 ns | 27.771 ns | 8,269.64 ns |  1.81 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 8,472.76 ns | 44.790 ns | 37.402 ns | 8,481.36 ns |  1.85 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 5,063.42 ns | 30.274 ns | 28.318 ns | 5,066.80 ns |  1.11 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 7,435.78 ns | 30.085 ns | 25.122 ns | 7,431.96 ns |  1.63 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 5,424.97 ns | 23.142 ns | 21.647 ns | 5,419.34 ns |  1.19 |    0.01 | 0.0153 |     - |     - |      40 B |
