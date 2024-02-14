## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
| Method                   | Runtime  | Start | Count | Mean      | Error    | StdDev   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 0     | 100   |  43.51 ns | 0.312 ns | 0.243 ns |     baseline |         |      - |         - |          NA |
| Linq                     | .NET 8.0 | 0     | 100   | 240.89 ns | 1.955 ns | 1.526 ns | 5.54x slower |   0.04x | 0.0420 |      88 B |          NA |
| LinqFaster               | .NET 8.0 | 0     | 100   | 269.97 ns | 5.288 ns | 4.688 ns | 6.20x slower |   0.13x | 0.4053 |     848 B |          NA |
| LinqFaster_SIMD          | .NET 8.0 | 0     | 100   | 136.03 ns | 2.499 ns | 2.878 ns | 3.14x slower |   0.09x | 0.4053 |     848 B |          NA |
| LinqAF                   | .NET 8.0 | 0     | 100   | 115.95 ns | 2.235 ns | 2.484 ns | 2.67x slower |   0.07x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 0     | 100   |  89.15 ns | 1.824 ns | 3.146 ns | 2.09x slower |   0.09x | 0.0114 |      24 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 0     | 100   |  47.27 ns | 0.964 ns | 0.902 ns | 1.09x slower |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 0     | 100   |  64.18 ns | 1.266 ns | 1.057 ns | 1.48x slower |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 0     | 100   |  49.45 ns | 0.593 ns | 0.463 ns | 1.14x slower |   0.01x |      - |         - |          NA |
|                          |          |       |       |           |          |          |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 0     | 100   |  45.69 ns | 0.941 ns | 0.924 ns |     baseline |         |      - |         - |          NA |
| Linq                     | .NET 9.0 | 0     | 100   | 204.61 ns | 4.059 ns | 6.669 ns | 4.47x slower |   0.13x | 0.0420 |      88 B |          NA |
| LinqFaster               | .NET 9.0 | 0     | 100   | 237.25 ns | 1.432 ns | 1.270 ns | 5.19x slower |   0.12x | 0.4053 |     848 B |          NA |
| LinqFaster_SIMD          | .NET 9.0 | 0     | 100   | 140.64 ns | 2.307 ns | 1.926 ns | 3.07x slower |   0.08x | 0.4053 |     848 B |          NA |
| LinqAF                   | .NET 9.0 | 0     | 100   | 133.40 ns | 0.647 ns | 0.505 ns | 2.91x slower |   0.07x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 0     | 100   |  84.80 ns | 0.762 ns | 0.748 ns | 1.86x slower |   0.04x | 0.0114 |      24 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 0     | 100   |  58.86 ns | 1.118 ns | 0.933 ns | 1.29x slower |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 0     | 100   | 111.64 ns | 0.728 ns | 0.809 ns | 2.45x slower |   0.05x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 0     | 100   |  84.03 ns | 0.627 ns | 0.523 ns | 1.84x slower |   0.04x |      - |         - |          NA |
