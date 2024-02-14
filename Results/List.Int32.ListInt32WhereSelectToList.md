## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
| Method                   | Runtime  | Count | Mean     | Error   | StdDev   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|--------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   | 237.5 ns | 1.75 ns |  1.64 ns |     baseline |         | 0.3095 |     648 B |             |
| ForeachLoop              | .NET 8.0 | 100   | 227.2 ns | 2.80 ns |  2.48 ns | 1.04x faster |   0.01x | 0.3095 |     648 B |  1.00x more |
| Linq                     | .NET 8.0 | 100   | 363.1 ns | 4.37 ns |  5.83 ns | 1.53x slower |   0.03x | 0.3824 |     800 B |  1.23x more |
| LinqFaster               | .NET 8.0 | 100   | 294.2 ns | 5.52 ns |  4.89 ns | 1.24x slower |   0.03x | 0.4396 |     920 B |  1.42x more |
| LinqFasterer             | .NET 8.0 | 100   | 269.9 ns | 2.61 ns |  2.04 ns | 1.14x slower |   0.01x | 0.5622 |    1176 B |  1.81x more |
| LinqAF                   | .NET 8.0 | 100   | 454.7 ns | 3.60 ns |  3.01 ns | 1.92x slower |   0.02x | 0.3090 |     648 B |  1.00x more |
| StructLinq               | .NET 8.0 | 100   | 386.2 ns | 5.49 ns |  5.39 ns | 1.63x slower |   0.03x | 0.1760 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 295.9 ns | 2.25 ns |  1.76 ns | 1.25x slower |   0.01x | 0.1297 |     272 B |  2.38x less |
| Hyperlinq                | .NET 8.0 | 100   | 339.9 ns | 4.96 ns |  6.27 ns | 1.44x slower |   0.03x | 0.1297 |     272 B |  2.38x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 304.6 ns | 2.31 ns |  2.84 ns | 1.28x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
| Faslinq                  | .NET 8.0 | 100   | 344.6 ns | 5.86 ns |  7.41 ns | 1.45x slower |   0.03x | 0.3095 |     648 B |  1.00x more |
|                          |          |       |          |         |          |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   | 247.0 ns | 4.83 ns |  6.28 ns |     baseline |         | 0.3095 |     648 B |             |
| ForeachLoop              | .NET 9.0 | 100   | 260.7 ns | 3.17 ns |  2.97 ns | 1.05x slower |   0.04x | 0.3095 |     648 B |  1.00x more |
| Linq                     | .NET 9.0 | 100   | 317.9 ns | 4.82 ns |  4.03 ns | 1.27x slower |   0.04x | 0.3824 |     800 B |  1.23x more |
| LinqFaster               | .NET 9.0 | 100   | 300.0 ns | 5.96 ns | 11.34 ns | 1.22x slower |   0.06x | 0.4396 |     920 B |  1.42x more |
| LinqFasterer             | .NET 9.0 | 100   | 307.6 ns | 5.95 ns |  6.11 ns | 1.24x slower |   0.05x | 0.5622 |    1176 B |  1.81x more |
| LinqAF                   | .NET 9.0 | 100   | 430.1 ns | 8.60 ns | 11.48 ns | 1.74x slower |   0.07x | 0.3095 |     648 B |  1.00x more |
| StructLinq               | .NET 9.0 | 100   | 367.1 ns | 6.71 ns | 11.39 ns | 1.49x slower |   0.06x | 0.1760 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 266.6 ns | 2.95 ns |  2.61 ns | 1.07x slower |   0.03x | 0.1297 |     272 B |  2.38x less |
| Hyperlinq                | .NET 9.0 | 100   | 393.2 ns | 4.32 ns |  4.24 ns | 1.58x slower |   0.05x | 0.1297 |     272 B |  2.38x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 290.4 ns | 4.43 ns |  3.46 ns | 1.16x slower |   0.04x | 0.1297 |     272 B |  2.38x less |
| Faslinq                  | .NET 9.0 | 100   | 315.7 ns | 4.34 ns |  3.62 ns | 1.27x slower |   0.04x | 0.3095 |     648 B |  1.00x more |
