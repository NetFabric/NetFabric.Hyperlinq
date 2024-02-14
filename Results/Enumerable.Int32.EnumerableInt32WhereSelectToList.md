## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
| ForeachLoop              | .NET 8.0 | 100   | 274.9 ns | 5.03 ns |  7.69 ns | 272.3 ns |     baseline |         | 0.3247 |     680 B |             |
| Linq                     | .NET 8.0 | 100   | 336.3 ns | 4.91 ns |  3.84 ns | 335.6 ns | 1.22x slower |   0.04x | 0.3824 |     800 B |  1.18x more |
| LinqAF                   | .NET 8.0 | 100   | 425.0 ns | 4.42 ns |  4.35 ns | 424.9 ns | 1.55x slower |   0.05x | 0.3247 |     680 B |  1.00x more |
| StructLinq               | .NET 8.0 | 100   | 465.3 ns | 2.93 ns |  2.60 ns | 464.2 ns | 1.69x slower |   0.05x | 0.1869 |     392 B |  1.73x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 413.6 ns | 5.88 ns |  5.21 ns | 413.0 ns | 1.50x slower |   0.04x | 0.1450 |     304 B |  2.24x less |
| Hyperlinq                | .NET 8.0 | 100   | 521.3 ns | 9.44 ns |  7.37 ns | 520.6 ns | 1.89x slower |   0.05x | 0.1450 |     304 B |  2.24x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 463.1 ns | 9.10 ns |  9.35 ns | 461.2 ns | 1.68x slower |   0.05x | 0.1450 |     304 B |  2.24x less |
|                          |          |       |          |         |          |          |              |         |        |           |             |
| ForeachLoop              | .NET 9.0 | 100   | 269.2 ns | 3.33 ns |  2.78 ns | 268.2 ns |     baseline |         | 0.3247 |     680 B |             |
| Linq                     | .NET 9.0 | 100   | 319.8 ns | 3.35 ns |  2.79 ns | 319.0 ns | 1.19x slower |   0.02x | 0.3824 |     800 B |  1.18x more |
| LinqAF                   | .NET 9.0 | 100   | 416.9 ns | 5.74 ns |  5.37 ns | 414.6 ns | 1.55x slower |   0.02x | 0.3242 |     680 B |  1.00x more |
| StructLinq               | .NET 9.0 | 100   | 478.0 ns | 4.07 ns |  3.40 ns | 476.5 ns | 1.78x slower |   0.03x | 0.1869 |     392 B |  1.73x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 366.9 ns | 7.32 ns | 15.91 ns | 359.4 ns | 1.38x slower |   0.08x | 0.1450 |     304 B |  2.24x less |
| Hyperlinq                | .NET 9.0 | 100   | 407.4 ns | 2.84 ns |  3.16 ns | 407.1 ns | 1.51x slower |   0.02x | 0.1450 |     304 B |  2.24x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 401.8 ns | 8.05 ns | 16.80 ns | 395.5 ns | 1.49x slower |   0.06x | 0.1450 |     304 B |  2.24x less |
