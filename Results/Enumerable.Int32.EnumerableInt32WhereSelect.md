## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
| Method                   | Runtime  | Count | Mean     | Error   | StdDev   | Median   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|--------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| ForeachLoop              | .NET 8.0 | 100   | 149.7 ns | 2.23 ns |  2.65 ns | 148.9 ns |     baseline |         | 0.0153 |      32 B |             |
| Linq                     | .NET 8.0 | 100   | 328.3 ns | 5.40 ns |  6.22 ns | 326.4 ns | 2.19x slower |   0.06x | 0.0725 |     152 B |  4.75x more |
| LinqAF                   | .NET 8.0 | 100   | 235.2 ns | 3.82 ns |  4.09 ns | 233.4 ns | 1.57x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
| StructLinq               | .NET 8.0 | 100   | 269.9 ns | 4.29 ns |  3.59 ns | 268.6 ns | 1.79x slower |   0.05x | 0.0420 |      88 B |  2.75x more |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 287.7 ns | 2.89 ns |  2.41 ns | 286.8 ns | 1.91x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq                | .NET 8.0 | 100   | 261.1 ns | 1.79 ns |  1.68 ns | 260.2 ns | 1.74x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 231.0 ns | 1.36 ns |  1.13 ns | 230.7 ns | 1.53x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
|                          |          |       |          |         |          |          |              |         |        |           |             |
| ForeachLoop              | .NET 9.0 | 100   | 147.9 ns | 1.03 ns |  0.92 ns | 148.0 ns |     baseline |         | 0.0153 |      32 B |             |
| Linq                     | .NET 9.0 | 100   | 436.4 ns | 7.83 ns | 11.47 ns | 430.3 ns | 2.95x slower |   0.08x | 0.0725 |     152 B |  4.75x more |
| LinqAF                   | .NET 9.0 | 100   | 266.2 ns | 2.53 ns |  2.37 ns | 265.7 ns | 1.80x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
| StructLinq               | .NET 9.0 | 100   | 253.8 ns | 1.51 ns |  1.34 ns | 253.4 ns | 1.72x slower |   0.01x | 0.0420 |      88 B |  2.75x more |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 206.1 ns | 3.02 ns |  3.23 ns | 205.1 ns | 1.40x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq                | .NET 9.0 | 100   | 233.8 ns | 1.86 ns |  1.56 ns | 233.9 ns | 1.58x slower |   0.01x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 206.3 ns | 3.50 ns |  4.30 ns | 204.5 ns | 1.40x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
