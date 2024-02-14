## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
| Method                   | Runtime  | Count | Mean      | Error     | StdDev    | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  64.77 ns |  0.792 ns |  0.702 ns |  64.57 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   | 117.12 ns |  1.601 ns |  1.337 ns | 116.83 ns | 1.81x slower |   0.02x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 332.15 ns |  6.307 ns |  8.842 ns | 328.48 ns | 5.12x slower |   0.09x | 0.0458 |      96 B |          NA |
| LinqFaster               | .NET 8.0 | 100   | 143.68 ns |  2.849 ns |  4.518 ns | 141.82 ns | 2.22x slower |   0.06x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 542.80 ns | 10.000 ns | 17.515 ns | 538.01 ns | 8.45x slower |   0.31x | 3.0670 |    6424 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 419.47 ns |  8.148 ns | 17.365 ns | 417.51 ns | 6.73x slower |   0.20x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 178.56 ns |  2.945 ns |  2.459 ns | 177.73 ns | 2.76x slower |   0.05x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  51.85 ns |  0.763 ns |  0.677 ns |  51.67 ns | 1.25x faster |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 123.59 ns |  1.657 ns |  1.384 ns | 122.96 ns | 1.91x slower |   0.02x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  41.77 ns |  0.457 ns |  0.357 ns |  41.73 ns | 1.55x faster |   0.02x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 426.30 ns |  8.343 ns | 18.661 ns | 417.28 ns | 6.54x slower |   0.23x | 0.5660 |    1184 B |          NA |
|                          |          |       |           |           |           |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  64.37 ns |  0.853 ns |  0.756 ns |  64.19 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   | 119.12 ns |  2.409 ns |  3.454 ns | 117.78 ns | 1.84x slower |   0.05x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 307.39 ns |  3.292 ns |  2.918 ns | 306.51 ns | 4.78x slower |   0.07x | 0.0458 |      96 B |          NA |
| LinqFaster               | .NET 9.0 | 100   | 163.83 ns |  3.071 ns |  3.884 ns | 162.61 ns | 2.56x slower |   0.08x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 585.17 ns |  6.270 ns |  5.236 ns | 583.57 ns | 9.08x slower |   0.15x | 3.0670 |    6424 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 426.79 ns | 11.554 ns | 34.068 ns | 410.43 ns | 6.37x slower |   0.35x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 180.79 ns |  3.246 ns |  4.221 ns | 179.27 ns | 2.80x slower |   0.08x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  58.79 ns |  1.040 ns |  1.556 ns |  58.06 ns | 1.09x faster |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 102.41 ns |  2.087 ns |  1.742 ns | 101.84 ns | 1.59x slower |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  43.78 ns |  0.598 ns |  0.500 ns |  43.54 ns | 1.47x faster |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 422.16 ns |  6.566 ns | 10.027 ns | 417.22 ns | 6.61x slower |   0.17x | 0.5655 |    1184 B |          NA |
