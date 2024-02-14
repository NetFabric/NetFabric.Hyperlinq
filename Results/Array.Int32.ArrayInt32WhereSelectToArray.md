## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
| ForLoop                  | .NET 8.0 | 100   | 242.5 ns | 4.49 ns | 10.04 ns | 238.4 ns |     baseline |         | 0.4246 |     888 B |             |
| ForeachLoop              | .NET 8.0 | 100   | 235.4 ns | 4.46 ns |  3.73 ns | 234.2 ns | 1.02x faster |   0.05x | 0.4244 |     888 B |  1.00x more |
| Linq                     | .NET 8.0 | 100   | 308.5 ns | 2.49 ns |  2.08 ns | 308.6 ns | 1.29x slower |   0.05x | 0.3786 |     792 B |  1.12x less |
| LinqFaster               | .NET 8.0 | 100   | 194.4 ns | 3.54 ns |  9.14 ns | 191.2 ns | 1.24x faster |   0.08x | 0.3173 |     664 B |  1.34x less |
| LinqFasterer             | .NET 8.0 | 100   | 301.8 ns | 2.77 ns |  2.46 ns | 301.6 ns | 1.26x slower |   0.05x | 0.3977 |     832 B |  1.07x less |
| LinqAF                   | .NET 8.0 | 100   | 372.4 ns | 7.40 ns |  8.81 ns | 370.4 ns | 1.55x slower |   0.07x | 0.4091 |     856 B |  1.04x less |
| StructLinq               | .NET 8.0 | 100   | 369.6 ns | 7.12 ns |  8.20 ns | 366.7 ns | 1.54x slower |   0.07x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 292.0 ns | 2.62 ns |  3.21 ns | 291.4 ns | 1.22x slower |   0.04x | 0.1144 |     240 B |  3.70x less |
| Hyperlinq                | .NET 8.0 | 100   | 340.8 ns | 4.82 ns |  4.02 ns | 339.4 ns | 1.42x slower |   0.05x | 0.1144 |     240 B |  3.70x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 278.8 ns | 2.89 ns |  2.25 ns | 278.9 ns | 1.16x slower |   0.04x | 0.1144 |     240 B |  3.70x less |
| Faslinq                  | .NET 8.0 | 100   | 177.7 ns | 2.99 ns |  2.79 ns | 177.2 ns | 1.36x faster |   0.06x | 0.2027 |     424 B |  2.09x less |
|                          |          |       |          |         |          |          |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   | 250.8 ns | 4.91 ns |  5.46 ns | 249.4 ns |     baseline |         | 0.4244 |     888 B |             |
| ForeachLoop              | .NET 9.0 | 100   | 237.9 ns | 4.03 ns |  3.57 ns | 238.4 ns | 1.06x faster |   0.03x | 0.4244 |     888 B |  1.00x more |
| Linq                     | .NET 9.0 | 100   | 311.2 ns | 6.23 ns |  8.74 ns | 307.3 ns | 1.24x slower |   0.05x | 0.1640 |     344 B |  2.58x less |
| LinqFaster               | .NET 9.0 | 100   | 186.6 ns | 2.55 ns |  2.13 ns | 185.8 ns | 1.35x faster |   0.03x | 0.3173 |     664 B |  1.34x less |
| LinqFasterer             | .NET 9.0 | 100   | 304.4 ns | 3.72 ns |  4.96 ns | 302.8 ns | 1.21x slower |   0.04x | 0.3977 |     832 B |  1.07x less |
| LinqAF                   | .NET 9.0 | 100   | 375.7 ns | 6.94 ns | 14.48 ns | 371.2 ns | 1.50x slower |   0.08x | 0.4091 |     856 B |  1.04x less |
| StructLinq               | .NET 9.0 | 100   | 363.4 ns | 7.03 ns |  7.81 ns | 360.9 ns | 1.45x slower |   0.05x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 330.9 ns | 6.38 ns |  7.84 ns | 328.0 ns | 1.32x slower |   0.05x | 0.1144 |     240 B |  3.70x less |
| Hyperlinq                | .NET 9.0 | 100   | 336.7 ns | 3.41 ns |  2.85 ns | 337.9 ns | 1.34x slower |   0.03x | 0.1144 |     240 B |  3.70x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 313.1 ns | 6.04 ns |  4.71 ns | 311.1 ns | 1.24x slower |   0.04x | 0.1144 |     240 B |  3.70x less |
| Faslinq                  | .NET 9.0 | 100   | 177.1 ns | 2.73 ns |  2.28 ns | 176.2 ns | 1.42x faster |   0.04x | 0.2027 |     424 B |  2.09x less |
