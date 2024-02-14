## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
| LinqAF                   | .NET 8.0 | 100   | 228.3 ns | 4.06 ns |  7.01 ns | 224.9 ns | 1.46x faster |   0.06x | 0.0153 |      32 B |  2.75x less |
| StructLinq               | .NET 8.0 | 100   | 238.6 ns | 2.54 ns |  2.38 ns | 238.6 ns | 1.41x faster |   0.05x | 0.0267 |      56 B |  1.57x less |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 204.0 ns | 2.34 ns |  2.07 ns | 203.6 ns | 1.65x faster |   0.07x | 0.0153 |      32 B |  2.75x less |
| Hyperlinq                | .NET 8.0 | 100   | 218.2 ns | 3.98 ns |  4.26 ns | 216.8 ns | 1.53x faster |   0.06x | 0.0153 |      32 B |  2.75x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 203.7 ns | 4.04 ns |  5.40 ns | 201.3 ns | 1.64x faster |   0.08x | 0.0153 |      32 B |  2.75x less |
| Linq                     | .NET 8.0 | 100   | 332.9 ns | 6.69 ns | 11.54 ns | 327.0 ns |     baseline |         | 0.0420 |      88 B |             |
|                          |          |       |          |         |          |          |              |         |        |           |             |
| LinqAF                   | .NET 9.0 | 100   | 244.0 ns | 1.91 ns |  1.49 ns | 243.8 ns | 1.37x faster |   0.04x | 0.0153 |      32 B |  2.75x less |
| StructLinq               | .NET 9.0 | 100   | 201.0 ns | 4.02 ns |  4.13 ns | 198.9 ns | 1.66x faster |   0.07x | 0.0267 |      56 B |  1.57x less |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 169.1 ns | 1.80 ns |  1.41 ns | 168.7 ns | 1.97x faster |   0.04x | 0.0153 |      32 B |  2.75x less |
| Hyperlinq                | .NET 9.0 | 100   | 235.3 ns | 4.71 ns |  4.83 ns | 233.5 ns | 1.42x faster |   0.05x | 0.0153 |      32 B |  2.75x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 172.8 ns | 3.36 ns |  4.37 ns | 171.6 ns | 1.94x faster |   0.08x | 0.0153 |      32 B |  2.75x less |
| Linq                     | .NET 9.0 | 100   | 333.8 ns | 6.40 ns |  9.37 ns | 329.9 ns |     baseline |         | 0.0420 |      88 B |             |
