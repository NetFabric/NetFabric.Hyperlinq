## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
| ForLoop                      | .NET 8.0 | 0     | 100   |  85.88 ns | 1.602 ns | 3.199 ns |  84.76 ns |     baseline |         | 0.2027 |     424 B |             |
| Linq                         | .NET 8.0 | 0     | 100   | 114.10 ns | 2.340 ns | 2.786 ns | 112.84 ns | 1.33x slower |   0.07x | 0.2449 |     512 B |  1.21x more |
| LinqFaster                   | .NET 8.0 | 0     | 100   | 151.12 ns | 2.996 ns | 5.983 ns | 150.29 ns | 1.76x slower |   0.10x | 0.4053 |     848 B |  2.00x more |
| LinqFaster_SIMD              | .NET 8.0 | 0     | 100   |  92.88 ns | 1.593 ns | 2.015 ns |  92.20 ns | 1.08x slower |   0.06x | 0.4054 |     848 B |  2.00x more |
| LinqAF                       | .NET 8.0 | 0     | 100   | 300.76 ns | 3.135 ns | 2.617 ns | 300.29 ns | 3.51x slower |   0.13x | 0.7534 |    1576 B |  3.72x more |
| StructLinq                   | .NET 8.0 | 0     | 100   | 109.73 ns | 2.237 ns | 4.956 ns | 107.81 ns | 1.28x slower |   0.07x | 0.2295 |     480 B |  1.13x more |
| StructLinq_ValueDelegate     | .NET 8.0 | 0     | 100   |  72.34 ns | 0.772 ns | 0.644 ns |  72.25 ns | 1.19x faster |   0.04x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq                    | .NET 8.0 | 0     | 100   | 145.64 ns | 1.721 ns | 1.343 ns | 145.35 ns | 1.70x slower |   0.06x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_ValueDelegate      | .NET 8.0 | 0     | 100   | 115.62 ns | 1.399 ns | 1.769 ns | 114.93 ns | 1.34x slower |   0.06x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_SIMD               | .NET 8.0 | 0     | 100   |  80.53 ns | 0.698 ns | 0.545 ns |  80.42 ns | 1.07x faster |   0.04x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_ValueDelegate_SIMD | .NET 8.0 | 0     | 100   |  58.76 ns | 0.849 ns | 0.794 ns |  58.40 ns | 1.46x faster |   0.05x | 0.2027 |     424 B |  1.00x more |
|                              |          |       |       |           |          |          |           |              |         |        |           |             |
| ForLoop                      | .NET 9.0 | 0     | 100   |  84.73 ns | 1.237 ns | 1.424 ns |  84.35 ns |     baseline |         | 0.2027 |     424 B |             |
| Linq                         | .NET 9.0 | 0     | 100   | 115.62 ns | 0.983 ns | 0.821 ns | 115.21 ns | 1.36x slower |   0.03x | 0.2449 |     512 B |  1.21x more |
| LinqFaster                   | .NET 9.0 | 0     | 100   | 146.78 ns | 2.333 ns | 1.948 ns | 146.83 ns | 1.73x slower |   0.04x | 0.4053 |     848 B |  2.00x more |
| LinqFaster_SIMD              | .NET 9.0 | 0     | 100   | 102.85 ns | 1.876 ns | 3.431 ns | 101.30 ns | 1.21x slower |   0.04x | 0.4054 |     848 B |  2.00x more |
| LinqAF                       | .NET 9.0 | 0     | 100   | 423.90 ns | 3.498 ns | 3.435 ns | 423.45 ns | 5.01x slower |   0.09x | 0.7534 |    1576 B |  3.72x more |
| StructLinq                   | .NET 9.0 | 0     | 100   |  99.71 ns | 1.763 ns | 1.377 ns |  99.52 ns | 1.18x slower |   0.03x | 0.2295 |     480 B |  1.13x more |
| StructLinq_ValueDelegate     | .NET 9.0 | 0     | 100   |  72.06 ns | 1.354 ns | 1.713 ns |  71.57 ns | 1.17x faster |   0.03x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq                    | .NET 9.0 | 0     | 100   | 169.67 ns | 2.870 ns | 3.732 ns | 168.13 ns | 2.01x slower |   0.05x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_ValueDelegate      | .NET 9.0 | 0     | 100   | 120.33 ns | 2.399 ns | 2.356 ns | 119.68 ns | 1.42x slower |   0.04x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_SIMD               | .NET 9.0 | 0     | 100   |  80.69 ns | 1.386 ns | 1.850 ns |  79.99 ns | 1.05x faster |   0.03x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_ValueDelegate_SIMD | .NET 9.0 | 0     | 100   |  57.69 ns | 0.854 ns | 0.713 ns |  57.45 ns | 1.47x faster |   0.03x | 0.2027 |     424 B |  1.00x more |
