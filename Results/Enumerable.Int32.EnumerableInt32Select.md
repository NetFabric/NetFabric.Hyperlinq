## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
| ForeachLoop              | .NET 8.0 | 100   | 173.3 ns | 3.14 ns |  5.49 ns | 171.1 ns |     baseline |         | 0.0153 |      32 B |             |
| Linq                     | .NET 8.0 | 100   | 272.6 ns | 2.79 ns |  2.61 ns | 272.4 ns | 1.57x slower |   0.05x | 0.0420 |      88 B |  2.75x more |
| LinqAF                   | .NET 8.0 | 100   | 217.1 ns | 3.30 ns |  3.39 ns | 216.0 ns | 1.26x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
| StructLinq               | .NET 8.0 | 100   | 229.5 ns | 1.96 ns |  1.64 ns | 229.3 ns | 1.32x slower |   0.04x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 163.6 ns | 2.09 ns |  1.74 ns | 163.1 ns | 1.06x faster |   0.04x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq                | .NET 8.0 | 100   | 207.5 ns | 4.01 ns |  4.12 ns | 205.0 ns | 1.20x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 169.9 ns | 1.56 ns |  1.30 ns | 169.7 ns | 1.02x faster |   0.03x | 0.0153 |      32 B |  1.00x more |
|                          |          |       |          |         |          |          |              |         |        |           |             |
| ForeachLoop              | .NET 9.0 | 100   | 160.8 ns | 3.13 ns |  3.47 ns | 159.4 ns |     baseline |         | 0.0153 |      32 B |             |
| Linq                     | .NET 9.0 | 100   | 328.8 ns | 6.59 ns | 13.91 ns | 321.5 ns | 2.06x slower |   0.12x | 0.0420 |      88 B |  2.75x more |
| LinqAF                   | .NET 9.0 | 100   | 265.0 ns | 3.18 ns |  2.65 ns | 264.0 ns | 1.65x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
| StructLinq               | .NET 9.0 | 100   | 198.8 ns | 3.94 ns |  4.98 ns | 196.4 ns | 1.24x slower |   0.02x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 161.8 ns | 1.64 ns |  1.28 ns | 161.5 ns | 1.01x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq                | .NET 9.0 | 100   | 194.0 ns | 3.92 ns |  3.48 ns | 192.8 ns | 1.21x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 169.2 ns | 2.64 ns |  2.34 ns | 168.4 ns | 1.05x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
