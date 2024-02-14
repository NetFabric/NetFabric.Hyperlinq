## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
| ForLoop                  | .NET 8.0 | 100   |  48.22 ns | 0.776 ns | 0.648 ns |  48.03 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  46.26 ns | 0.921 ns | 1.024 ns |  45.80 ns | 1.04x faster |   0.02x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 218.97 ns | 4.365 ns | 9.207 ns | 213.65 ns | 4.58x slower |   0.23x | 0.0229 |      48 B |          NA |
| LinqFaster               | .NET 8.0 | 100   | 146.73 ns | 2.147 ns | 2.386 ns | 145.93 ns | 3.05x slower |   0.07x | 0.2027 |     424 B |          NA |
| LinqFaster_SIMD          | .NET 8.0 | 100   |  98.68 ns | 1.955 ns | 2.092 ns |  97.77 ns | 2.05x slower |   0.06x | 0.2027 |     424 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 255.27 ns | 2.719 ns | 2.410 ns | 254.40 ns | 5.30x slower |   0.10x | 0.2179 |     456 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 138.87 ns | 0.567 ns | 0.443 ns | 138.87 ns | 2.88x slower |   0.04x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 110.89 ns | 1.776 ns | 1.662 ns | 110.67 ns | 2.31x slower |   0.05x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  59.51 ns | 0.532 ns | 0.444 ns |  59.39 ns | 1.23x slower |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 113.43 ns | 2.136 ns | 3.627 ns | 111.64 ns | 2.36x slower |   0.08x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  46.33 ns | 0.936 ns | 1.041 ns |  45.84 ns | 1.03x faster |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 176.41 ns | 2.006 ns | 1.675 ns | 175.92 ns | 3.66x slower |   0.07x | 0.2027 |     424 B |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  46.21 ns | 0.305 ns | 0.238 ns |  46.18 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  50.81 ns | 1.045 ns | 1.803 ns |  50.30 ns | 1.09x slower |   0.04x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 211.40 ns | 3.945 ns | 8.147 ns | 207.05 ns | 4.54x slower |   0.16x | 0.0229 |      48 B |          NA |
| LinqFaster               | .NET 9.0 | 100   | 201.46 ns | 3.996 ns | 4.908 ns | 199.86 ns | 4.37x slower |   0.15x | 0.2027 |     424 B |          NA |
| LinqFaster_SIMD          | .NET 9.0 | 100   |  96.92 ns | 1.068 ns | 0.892 ns |  96.83 ns | 2.10x slower |   0.03x | 0.2027 |     424 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 327.39 ns | 3.966 ns | 3.312 ns | 326.38 ns | 7.08x slower |   0.07x | 0.2179 |     456 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 139.98 ns | 2.168 ns | 1.810 ns | 139.57 ns | 3.02x slower |   0.04x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 115.74 ns | 2.054 ns | 3.010 ns | 114.69 ns | 2.49x slower |   0.07x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  58.49 ns | 1.136 ns | 1.007 ns |  58.13 ns | 1.27x slower |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |  86.49 ns | 0.640 ns | 0.500 ns |  86.34 ns | 1.87x slower |   0.01x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  58.70 ns | 1.210 ns | 2.302 ns |  57.58 ns | 1.29x slower |   0.07x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 281.75 ns | 5.535 ns | 6.152 ns | 278.32 ns | 6.07x slower |   0.12x | 0.2027 |     424 B |          NA |
