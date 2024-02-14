## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
| Method                   | Runtime  | Duplicates | Count | Mean       | Error     | StdDev    | Median     | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio   |
|------------------------- |--------- |----------- |------ |-----------:|----------:|----------:|-----------:|-------------:|--------:|-------:|----------:|--------------:|
| ForLoop                  | .NET 8.0 | 4          | 100   | 3,280.4 ns |  64.85 ns |  72.08 ns | 3,256.8 ns |     baseline |         | 2.8610 |    6000 B |               |
| ForeachLoop              | .NET 8.0 | 4          | 100   | 3,155.9 ns |  61.79 ns |  71.15 ns | 3,130.6 ns | 1.04x faster |   0.03x | 2.8648 |    6000 B |   1.000x more |
| Linq                     | .NET 8.0 | 4          | 100   | 3,850.0 ns |  29.28 ns |  22.86 ns | 3,845.4 ns | 1.17x slower |   0.03x | 2.8610 |    6000 B |   1.000x more |
| LinqFaster               | .NET 8.0 | 4          | 100   |   553.3 ns |   9.01 ns |   9.25 ns |   549.5 ns | 5.94x faster |   0.18x |      - |         - |            NA |
| LinqFasterer             | .NET 8.0 | 4          | 100   | 3,658.0 ns |  72.32 ns | 132.23 ns | 3,608.1 ns | 1.12x slower |   0.06x | 5.2071 |   10896 B |   1.816x more |
| LinqAF                   | .NET 8.0 | 4          | 100   | 6,357.2 ns | 121.38 ns | 338.35 ns | 6,179.7 ns | 1.95x slower |   0.12x | 5.9280 |   12400 B |   2.067x more |
| StructLinq               | .NET 8.0 | 4          | 100   | 2,785.9 ns |  55.50 ns |  75.97 ns | 2,744.9 ns | 1.17x faster |   0.04x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 8.0 | 4          | 100   | 2,670.7 ns |  16.76 ns |  13.99 ns | 2,671.8 ns | 1.23x faster |   0.03x |      - |         - |            NA |
| Hyperlinq                | .NET 8.0 | 4          | 100   | 2,593.4 ns |  40.63 ns |  52.83 ns | 2,573.5 ns | 1.26x faster |   0.04x |      - |         - |            NA |
|                          |          |            |       |            |           |           |            |              |         |        |           |               |
| ForLoop                  | .NET 9.0 | 4          | 100   | 3,253.2 ns |  57.87 ns |  51.30 ns | 3,235.5 ns |     baseline |         | 2.8610 |    6000 B |               |
| ForeachLoop              | .NET 9.0 | 4          | 100   | 3,544.6 ns |  69.46 ns | 114.13 ns | 3,495.0 ns | 1.09x slower |   0.04x | 2.8648 |    6000 B |   1.000x more |
| Linq                     | .NET 9.0 | 4          | 100   | 4,336.0 ns |  64.30 ns |  50.20 ns | 4,327.7 ns | 1.33x slower |   0.02x | 2.8610 |    6000 B |   1.000x more |
| LinqFaster               | .NET 9.0 | 4          | 100   |   621.5 ns |  12.22 ns |  10.83 ns |   616.8 ns | 5.24x faster |   0.10x |      - |         - |            NA |
| LinqFasterer             | .NET 9.0 | 4          | 100   | 3,625.1 ns |  68.70 ns |  70.55 ns | 3,591.1 ns | 1.12x slower |   0.02x | 5.2032 |   10896 B |   1.816x more |
| LinqAF                   | .NET 9.0 | 4          | 100   | 6,318.9 ns |  98.32 ns | 109.28 ns | 6,307.7 ns | 1.94x slower |   0.05x | 5.9280 |   12400 B |   2.067x more |
| StructLinq               | .NET 9.0 | 4          | 100   | 2,755.3 ns |  19.40 ns |  16.20 ns | 2,753.7 ns | 1.18x faster |   0.02x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 9.0 | 4          | 100   | 2,785.8 ns |  55.42 ns |  63.83 ns | 2,767.6 ns | 1.16x faster |   0.04x |      - |         - |            NA |
| Hyperlinq                | .NET 9.0 | 4          | 100   | 2,509.4 ns |  36.56 ns |  32.41 ns | 2,499.9 ns | 1.30x faster |   0.02x |      - |         - |            NA |
