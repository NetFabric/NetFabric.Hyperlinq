## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
| ForLoop                  | .NET 8.0 | 100   |   689.0 ns | 12.77 ns | 28.31 ns |   676.8 ns |     baseline |         | 3.8605 |    7.9 KB |             |
| ForeachLoop              | .NET 8.0 | 100   |   679.6 ns | 12.32 ns | 22.53 ns |   672.4 ns | 1.02x faster |   0.05x | 3.8605 |    7.9 KB |  1.00x more |
| Linq                     | .NET 8.0 | 100   |   848.1 ns | 17.03 ns | 34.02 ns |   835.6 ns | 1.23x slower |   0.07x | 3.9682 |   8.11 KB |  1.03x more |
| LinqFaster               | .NET 8.0 | 100   | 1,060.6 ns | 16.04 ns | 15.00 ns | 1,057.1 ns | 1.54x slower |   0.06x | 6.4087 |   13.1 KB |  1.66x more |
| LinqFasterer             | .NET 8.0 | 100   | 1,714.3 ns | 17.94 ns | 15.91 ns | 1,710.1 ns | 2.49x slower |   0.10x | 9.0332 |  18.48 KB |  2.34x more |
| LinqAF                   | .NET 8.0 | 100   | 1,198.5 ns | 13.27 ns | 11.08 ns | 1,193.3 ns | 1.74x slower |   0.07x | 3.8605 |    7.9 KB |  1.00x more |
| StructLinq               | .NET 8.0 | 100   |   947.5 ns |  8.34 ns |  7.40 ns |   945.9 ns | 1.37x slower |   0.06x | 1.7223 |   3.52 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |   623.3 ns |  9.50 ns |  8.42 ns |   621.5 ns | 1.11x faster |   0.04x | 1.6775 |   3.43 KB |  2.30x less |
| Hyperlinq                | .NET 8.0 | 100   |   689.7 ns |  8.13 ns |  9.04 ns |   686.8 ns | 1.01x slower |   0.03x | 1.6775 |   3.43 KB |  2.30x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |   615.3 ns |  4.00 ns |  4.91 ns |   614.5 ns | 1.11x faster |   0.03x | 1.6775 |   3.43 KB |  2.30x less |
| Faslinq                  | .NET 8.0 | 100   | 1,245.3 ns | 16.19 ns | 17.99 ns | 1,243.3 ns | 1.82x slower |   0.05x | 6.1531 |  12.58 KB |  1.59x more |
|                          |          |       |            |          |          |            |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |   692.5 ns | 12.03 ns |  9.39 ns |   692.6 ns |     baseline |         | 3.8605 |    7.9 KB |             |
| ForeachLoop              | .NET 9.0 | 100   |   679.8 ns | 13.63 ns | 14.00 ns |   675.9 ns | 1.02x faster |   0.03x | 3.8605 |    7.9 KB |  1.00x more |
| Linq                     | .NET 9.0 | 100   |   906.1 ns | 22.39 ns | 64.97 ns |   873.7 ns | 1.29x slower |   0.07x | 3.9682 |   8.11 KB |  1.03x more |
| LinqFaster               | .NET 9.0 | 100   | 1,044.2 ns | 13.91 ns | 10.86 ns | 1,044.0 ns | 1.51x slower |   0.03x | 6.4087 |   13.1 KB |  1.66x more |
| LinqFasterer             | .NET 9.0 | 100   | 1,665.0 ns | 25.79 ns | 30.70 ns | 1,653.2 ns | 2.41x slower |   0.06x | 9.0351 |  18.48 KB |  2.34x more |
| LinqAF                   | .NET 9.0 | 100   | 1,200.7 ns | 17.52 ns | 15.53 ns | 1,193.4 ns | 1.73x slower |   0.04x | 3.8605 |    7.9 KB |  1.00x more |
| StructLinq               | .NET 9.0 | 100   |   952.7 ns |  9.55 ns |  8.93 ns |   947.9 ns | 1.38x slower |   0.02x | 1.7223 |   3.52 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |   616.5 ns |  7.82 ns |  6.93 ns |   614.8 ns | 1.13x faster |   0.02x | 1.6775 |   3.43 KB |  2.30x less |
| Hyperlinq                | .NET 9.0 | 100   |   684.0 ns |  8.95 ns |  6.99 ns |   682.7 ns | 1.01x faster |   0.02x | 1.6775 |   3.43 KB |  2.30x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |   631.7 ns |  9.86 ns | 11.36 ns |   627.4 ns | 1.09x faster |   0.02x | 1.6775 |   3.43 KB |  2.30x less |
| Faslinq                  | .NET 9.0 | 100   |   960.4 ns |  8.22 ns |  7.28 ns |   958.1 ns | 1.39x slower |   0.02x | 6.1531 |  12.58 KB |  1.59x more |
