## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
| Method                       | Runtime  | Start | Count | Mean      | Error    | StdDev   | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |--------- |------ |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                      | .NET 8.0 | 0     | 100   | 298.29 ns | 3.405 ns | 2.844 ns | 297.99 ns |     baseline |         | 0.5660 |    1184 B |             |
| Linq                         | .NET 8.0 | 0     | 100   | 122.14 ns | 2.483 ns | 2.760 ns | 122.36 ns | 2.46x faster |   0.07x | 0.2601 |     544 B |  2.18x less |
| LinqFaster                   | .NET 8.0 | 0     | 100   | 197.52 ns | 3.387 ns | 5.752 ns | 195.16 ns | 1.49x faster |   0.04x | 0.6232 |    1304 B |  1.10x more |
| LinqAF                       | .NET 8.0 | 0     | 100   | 347.59 ns | 2.883 ns | 2.250 ns | 347.75 ns | 1.17x slower |   0.01x | 0.5660 |    1184 B |  1.00x more |
| StructLinq                   | .NET 8.0 | 0     | 100   | 177.54 ns | 2.974 ns | 3.055 ns | 177.47 ns | 1.68x faster |   0.04x | 0.2449 |     512 B |  2.31x less |
| StructLinq_ValueDelegate     | .NET 8.0 | 0     | 100   |  94.08 ns | 1.828 ns | 1.956 ns |  94.15 ns | 3.17x faster |   0.08x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq                    | .NET 8.0 | 0     | 100   | 154.60 ns | 2.198 ns | 1.716 ns | 154.61 ns | 1.93x faster |   0.03x | 0.2179 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate      | .NET 8.0 | 0     | 100   | 127.12 ns | 1.392 ns | 1.162 ns | 126.77 ns | 2.35x faster |   0.03x | 0.2179 |     456 B |  2.60x less |
| Hyperlinq_SIMD               | .NET 8.0 | 0     | 100   |  85.01 ns | 1.318 ns | 1.029 ns |  84.59 ns | 3.51x faster |   0.06x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 8.0 | 0     | 100   |  66.78 ns | 1.170 ns | 1.480 ns |  66.83 ns | 4.48x faster |   0.16x | 0.2180 |     456 B |  2.60x less |
|                              |          |       |       |           |          |          |           |              |         |        |           |             |
| ForLoop                      | .NET 9.0 | 0     | 100   | 296.23 ns | 4.461 ns | 3.725 ns | 295.43 ns |     baseline |         | 0.5660 |    1184 B |             |
| Linq                         | .NET 9.0 | 0     | 100   | 143.48 ns | 1.644 ns | 1.284 ns | 142.82 ns | 2.06x faster |   0.03x | 0.2601 |     544 B |  2.18x less |
| LinqFaster                   | .NET 9.0 | 0     | 100   | 281.22 ns | 5.302 ns | 6.106 ns | 279.60 ns | 1.05x faster |   0.03x | 0.6232 |    1304 B |  1.10x more |
| LinqAF                       | .NET 9.0 | 0     | 100   | 408.86 ns | 7.341 ns | 5.731 ns | 406.78 ns | 1.38x slower |   0.02x | 0.5660 |    1184 B |  1.00x more |
| StructLinq                   | .NET 9.0 | 0     | 100   | 119.84 ns | 2.193 ns | 3.414 ns | 118.67 ns | 2.44x faster |   0.10x | 0.2449 |     512 B |  2.31x less |
| StructLinq_ValueDelegate     | .NET 9.0 | 0     | 100   |  78.28 ns | 1.329 ns | 2.497 ns |  77.77 ns | 3.75x faster |   0.15x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq                    | .NET 9.0 | 0     | 100   | 177.73 ns | 3.583 ns | 4.783 ns | 176.23 ns | 1.65x faster |   0.06x | 0.2179 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate      | .NET 9.0 | 0     | 100   | 133.62 ns | 2.510 ns | 6.250 ns | 131.47 ns | 2.15x faster |   0.14x | 0.2179 |     456 B |  2.60x less |
| Hyperlinq_SIMD               | .NET 9.0 | 0     | 100   |  85.82 ns | 1.122 ns | 1.050 ns |  85.81 ns | 3.45x faster |   0.06x | 0.2179 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 9.0 | 0     | 100   |  65.78 ns | 1.229 ns | 0.960 ns |  66.15 ns | 4.50x faster |   0.10x | 0.2180 |     456 B |  2.60x less |
