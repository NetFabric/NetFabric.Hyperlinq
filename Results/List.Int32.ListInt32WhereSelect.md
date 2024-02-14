## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
| Method                   | Runtime  | Count | Mean      | Error    | StdDev    | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   | 108.29 ns | 0.766 ns |  0.640 ns | 108.20 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  79.40 ns | 1.433 ns |  1.408 ns |  78.96 ns | 1.36x faster |   0.03x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 297.60 ns | 5.784 ns |  5.128 ns | 295.82 ns | 2.74x slower |   0.05x | 0.0725 |     152 B |          NA |
| LinqFaster               | .NET 8.0 | 100   | 323.87 ns | 6.488 ns |  7.968 ns | 320.98 ns | 3.01x slower |   0.09x | 0.3095 |     648 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 322.73 ns | 5.175 ns |  4.588 ns | 321.32 ns | 2.98x slower |   0.05x | 0.4473 |     936 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 205.74 ns | 4.024 ns |  6.265 ns | 203.44 ns | 1.92x slower |   0.07x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 200.84 ns | 2.413 ns |  2.370 ns | 200.06 ns | 1.85x slower |   0.02x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  94.48 ns | 0.524 ns |  0.409 ns |  94.67 ns | 1.15x faster |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 136.94 ns | 2.446 ns |  4.474 ns | 135.12 ns | 1.27x slower |   0.05x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  79.17 ns | 0.816 ns |  0.682 ns |  79.05 ns | 1.37x faster |   0.01x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 345.48 ns | 2.985 ns |  3.317 ns | 344.77 ns | 3.20x slower |   0.05x | 0.3095 |     648 B |          NA |
|                          |          |       |           |          |           |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   | 116.80 ns | 1.809 ns |  1.603 ns | 116.72 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  79.68 ns | 1.559 ns |  1.382 ns |  79.13 ns | 1.47x faster |   0.03x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 307.97 ns | 6.030 ns |  6.944 ns | 305.14 ns | 2.65x slower |   0.07x | 0.0725 |     152 B |          NA |
| LinqFaster               | .NET 9.0 | 100   | 380.36 ns | 6.480 ns |  7.203 ns | 378.15 ns | 3.26x slower |   0.08x | 0.3095 |     648 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 385.15 ns | 7.624 ns | 13.748 ns | 378.39 ns | 3.32x slower |   0.16x | 0.4473 |     936 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 183.89 ns | 3.538 ns |  3.933 ns | 182.58 ns | 1.58x slower |   0.05x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 193.12 ns | 3.905 ns |  9.796 ns | 188.40 ns | 1.62x slower |   0.07x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 105.52 ns | 1.391 ns |  1.086 ns | 105.12 ns | 1.11x faster |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 143.95 ns | 1.468 ns |  1.632 ns | 143.51 ns | 1.23x slower |   0.02x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  88.86 ns | 1.820 ns |  2.096 ns |  88.06 ns | 1.32x faster |   0.04x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 448.04 ns | 8.190 ns | 16.545 ns | 441.38 ns | 3.85x slower |   0.21x | 0.3095 |     648 B |          NA |
