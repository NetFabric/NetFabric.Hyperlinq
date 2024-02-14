## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
| Method                   | Runtime  | Count | Mean      | Error    | StdDev   | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  41.67 ns | 0.872 ns | 1.457 ns |  41.28 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  41.07 ns | 0.863 ns | 1.642 ns |  40.47 ns | 1.01x faster |   0.05x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   |  12.03 ns | 0.332 ns | 0.965 ns |  11.55 ns | 3.50x faster |   0.30x |      - |         - |          NA |
| LinqFaster               | .NET 8.0 | 100   |  12.42 ns | 0.286 ns | 0.811 ns |  12.10 ns | 3.31x faster |   0.21x |      - |         - |          NA |
| LinqFaster_SIMD          | .NET 8.0 | 100   |  19.12 ns | 0.359 ns | 0.280 ns |  19.00 ns | 2.17x faster |   0.07x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   |  13.62 ns | 0.372 ns | 1.067 ns |  13.08 ns | 3.08x faster |   0.25x |      - |         - |          NA |
| LinqAF                   | .NET 8.0 | 100   |  15.04 ns | 0.326 ns | 0.952 ns |  14.72 ns | 2.75x faster |   0.18x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   |  75.90 ns | 1.750 ns | 5.161 ns |  74.07 ns | 1.82x slower |   0.15x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  50.27 ns | 1.030 ns | 2.283 ns |  49.87 ns | 1.21x slower |   0.07x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |  18.76 ns | 0.231 ns | 0.181 ns |  18.71 ns | 2.21x faster |   0.07x | 0.0153 |      32 B |          NA |
| Hyperlinq_SIMD           | .NET 8.0 | 100   |  12.39 ns | 0.279 ns | 0.298 ns |  12.27 ns | 3.38x faster |   0.12x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   |  77.18 ns | 1.511 ns | 3.411 ns |  75.89 ns | 1.87x slower |   0.12x | 0.0305 |      64 B |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  41.49 ns | 0.863 ns | 1.027 ns |  41.43 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  42.81 ns | 0.888 ns | 0.987 ns |  42.58 ns | 1.03x slower |   0.04x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   |  12.36 ns | 0.280 ns | 0.520 ns |  12.13 ns | 3.36x faster |   0.14x |      - |         - |          NA |
| LinqFaster               | .NET 9.0 | 100   |  14.36 ns | 0.309 ns | 0.331 ns |  14.29 ns | 2.90x faster |   0.11x |      - |         - |          NA |
| LinqFaster_SIMD          | .NET 9.0 | 100   |  20.36 ns | 0.403 ns | 0.357 ns |  20.21 ns | 2.05x faster |   0.07x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   |  15.96 ns | 0.127 ns | 0.099 ns |  15.94 ns | 2.61x faster |   0.08x |      - |         - |          NA |
| LinqAF                   | .NET 9.0 | 100   |  15.67 ns | 0.149 ns | 0.117 ns |  15.63 ns | 2.66x faster |   0.09x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   |  71.04 ns | 1.409 ns | 1.100 ns |  70.77 ns | 1.71x slower |   0.05x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  67.83 ns | 1.097 ns | 0.973 ns |  67.54 ns | 1.63x slower |   0.06x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |  17.88 ns | 0.112 ns | 0.093 ns |  17.89 ns | 2.33x faster |   0.07x | 0.0153 |      32 B |          NA |
| Hyperlinq_SIMD           | .NET 9.0 | 100   |  18.34 ns | 0.394 ns | 0.454 ns |  18.18 ns | 2.27x faster |   0.08x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 115.45 ns | 1.732 ns | 1.535 ns | 115.28 ns | 2.77x slower |   0.09x | 0.0305 |      64 B |          NA |
