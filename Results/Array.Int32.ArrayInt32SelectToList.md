## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
| Method                       | Runtime  | Count | Mean      | Error    | StdDev    | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |--------- |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                      | .NET 8.0 | 100   | 276.25 ns | 5.372 ns |  9.409 ns | 272.43 ns |     baseline |         | 0.5660 |    1184 B |             |
| ForeachLoop                  | .NET 8.0 | 100   | 272.02 ns | 2.804 ns |  2.342 ns | 271.20 ns | 1.02x faster |   0.04x | 0.5660 |    1184 B |  1.00x more |
| Linq                         | .NET 8.0 | 100   | 117.38 ns | 0.929 ns |  0.775 ns | 117.39 ns | 2.37x faster |   0.10x | 0.2408 |     504 B |  2.35x less |
| LinqFaster                   | .NET 8.0 | 100   | 130.32 ns | 1.711 ns |  1.428 ns | 129.73 ns | 2.14x faster |   0.09x | 0.4206 |     880 B |  1.35x less |
| LinqFaster_SIMD              | .NET 8.0 | 100   | 104.70 ns | 1.056 ns |  0.882 ns | 104.57 ns | 2.66x faster |   0.10x | 0.4206 |     880 B |  1.35x less |
| LinqFasterer                 | .NET 8.0 | 100   | 136.37 ns | 2.799 ns |  2.995 ns | 135.51 ns | 2.03x faster |   0.08x | 0.4206 |     880 B |  1.35x less |
| LinqAF                       | .NET 8.0 | 100   | 394.83 ns | 7.249 ns | 11.910 ns | 389.77 ns | 1.43x slower |   0.06x | 0.5660 |    1184 B |  1.00x more |
| StructLinq                   | .NET 8.0 | 100   | 152.47 ns | 3.025 ns |  3.934 ns | 151.02 ns | 1.83x faster |   0.09x | 0.2484 |     520 B |  2.28x less |
| StructLinq_ValueDelegate     | .NET 8.0 | 100   | 117.55 ns | 2.350 ns |  3.056 ns | 116.31 ns | 2.37x faster |   0.12x | 0.2371 |     496 B |  2.39x less |
| Hyperlinq                    | .NET 8.0 | 100   | 200.74 ns | 4.075 ns |  9.114 ns | 195.68 ns | 1.37x faster |   0.07x | 0.2179 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate      | .NET 8.0 | 100   |  91.69 ns | 0.947 ns |  0.739 ns |  91.68 ns | 3.05x faster |   0.12x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_SIMD               | .NET 8.0 | 100   |  56.66 ns | 1.170 ns |  2.934 ns |  55.46 ns | 4.84x faster |   0.33x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 8.0 | 100   |  45.14 ns | 0.948 ns |  1.266 ns |  45.12 ns | 6.18x faster |   0.30x | 0.2180 |     456 B |  2.60x less |
| Faslinq                      | .NET 8.0 | 100   | 238.67 ns | 0.873 ns |  0.729 ns | 238.58 ns | 1.17x faster |   0.05x | 0.4206 |     880 B |  1.35x less |
|                              |          |       |           |          |           |           |              |         |        |           |             |
| ForLoop                      | .NET 9.0 | 100   | 274.45 ns | 2.055 ns |  1.605 ns | 274.94 ns |     baseline |         | 0.5660 |    1184 B |             |
| ForeachLoop                  | .NET 9.0 | 100   | 282.18 ns | 3.159 ns |  2.800 ns | 281.38 ns | 1.03x slower |   0.01x | 0.5660 |    1184 B |  1.00x more |
| Linq                         | .NET 9.0 | 100   | 131.64 ns | 2.012 ns |  1.570 ns | 131.48 ns | 2.09x faster |   0.02x | 0.2408 |     504 B |  2.35x less |
| LinqFaster                   | .NET 9.0 | 100   | 234.25 ns | 4.379 ns | 11.989 ns | 229.30 ns | 1.15x faster |   0.06x | 0.4206 |     880 B |  1.35x less |
| LinqFaster_SIMD              | .NET 9.0 | 100   | 114.74 ns | 2.701 ns |  7.880 ns | 111.19 ns | 2.34x faster |   0.16x | 0.4207 |     880 B |  1.35x less |
| LinqFasterer                 | .NET 9.0 | 100   | 204.62 ns | 2.597 ns |  2.887 ns | 204.47 ns | 1.34x faster |   0.02x | 0.4206 |     880 B |  1.35x less |
| LinqAF                       | .NET 9.0 | 100   | 420.92 ns | 8.372 ns |  8.597 ns | 417.77 ns | 1.54x slower |   0.04x | 0.5660 |    1184 B |  1.00x more |
| StructLinq                   | .NET 9.0 | 100   | 208.60 ns | 3.102 ns |  2.422 ns | 207.64 ns | 1.32x faster |   0.01x | 0.2484 |     520 B |  2.28x less |
| StructLinq_ValueDelegate     | .NET 9.0 | 100   | 147.04 ns | 1.581 ns |  1.999 ns | 146.77 ns | 1.86x faster |   0.03x | 0.2370 |     496 B |  2.39x less |
| Hyperlinq                    | .NET 9.0 | 100   | 173.66 ns | 2.118 ns |  2.522 ns | 173.13 ns | 1.57x faster |   0.02x | 0.2179 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate      | .NET 9.0 | 100   |  91.44 ns | 1.691 ns |  1.736 ns |  91.17 ns | 2.99x faster |   0.08x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_SIMD               | .NET 9.0 | 100   |  56.77 ns | 0.997 ns |  0.884 ns |  57.01 ns | 4.85x faster |   0.09x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 9.0 | 100   |  43.65 ns | 0.931 ns |  1.211 ns |  43.49 ns | 6.19x faster |   0.14x | 0.2180 |     456 B |  2.60x less |
| Faslinq                      | .NET 9.0 | 100   | 185.87 ns | 3.785 ns |  8.922 ns | 182.10 ns | 1.49x faster |   0.05x | 0.4206 |     880 B |  1.35x less |
