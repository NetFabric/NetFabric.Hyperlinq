## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
| Method                   | Runtime  | Skip | Count | Mean        | Error     | StdDev    | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 1000 | 100   |   116.90 ns |  2.322 ns |  3.179 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 8.0 | 1000 | 100   |   431.75 ns |  8.594 ns | 16.558 ns |  3.74x slower |   0.13x | 0.0725 |     152 B |          NA |
| LinqFaster               | .NET 8.0 | 1000 | 100   |   685.74 ns |  7.211 ns |  5.630 ns |  5.83x slower |   0.18x | 0.7458 |    1560 B |          NA |
| LinqFasterer             | .NET 8.0 | 1000 | 100   |   550.38 ns | 10.893 ns | 12.968 ns |  4.69x slower |   0.18x | 2.4424 |    5112 B |          NA |
| LinqAF                   | .NET 8.0 | 1000 | 100   | 2,568.74 ns | 18.626 ns | 15.554 ns | 21.88x slower |   0.66x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 1000 | 100   |   197.75 ns |  3.557 ns |  4.369 ns |  1.69x slower |   0.06x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   |    76.82 ns |  1.333 ns |  1.482 ns |  1.53x faster |   0.05x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 1000 | 100   |   124.92 ns |  2.399 ns |  2.463 ns |  1.06x slower |   0.04x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   |    68.46 ns |  0.745 ns |  0.622 ns |  1.72x faster |   0.06x |      - |         - |          NA |
|                          |          |      |       |             |           |           |               |         |        |           |             |
| ForLoop                  | .NET 9.0 | 1000 | 100   |   115.61 ns |  2.267 ns |  1.893 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 9.0 | 1000 | 100   |   644.86 ns |  7.060 ns |  5.895 ns |  5.58x slower |   0.11x | 0.0725 |     152 B |          NA |
| LinqFaster               | .NET 9.0 | 1000 | 100   |   732.80 ns |  9.337 ns | 14.536 ns |  6.35x slower |   0.11x | 0.7458 |    1560 B |          NA |
| LinqFasterer             | .NET 9.0 | 1000 | 100   |   589.26 ns |  4.737 ns |  3.956 ns |  5.10x slower |   0.09x | 2.4424 |    5112 B |          NA |
| LinqAF                   | .NET 9.0 | 1000 | 100   | 2,631.52 ns | 18.558 ns | 14.489 ns | 22.74x slower |   0.42x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 1000 | 100   |   144.72 ns |  1.853 ns |  2.474 ns |  1.26x slower |   0.03x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   |   106.84 ns |  2.176 ns |  2.329 ns |  1.08x faster |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 1000 | 100   |   110.46 ns |  2.185 ns |  3.270 ns |  1.04x faster |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   |    78.18 ns |  1.550 ns |  1.591 ns |  1.48x faster |   0.05x |      - |         - |          NA |
