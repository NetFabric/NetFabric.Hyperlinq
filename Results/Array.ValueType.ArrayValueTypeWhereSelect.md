## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
| Method                   | Runtime  | Count | Mean        | Error     | StdDev    | Median      | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |   109.81 ns |  2.168 ns |  2.129 ns |   108.97 ns |      baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |   110.63 ns |  2.050 ns |  1.817 ns |   110.05 ns |  1.01x slower |   0.02x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   |   668.47 ns |  3.593 ns |  3.001 ns |   668.03 ns |  6.07x slower |   0.14x | 0.1030 |     216 B |          NA |
| LinqFaster               | .NET 8.0 | 100   |   848.49 ns | 16.136 ns | 17.266 ns |   842.61 ns |  7.73x slower |   0.16x | 4.7274 |    9904 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 1,642.80 ns | 32.870 ns | 85.434 ns | 1,598.31 ns | 15.00x slower |   0.84x | 6.0234 |   12624 B |          NA |
| LinqAF                   | .NET 8.0 | 100   |   303.14 ns |  2.775 ns |  2.460 ns |   302.51 ns |  2.76x slower |   0.06x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   |   365.47 ns |  7.238 ns |  8.335 ns |   363.79 ns |  3.33x slower |   0.11x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |   104.76 ns |  1.958 ns |  2.331 ns |   103.78 ns |  1.05x faster |   0.04x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |   414.98 ns |  3.637 ns |  3.572 ns |   414.46 ns |  3.78x slower |   0.08x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |   114.96 ns |  2.163 ns |  1.806 ns |   114.24 ns |  1.04x slower |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   |   670.41 ns | 10.931 ns | 16.693 ns |   664.61 ns |  6.15x slower |   0.25x | 3.0670 |    6424 B |          NA |
|                          |          |       |             |           |           |             |               |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |   109.93 ns |  1.009 ns |  0.843 ns |   109.71 ns |      baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |    84.84 ns |  1.685 ns |  1.407 ns |    84.32 ns |  1.30x faster |   0.03x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   |   652.22 ns | 10.848 ns | 12.914 ns |   647.89 ns |  5.97x slower |   0.16x | 0.1030 |     216 B |          NA |
| LinqFaster               | .NET 9.0 | 100   |   877.09 ns |  9.785 ns |  8.171 ns |   874.34 ns |  7.98x slower |   0.11x | 4.7274 |    9904 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 1,552.01 ns | 29.516 ns | 36.248 ns | 1,539.66 ns | 14.09x slower |   0.27x | 6.0234 |   12624 B |          NA |
| LinqAF                   | .NET 9.0 | 100   |   291.39 ns |  1.250 ns |  0.976 ns |   291.55 ns |  2.65x slower |   0.02x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   |   339.68 ns |  2.719 ns |  2.123 ns |   339.79 ns |  3.09x slower |   0.03x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |   130.39 ns |  1.243 ns |  0.970 ns |   130.36 ns |  1.19x slower |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |   395.53 ns |  7.427 ns |  7.294 ns |   394.37 ns |  3.60x slower |   0.08x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |    90.71 ns |  0.770 ns |  0.856 ns |    90.29 ns |  1.21x faster |   0.01x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   |   659.48 ns | 10.070 ns |  7.862 ns |   656.61 ns |  6.00x slower |   0.07x | 3.0670 |    6424 B |          NA |
