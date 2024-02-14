## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
| ForLoop                  | .NET 8.0 | 100   |  70.29 ns | 0.307 ns |  0.256 ns |  70.27 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   | 111.63 ns | 2.261 ns |  4.302 ns | 109.36 ns | 1.58x slower |   0.06x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 296.67 ns | 4.478 ns |  3.970 ns | 295.57 ns | 4.22x slower |   0.06x | 0.0343 |      72 B |          NA |
| LinqFaster               | .NET 8.0 | 100   | 298.78 ns | 4.838 ns |  6.290 ns | 297.36 ns | 4.27x slower |   0.11x | 0.2179 |     456 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 286.08 ns | 2.137 ns |  1.785 ns | 285.57 ns | 4.07x slower |   0.03x | 0.4206 |     880 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 217.75 ns | 4.315 ns |  3.603 ns | 216.33 ns | 3.10x slower |   0.05x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   |  94.99 ns | 1.933 ns |  3.386 ns |  93.62 ns | 1.35x slower |   0.05x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  59.96 ns | 1.176 ns |  1.155 ns |  59.60 ns | 1.17x faster |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 136.30 ns | 0.606 ns |  0.473 ns | 136.23 ns | 1.94x slower |   0.01x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  48.94 ns | 0.563 ns |  0.439 ns |  48.86 ns | 1.44x faster |   0.02x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 416.89 ns | 8.326 ns | 18.623 ns | 410.16 ns | 5.94x slower |   0.29x | 0.5660 |    1184 B |          NA |
|                          |          |       |           |          |           |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  69.29 ns | 0.618 ns |  0.548 ns |  69.15 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   | 108.44 ns | 0.647 ns |  0.505 ns | 108.15 ns | 1.56x slower |   0.01x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 278.79 ns | 5.032 ns |  8.680 ns | 275.49 ns | 4.03x slower |   0.15x | 0.0343 |      72 B |          NA |
| LinqFaster               | .NET 9.0 | 100   | 436.59 ns | 5.595 ns |  4.672 ns | 434.44 ns | 6.30x slower |   0.08x | 0.2174 |     456 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 344.22 ns | 5.463 ns |  4.562 ns | 344.08 ns | 4.97x slower |   0.07x | 0.4206 |     880 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 195.41 ns | 3.454 ns |  7.133 ns | 191.78 ns | 2.83x slower |   0.11x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 115.08 ns | 1.153 ns |  1.233 ns | 114.67 ns | 1.66x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  59.03 ns | 0.401 ns |  0.356 ns |  59.02 ns | 1.17x faster |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 113.76 ns | 2.286 ns |  2.973 ns | 112.47 ns | 1.64x slower |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  57.19 ns | 0.484 ns |  0.404 ns |  57.06 ns | 1.21x faster |   0.01x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 454.29 ns | 7.575 ns |  6.715 ns | 452.19 ns | 6.56x slower |   0.09x | 0.5655 |    1184 B |          NA |
