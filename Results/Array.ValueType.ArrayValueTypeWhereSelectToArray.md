## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
| Method                   | Runtime  | Count | Mean       | Error    | StdDev   | Median     | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |   906.2 ns | 10.70 ns | 10.01 ns |   901.2 ns |     baseline |         | 5.5237 |   11.3 KB |             |
| ForeachLoop              | .NET 8.0 | 100   |   904.2 ns |  8.44 ns |  7.89 ns |   901.1 ns | 1.00x faster |   0.02x | 5.5237 |   11.3 KB |  1.00x more |
| Linq                     | .NET 8.0 | 100   |   922.8 ns | 11.57 ns |  9.66 ns |   922.7 ns | 1.02x slower |   0.01x | 3.9291 |   8.03 KB |  1.41x less |
| LinqFaster               | .NET 8.0 | 100   |   814.5 ns | 16.35 ns | 28.63 ns |   800.4 ns | 1.11x faster |   0.03x | 4.7274 |   9.67 KB |  1.17x less |
| LinqFasterer             | .NET 8.0 | 100   | 1,305.5 ns | 21.21 ns | 17.71 ns | 1,302.8 ns | 1.44x slower |   0.03x | 6.0043 |   12.3 KB |  1.09x more |
| LinqAF                   | .NET 8.0 | 100   | 1,439.9 ns | 20.72 ns | 17.31 ns | 1,435.1 ns | 1.59x slower |   0.03x | 5.5084 |  11.27 KB |  1.00x less |
| StructLinq               | .NET 8.0 | 100   |   936.9 ns |  9.04 ns |  7.55 ns |   933.8 ns | 1.04x slower |   0.02x | 1.7061 |   3.49 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |   595.0 ns |  8.37 ns |  6.99 ns |   594.0 ns | 1.52x faster |   0.02x | 1.6575 |    3.4 KB |  3.32x less |
| Hyperlinq                | .NET 8.0 | 100   |   661.3 ns |  8.56 ns |  9.16 ns |   660.2 ns | 1.37x faster |   0.03x | 1.6575 |    3.4 KB |  3.32x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |   586.7 ns | 10.55 ns | 21.78 ns |   579.1 ns | 1.54x faster |   0.05x | 1.6575 |    3.4 KB |  3.32x less |
| Faslinq                  | .NET 8.0 | 100   |   556.5 ns |  6.08 ns |  4.74 ns |   555.5 ns | 1.63x faster |   0.02x | 3.0670 |   6.27 KB |  1.80x less |
|                          |          |       |            |          |          |            |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |   955.8 ns | 21.43 ns | 62.16 ns |   929.0 ns |     baseline |         | 5.5246 |   11.3 KB |             |
| ForeachLoop              | .NET 9.0 | 100   |   945.9 ns | 18.94 ns | 54.04 ns |   924.5 ns | 1.01x faster |   0.10x | 5.5246 |   11.3 KB |  1.00x more |
| Linq                     | .NET 9.0 | 100   |   614.4 ns |  9.27 ns |  7.24 ns |   612.3 ns | 1.57x faster |   0.10x | 1.7633 |   3.61 KB |  3.13x less |
| LinqFaster               | .NET 9.0 | 100   |   835.9 ns | 16.73 ns | 44.67 ns |   819.0 ns | 1.14x faster |   0.08x | 4.7274 |   9.67 KB |  1.17x less |
| LinqFasterer             | .NET 9.0 | 100   | 1,281.3 ns | 20.90 ns | 17.45 ns | 1,287.0 ns | 1.34x slower |   0.08x | 6.0043 |   12.3 KB |  1.09x more |
| LinqAF                   | .NET 9.0 | 100   | 1,408.8 ns |  6.04 ns |  5.04 ns | 1,407.0 ns | 1.47x slower |   0.09x | 5.5084 |  11.27 KB |  1.00x less |
| StructLinq               | .NET 9.0 | 100   |   918.8 ns |  9.48 ns |  7.92 ns |   920.8 ns | 1.05x faster |   0.06x | 1.7061 |   3.49 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |   570.5 ns | 10.61 ns |  9.41 ns |   568.7 ns | 1.68x faster |   0.11x | 1.6575 |    3.4 KB |  3.32x less |
| Hyperlinq                | .NET 9.0 | 100   |   641.3 ns |  9.10 ns |  7.11 ns |   640.4 ns | 1.50x faster |   0.08x | 1.6575 |    3.4 KB |  3.32x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |   572.7 ns |  7.07 ns |  7.86 ns |   571.0 ns | 1.65x faster |   0.08x | 1.6575 |    3.4 KB |  3.32x less |
| Faslinq                  | .NET 9.0 | 100   |   578.0 ns | 11.51 ns | 21.34 ns |   568.5 ns | 1.65x faster |   0.11x | 3.0670 |   6.27 KB |  1.80x less |
