## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta22](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta22)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|      Method |           Job |       Runtime | Duplicates | Count |     Mean |    Error |    StdDev |   Median | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|------------ |-------------- |-------------- |----------- |------ |---------:|---------:|----------:|---------:|------:|--------:|----------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|     ForLoop |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 678.9 μs |  5.52 μs |   4.61 μs | 679.7 μs |  1.00 |    0.00 | 1095.7031 |     - |     - |   2.19 MB |      0 MB |          2,810 |                     651 |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 807.3 μs | 54.87 μs | 161.79 μs | 675.9 μs |  1.45 |    0.06 | 1095.7031 |     - |     - |   2.19 MB |      0 MB |          2,319 |                     576 |
|        Linq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 672.5 μs |  3.83 μs |   3.39 μs | 671.8 μs |  0.99 |    0.01 | 1092.7734 |     - |     - |   2.19 MB |      0 MB |          2,387 |                     578 |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 726.2 μs |  4.50 μs |   4.21 μs | 726.3 μs |  1.07 |    0.01 | 1086.9141 |     - |     - |   2.17 MB |      0 MB |          2,705 |                     608 |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 633.8 μs |  4.57 μs |   4.27 μs | 634.0 μs |  0.93 |    0.01 | 1045.8984 |     - |     - |   2.09 MB |      0 MB |          2,265 |                     538 |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 623.6 μs |  3.24 μs |   3.03 μs | 623.8 μs |  0.92 |    0.01 | 1095.7031 |     - |     - |   2.19 MB |      0 MB |          2,906 |                     604 |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 594.5 μs |  3.68 μs |   2.87 μs | 594.8 μs |  0.88 |    0.01 | 1095.7031 |     - |     - |   2.19 MB |      0 MB |          2,627 |                     607 |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 633.1 μs |  3.52 μs |   3.12 μs | 633.6 μs |  0.93 |    0.01 | 1092.7734 |     - |     - |   2.18 MB |      0 MB |          2,700 |                     578 |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 644.1 μs |  6.33 μs |   5.61 μs | 643.4 μs |  0.95 |    0.01 | 1086.9141 |     - |     - |   2.17 MB |      0 MB |          3,239 |                     635 |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 548.2 μs |  4.32 μs |   3.83 μs | 546.3 μs |  0.81 |    0.01 | 1045.8984 |     - |     - |   2.09 MB |      0 MB |          1,987 |                     473 |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 521.6 μs |  2.08 μs |   1.85 μs | 521.5 μs |  0.77 |    0.01 | 1095.7031 |     - |     - |   2.19 MB |      0 MB |          2,078 |                     475 |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 521.2 μs |  3.47 μs |   3.24 μs | 521.1 μs |  0.77 |    0.01 | 1095.7031 |     - |     - |   2.19 MB |      0 MB |          2,272 |                     540 |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 529.9 μs |  3.72 μs |   3.30 μs | 530.4 μs |  0.78 |    0.01 | 1092.7734 |     - |     - |   2.18 MB |      0 MB |          2,585 |                     554 |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 593.1 μs |  6.47 μs |   6.05 μs | 592.3 μs |  0.87 |    0.01 | 1086.9141 |     - |     - |   2.17 MB |      0 MB |          2,298 |                     487 |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 496.0 μs |  6.80 μs |   6.36 μs | 493.2 μs |  0.73 |    0.01 | 1045.8984 |     - |     - |   2.09 MB |      0 MB |          2,368 |                     501 |
