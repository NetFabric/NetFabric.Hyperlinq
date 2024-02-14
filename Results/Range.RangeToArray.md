## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
| Method          | Runtime  | Start | Count | Mean      | Error    | StdDev   | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------- |--------- |------ |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop         | .NET 8.0 | 0     | 100   |  80.97 ns | 1.616 ns | 1.350 ns |  80.42 ns |     baseline |         | 0.2027 |     424 B |             |
| Linq            | .NET 8.0 | 0     | 100   |  44.56 ns | 0.951 ns | 2.279 ns |  43.73 ns | 1.81x faster |   0.08x | 0.2218 |     464 B |  1.09x more |
| LinqFaster      | .NET 8.0 | 0     | 100   |  63.69 ns | 1.245 ns | 1.619 ns |  63.34 ns | 1.27x faster |   0.04x | 0.2027 |     424 B |  1.00x more |
| LinqFaster_SIMD | .NET 8.0 | 0     | 100   |  39.18 ns | 0.392 ns | 0.328 ns |  39.22 ns | 2.07x faster |   0.03x | 0.2027 |     424 B |  1.00x more |
| LinqAF          | .NET 8.0 | 0     | 100   | 126.25 ns | 1.501 ns | 1.253 ns | 125.82 ns | 1.56x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
| StructLinq      | .NET 8.0 | 0     | 100   |  66.52 ns | 1.326 ns | 1.419 ns |  65.93 ns | 1.22x faster |   0.03x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq       | .NET 8.0 | 0     | 100   |  48.99 ns | 0.926 ns | 1.205 ns |  48.61 ns | 1.65x faster |   0.05x | 0.2027 |     424 B |  1.00x more |
|                 |          |       |       |           |          |          |           |              |         |        |           |             |
| ForLoop         | .NET 9.0 | 0     | 100   |  71.75 ns | 0.794 ns | 0.620 ns |  71.70 ns |     baseline |         | 0.2027 |     424 B |             |
| Linq            | .NET 9.0 | 0     | 100   |  44.25 ns | 0.944 ns | 2.568 ns |  43.14 ns | 1.59x faster |   0.11x | 0.2218 |     464 B |  1.09x more |
| LinqFaster      | .NET 9.0 | 0     | 100   |  64.74 ns | 0.926 ns | 0.821 ns |  64.50 ns | 1.11x faster |   0.02x | 0.2027 |     424 B |  1.00x more |
| LinqFaster_SIMD | .NET 9.0 | 0     | 100   |  49.94 ns | 1.061 ns | 2.796 ns |  48.91 ns | 1.44x faster |   0.07x | 0.2027 |     424 B |  1.00x more |
| LinqAF          | .NET 9.0 | 0     | 100   | 101.93 ns | 2.020 ns | 4.917 ns |  99.72 ns | 1.43x slower |   0.06x | 0.2027 |     424 B |  1.00x more |
| StructLinq      | .NET 9.0 | 0     | 100   |  66.09 ns | 1.019 ns | 1.214 ns |  66.05 ns | 1.08x faster |   0.02x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq       | .NET 9.0 | 0     | 100   |  47.24 ns | 0.826 ns | 1.015 ns |  46.77 ns | 1.52x faster |   0.02x | 0.2027 |     424 B |  1.00x more |
