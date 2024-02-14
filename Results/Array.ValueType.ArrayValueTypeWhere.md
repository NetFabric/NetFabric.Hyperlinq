## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
| Method                   | Runtime  | Count | Mean      | Error     | StdDev    | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   | 111.17 ns |  2.236 ns |  2.575 ns | 109.98 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  78.72 ns |  0.581 ns |  0.453 ns |  78.62 ns | 1.41x faster |   0.02x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 653.83 ns | 12.724 ns | 13.067 ns | 648.95 ns | 5.87x slower |   0.21x | 0.0496 |     104 B |          NA |
| LinqFaster               | .NET 8.0 | 100   | 783.41 ns | 14.942 ns | 12.477 ns | 779.55 ns | 7.02x slower |   0.14x | 4.7274 |    9904 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 979.89 ns | 19.617 ns | 56.600 ns | 955.01 ns | 8.85x slower |   0.61x | 3.0203 |    6328 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 323.98 ns |  2.117 ns |  1.876 ns | 324.13 ns | 2.89x slower |   0.08x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 234.92 ns |  4.721 ns | 12.437 ns | 229.99 ns | 2.22x slower |   0.12x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 100.54 ns |  2.016 ns |  2.476 ns |  99.27 ns | 1.10x faster |   0.04x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 291.77 ns |  5.880 ns |  7.221 ns | 289.71 ns | 2.62x slower |   0.09x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 117.62 ns |  0.931 ns |  0.727 ns | 117.30 ns | 1.06x slower |   0.02x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 620.28 ns |  8.925 ns |  7.912 ns | 617.29 ns | 5.54x slower |   0.16x | 3.0670 |    6424 B |          NA |
|                          |          |       |           |           |           |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   | 130.87 ns |  0.809 ns |  0.632 ns | 130.68 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   | 131.32 ns |  2.074 ns |  1.620 ns | 130.38 ns | 1.00x slower |   0.01x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 638.91 ns |  7.795 ns |  6.509 ns | 636.16 ns | 4.88x slower |   0.05x | 0.0496 |     104 B |          NA |
| LinqFaster               | .NET 9.0 | 100   | 783.66 ns | 15.268 ns | 19.853 ns | 778.11 ns | 6.03x slower |   0.16x | 4.7274 |    9904 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 956.19 ns | 18.390 ns | 17.202 ns | 953.30 ns | 7.33x slower |   0.12x | 3.0193 |    6328 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 322.64 ns |  5.365 ns |  7.521 ns | 320.34 ns | 2.47x slower |   0.08x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 224.52 ns |  1.486 ns |  1.317 ns | 224.27 ns | 1.72x slower |   0.01x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 116.96 ns |  2.369 ns |  3.546 ns | 115.06 ns | 1.11x faster |   0.04x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 247.23 ns |  2.091 ns |  1.746 ns | 247.07 ns | 1.89x slower |   0.02x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 106.09 ns |  1.903 ns |  2.037 ns | 105.28 ns | 1.23x faster |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 646.80 ns |  7.393 ns |  6.173 ns | 647.16 ns | 4.94x slower |   0.06x | 3.0670 |    6424 B |          NA |
