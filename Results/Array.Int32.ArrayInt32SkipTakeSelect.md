## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|                   Method |    Job |  Runtime | Skip | Count |        Mean |      Error |     StdDev |      Median |          Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |----- |------ |------------:|-----------:|-----------:|------------:|---------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 | 1000 |   100 |    59.53 ns |   0.537 ns |   0.448 ns |    59.39 ns |       baseline |         |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 | 1,025.47 ns |  10.007 ns |   8.356 ns | 1,023.25 ns |  17.23x slower |   0.12x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 | 1000 |   100 |   326.38 ns |   3.172 ns |   2.649 ns |   325.22 ns |   5.48x slower |   0.06x | 0.6080 |    1272 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 | 1000 |   100 |   725.98 ns |  25.226 ns |  73.187 ns |   686.71 ns |  12.27x slower |   1.30x | 0.4206 |     880 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 | 1000 |   100 | 2,527.53 ns |  39.779 ns |  50.308 ns | 2,510.80 ns |  42.81x slower |   1.07x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 | 2,148.98 ns |  25.124 ns |  20.980 ns | 2,155.85 ns |  36.10x slower |   0.52x | 4.2343 |    8866 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 | 1000 |   100 |   257.00 ns |   0.730 ns |   0.610 ns |   256.90 ns |   4.32x slower |   0.03x |      - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 | 7,618.54 ns | 231.742 ns | 676.003 ns | 7,255.97 ns | 128.47x slower |  11.82x | 0.4349 |     912 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |   276.26 ns |   5.483 ns |   8.853 ns |   272.03 ns |   4.68x slower |   0.19x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |   164.50 ns |   1.643 ns |   1.372 ns |   164.05 ns |   2.76x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |   253.13 ns |   4.678 ns |   3.652 ns |   251.85 ns |   4.25x slower |   0.06x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |   200.88 ns |   3.814 ns |   3.746 ns |   199.42 ns |   3.39x slower |   0.07x |      - |         - |          NA |
|                          |        |          |      |       |             |            |            |             |                |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 | 1000 |   100 |    58.37 ns |   0.365 ns |   0.285 ns |    58.38 ns |       baseline |         |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |   630.10 ns |   2.498 ns |   1.950 ns |   630.34 ns |  10.79x slower |   0.05x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 | 1000 |   100 |   211.15 ns |   1.695 ns |   1.586 ns |   210.99 ns |   3.61x slower |   0.03x | 0.6080 |    1272 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 | 1000 |   100 |   359.36 ns |   5.011 ns |   4.922 ns |   357.67 ns |   6.15x slower |   0.07x | 0.4206 |     880 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 | 1000 |   100 | 1,972.54 ns |  27.854 ns |  23.259 ns | 1,964.64 ns |  33.80x slower |   0.38x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 | 1,759.94 ns |  28.678 ns |  28.166 ns | 1,757.84 ns |  30.16x slower |   0.51x | 4.2362 |    8865 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 | 1000 |   100 |   199.22 ns |   3.919 ns |   6.439 ns |   196.15 ns |   3.40x slower |   0.09x |      - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 | 5,681.95 ns |  66.565 ns |  51.970 ns | 5,666.70 ns |  97.34x slower |   0.72x | 0.4349 |     912 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |   206.61 ns |   4.117 ns |   9.292 ns |   201.33 ns |   3.56x slower |   0.18x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |   155.53 ns |   0.988 ns |   0.825 ns |   155.40 ns |   2.66x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |   171.22 ns |   3.019 ns |   5.443 ns |   168.45 ns |   2.96x slower |   0.12x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |   152.79 ns |   1.735 ns |   1.355 ns |   152.47 ns |   2.62x slower |   0.02x |      - |         - |          NA |
