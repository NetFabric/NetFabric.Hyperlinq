## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|                   Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |  68.33 ns |  1.342 ns |  1.318 ns |  67.88 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 147.25 ns |  1.857 ns |  1.551 ns | 147.24 ns |  2.15x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 798.54 ns | 17.404 ns | 49.935 ns | 770.35 ns | 11.72x slower |   0.88x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 280.37 ns |  5.318 ns |  6.726 ns | 277.68 ns |  4.13x slower |   0.15x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 273.22 ns |  1.494 ns |  1.166 ns | 273.44 ns |  3.98x slower |   0.08x |      - |         - |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 668.23 ns | 12.809 ns | 34.848 ns | 653.92 ns |  9.78x slower |   0.73x |      - |         - |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 262.61 ns |  4.891 ns |  4.804 ns | 260.81 ns |  3.84x slower |   0.08x | 0.0305 |      64 B |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 495.68 ns |  6.482 ns |  7.205 ns | 493.29 ns |  7.25x slower |   0.20x | 0.0114 |      24 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 638.87 ns |  9.202 ns |  7.684 ns | 636.67 ns |  9.32x slower |   0.16x | 0.1717 |     360 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 176.06 ns |  3.519 ns |  6.069 ns | 173.45 ns |  2.60x slower |   0.13x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 492.09 ns |  9.544 ns | 14.284 ns | 483.67 ns |  7.19x slower |   0.26x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 343.46 ns |  5.336 ns |  6.554 ns | 341.15 ns |  5.05x slower |   0.16x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 664.61 ns |  9.583 ns |  8.002 ns | 665.36 ns |  9.70x slower |   0.22x | 3.0670 |    6424 B |          NA |
|                          |        |          |       |           |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |  68.29 ns |  1.394 ns |  1.999 ns |  67.37 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 104.89 ns |  2.027 ns |  3.034 ns | 103.25 ns |  1.54x slower |   0.07x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 332.40 ns |  2.143 ns |  1.673 ns | 331.60 ns |  4.86x slower |   0.19x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 108.08 ns |  0.841 ns |  1.033 ns | 107.88 ns |  1.58x slower |   0.04x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 159.87 ns |  1.696 ns |  1.503 ns | 159.32 ns |  2.34x slower |   0.08x |      - |         - |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 256.70 ns |  1.426 ns |  1.265 ns | 256.52 ns |  3.76x slower |   0.13x |      - |         - |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 185.60 ns |  2.366 ns |  2.531 ns | 184.83 ns |  2.70x slower |   0.09x | 0.0305 |      64 B |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 292.52 ns |  3.157 ns |  2.465 ns | 292.27 ns |  4.28x slower |   0.16x | 0.0114 |      24 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 576.51 ns |  5.291 ns |  4.690 ns | 574.53 ns |  8.43x slower |   0.30x | 0.1717 |     360 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 151.05 ns |  2.445 ns |  2.816 ns | 149.99 ns |  2.20x slower |   0.06x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 167.27 ns |  2.311 ns |  1.930 ns | 166.79 ns |  2.45x slower |   0.10x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |  98.69 ns |  2.856 ns |  8.194 ns |  94.30 ns |  1.47x slower |   0.16x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 539.39 ns |  4.762 ns |  5.293 ns | 537.47 ns |  7.87x slower |   0.30x | 3.0670 |    6424 B |          NA |
