## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
| ForLoop                  | .NET 8.0 | 100   |  40.33 ns | 0.820 ns | 1.037 ns |  40.01 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  42.10 ns | 0.865 ns | 0.675 ns |  42.22 ns | 1.04x slower |   0.03x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   |  15.38 ns | 0.336 ns | 0.502 ns |  15.23 ns | 2.60x faster |   0.08x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   |  46.93 ns | 0.382 ns | 0.425 ns |  46.82 ns | 1.16x slower |   0.03x | 0.2142 |     448 B |          NA |
| StructLinq               | .NET 8.0 | 100   |  77.56 ns | 1.157 ns | 1.332 ns |  77.20 ns | 1.92x slower |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 161.17 ns | 0.893 ns | 0.746 ns | 161.18 ns | 3.97x slower |   0.13x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |  18.60 ns | 0.310 ns | 0.242 ns |  18.55 ns | 2.19x faster |   0.06x | 0.0153 |      32 B |          NA |
| Hyperlinq_SIMD           | .NET 8.0 | 100   |  13.30 ns | 0.133 ns | 0.148 ns |  13.27 ns | 3.04x faster |   0.07x |      - |         - |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  41.90 ns | 0.538 ns | 0.420 ns |  41.74 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  44.42 ns | 0.922 ns | 1.062 ns |  44.01 ns | 1.07x slower |   0.03x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   |  13.64 ns | 0.302 ns | 0.662 ns |  13.24 ns | 3.02x faster |   0.14x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   |  49.81 ns | 0.328 ns | 0.322 ns |  49.79 ns | 1.19x slower |   0.01x | 0.2142 |     448 B |          NA |
| StructLinq               | .NET 9.0 | 100   |  97.18 ns | 1.860 ns | 1.827 ns |  96.61 ns | 2.32x slower |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 128.10 ns | 2.178 ns | 2.508 ns | 128.08 ns | 3.06x slower |   0.07x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |  18.77 ns | 0.168 ns | 0.149 ns |  18.77 ns | 2.24x faster |   0.02x | 0.0153 |      32 B |          NA |
| Hyperlinq_SIMD           | .NET 9.0 | 100   |  17.89 ns | 0.222 ns | 0.273 ns |  17.78 ns | 2.34x faster |   0.05x |      - |         - |          NA |
