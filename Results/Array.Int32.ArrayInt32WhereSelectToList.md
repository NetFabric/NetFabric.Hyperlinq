## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
| ForLoop                  | .NET 8.0 | 100   | 232.4 ns | 2.35 ns |  2.09 ns | 231.5 ns |     baseline |         | 0.3095 |     648 B |             |
| ForeachLoop              | .NET 8.0 | 100   | 230.1 ns | 3.34 ns |  2.79 ns | 229.4 ns | 1.01x faster |   0.01x | 0.3095 |     648 B |  1.00x more |
| Linq                     | .NET 8.0 | 100   | 320.9 ns | 3.69 ns |  3.08 ns | 320.0 ns | 1.38x slower |   0.02x | 0.3595 |     752 B |  1.16x more |
| LinqFaster               | .NET 8.0 | 100   | 233.6 ns | 4.27 ns |  3.79 ns | 232.8 ns | 1.01x slower |   0.02x | 0.4473 |     936 B |  1.44x more |
| LinqFasterer             | .NET 8.0 | 100   | 350.3 ns | 5.61 ns |  7.86 ns | 347.5 ns | 1.52x slower |   0.05x | 0.6118 |    1280 B |  1.98x more |
| LinqAF                   | .NET 8.0 | 100   | 418.3 ns | 7.99 ns |  8.88 ns | 414.1 ns | 1.81x slower |   0.05x | 0.3095 |     648 B |  1.00x more |
| StructLinq               | .NET 8.0 | 100   | 384.3 ns | 7.68 ns | 16.20 ns | 378.4 ns | 1.66x slower |   0.09x | 0.1760 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 305.4 ns | 4.33 ns |  3.62 ns | 304.1 ns | 1.31x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
| Hyperlinq                | .NET 8.0 | 100   | 338.5 ns | 2.70 ns |  2.65 ns | 338.2 ns | 1.46x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 305.8 ns | 5.47 ns | 12.00 ns | 300.6 ns | 1.31x slower |   0.05x | 0.1297 |     272 B |  2.38x less |
| Faslinq                  | .NET 8.0 | 100   | 236.5 ns | 3.60 ns |  3.01 ns | 235.0 ns | 1.02x slower |   0.01x | 0.4206 |     880 B |  1.36x more |
|                          |          |       |          |         |          |          |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   | 232.9 ns | 3.31 ns |  2.58 ns | 231.8 ns |     baseline |         | 0.3095 |     648 B |             |
| ForeachLoop              | .NET 9.0 | 100   | 213.2 ns | 3.84 ns |  7.12 ns | 210.7 ns | 1.10x faster |   0.04x | 0.3097 |     648 B |  1.00x more |
| Linq                     | .NET 9.0 | 100   | 353.1 ns | 6.25 ns |  5.54 ns | 352.1 ns | 1.52x slower |   0.03x | 0.3595 |     752 B |  1.16x more |
| LinqFaster               | .NET 9.0 | 100   | 222.3 ns | 4.46 ns |  8.91 ns | 218.0 ns | 1.06x faster |   0.03x | 0.4475 |     936 B |  1.44x more |
| LinqFasterer             | .NET 9.0 | 100   | 339.4 ns | 3.41 ns |  2.84 ns | 340.1 ns | 1.46x slower |   0.02x | 0.6118 |    1280 B |  1.98x more |
| LinqAF                   | .NET 9.0 | 100   | 384.2 ns | 4.51 ns |  3.76 ns | 383.2 ns | 1.65x slower |   0.03x | 0.3090 |     648 B |  1.00x more |
| StructLinq               | .NET 9.0 | 100   | 369.2 ns | 6.82 ns |  7.86 ns | 368.0 ns | 1.59x slower |   0.05x | 0.1760 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 346.8 ns | 4.28 ns |  3.34 ns | 345.7 ns | 1.49x slower |   0.03x | 0.1297 |     272 B |  2.38x less |
| Hyperlinq                | .NET 9.0 | 100   | 359.7 ns | 6.83 ns | 16.50 ns | 351.9 ns | 1.55x slower |   0.07x | 0.1297 |     272 B |  2.38x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 286.4 ns | 3.83 ns |  3.40 ns | 285.7 ns | 1.23x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
| Faslinq                  | .NET 9.0 | 100   | 237.5 ns | 4.78 ns | 10.29 ns | 232.2 ns | 1.03x slower |   0.06x | 0.4206 |     880 B |  1.36x more |
