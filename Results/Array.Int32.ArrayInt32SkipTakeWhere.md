## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
| Method                   | Runtime  | Skip | Count | Mean      | Error     | StdDev    | Median    | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 1000 | 100   |  89.51 ns |  1.785 ns |  2.125 ns |  88.85 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 8.0 | 1000 | 100   | 862.16 ns | 16.917 ns | 14.997 ns | 855.05 ns |  9.58x slower |   0.32x | 0.0725 |     152 B |          NA |
| LinqFaster               | .NET 8.0 | 1000 | 100   | 219.97 ns |  4.432 ns |  9.913 ns | 216.26 ns |  2.45x slower |   0.07x | 0.7191 |    1504 B |          NA |
| LinqFasterer             | .NET 8.0 | 1000 | 100   | 279.36 ns |  2.785 ns |  2.325 ns | 278.60 ns |  3.10x slower |   0.09x | 0.3285 |     688 B |          NA |
| LinqAF                   | .NET 8.0 | 1000 | 100   | 950.26 ns | 11.955 ns |  9.983 ns | 949.21 ns | 10.54x slower |   0.33x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 1000 | 100   | 151.07 ns |  1.310 ns |  1.094 ns | 150.95 ns |  1.68x slower |   0.05x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   |  91.63 ns |  1.846 ns |  2.400 ns |  90.73 ns |  1.02x slower |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 1000 | 100   | 160.01 ns |  1.578 ns |  1.318 ns | 159.77 ns |  1.77x slower |   0.05x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   |  78.10 ns |  1.451 ns |  2.464 ns |  77.11 ns |  1.15x faster |   0.03x |      - |         - |          NA |
|                          |          |      |       |           |           |           |           |               |         |        |           |             |
| ForLoop                  | .NET 9.0 | 1000 | 100   |  89.26 ns |  0.701 ns |  0.547 ns |  89.24 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 9.0 | 1000 | 100   | 872.27 ns |  8.952 ns |  8.374 ns | 871.45 ns |  9.78x slower |   0.07x | 0.0725 |     152 B |          NA |
| LinqFaster               | .NET 9.0 | 1000 | 100   | 291.70 ns |  5.861 ns |  8.951 ns | 287.87 ns |  3.27x slower |   0.07x | 0.7191 |    1504 B |          NA |
| LinqFasterer             | .NET 9.0 | 1000 | 100   | 301.90 ns |  5.745 ns |  5.093 ns | 299.84 ns |  3.39x slower |   0.07x | 0.3285 |     688 B |          NA |
| LinqAF                   | .NET 9.0 | 1000 | 100   | 936.47 ns | 16.650 ns | 13.904 ns | 930.63 ns | 10.49x slower |   0.16x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 1000 | 100   | 130.08 ns |  1.444 ns |  1.418 ns | 130.26 ns |  1.46x slower |   0.02x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   |  94.50 ns |  1.522 ns |  1.811 ns |  93.81 ns |  1.06x slower |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 1000 | 100   | 135.33 ns |  0.705 ns |  0.589 ns | 135.41 ns |  1.52x slower |   0.01x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   |  82.81 ns |  1.635 ns |  1.817 ns |  82.29 ns |  1.08x faster |   0.03x |      - |         - |          NA |
