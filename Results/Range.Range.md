## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
| Method          | Runtime  | Start | Count | Mean      | Error    | StdDev    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------- |--------- |------ |------ |----------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop         | .NET 8.0 | 0     | 100   |  33.65 ns | 0.499 ns |  0.442 ns |     baseline |         |      - |         - |          NA |
| Linq            | .NET 8.0 | 0     | 100   | 212.26 ns | 0.723 ns |  0.641 ns | 6.31x slower |   0.09x | 0.0191 |      40 B |          NA |
| LinqFaster      | .NET 8.0 | 0     | 100   | 134.25 ns | 8.429 ns | 24.852 ns | 3.25x slower |   0.15x | 0.2027 |     424 B |          NA |
| LinqFaster_SIMD | .NET 8.0 | 0     | 100   | 100.81 ns | 2.641 ns |  7.705 ns | 3.05x slower |   0.20x | 0.2027 |     424 B |          NA |
| LinqAF          | .NET 8.0 | 0     | 100   |  61.40 ns | 1.226 ns |  2.449 ns | 1.76x slower |   0.07x |      - |         - |          NA |
| StructLinq      | .NET 8.0 | 0     | 100   |  40.76 ns | 1.188 ns |  3.446 ns | 1.30x slower |   0.08x |      - |         - |          NA |
| Hyperlinq       | .NET 8.0 | 0     | 100   |  45.72 ns | 0.909 ns |  1.082 ns | 1.37x slower |   0.03x |      - |         - |          NA |
|                 |          |       |       |           |          |           |              |         |        |           |             |
| ForLoop         | .NET 9.0 | 0     | 100   |  33.66 ns | 0.382 ns |  0.484 ns |     baseline |         |      - |         - |          NA |
| Linq            | .NET 9.0 | 0     | 100   | 212.99 ns | 1.365 ns |  1.210 ns | 6.31x slower |   0.12x | 0.0191 |      40 B |          NA |
| LinqFaster      | .NET 9.0 | 0     | 100   | 113.49 ns | 2.247 ns |  2.760 ns | 3.37x slower |   0.10x | 0.2027 |     424 B |          NA |
| LinqFaster_SIMD | .NET 9.0 | 0     | 100   |  90.77 ns | 1.250 ns |  1.337 ns | 2.69x slower |   0.05x | 0.2027 |     424 B |          NA |
| LinqAF          | .NET 9.0 | 0     | 100   |  53.87 ns | 1.064 ns |  1.225 ns | 1.60x slower |   0.05x |      - |         - |          NA |
| StructLinq      | .NET 9.0 | 0     | 100   |  41.36 ns | 0.473 ns |  0.395 ns | 1.23x slower |   0.02x |      - |         - |          NA |
| Hyperlinq       | .NET 9.0 | 0     | 100   |  50.35 ns | 0.892 ns |  1.466 ns | 1.50x slower |   0.05x |      - |         - |          NA |
