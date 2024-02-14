## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
| Method                   | Runtime  | Count | Mean      | Error    | StdDev   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  65.66 ns | 1.041 ns | 0.923 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  80.71 ns | 1.586 ns | 2.006 ns | 1.24x slower |   0.04x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 183.91 ns | 2.738 ns | 2.137 ns | 2.81x slower |   0.04x | 0.0229 |      48 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 287.72 ns | 5.344 ns | 4.463 ns | 4.38x slower |   0.10x | 0.3443 |     720 B |          NA |
| StructLinq               | .NET 8.0 | 100   | 148.45 ns | 1.285 ns | 1.139 ns | 2.26x slower |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  70.27 ns | 0.483 ns | 0.403 ns | 1.07x slower |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 132.96 ns | 1.859 ns | 1.451 ns | 2.03x slower |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  75.13 ns | 1.295 ns | 1.542 ns | 1.15x slower |   0.03x |      - |         - |          NA |
|                          |          |       |           |          |          |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  66.18 ns | 1.290 ns | 1.144 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  66.79 ns | 0.834 ns | 0.651 ns | 1.01x slower |   0.02x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 171.24 ns | 1.394 ns | 1.088 ns | 2.58x slower |   0.05x | 0.0229 |      48 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 301.08 ns | 5.997 ns | 7.139 ns | 4.58x slower |   0.15x | 0.3443 |     720 B |          NA |
| StructLinq               | .NET 9.0 | 100   | 141.89 ns | 1.682 ns | 1.405 ns | 2.14x slower |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  54.08 ns | 0.936 ns | 1.457 ns | 1.22x faster |   0.05x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 104.25 ns | 1.782 ns | 1.580 ns | 1.58x slower |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  88.16 ns | 1.799 ns | 2.522 ns | 1.33x slower |   0.04x |      - |         - |          NA |
