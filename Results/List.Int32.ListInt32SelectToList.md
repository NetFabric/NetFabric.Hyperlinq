## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
| Method                       | Runtime  | Count | Mean      | Error     | StdDev    | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |--------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                      | .NET 8.0 | 100   | 320.03 ns |  5.653 ns |  7.546 ns | 317.11 ns |     baseline |         | 0.5660 |    1184 B |             |
| ForeachLoop                  | .NET 8.0 | 100   | 335.75 ns |  6.024 ns |  8.640 ns | 333.40 ns | 1.05x slower |   0.03x | 0.5660 |    1184 B |  1.00x more |
| Linq                         | .NET 8.0 | 100   | 142.83 ns |  2.860 ns |  3.719 ns | 141.65 ns | 2.24x faster |   0.07x | 0.2522 |     528 B |  2.24x less |
| LinqFaster                   | .NET 8.0 | 100   | 252.11 ns |  4.647 ns |  3.881 ns | 251.28 ns | 1.27x faster |   0.03x | 0.4358 |     912 B |  1.30x less |
| LinqFasterer                 | .NET 8.0 | 100   | 169.14 ns |  2.003 ns |  1.564 ns | 168.93 ns | 1.88x faster |   0.03x | 0.6235 |    1304 B |  1.10x more |
| LinqAF                       | .NET 8.0 | 100   | 555.17 ns |  7.771 ns |  6.067 ns | 554.59 ns | 1.74x slower |   0.02x | 0.5655 |    1184 B |  1.00x more |
| StructLinq                   | .NET 8.0 | 100   | 170.68 ns |  2.108 ns |  1.760 ns | 170.36 ns | 1.87x faster |   0.04x | 0.2484 |     520 B |  2.28x less |
| StructLinq_ValueDelegate     | .NET 8.0 | 100   | 115.63 ns |  2.019 ns |  3.693 ns | 114.38 ns | 2.78x faster |   0.11x | 0.2370 |     496 B |  2.39x less |
| Hyperlinq                    | .NET 8.0 | 100   | 194.87 ns |  2.691 ns |  2.101 ns | 194.49 ns | 1.64x faster |   0.05x | 0.2179 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate      | .NET 8.0 | 100   |  94.20 ns |  1.921 ns |  3.156 ns |  93.13 ns | 3.38x faster |   0.17x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_SIMD               | .NET 8.0 | 100   |  54.19 ns |  0.389 ns |  0.345 ns |  54.13 ns | 5.93x faster |   0.16x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 8.0 | 100   |  44.27 ns |  0.757 ns |  0.872 ns |  44.02 ns | 7.26x faster |   0.27x | 0.2180 |     456 B |  2.60x less |
| Faslinq                      | .NET 8.0 | 100   | 361.20 ns |  7.279 ns | 17.015 ns | 353.54 ns | 1.14x slower |   0.08x | 0.5660 |    1184 B |  1.00x more |
|                              |          |       |           |           |           |           |              |         |        |           |             |
| ForLoop                      | .NET 9.0 | 100   | 327.55 ns |  3.220 ns |  2.689 ns | 327.04 ns |     baseline |         | 0.5660 |    1184 B |             |
| ForeachLoop                  | .NET 9.0 | 100   | 341.81 ns |  6.733 ns |  8.269 ns | 339.48 ns | 1.05x slower |   0.03x | 0.5660 |    1184 B |  1.00x more |
| Linq                         | .NET 9.0 | 100   | 115.15 ns |  2.275 ns |  1.900 ns | 114.12 ns | 2.85x faster |   0.05x | 0.2522 |     528 B |  2.24x less |
| LinqFaster                   | .NET 9.0 | 100   | 253.80 ns |  3.202 ns |  2.995 ns | 252.53 ns | 1.29x faster |   0.02x | 0.4358 |     912 B |  1.30x less |
| LinqFasterer                 | .NET 9.0 | 100   | 248.21 ns |  3.602 ns |  3.193 ns | 247.48 ns | 1.32x faster |   0.02x | 0.6232 |    1304 B |  1.10x more |
| LinqAF                       | .NET 9.0 | 100   | 586.68 ns | 12.074 ns | 34.642 ns | 568.62 ns | 1.83x slower |   0.15x | 0.5655 |    1184 B |  1.00x more |
| StructLinq                   | .NET 9.0 | 100   | 190.46 ns |  3.831 ns |  7.652 ns | 187.11 ns | 1.72x faster |   0.06x | 0.2484 |     520 B |  2.28x less |
| StructLinq_ValueDelegate     | .NET 9.0 | 100   | 146.11 ns |  1.523 ns |  1.189 ns | 146.05 ns | 2.24x faster |   0.03x | 0.2370 |     496 B |  2.39x less |
| Hyperlinq                    | .NET 9.0 | 100   | 174.59 ns |  3.436 ns |  7.322 ns | 171.00 ns | 1.84x faster |   0.10x | 0.2179 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate      | .NET 9.0 | 100   |  93.29 ns |  1.205 ns |  1.183 ns |  93.01 ns | 3.51x faster |   0.06x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_SIMD               | .NET 9.0 | 100   |  56.86 ns |  1.219 ns |  3.458 ns |  55.66 ns | 5.45x faster |   0.33x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 9.0 | 100   |  43.23 ns |  0.783 ns |  0.611 ns |  43.15 ns | 7.57x faster |   0.10x | 0.2180 |     456 B |  2.60x less |
| Faslinq                      | .NET 9.0 | 100   | 330.72 ns |  4.222 ns |  3.525 ns | 329.81 ns | 1.01x slower |   0.01x | 0.5660 |    1184 B |  1.00x more |
