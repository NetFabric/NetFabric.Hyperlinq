## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
| ForLoop                  | .NET 8.0 | 100   |   741.2 ns | 14.88 ns | 36.51 ns |   728.3 ns |     baseline |         | 3.8605 |    7.9 KB |             |
| ForeachLoop              | .NET 8.0 | 100   |   799.8 ns | 16.03 ns | 42.22 ns |   784.6 ns | 1.08x slower |   0.06x | 3.8605 |    7.9 KB |  1.00x more |
| Linq                     | .NET 8.0 | 100   |   899.2 ns | 17.59 ns | 27.90 ns |   895.0 ns | 1.20x slower |   0.07x | 4.0436 |   8.27 KB |  1.05x more |
| LinqFaster               | .NET 8.0 | 100   | 1,142.5 ns | 16.25 ns | 14.40 ns | 1,138.1 ns | 1.52x slower |   0.08x | 5.5389 |  11.33 KB |  1.43x more |
| LinqFasterer             | .NET 8.0 | 100   | 1,458.7 ns | 29.19 ns | 51.13 ns | 1,434.1 ns | 1.95x slower |   0.10x | 8.0643 |   16.5 KB |  2.09x more |
| LinqAF                   | .NET 8.0 | 100   | 1,322.5 ns | 12.46 ns | 10.40 ns | 1,323.5 ns | 1.76x slower |   0.11x | 3.8605 |    7.9 KB |  1.00x more |
| StructLinq               | .NET 8.0 | 100   |   951.9 ns |  9.26 ns |  8.67 ns |   952.3 ns | 1.27x slower |   0.08x | 1.7262 |   3.53 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |   610.8 ns | 10.00 ns | 14.34 ns |   606.3 ns | 1.24x faster |   0.09x | 1.6775 |   3.43 KB |  2.30x less |
| Hyperlinq                | .NET 8.0 | 100   |   704.5 ns | 13.81 ns | 14.78 ns |   699.7 ns | 1.06x faster |   0.06x | 1.6766 |   3.43 KB |  2.30x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |   617.1 ns |  8.13 ns |  6.79 ns |   615.2 ns | 1.22x faster |   0.07x | 1.6775 |   3.43 KB |  2.30x less |
| Faslinq                  | .NET 8.0 | 100   |   838.1 ns | 15.28 ns | 12.76 ns |   835.0 ns | 1.11x slower |   0.07x | 3.8605 |    7.9 KB |  1.00x more |
|                          |          |       |            |          |          |            |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |   726.3 ns | 11.93 ns |  9.31 ns |   727.4 ns |     baseline |         | 3.8605 |    7.9 KB |             |
| ForeachLoop              | .NET 9.0 | 100   |   765.2 ns | 11.79 ns | 12.62 ns |   762.3 ns | 1.06x slower |   0.02x | 3.8605 |    7.9 KB |  1.00x more |
| Linq                     | .NET 9.0 | 100   |   833.9 ns | 10.90 ns | 10.70 ns |   829.7 ns | 1.15x slower |   0.03x | 4.0436 |   8.27 KB |  1.05x more |
| LinqFaster               | .NET 9.0 | 100   | 1,180.0 ns | 14.01 ns | 11.70 ns | 1,177.6 ns | 1.63x slower |   0.02x | 5.5389 |  11.33 KB |  1.43x more |
| LinqFasterer             | .NET 9.0 | 100   | 1,375.5 ns | 17.04 ns | 13.30 ns | 1,374.5 ns | 1.89x slower |   0.03x | 8.0643 |   16.5 KB |  2.09x more |
| LinqAF                   | .NET 9.0 | 100   | 1,394.3 ns | 27.78 ns | 47.91 ns | 1,373.9 ns | 1.95x slower |   0.07x | 3.8605 |    7.9 KB |  1.00x more |
| StructLinq               | .NET 9.0 | 100   |   946.9 ns |  9.44 ns |  8.37 ns |   945.9 ns | 1.30x slower |   0.02x | 1.7262 |   3.53 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |   628.5 ns | 10.80 ns |  9.02 ns |   626.6 ns | 1.15x faster |   0.02x | 1.6775 |   3.43 KB |  2.30x less |
| Hyperlinq                | .NET 9.0 | 100   |   714.0 ns | 12.78 ns | 22.72 ns |   705.9 ns | 1.01x faster |   0.04x | 1.6775 |   3.43 KB |  2.30x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |   632.1 ns | 12.55 ns | 24.18 ns |   621.7 ns | 1.17x faster |   0.02x | 1.6775 |   3.43 KB |  2.30x less |
| Faslinq                  | .NET 9.0 | 100   |   869.3 ns | 12.70 ns | 13.04 ns |   864.5 ns | 1.20x slower |   0.03x | 3.8605 |    7.9 KB |  1.00x more |
