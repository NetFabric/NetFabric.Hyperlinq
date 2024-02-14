## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
| Method                   | Runtime  | Skip | Count | Mean      | Error    | StdDev   | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 1000 | 100   |  57.43 ns | 0.624 ns | 0.553 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 8.0 | 1000 | 100   | 342.77 ns | 6.603 ns | 6.485 ns |  5.96x slower |   0.12x | 0.0839 |     176 B |          NA |
| LinqFasterer             | .NET 8.0 | 1000 | 100   | 598.79 ns | 7.342 ns | 7.210 ns | 10.44x slower |   0.19x | 2.5444 |    5328 B |          NA |
| StructLinq               | .NET 8.0 | 1000 | 100   | 160.00 ns | 2.207 ns | 1.843 ns |  2.79x slower |   0.03x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   |  87.39 ns | 1.773 ns | 2.110 ns |  1.52x slower |   0.04x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 1000 | 100   |  69.26 ns | 0.490 ns | 0.382 ns |  1.21x slower |   0.01x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   |  49.54 ns | 0.880 ns | 0.865 ns |  1.16x faster |   0.02x |      - |         - |          NA |
|                          |          |      |       |           |          |          |               |         |        |           |             |
| ForLoop                  | .NET 9.0 | 1000 | 100   |  57.95 ns | 1.164 ns | 1.340 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 9.0 | 1000 | 100   | 348.78 ns | 7.026 ns | 7.518 ns |  6.02x slower |   0.22x | 0.0839 |     176 B |          NA |
| LinqFasterer             | .NET 9.0 | 1000 | 100   | 658.84 ns | 7.152 ns | 5.584 ns | 11.30x slower |   0.29x | 2.5444 |    5328 B |          NA |
| StructLinq               | .NET 9.0 | 1000 | 100   | 158.71 ns | 2.355 ns | 2.892 ns |  2.74x slower |   0.08x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   |  61.33 ns | 0.774 ns | 0.605 ns |  1.05x slower |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 1000 | 100   | 116.63 ns | 2.328 ns | 2.178 ns |  2.01x slower |   0.07x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   |  61.00 ns | 0.387 ns | 0.343 ns |  1.05x slower |   0.03x |      - |         - |          NA |
