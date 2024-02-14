## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
| ForeachLoop              | .NET 8.0 | 100   | 190.3 ns | 3.83 ns | 4.41 ns |     baseline |         | 0.0153 |      32 B |             |
| Linq                     | .NET 8.0 | 100   | 161.5 ns | 1.58 ns | 1.40 ns | 1.18x faster |   0.03x | 0.0153 |      32 B |  1.00x more |
| LinqAF                   | .NET 8.0 | 100   | 229.2 ns | 4.47 ns | 3.96 ns | 1.20x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
| StructLinq               | .NET 8.0 | 100   | 200.2 ns | 3.81 ns | 4.82 ns | 1.05x slower |   0.02x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 193.8 ns | 3.82 ns | 3.57 ns | 1.01x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq                | .NET 8.0 | 100   | 176.3 ns | 3.46 ns | 3.56 ns | 1.08x faster |   0.04x | 0.0153 |      32 B |  1.00x more |
|                          |          |       |          |         |         |              |         |        |           |             |
| ForeachLoop              | .NET 9.0 | 100   | 199.8 ns | 2.32 ns | 1.94 ns |     baseline |         | 0.0153 |      32 B |             |
| Linq                     | .NET 9.0 | 100   | 162.7 ns | 3.16 ns | 3.24 ns | 1.22x faster |   0.03x | 0.0153 |      32 B |  1.00x more |
| LinqAF                   | .NET 9.0 | 100   | 225.3 ns | 1.34 ns | 1.12 ns | 1.13x slower |   0.01x | 0.0153 |      32 B |  1.00x more |
| StructLinq               | .NET 9.0 | 100   | 206.5 ns | 4.09 ns | 4.55 ns | 1.03x slower |   0.02x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 195.0 ns | 2.04 ns | 1.59 ns | 1.02x faster |   0.01x | 0.0153 |      32 B |  1.00x more |
| Hyperlinq                | .NET 9.0 | 100   | 173.8 ns | 3.42 ns | 4.20 ns | 1.14x faster |   0.03x | 0.0153 |      32 B |  1.00x more |
