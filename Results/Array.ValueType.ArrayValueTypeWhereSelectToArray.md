## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |-------------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |  1.584 μs | 0.0184 μs | 0.0163 μs |  1.579 μs |     baseline |         |  5.5237 |      - |     11 KB |
|              ForeachLoop |        .NET 6 |   100 |  1.687 μs | 0.0125 μs | 0.0117 μs |  1.688 μs | 1.06x slower |   0.01x |  5.5237 |      - |     11 KB |
|                     Linq |        .NET 6 |   100 |  1.825 μs | 0.0086 μs | 0.0076 μs |  1.825 μs | 1.15x slower |   0.01x |  3.9291 |      - |      8 KB |
|               LinqFaster |        .NET 6 |   100 |  1.557 μs | 0.0095 μs | 0.0084 μs |  1.553 μs | 1.02x faster |   0.01x |  4.7264 |      - |     10 KB |
|             LinqFasterer |        .NET 6 |   100 |  2.587 μs | 0.0167 μs | 0.0156 μs |  2.581 μs | 1.63x slower |   0.02x |  6.0043 |      - |     12 KB |
|                   LinqAF |        .NET 6 |   100 |  2.909 μs | 0.0157 μs | 0.0140 μs |  2.905 μs | 1.84x slower |   0.02x |  5.5122 |      - |     11 KB |
|            LinqOptimizer |        .NET 6 |   100 |  9.394 μs | 0.1237 μs | 0.1157 μs |  9.416 μs | 5.92x slower |   0.10x | 62.4695 | 0.0153 |    132 KB |
|                 SpanLinq |        .NET 6 |   100 |  2.432 μs | 0.0161 μs | 0.0142 μs |  2.433 μs | 1.54x slower |   0.02x |  5.5237 |      - |     11 KB |
|                  Streams |        .NET 6 |   100 |  2.701 μs | 0.0526 μs | 0.0626 μs |  2.689 μs | 1.70x slower |   0.05x |  5.7716 |      - |     12 KB |
|               StructLinq |        .NET 6 |   100 |  1.632 μs | 0.0224 μs | 0.0199 μs |  1.638 μs | 1.03x slower |   0.02x |  1.7052 |      - |      3 KB |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  1.242 μs | 0.0092 μs | 0.0086 μs |  1.239 μs | 1.28x faster |   0.02x |  1.6575 |      - |      3 KB |
|                Hyperlinq |        .NET 6 |   100 |  1.801 μs | 0.0156 μs | 0.0146 μs |  1.802 μs | 1.14x slower |   0.02x |  1.6575 |      - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |  1.455 μs | 0.0257 μs | 0.0392 μs |  1.436 μs | 1.08x faster |   0.03x |  1.6575 |      - |      3 KB |
|                          |               |       |           |           |           |           |              |         |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |  1.659 μs | 0.0333 μs | 0.0489 μs |  1.659 μs |     baseline |         |  5.5237 |      - |     11 KB |
|              ForeachLoop |    .NET 6 PGO |   100 |  1.820 μs | 0.0249 μs | 0.0233 μs |  1.818 μs | 1.07x slower |   0.02x |  5.5237 |      - |     11 KB |
|                     Linq |    .NET 6 PGO |   100 |  1.960 μs | 0.0365 μs | 0.0359 μs |  1.953 μs | 1.16x slower |   0.04x |  3.9291 |      - |      8 KB |
|               LinqFaster |    .NET 6 PGO |   100 |  1.998 μs | 0.1579 μs | 0.4454 μs |  1.810 μs | 1.39x slower |   0.32x |  4.7264 |      - |     10 KB |
|             LinqFasterer |    .NET 6 PGO |   100 |  2.861 μs | 0.0841 μs | 0.2398 μs |  2.767 μs | 1.88x slower |   0.11x |  6.0043 |      - |     12 KB |
|                   LinqAF |    .NET 6 PGO |   100 |  2.988 μs | 0.0592 μs | 0.0770 μs |  2.956 μs | 1.79x slower |   0.06x |  5.5122 |      - |     11 KB |
|            LinqOptimizer |    .NET 6 PGO |   100 | 12.212 μs | 0.8846 μs | 2.5523 μs | 11.270 μs | 6.56x slower |   1.21x | 62.4542 | 0.0305 |    132 KB |
|                 SpanLinq |    .NET 6 PGO |   100 |  2.639 μs | 0.0701 μs | 0.1965 μs |  2.654 μs | 1.65x slower |   0.10x |  5.5237 |      - |     11 KB |
|                  Streams |    .NET 6 PGO |   100 |  2.808 μs | 0.0558 μs | 0.0522 μs |  2.805 μs | 1.66x slower |   0.06x |  5.7716 |      - |     12 KB |
|               StructLinq |    .NET 6 PGO |   100 |  1.645 μs | 0.0281 μs | 0.0263 μs |  1.645 μs | 1.03x faster |   0.02x |  1.7052 |      - |      3 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  1.178 μs | 0.0235 μs | 0.0501 μs |  1.166 μs | 1.40x faster |   0.06x |  1.6575 |      - |      3 KB |
|                Hyperlinq |    .NET 6 PGO |   100 |  1.898 μs | 0.0231 μs | 0.0205 μs |  1.894 μs | 1.12x slower |   0.03x |  1.6556 |      - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |  1.423 μs | 0.0183 μs | 0.0163 μs |  1.426 μs | 1.19x faster |   0.03x |  1.6575 |      - |      3 KB |
|                          |               |       |           |           |           |           |              |         |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |  1.664 μs | 0.0323 μs | 0.0590 μs |  1.654 μs |     baseline |         |  5.5237 |      - |     11 KB |
|              ForeachLoop | .NET Core 3.1 |   100 |  1.824 μs | 0.0353 μs | 0.0636 μs |  1.813 μs | 1.10x slower |   0.04x |  5.5237 |      - |     11 KB |
|                     Linq | .NET Core 3.1 |   100 |  2.021 μs | 0.0662 μs | 0.1855 μs |  1.927 μs | 1.25x slower |   0.13x |  3.9291 |      - |      8 KB |
|               LinqFaster | .NET Core 3.1 |   100 |  1.635 μs | 0.0324 μs | 0.0585 μs |  1.613 μs | 1.02x faster |   0.05x |  4.7226 |      - |     10 KB |
|             LinqFasterer | .NET Core 3.1 |   100 |  2.703 μs | 0.0221 μs | 0.0196 μs |  2.697 μs | 1.62x slower |   0.07x |  6.0043 |      - |     12 KB |
|                   LinqAF | .NET Core 3.1 |   100 |  3.846 μs | 0.0366 μs | 0.0306 μs |  3.856 μs | 2.31x slower |   0.10x |  5.5084 |      - |     11 KB |
|            LinqOptimizer | .NET Core 3.1 |   100 |  9.254 μs | 0.1826 μs | 0.1954 μs |  9.186 μs | 5.53x slower |   0.25x | 62.4847 | 0.2441 |    132 KB |
|                 SpanLinq | .NET Core 3.1 |   100 |  2.853 μs | 0.0851 μs | 0.2415 μs |  2.720 μs | 1.68x slower |   0.12x |  5.5237 |      - |     11 KB |
|                  Streams | .NET Core 3.1 |   100 |  2.632 μs | 0.0498 μs | 0.1277 μs |  2.589 μs | 1.61x slower |   0.11x |  5.7716 |      - |     12 KB |
|               StructLinq | .NET Core 3.1 |   100 |  1.809 μs | 0.0240 μs | 0.0224 μs |  1.804 μs | 1.09x slower |   0.05x |  1.7090 |      - |      3 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  1.610 μs | 0.0350 μs | 0.0994 μs |  1.605 μs | 1.03x faster |   0.06x |  1.6632 |      - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |   100 |  2.425 μs | 0.0657 μs | 0.1777 μs |  2.406 μs | 1.48x slower |   0.12x |  1.6632 |      - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |  1.751 μs | 0.0347 μs | 0.0700 μs |  1.722 μs | 1.06x slower |   0.05x |  1.6632 |      - |      3 KB |
