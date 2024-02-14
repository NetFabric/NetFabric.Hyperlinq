## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
| ForLoop                  | .NET 8.0 | 100   |   968.1 ns | 19.13 ns | 41.18 ns |   951.0 ns |     baseline |         | 5.5246 |   11.3 KB |             |
| ForeachLoop              | .NET 8.0 | 100   | 1,014.6 ns | 19.69 ns | 27.60 ns | 1,007.0 ns | 1.04x slower |   0.06x | 5.5237 |   11.3 KB |  1.00x more |
| Linq                     | .NET 8.0 | 100   |   909.1 ns | 17.12 ns | 17.58 ns |   906.6 ns | 1.09x faster |   0.06x | 4.0045 |   8.19 KB |  1.38x less |
| LinqFaster               | .NET 8.0 | 100   | 1,139.9 ns | 12.29 ns | 10.26 ns | 1,137.6 ns | 1.14x slower |   0.06x | 5.5237 |   11.3 KB |  1.00x more |
| LinqFasterer             | .NET 8.0 | 100   | 1,237.0 ns | 24.79 ns | 59.86 ns | 1,209.8 ns | 1.28x slower |   0.09x | 6.3953 |  13.07 KB |  1.16x more |
| LinqAF                   | .NET 8.0 | 100   | 1,596.3 ns | 20.26 ns | 15.82 ns | 1,595.3 ns | 1.59x slower |   0.09x | 5.5084 |  11.27 KB |  1.00x less |
| StructLinq               | .NET 8.0 | 100   |   967.0 ns |  9.05 ns |  7.07 ns |   966.9 ns | 1.04x faster |   0.06x | 1.7109 |    3.5 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |   588.9 ns | 11.75 ns | 14.86 ns |   583.6 ns | 1.67x faster |   0.10x | 1.6575 |    3.4 KB |  3.32x less |
| Hyperlinq                | .NET 8.0 | 100   |   653.4 ns |  5.42 ns |  4.52 ns |   655.4 ns | 1.53x faster |   0.09x | 1.6575 |    3.4 KB |  3.32x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |   584.4 ns |  8.05 ns |  7.91 ns |   581.2 ns | 1.69x faster |   0.09x | 1.6575 |    3.4 KB |  3.32x less |
| Faslinq                  | .NET 8.0 | 100   | 1,105.5 ns | 20.75 ns | 39.49 ns | 1,091.2 ns | 1.14x slower |   0.05x | 5.5237 |   11.3 KB |  1.00x more |
|                          |          |       |            |          |          |            |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |   985.8 ns | 18.77 ns | 42.36 ns |   969.4 ns |     baseline |         | 5.5237 |   11.3 KB |             |
| ForeachLoop              | .NET 9.0 | 100   | 1,005.1 ns | 16.97 ns | 15.88 ns |   995.8 ns | 1.02x slower |   0.05x | 5.5237 |   11.3 KB |  1.00x more |
| Linq                     | .NET 9.0 | 100   |   661.0 ns | 12.14 ns |  9.48 ns |   655.7 ns | 1.47x faster |   0.05x | 1.8415 |   3.77 KB |  3.00x less |
| LinqFaster               | .NET 9.0 | 100   | 1,109.4 ns | 21.98 ns | 32.21 ns | 1,096.5 ns | 1.13x slower |   0.05x | 5.5237 |   11.3 KB |  1.00x more |
| LinqFasterer             | .NET 9.0 | 100   | 1,149.1 ns | 19.40 ns | 27.20 ns | 1,138.0 ns | 1.17x slower |   0.06x | 6.3953 |  13.07 KB |  1.16x more |
| LinqAF                   | .NET 9.0 | 100   | 1,637.9 ns | 18.20 ns | 17.88 ns | 1,635.8 ns | 1.67x slower |   0.08x | 5.5084 |  11.27 KB |  1.00x less |
| StructLinq               | .NET 9.0 | 100   |   977.3 ns | 13.61 ns | 11.36 ns |   973.6 ns | 1.00x slower |   0.04x | 1.7109 |    3.5 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |   570.2 ns |  7.31 ns |  6.48 ns |   569.5 ns | 1.71x faster |   0.07x | 1.6575 |    3.4 KB |  3.32x less |
| Hyperlinq                | .NET 9.0 | 100   |   651.3 ns | 12.53 ns | 16.29 ns |   645.8 ns | 1.52x faster |   0.07x | 1.6575 |    3.4 KB |  3.32x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |   583.9 ns |  7.22 ns |  6.03 ns |   582.4 ns | 1.67x faster |   0.08x | 1.6575 |    3.4 KB |  3.32x less |
| Faslinq                  | .NET 9.0 | 100   | 1,148.2 ns | 21.39 ns | 21.01 ns | 1,146.5 ns | 1.17x slower |   0.06x | 5.5237 |   11.3 KB |  1.00x more |
