## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
| Method                   | Runtime  | Count | Mean     | Error   | StdDev  | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|--------:|--------:|-------------:|--------:|-------:|----------:|------------:|
| ForeachLoop              | .NET 8.0 | 100   | 150.4 ns | 1.21 ns | 1.07 ns |     baseline |         | 0.0153 |      32 B |             |
| Linq                     | .NET 8.0 | 100   | 180.1 ns | 1.32 ns | 1.47 ns | 1.20x slower |   0.01x | 0.0153 |      32 B |  1.00x more |
| LinqAF                   | .NET 8.0 | 100   | 233.1 ns | 4.41 ns | 3.91 ns | 1.55x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
| StructLinq               | .NET 8.0 | 100   | 266.7 ns | 2.82 ns | 2.36 ns | 1.77x slower |   0.02x | 0.0420 |      88 B |  2.75x more |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 186.6 ns | 1.69 ns | 1.32 ns | 1.24x slower |   0.01x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq                | .NET 8.0 | 100   | 303.8 ns | 5.94 ns | 6.60 ns | 2.03x slower |   0.05x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 221.4 ns | 2.06 ns | 2.38 ns | 1.48x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
|                          |          |       |          |         |         |              |         |        |           |             |
| ForeachLoop              | .NET 9.0 | 100   | 145.7 ns | 1.20 ns | 1.06 ns |     baseline |         | 0.0153 |      32 B |             |
| Linq                     | .NET 9.0 | 100   | 180.9 ns | 2.96 ns | 2.47 ns | 1.24x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
| LinqAF                   | .NET 9.0 | 100   | 214.7 ns | 2.79 ns | 2.61 ns | 1.47x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
| StructLinq               | .NET 9.0 | 100   | 221.3 ns | 3.87 ns | 3.43 ns | 1.52x slower |   0.03x | 0.0420 |      88 B |  2.75x more |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 172.5 ns | 2.38 ns | 2.11 ns | 1.18x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq                | .NET 9.0 | 100   | 200.0 ns | 3.84 ns | 3.94 ns | 1.38x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 196.4 ns | 3.72 ns | 3.10 ns | 1.35x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
