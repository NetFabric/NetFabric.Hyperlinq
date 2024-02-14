## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
| ForLoop                  | .NET 8.0 | 1000 | 100   |   148.9 ns |   1.05 ns |   0.88 ns |   148.9 ns |      baseline |         |       - |         - |          NA |
| Linq                     | .NET 8.0 | 1000 | 100   |   753.5 ns |  18.27 ns |  53.30 ns |   727.3 ns |  5.49x slower |   0.22x |  0.1526 |     320 B |          NA |
| LinqFaster               | .NET 8.0 | 1000 | 100   | 2,079.5 ns |  38.79 ns |  34.38 ns | 2,063.5 ns | 13.98x slower |   0.25x | 10.0250 |   21000 B |          NA |
| LinqFasterer             | .NET 8.0 | 1000 | 100   | 5,603.2 ns | 105.18 ns | 133.02 ns | 5,566.1 ns | 37.46x slower |   0.88x | 37.7350 |   80168 B |          NA |
| LinqAF                   | .NET 8.0 | 1000 | 100   | 5,575.4 ns |  42.82 ns |  35.75 ns | 5,568.2 ns | 37.43x slower |   0.26x |       - |         - |          NA |
| StructLinq               | .NET 8.0 | 1000 | 100   |   246.7 ns |   2.76 ns |   2.44 ns |   245.7 ns |  1.66x slower |   0.02x |  0.0572 |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   |   125.4 ns |   2.40 ns |   2.13 ns |   124.5 ns |  1.19x faster |   0.02x |       - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 1000 | 100   |   206.1 ns |   2.36 ns |   2.43 ns |   205.3 ns |  1.39x slower |   0.02x |       - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   |   104.0 ns |   2.11 ns |   3.97 ns |   102.2 ns |  1.43x faster |   0.05x |       - |         - |          NA |
|                          |          |      |       |            |           |           |            |               |         |         |           |             |
| ForLoop                  | .NET 9.0 | 1000 | 100   |   148.1 ns |   1.70 ns |   1.32 ns |   148.2 ns |      baseline |         |       - |         - |          NA |
| Linq                     | .NET 9.0 | 1000 | 100   |   939.3 ns |  18.74 ns |  40.75 ns |   919.5 ns |  6.43x slower |   0.31x |  0.1526 |     320 B |          NA |
| LinqFaster               | .NET 9.0 | 1000 | 100   | 2,129.8 ns |  42.11 ns | 101.71 ns | 2,091.5 ns | 14.71x slower |   0.82x | 10.0250 |   21000 B |          NA |
| LinqFasterer             | .NET 9.0 | 1000 | 100   | 5,714.2 ns | 112.76 ns | 256.80 ns | 5,635.3 ns | 39.12x slower |   1.91x | 37.7350 |   80168 B |          NA |
| LinqAF                   | .NET 9.0 | 1000 | 100   | 4,558.9 ns |  84.12 ns | 106.38 ns | 4,510.8 ns | 30.74x slower |   0.98x |       - |         - |          NA |
| StructLinq               | .NET 9.0 | 1000 | 100   |   223.4 ns |   2.79 ns |   3.21 ns |   222.4 ns |  1.51x slower |   0.04x |  0.0572 |     120 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   |   105.9 ns |   2.14 ns |   2.37 ns |   104.8 ns |  1.39x faster |   0.04x |       - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 1000 | 100   |   243.9 ns |   1.04 ns |   0.81 ns |   243.8 ns |  1.65x slower |   0.02x |       - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   |   128.7 ns |   1.58 ns |   1.48 ns |   128.5 ns |  1.15x faster |   0.01x |       - |         - |          NA |
