## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
| Method                   | Runtime  | Count | Mean     | Error     | StdDev    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForeachLoop              | .NET 8.0 | 100   | 1.090 μs | 0.0140 μs | 0.0125 μs |     baseline |         | 1.3485 |    2824 B |             |
| Linq                     | .NET 8.0 | 100   | 1.237 μs | 0.0242 μs | 0.0306 μs | 1.13x slower |   0.01x | 1.3294 |    2784 B |  1.01x less |
| LinqAF                   | .NET 8.0 | 100   | 2.747 μs | 0.0459 μs | 0.0384 μs | 2.52x slower |   0.04x | 1.6365 |    3424 B |  1.21x more |
| StructLinq               | .NET 8.0 | 100   | 1.079 μs | 0.0119 μs | 0.0106 μs | 1.01x faster |   0.01x | 0.0267 |      56 B | 50.43x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 1.132 μs | 0.0113 μs | 0.0100 μs | 1.04x slower |   0.01x | 0.0153 |      32 B | 88.25x less |
| Hyperlinq                | .NET 8.0 | 100   | 1.278 μs | 0.0222 μs | 0.0173 μs | 1.18x slower |   0.02x | 0.0153 |      32 B | 88.25x less |
|                          |          |       |          |           |           |              |         |        |           |             |
| ForeachLoop              | .NET 9.0 | 100   | 1.129 μs | 0.0136 μs | 0.0151 μs |     baseline |         | 1.3485 |    2824 B |             |
| Linq                     | .NET 9.0 | 100   | 1.258 μs | 0.0247 μs | 0.0193 μs | 1.11x slower |   0.03x | 1.3294 |    2784 B |  1.01x less |
| LinqAF                   | .NET 9.0 | 100   | 2.821 μs | 0.0385 μs | 0.0396 μs | 2.50x slower |   0.05x | 1.6365 |    3424 B |  1.21x more |
| StructLinq               | .NET 9.0 | 100   | 1.150 μs | 0.0084 μs | 0.0070 μs | 1.02x slower |   0.02x | 0.0267 |      56 B | 50.43x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 1.120 μs | 0.0114 μs | 0.0095 μs | 1.01x faster |   0.02x | 0.0153 |      32 B | 88.25x less |
| Hyperlinq                | .NET 9.0 | 100   | 1.323 μs | 0.0158 μs | 0.0123 μs | 1.17x slower |   0.03x | 0.0153 |      32 B | 88.25x less |
