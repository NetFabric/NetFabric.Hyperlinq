## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
| Method                   | Runtime  | Count | Mean       | Error    | StdDev   | Median      | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|---------:|---------:|------------:|--------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |   122.3 ns |  1.88 ns |  1.66 ns |   121.70 ns |      baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |   156.0 ns |  1.63 ns |  1.36 ns |   155.81 ns |  1.27x slower |   0.01x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 1,147.7 ns |  5.92 ns |  4.63 ns | 1,147.68 ns |  9.37x slower |   0.14x | 0.0877 |     184 B |          NA |
| LinqFaster               | .NET 8.0 | 100   |   978.2 ns | 19.97 ns | 58.89 ns |   951.46 ns |  8.00x slower |   0.41x | 3.0861 |    6456 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 1,371.1 ns | 18.24 ns | 24.36 ns | 1,364.76 ns | 11.27x slower |   0.21x | 6.1531 |   12880 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 1,174.7 ns |  6.64 ns |  5.18 ns | 1,173.53 ns |  9.59x slower |   0.12x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   |   252.0 ns |  3.99 ns |  3.33 ns |   251.39 ns |  2.06x slower |   0.04x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |   119.1 ns |  1.97 ns |  2.49 ns |   118.43 ns |  1.02x faster |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |   295.0 ns |  3.62 ns |  3.02 ns |   293.84 ns |  2.41x slower |   0.02x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |   100.0 ns |  1.76 ns |  2.03 ns |    99.26 ns |  1.22x faster |   0.04x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 1,582.5 ns | 25.48 ns | 19.89 ns | 1,575.77 ns | 12.92x slower |   0.17x | 7.7820 |   16304 B |          NA |
|                          |          |       |            |          |          |             |               |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |   123.3 ns |  2.45 ns |  3.27 ns |   122.29 ns |      baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |   155.5 ns |  2.17 ns |  1.81 ns |   154.91 ns |  1.26x slower |   0.04x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 1,108.7 ns |  5.36 ns |  4.75 ns | 1,107.65 ns |  8.99x slower |   0.26x | 0.0877 |     184 B |          NA |
| LinqFaster               | .NET 9.0 | 100   |   914.3 ns | 10.43 ns |  8.71 ns |   911.30 ns |  7.43x slower |   0.22x | 3.0861 |    6456 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 1,314.1 ns | 15.68 ns | 17.43 ns | 1,315.54 ns | 10.64x slower |   0.31x | 6.1531 |   12880 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 1,150.3 ns |  7.06 ns |  5.51 ns | 1,148.82 ns |  9.38x slower |   0.27x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   |   236.4 ns |  1.74 ns |  1.35 ns |   235.81 ns |  1.93x slower |   0.06x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |   127.1 ns |  2.51 ns |  2.98 ns |   126.04 ns |  1.03x slower |   0.05x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |   275.1 ns |  1.19 ns |  1.06 ns |   274.92 ns |  2.23x slower |   0.07x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |   104.5 ns |  1.42 ns |  1.52 ns |   103.86 ns |  1.18x faster |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 1,616.8 ns | 32.29 ns | 85.62 ns | 1,574.96 ns | 13.18x slower |   0.90x | 7.7820 |   16304 B |          NA |
