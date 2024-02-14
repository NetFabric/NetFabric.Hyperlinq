## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
| Method                   | Runtime  | Count | Mean      | Error    | StdDev   | Median    | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|----------:|--------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  84.57 ns | 1.731 ns | 2.189 ns |  83.47 ns |      baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  72.50 ns | 0.357 ns | 0.279 ns |  72.51 ns |  1.16x faster |   0.03x |      - |         - |          NA |
| List_Exists              | .NET 8.0 | 100   | 120.11 ns | 2.419 ns | 5.310 ns | 117.58 ns |  1.44x slower |   0.08x | 0.0305 |      64 B |          NA |
| Linq                     | .NET 8.0 | 100   |  12.93 ns | 0.275 ns | 0.270 ns |  12.85 ns |  6.55x faster |   0.17x |      - |         - |          NA |
| LinqFaster               | .NET 8.0 | 100   |  13.63 ns | 0.217 ns | 0.181 ns |  13.56 ns |  6.19x faster |   0.19x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   |  44.22 ns | 0.656 ns | 0.729 ns |  44.37 ns |  1.92x faster |   0.06x | 0.2027 |     424 B |          NA |
| LinqAF                   | .NET 8.0 | 100   |  13.80 ns | 0.268 ns | 0.287 ns |  13.71 ns |  6.15x faster |   0.24x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   |  57.09 ns | 0.257 ns | 0.214 ns |  57.03 ns |  1.48x faster |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  59.65 ns | 0.426 ns | 0.333 ns |  59.58 ns |  1.41x faster |   0.04x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |  19.08 ns | 0.376 ns | 0.476 ns |  18.88 ns |  4.43x faster |   0.13x | 0.0153 |      32 B |          NA |
| Hyperlinq_SIMD           | .NET 8.0 | 100   |  13.24 ns | 0.140 ns | 0.109 ns |  13.19 ns |  6.36x faster |   0.18x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 142.14 ns | 1.944 ns | 2.239 ns | 141.09 ns |  1.68x slower |   0.05x | 0.0305 |      64 B |          NA |
|                          |          |       |           |          |          |           |               |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   | 136.66 ns | 2.748 ns | 5.024 ns | 134.03 ns |      baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  72.29 ns | 0.528 ns | 0.441 ns |  72.22 ns |  1.91x faster |   0.07x |      - |         - |          NA |
| List_Exists              | .NET 9.0 | 100   | 106.27 ns | 2.126 ns | 2.530 ns | 105.49 ns |  1.29x faster |   0.05x | 0.0305 |      64 B |          NA |
| Linq                     | .NET 9.0 | 100   |  12.20 ns | 0.117 ns | 0.098 ns |  12.15 ns | 11.35x faster |   0.49x |      - |         - |          NA |
| LinqFaster               | .NET 9.0 | 100   |  13.38 ns | 0.148 ns | 0.116 ns |  13.34 ns | 10.38x faster |   0.47x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   |  47.66 ns | 0.769 ns | 0.682 ns |  47.43 ns |  2.90x faster |   0.12x | 0.2027 |     424 B |          NA |
| LinqAF                   | .NET 9.0 | 100   |  13.85 ns | 0.117 ns | 0.104 ns |  13.82 ns |  9.97x faster |   0.39x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   |  70.49 ns | 0.908 ns | 0.758 ns |  70.10 ns |  1.96x faster |   0.08x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 112.94 ns | 2.054 ns | 3.011 ns | 111.55 ns |  1.22x faster |   0.06x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |  18.98 ns | 0.413 ns | 0.492 ns |  18.80 ns |  7.21x faster |   0.35x | 0.0153 |      32 B |          NA |
| Hyperlinq_SIMD           | .NET 9.0 | 100   |  18.29 ns | 0.309 ns | 0.390 ns |  18.17 ns |  7.48x faster |   0.31x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 120.02 ns | 2.410 ns | 2.679 ns | 118.91 ns |  1.14x faster |   0.03x | 0.0305 |      64 B |          NA |
