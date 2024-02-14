## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
| Method                   | Runtime  | Count | Mean     | Error   | StdDev  | Median   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|--------:|--------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| ForeachLoop              | .NET 8.0 | 100   | 162.6 ns | 3.20 ns | 3.55 ns | 161.0 ns |     baseline |         | 0.0153 |      32 B |             |
| Linq                     | .NET 8.0 | 100   | 178.0 ns | 3.60 ns | 8.95 ns | 173.2 ns | 1.11x slower |   0.07x | 0.0153 |      32 B |  1.00x more |
| LinqAF                   | .NET 8.0 | 100   | 238.5 ns | 3.13 ns | 2.61 ns | 237.5 ns | 1.46x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
| StructLinq               | .NET 8.0 | 100   | 196.6 ns | 0.98 ns | 0.92 ns | 196.2 ns | 1.21x slower |   0.02x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 190.7 ns | 3.47 ns | 4.39 ns | 188.8 ns | 1.18x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq                | .NET 8.0 | 100   | 198.4 ns | 3.68 ns | 3.26 ns | 196.9 ns | 1.22x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
|                          |          |       |          |         |         |          |              |         |        |           |             |
| ForeachLoop              | .NET 9.0 | 100   | 157.4 ns | 0.93 ns | 0.78 ns | 157.2 ns |     baseline |         | 0.0153 |      32 B |             |
| Linq                     | .NET 9.0 | 100   | 167.4 ns | 3.22 ns | 4.82 ns | 165.4 ns | 1.06x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
| LinqAF                   | .NET 9.0 | 100   | 231.3 ns | 4.46 ns | 5.96 ns | 229.3 ns | 1.47x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
| StructLinq               | .NET 9.0 | 100   | 205.0 ns | 3.55 ns | 4.86 ns | 202.8 ns | 1.30x slower |   0.03x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 192.0 ns | 2.87 ns | 2.40 ns | 190.9 ns | 1.22x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq                | .NET 9.0 | 100   | 163.0 ns | 3.22 ns | 5.21 ns | 160.2 ns | 1.05x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
