## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
| ForeachLoop              | .NET 8.0 | 100   | 295.2 ns | 5.32 ns |  4.71 ns | 293.5 ns |     baseline |         | 0.4396 |     920 B |             |
| Linq                     | .NET 8.0 | 100   | 441.2 ns | 8.41 ns | 23.72 ns | 430.8 ns | 1.47x slower |   0.06x | 0.4015 |     840 B |  1.10x less |
| LinqAF                   | .NET 8.0 | 100   | 513.0 ns | 5.00 ns |  4.43 ns | 511.3 ns | 1.74x slower |   0.04x | 0.4244 |     888 B |  1.04x less |
| StructLinq               | .NET 8.0 | 100   | 468.1 ns | 8.03 ns |  7.51 ns | 466.6 ns | 1.58x slower |   0.04x | 0.1717 |     360 B |  2.56x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 409.8 ns | 8.24 ns | 12.58 ns | 405.5 ns | 1.39x slower |   0.05x | 0.1297 |     272 B |  3.38x less |
| Hyperlinq                | .NET 8.0 | 100   | 510.3 ns | 2.94 ns |  2.29 ns | 511.0 ns | 1.74x slower |   0.03x | 0.1297 |     272 B |  3.38x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 448.1 ns | 8.79 ns |  8.22 ns | 445.1 ns | 1.52x slower |   0.04x | 0.1297 |     272 B |  3.38x less |
|                          |          |       |          |         |          |          |              |         |        |           |             |
| ForeachLoop              | .NET 9.0 | 100   | 286.4 ns | 2.33 ns |  1.95 ns | 287.0 ns |     baseline |         | 0.4396 |     920 B |             |
| Linq                     | .NET 9.0 | 100   | 349.4 ns | 2.35 ns |  2.61 ns | 349.0 ns | 1.22x slower |   0.01x | 0.1874 |     392 B |  2.35x less |
| LinqAF                   | .NET 9.0 | 100   | 452.1 ns | 8.66 ns | 21.55 ns | 441.3 ns | 1.60x slower |   0.08x | 0.4244 |     888 B |  1.04x less |
| StructLinq               | .NET 9.0 | 100   | 471.9 ns | 3.81 ns |  3.57 ns | 471.5 ns | 1.65x slower |   0.02x | 0.1717 |     360 B |  2.56x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 363.5 ns | 7.29 ns | 11.56 ns | 358.7 ns | 1.28x slower |   0.05x | 0.1297 |     272 B |  3.38x less |
| Hyperlinq                | .NET 9.0 | 100   | 398.4 ns | 7.86 ns |  9.66 ns | 394.0 ns | 1.39x slower |   0.04x | 0.1297 |     272 B |  3.38x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 390.6 ns | 5.79 ns |  5.13 ns | 389.6 ns | 1.36x slower |   0.02x | 0.1297 |     272 B |  3.38x less |
