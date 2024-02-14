## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
| ForLoop                  | .NET 8.0 | 100   | 300.0 ns | 3.76 ns |  4.02 ns | 298.7 ns |     baseline |         | 0.4244 |     888 B |             |
| ForeachLoop              | .NET 8.0 | 100   | 316.0 ns | 4.33 ns |  3.61 ns | 314.6 ns | 1.05x slower |   0.02x | 0.4244 |     888 B |  1.00x more |
| Linq                     | .NET 8.0 | 100   | 369.1 ns | 7.43 ns | 17.66 ns | 361.0 ns | 1.22x slower |   0.04x | 0.4015 |     840 B |  1.06x less |
| LinqFaster               | .NET 8.0 | 100   | 279.5 ns | 4.85 ns |  4.54 ns | 279.1 ns | 1.07x faster |   0.02x | 0.4244 |     888 B |  1.00x more |
| LinqFasterer             | .NET 8.0 | 100   | 213.4 ns | 2.66 ns |  2.35 ns | 212.7 ns | 1.41x faster |   0.03x | 0.4320 |     904 B |  1.02x more |
| LinqAF                   | .NET 8.0 | 100   | 457.6 ns | 8.92 ns | 11.28 ns | 455.0 ns | 1.53x slower |   0.05x | 0.4091 |     856 B |  1.04x less |
| StructLinq               | .NET 8.0 | 100   | 381.7 ns | 2.69 ns |  2.99 ns | 381.7 ns | 1.27x slower |   0.02x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 310.5 ns | 5.56 ns |  4.34 ns | 309.6 ns | 1.04x slower |   0.02x | 0.1144 |     240 B |  3.70x less |
| Hyperlinq                | .NET 8.0 | 100   | 345.9 ns | 5.92 ns |  6.81 ns | 343.8 ns | 1.15x slower |   0.03x | 0.1144 |     240 B |  3.70x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 298.6 ns | 5.67 ns |  4.43 ns | 297.2 ns | 1.00x faster |   0.02x | 0.1144 |     240 B |  3.70x less |
| Faslinq                  | .NET 8.0 | 100   | 393.9 ns | 7.92 ns | 19.14 ns | 385.4 ns | 1.31x slower |   0.07x | 0.4244 |     888 B |  1.00x more |
|                          |          |       |          |         |          |          |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   | 312.3 ns | 6.25 ns | 16.46 ns | 304.0 ns |     baseline |         | 0.4244 |     888 B |             |
| ForeachLoop              | .NET 9.0 | 100   | 279.5 ns | 5.63 ns |  7.52 ns | 277.6 ns | 1.12x faster |   0.07x | 0.4244 |     888 B |  1.00x more |
| Linq                     | .NET 9.0 | 100   | 284.8 ns | 5.41 ns |  4.52 ns | 283.0 ns | 1.09x faster |   0.03x | 0.1874 |     392 B |  2.27x less |
| LinqFaster               | .NET 9.0 | 100   | 284.7 ns | 5.29 ns |  7.76 ns | 282.3 ns | 1.09x faster |   0.05x | 0.4244 |     888 B |  1.00x more |
| LinqFasterer             | .NET 9.0 | 100   | 293.3 ns | 3.95 ns |  3.30 ns | 291.5 ns | 1.06x faster |   0.04x | 0.4320 |     904 B |  1.02x more |
| LinqAF                   | .NET 9.0 | 100   | 447.2 ns | 3.40 ns |  3.18 ns | 446.8 ns | 1.44x slower |   0.05x | 0.4091 |     856 B |  1.04x less |
| StructLinq               | .NET 9.0 | 100   | 361.0 ns | 5.76 ns |  4.49 ns | 359.8 ns | 1.16x slower |   0.05x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 257.5 ns | 5.06 ns |  6.22 ns | 256.1 ns | 1.22x faster |   0.07x | 0.1144 |     240 B |  3.70x less |
| Hyperlinq                | .NET 9.0 | 100   | 355.1 ns | 7.12 ns | 16.65 ns | 347.5 ns | 1.13x slower |   0.07x | 0.1144 |     240 B |  3.70x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 311.4 ns | 3.50 ns |  2.74 ns | 311.0 ns | 1.00x slower |   0.04x | 0.1144 |     240 B |  3.70x less |
| Faslinq                  | .NET 9.0 | 100   | 403.5 ns | 8.18 ns |  9.42 ns | 399.1 ns | 1.29x slower |   0.07x | 0.4244 |     888 B |  1.00x more |
