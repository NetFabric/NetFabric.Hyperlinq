## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
| Method                   | Runtime  | Count | Mean        | Error     | StdDev    | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |   106.32 ns |  1.862 ns |  2.843 ns |      baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |    99.85 ns |  2.029 ns |  3.036 ns |  1.07x faster |   0.03x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   |   957.70 ns |  5.144 ns |  4.016 ns |  8.97x slower |   0.26x | 0.0496 |     104 B |          NA |
| LinqFaster               | .NET 8.0 | 100   |   727.04 ns |  9.560 ns |  7.464 ns |  6.81x slower |   0.18x | 3.0670 |    6424 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   |   968.19 ns | 11.624 ns |  9.075 ns |  9.06x slower |   0.31x | 3.0861 |    6456 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 1,054.60 ns | 12.803 ns | 10.691 ns |  9.88x slower |   0.32x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   |   248.60 ns |  3.421 ns |  2.671 ns |  2.33x slower |   0.08x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |   138.90 ns |  2.641 ns |  3.871 ns |  1.31x slower |   0.06x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |   296.81 ns |  2.602 ns |  2.173 ns |  2.78x slower |   0.09x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |    97.66 ns |  1.922 ns |  2.288 ns |  1.10x faster |   0.05x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   |   768.24 ns |  8.693 ns | 10.676 ns |  7.19x slower |   0.25x | 3.0670 |    6424 B |          NA |
|                          |          |       |             |           |           |               |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |   105.95 ns |  2.123 ns |  1.986 ns |      baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |    97.93 ns |  1.686 ns |  2.008 ns |  1.08x faster |   0.03x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   |   953.42 ns |  6.885 ns |  5.749 ns |  8.98x slower |   0.18x | 0.0496 |     104 B |          NA |
| LinqFaster               | .NET 9.0 | 100   |   720.89 ns | 10.191 ns |  7.956 ns |  6.78x slower |   0.15x | 3.0670 |    6424 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   |   930.53 ns | 15.475 ns | 14.475 ns |  8.79x slower |   0.22x | 3.0861 |    6456 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 1,071.91 ns |  4.416 ns |  3.915 ns | 10.11x slower |   0.21x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   |   236.82 ns |  3.306 ns |  3.092 ns |  2.24x slower |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |   114.49 ns |  1.005 ns |  0.891 ns |  1.08x slower |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |   292.94 ns |  2.127 ns |  1.661 ns |  2.75x slower |   0.05x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |   105.19 ns |  1.449 ns |  1.488 ns |  1.01x faster |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   |   704.00 ns |  9.847 ns |  7.688 ns |  6.62x slower |   0.14x | 3.0670 |    6424 B |          NA |
