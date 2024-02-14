## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.28.2](https://www.nuget.org/packages/StructLinq/0.28.2)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3996/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.100-preview.1.24101.2
  [Host]     : .NET 6.0.26 (6.0.2623.60508), X64 RyuJIT AVX2
  Job-THTHEP : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  Job-OQLBIM : .NET 9.0.0 (9.0.24.8009), X64 RyuJIT AVX2


```
| Method                   | Runtime  | Count | Mean        | Error     | StdDev    | Median      | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |------------:|----------:|----------:|------------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |   147.71 ns |  1.583 ns |  1.236 ns |   147.70 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |   136.47 ns |  2.015 ns |  1.682 ns |   135.87 ns | 1.08x faster |   0.01x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   |   776.58 ns | 12.998 ns | 10.854 ns |   773.29 ns | 5.26x slower |   0.09x | 0.0877 |     184 B |          NA |
| LinqFaster               | .NET 8.0 | 100   |   881.00 ns | 17.646 ns | 49.770 ns |   855.90 ns | 5.97x slower |   0.33x | 3.8605 |    8088 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   |   993.18 ns | 19.526 ns | 29.225 ns |   993.59 ns | 6.81x slower |   0.25x | 4.7379 |    9936 B |          NA |
| LinqAF                   | .NET 8.0 | 100   |   494.50 ns |  3.185 ns |  2.979 ns |   493.08 ns | 3.35x slower |   0.04x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   |   227.97 ns |  3.510 ns |  3.283 ns |   226.68 ns | 1.55x slower |   0.03x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |   131.78 ns |  1.070 ns |  0.948 ns |   131.57 ns | 1.12x faster |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |   249.35 ns |  2.187 ns |  2.045 ns |   248.69 ns | 1.69x slower |   0.02x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |   125.35 ns |  0.948 ns |  0.886 ns |   124.91 ns | 1.18x faster |   0.01x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   |   902.18 ns | 17.695 ns | 17.379 ns |   897.54 ns | 6.14x slower |   0.10x | 3.8605 |    8088 B |          NA |
|                          |          |       |             |           |           |             |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |   147.69 ns |  1.737 ns |  1.540 ns |   147.27 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |   135.79 ns |  1.101 ns |  0.919 ns |   135.57 ns | 1.09x faster |   0.01x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   |   765.78 ns | 10.943 ns | 11.238 ns |   761.57 ns | 5.19x slower |   0.11x | 0.0877 |     184 B |          NA |
| LinqFaster               | .NET 9.0 | 100   |   856.94 ns | 12.408 ns | 14.289 ns |   850.71 ns | 5.80x slower |   0.13x | 3.8605 |    8088 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 1,013.08 ns | 10.105 ns |  8.438 ns | 1,012.88 ns | 6.86x slower |   0.09x | 4.7379 |    9936 B |          NA |
| LinqAF                   | .NET 9.0 | 100   |   490.81 ns |  8.423 ns |  7.034 ns |   486.84 ns | 3.33x slower |   0.05x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   |   226.45 ns |  4.415 ns |  8.184 ns |   223.23 ns | 1.54x slower |   0.07x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |   107.33 ns |  1.942 ns |  2.385 ns |   106.43 ns | 1.37x faster |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |   248.01 ns |  4.592 ns |  4.295 ns |   246.52 ns | 1.68x slower |   0.02x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |    99.70 ns |  0.841 ns |  0.826 ns |    99.56 ns | 1.48x faster |   0.02x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   |   991.74 ns | 20.272 ns | 58.812 ns |   966.16 ns | 6.81x slower |   0.35x | 3.8605 |    8088 B |          NA |
