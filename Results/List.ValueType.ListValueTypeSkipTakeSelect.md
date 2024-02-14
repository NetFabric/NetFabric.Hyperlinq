## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
| Method                   | Runtime  | Skip | Count | Mean       | Error     | StdDev    | Median     | Ratio         | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |-----------:|----------:|----------:|-----------:|--------------:|--------:|--------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 1000 | 100   |   161.7 ns |   2.47 ns |   2.06 ns |   161.2 ns |      baseline |         |       - |         - |          NA |
| Linq                     | .NET 8.0 | 1000 | 100   | 1,081.3 ns |  18.50 ns |  16.40 ns | 1,074.4 ns |  6.69x slower |   0.08x |  0.1526 |     320 B |          NA |
| LinqFaster               | .NET 8.0 | 1000 | 100   | 2,174.0 ns |  31.74 ns |  24.78 ns | 2,170.9 ns | 13.45x slower |   0.20x |  9.2583 |   19368 B |          NA |
| LinqFasterer             | .NET 8.0 | 1000 | 100   | 6,330.2 ns | 124.05 ns | 304.30 ns | 6,189.5 ns | 39.52x slower |   2.49x | 38.4598 |   83304 B |          NA |
| LinqAF                   | .NET 8.0 | 1000 | 100   | 5,744.7 ns |  92.08 ns | 151.29 ns | 5,675.9 ns | 35.95x slower |   1.42x |       - |         - |          NA |
| StructLinq               | .NET 8.0 | 1000 | 100   |   276.9 ns |   4.01 ns |   3.35 ns |   276.6 ns |  1.71x slower |   0.03x |  0.0572 |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   |   124.3 ns |   2.45 ns |   2.29 ns |   124.1 ns |  1.30x faster |   0.03x |       - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 1000 | 100   |   286.8 ns |   3.01 ns |   2.35 ns |   287.0 ns |  1.77x slower |   0.03x |       - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   |   101.3 ns |   1.08 ns |   0.90 ns |   100.8 ns |  1.60x faster |   0.02x |       - |         - |          NA |
|                          |          |      |       |            |           |           |            |               |         |         |           |             |
| ForLoop                  | .NET 9.0 | 1000 | 100   |   124.4 ns |   1.63 ns |   1.74 ns |   123.9 ns |      baseline |         |       - |         - |          NA |
| Linq                     | .NET 9.0 | 1000 | 100   | 1,094.0 ns |  21.81 ns |  23.34 ns | 1,084.2 ns |  8.80x slower |   0.19x |  0.1526 |     320 B |          NA |
| LinqFaster               | .NET 9.0 | 1000 | 100   | 2,191.7 ns |  30.25 ns |  26.81 ns | 2,180.1 ns | 17.59x slower |   0.27x |  9.2583 |   19368 B |          NA |
| LinqFasterer             | .NET 9.0 | 1000 | 100   | 6,246.7 ns | 126.39 ns | 362.65 ns | 6,090.5 ns | 50.46x slower |   3.22x | 38.4598 |   83304 B |          NA |
| LinqAF                   | .NET 9.0 | 1000 | 100   | 4,900.5 ns |  97.14 ns | 151.24 ns | 4,845.2 ns | 39.19x slower |   0.95x |       - |         - |          NA |
| StructLinq               | .NET 9.0 | 1000 | 100   |   262.9 ns |   4.60 ns |   6.14 ns |   261.3 ns |  2.12x slower |   0.06x |  0.0572 |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   |   125.8 ns |   0.86 ns |   0.72 ns |   125.8 ns |  1.01x slower |   0.02x |       - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 1000 | 100   |   282.8 ns |   3.56 ns |   2.78 ns |   282.2 ns |  2.27x slower |   0.05x |       - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   |   109.4 ns |   1.86 ns |   2.61 ns |   108.3 ns |  1.14x faster |   0.04x |       - |         - |          NA |
