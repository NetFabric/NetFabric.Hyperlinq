## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
| Method                   | Runtime  | Skip | Count | Mean        | Error     | StdDev     | Median      | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |------------:|----------:|-----------:|------------:|--------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 1000 | 100   |    71.09 ns |  1.437 ns |   1.537 ns |    70.67 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 8.0 | 1000 | 100   |   397.18 ns |  7.847 ns |  11.254 ns |   390.71 ns |  5.62x slower |   0.24x | 0.0725 |     152 B |          NA |
| LinqFaster               | .NET 8.0 | 1000 | 100   |   703.12 ns |  6.620 ns |   5.169 ns |   701.33 ns |  9.90x slower |   0.27x | 0.6533 |    1368 B |          NA |
| LinqFasterer             | .NET 8.0 | 1000 | 100   |   611.70 ns | 10.925 ns |  12.144 ns |   607.81 ns |  8.62x slower |   0.25x | 2.5311 |    5304 B |          NA |
| LinqAF                   | .NET 8.0 | 1000 | 100   | 2,918.86 ns | 57.708 ns |  84.588 ns | 2,898.37 ns | 41.65x slower |   1.60x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 1000 | 100   |   113.11 ns |  1.877 ns |   1.664 ns |   112.52 ns |  1.59x slower |   0.05x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   |    61.33 ns |  1.269 ns |   1.358 ns |    60.70 ns |  1.16x faster |   0.04x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 1000 | 100   |    70.33 ns |  0.721 ns |   0.563 ns |    70.22 ns |  1.01x faster |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   |    57.87 ns |  1.484 ns |   4.329 ns |    58.00 ns |  1.35x faster |   0.04x |      - |         - |          NA |
|                          |          |      |       |             |           |            |             |               |         |        |           |             |
| ForLoop                  | .NET 9.0 | 1000 | 100   |    85.34 ns |  2.534 ns |   7.063 ns |    83.37 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 9.0 | 1000 | 100   |   552.84 ns | 17.524 ns |  49.998 ns |   533.50 ns |  6.55x slower |   0.89x | 0.0725 |     152 B |          NA |
| LinqFaster               | .NET 9.0 | 1000 | 100   | 1,235.69 ns | 68.529 ns | 202.060 ns | 1,179.36 ns | 14.21x slower |   2.41x | 0.6523 |    1368 B |          NA |
| LinqFasterer             | .NET 9.0 | 1000 | 100   |   685.40 ns | 27.503 ns |  78.469 ns |   645.81 ns |  8.10x slower |   1.13x | 2.5311 |    5304 B |          NA |
| LinqAF                   | .NET 9.0 | 1000 | 100   | 2,595.61 ns | 31.274 ns |  33.463 ns | 2,579.12 ns | 30.56x slower |   1.81x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 1000 | 100   |   138.25 ns |  2.075 ns |   1.733 ns |   137.65 ns |  1.61x slower |   0.12x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   |    61.18 ns |  1.140 ns |   0.952 ns |    60.79 ns |  1.41x faster |   0.12x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 1000 | 100   |    91.67 ns |  1.562 ns |   1.798 ns |    91.12 ns |  1.08x slower |   0.06x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   |    62.20 ns |  0.414 ns |   0.387 ns |    62.36 ns |  1.38x faster |   0.10x |      - |         - |          NA |
