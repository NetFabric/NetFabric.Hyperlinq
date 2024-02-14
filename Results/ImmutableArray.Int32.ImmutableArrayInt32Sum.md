## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
| Method                   | Runtime  | Count | Mean       | Error     | StdDev    | Median     | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|----------:|----------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  40.994 ns | 0.5290 ns | 0.5880 ns |  40.876 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  40.060 ns | 0.6265 ns | 0.4891 ns |  39.912 ns | 1.02x faster |   0.02x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 177.230 ns | 1.3646 ns | 1.1395 ns | 176.803 ns | 4.32x slower |   0.07x | 0.0267 |      56 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   |  99.545 ns | 1.8023 ns | 3.5994 ns |  98.261 ns | 2.43x slower |   0.10x | 0.2142 |     448 B |          NA |
| StructLinq               | .NET 8.0 | 100   | 113.599 ns | 0.5021 ns | 0.4451 ns | 113.457 ns | 2.77x slower |   0.05x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  83.281 ns | 0.5347 ns | 0.4740 ns |  83.333 ns | 2.03x slower |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |   9.982 ns | 0.1598 ns | 0.1335 ns |   9.976 ns | 4.11x faster |   0.10x |      - |         - |          NA |
|                          |          |       |            |           |           |            |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  40.754 ns | 0.3270 ns | 0.2553 ns |  40.746 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  49.506 ns | 0.9175 ns | 1.2559 ns |  48.970 ns | 1.21x slower |   0.03x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 164.449 ns | 1.7715 ns | 1.4793 ns | 164.460 ns | 4.03x slower |   0.03x | 0.0267 |      56 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 106.945 ns | 1.9792 ns | 3.9068 ns | 105.502 ns | 2.64x slower |   0.13x | 0.2142 |     448 B |          NA |
| StructLinq               | .NET 9.0 | 100   |  79.313 ns | 0.6960 ns | 0.5434 ns |  79.225 ns | 1.95x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  45.702 ns | 0.9433 ns | 1.9481 ns |  44.706 ns | 1.14x slower |   0.06x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |  10.421 ns | 0.2344 ns | 0.2078 ns |  10.333 ns | 3.91x faster |   0.08x |      - |         - |          NA |
