## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
| Method     | Runtime  | Start | Count | Mean      | Error    | StdDev   | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------- |--------- |------ |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop    | .NET 8.0 | 0     | 100   | 272.11 ns | 2.301 ns | 2.040 ns | 271.89 ns |     baseline |         | 0.5660 |    1184 B |             |
| Linq       | .NET 8.0 | 0     | 100   |  50.18 ns | 1.093 ns | 3.119 ns |  48.71 ns | 5.30x faster |   0.29x | 0.2372 |     496 B |  2.39x less |
| LinqFaster | .NET 8.0 | 0     | 100   | 111.26 ns | 1.098 ns | 0.973 ns | 110.80 ns | 2.45x faster |   0.02x | 0.4206 |     880 B |  1.35x less |
| LinqAF     | .NET 8.0 | 0     | 100   | 202.98 ns | 4.032 ns | 4.482 ns | 201.01 ns | 1.34x faster |   0.03x | 0.2179 |     456 B |  2.60x less |
| StructLinq | .NET 8.0 | 0     | 100   |  72.08 ns | 1.503 ns | 2.552 ns |  70.90 ns | 3.78x faster |   0.12x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq  | .NET 8.0 | 0     | 100   |  55.20 ns | 1.142 ns | 1.778 ns |  54.31 ns | 4.91x faster |   0.21x | 0.2180 |     456 B |  2.60x less |
|            |          |       |       |           |          |          |           |              |         |        |           |             |
| ForLoop    | .NET 9.0 | 0     | 100   | 279.63 ns | 5.570 ns | 6.631 ns | 277.23 ns |     baseline |         | 0.5660 |    1184 B |             |
| Linq       | .NET 9.0 | 0     | 100   |  46.60 ns | 0.630 ns | 0.674 ns |  46.36 ns | 6.02x faster |   0.17x | 0.2372 |     496 B |  2.39x less |
| LinqFaster | .NET 9.0 | 0     | 100   | 116.30 ns | 2.360 ns | 3.943 ns | 115.03 ns | 2.37x faster |   0.11x | 0.4206 |     880 B |  1.35x less |
| LinqAF     | .NET 9.0 | 0     | 100   | 217.15 ns | 3.603 ns | 8.422 ns | 213.25 ns | 1.29x faster |   0.04x | 0.2179 |     456 B |  2.60x less |
| StructLinq | .NET 9.0 | 0     | 100   |  69.91 ns | 1.024 ns | 0.799 ns |  69.89 ns | 4.03x faster |   0.13x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq  | .NET 9.0 | 0     | 100   |  54.70 ns | 1.136 ns | 1.735 ns |  54.02 ns | 5.13x faster |   0.22x | 0.2180 |     456 B |  2.60x less |
