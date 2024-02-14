## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
| Method                   | Runtime  | Duplicates | Count | Mean     | Error     | StdDev    | Median   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio   |
|------------------------- |--------- |----------- |------ |---------:|----------:|----------:|---------:|-------------:|--------:|-------:|----------:|--------------:|
| ForLoop                  | .NET 8.0 | 4          | 100   | 2.884 μs | 0.0550 μs | 0.0430 μs | 2.868 μs |     baseline |         | 2.8648 |    6000 B |               |
| ForeachLoop              | .NET 8.0 | 4          | 100   | 2.868 μs | 0.0346 μs | 0.0324 μs | 2.865 μs | 1.00x faster |   0.02x | 2.8648 |    6000 B |   1.000x more |
| Linq                     | .NET 8.0 | 4          | 100   | 3.685 μs | 0.0733 μs | 0.1654 μs | 3.603 μs | 1.29x slower |   0.06x | 2.8648 |    5992 B |   1.001x less |
| LinqFasterer             | .NET 8.0 | 4          | 100   | 3.725 μs | 0.0843 μs | 0.2364 μs | 3.629 μs | 1.28x slower |   0.08x | 4.4212 |    9272 B |   1.545x more |
| LinqAF                   | .NET 8.0 | 4          | 100   | 5.854 μs | 0.1137 μs | 0.3133 μs | 5.733 μs | 2.01x slower |   0.11x | 5.9280 |   12400 B |   2.067x more |
| StructLinq               | .NET 8.0 | 4          | 100   | 2.762 μs | 0.0517 μs | 0.0404 μs | 2.758 μs | 1.04x faster |   0.02x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 8.0 | 4          | 100   | 2.772 μs | 0.0515 μs | 0.1163 μs | 2.743 μs | 1.03x faster |   0.05x |      - |         - |            NA |
| Hyperlinq                | .NET 8.0 | 4          | 100   | 2.588 μs | 0.0504 μs | 0.1018 μs | 2.553 μs | 1.13x faster |   0.04x |      - |         - |            NA |
|                          |          |            |       |          |           |           |          |              |         |        |           |               |
| ForLoop                  | .NET 9.0 | 4          | 100   | 2.987 μs | 0.0595 μs | 0.1578 μs | 2.911 μs |     baseline |         | 2.8648 |    6000 B |               |
| ForeachLoop              | .NET 9.0 | 4          | 100   | 2.894 μs | 0.0322 μs | 0.0302 μs | 2.881 μs | 1.05x faster |   0.06x | 2.8610 |    6000 B |   1.000x more |
| Linq                     | .NET 9.0 | 4          | 100   | 3.986 μs | 0.0790 μs | 0.1751 μs | 3.911 μs | 1.34x slower |   0.09x | 2.8610 |    5992 B |   1.001x less |
| LinqFasterer             | .NET 9.0 | 4          | 100   | 3.574 μs | 0.0666 μs | 0.1622 μs | 3.496 μs | 1.19x slower |   0.08x | 4.4212 |    9272 B |   1.545x more |
| LinqAF                   | .NET 9.0 | 4          | 100   | 5.827 μs | 0.0918 μs | 0.1057 μs | 5.784 μs | 1.95x slower |   0.11x | 5.9280 |   12400 B |   2.067x more |
| StructLinq               | .NET 9.0 | 4          | 100   | 2.706 μs | 0.0384 μs | 0.0321 μs | 2.698 μs | 1.11x faster |   0.06x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 9.0 | 4          | 100   | 2.700 μs | 0.0531 μs | 0.0710 μs | 2.671 μs | 1.10x faster |   0.05x |      - |         - |            NA |
| Hyperlinq                | .NET 9.0 | 4          | 100   | 2.956 μs | 0.0563 μs | 0.0553 μs | 2.947 μs | 1.02x faster |   0.05x |      - |         - |            NA |
