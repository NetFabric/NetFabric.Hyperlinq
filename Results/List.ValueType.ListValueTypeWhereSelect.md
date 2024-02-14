## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
| Method                   | Runtime  | Count | Mean       | Error    | StdDev   | Median     | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |   148.9 ns |  2.58 ns |  2.01 ns |   148.5 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |   209.4 ns |  2.28 ns |  2.63 ns |   208.7 ns | 1.41x slower |   0.03x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   |   800.9 ns | 14.12 ns | 16.80 ns |   794.6 ns | 5.41x slower |   0.16x | 0.1793 |     376 B |          NA |
| LinqFaster               | .NET 8.0 | 100   |   967.0 ns | 10.27 ns |  9.61 ns |   961.8 ns | 6.50x slower |   0.10x | 3.8605 |    8088 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 1,349.2 ns | 26.47 ns | 28.32 ns | 1,339.9 ns | 9.09x slower |   0.25x | 6.4087 |   13416 B |          NA |
| LinqAF                   | .NET 8.0 | 100   |   561.0 ns | 11.01 ns | 12.24 ns |   557.1 ns | 3.80x slower |   0.10x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   |   369.3 ns |  6.66 ns | 10.94 ns |   365.2 ns | 2.50x slower |   0.11x | 0.0343 |      72 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |   110.3 ns |  2.04 ns |  1.80 ns |   109.8 ns | 1.35x faster |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |   425.9 ns |  8.14 ns | 10.29 ns |   421.3 ns | 2.85x slower |   0.06x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |   126.5 ns |  1.21 ns |  1.01 ns |   126.1 ns | 1.18x faster |   0.02x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   |   988.6 ns | 12.77 ns | 11.32 ns |   987.1 ns | 6.64x slower |   0.14x | 3.8605 |    8088 B |          NA |
|                          |          |       |            |          |          |            |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |   144.8 ns |  1.05 ns |  0.93 ns |   144.8 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |   135.9 ns |  1.00 ns |  0.83 ns |   135.5 ns | 1.07x faster |   0.01x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   |   788.9 ns | 14.32 ns | 14.06 ns |   785.5 ns | 5.45x slower |   0.09x | 0.1793 |     376 B |          NA |
| LinqFaster               | .NET 9.0 | 100   |   949.4 ns | 17.90 ns | 13.97 ns |   941.7 ns | 6.56x slower |   0.12x | 3.8605 |    8088 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 1,318.0 ns | 25.06 ns | 19.57 ns | 1,318.9 ns | 9.11x slower |   0.12x | 6.4087 |   13416 B |          NA |
| LinqAF                   | .NET 9.0 | 100   |   458.3 ns |  4.91 ns |  3.83 ns |   456.0 ns | 3.17x slower |   0.04x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   |   345.6 ns |  6.34 ns |  8.24 ns |   342.1 ns | 2.40x slower |   0.07x | 0.0343 |      72 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |   106.8 ns |  1.34 ns |  1.12 ns |   106.2 ns | 1.36x faster |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |   394.3 ns |  7.58 ns |  7.09 ns |   391.2 ns | 2.72x slower |   0.06x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |   129.5 ns |  2.40 ns |  2.01 ns |   128.6 ns | 1.12x faster |   0.02x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   |   977.6 ns | 18.87 ns | 31.53 ns |   962.1 ns | 6.78x slower |   0.24x | 3.8605 |    8088 B |          NA |
