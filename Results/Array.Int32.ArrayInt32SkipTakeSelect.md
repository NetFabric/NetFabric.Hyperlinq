## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
| Method                   | Runtime  | Skip | Count | Mean      | Error     | StdDev    | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 1000 | 100   |  57.16 ns |  1.030 ns |  0.913 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 8.0 | 1000 | 100   | 576.83 ns |  9.565 ns |  7.467 ns | 10.08x slower |   0.20x | 0.0725 |     152 B |          NA |
| LinqFaster               | .NET 8.0 | 1000 | 100   | 259.46 ns |  4.175 ns |  3.259 ns |  4.53x slower |   0.10x | 0.6080 |    1272 B |          NA |
| LinqFasterer             | .NET 8.0 | 1000 | 100   | 401.93 ns |  5.437 ns |  4.245 ns |  7.02x slower |   0.11x | 0.4206 |     880 B |          NA |
| LinqAF                   | .NET 8.0 | 1000 | 100   | 916.62 ns |  9.007 ns |  7.032 ns | 16.02x slower |   0.32x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 1000 | 100   | 112.90 ns |  1.213 ns |  1.013 ns |  1.97x slower |   0.04x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   |  61.64 ns |  0.877 ns |  0.777 ns |  1.08x slower |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 1000 | 100   | 139.18 ns |  1.633 ns |  1.364 ns |  2.43x slower |   0.04x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   |  51.02 ns |  1.023 ns |  0.957 ns |  1.12x faster |   0.03x |      - |         - |          NA |
|                          |          |      |       |           |           |           |               |         |        |           |             |
| ForLoop                  | .NET 9.0 | 1000 | 100   |  57.64 ns |  0.695 ns |  0.542 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 9.0 | 1000 | 100   | 640.65 ns | 12.464 ns | 11.049 ns | 11.11x slower |   0.25x | 0.0725 |     152 B |          NA |
| LinqFaster               | .NET 9.0 | 1000 | 100   | 268.85 ns |  3.255 ns |  2.885 ns |  4.65x slower |   0.05x | 0.6080 |    1272 B |          NA |
| LinqFasterer             | .NET 9.0 | 1000 | 100   | 374.90 ns |  7.531 ns | 16.049 ns |  6.41x slower |   0.30x | 0.4206 |     880 B |          NA |
| LinqAF                   | .NET 9.0 | 1000 | 100   | 793.30 ns | 11.728 ns | 14.403 ns | 13.70x slower |   0.15x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 1000 | 100   | 101.60 ns |  1.486 ns |  1.652 ns |  1.76x slower |   0.04x | 0.0459 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   |  61.70 ns |  0.519 ns |  0.461 ns |  1.07x slower |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 1000 | 100   |  70.75 ns |  0.420 ns |  0.372 ns |  1.23x slower |   0.01x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   |  62.02 ns |  0.409 ns |  0.341 ns |  1.08x slower |   0.01x |      - |         - |          NA |
