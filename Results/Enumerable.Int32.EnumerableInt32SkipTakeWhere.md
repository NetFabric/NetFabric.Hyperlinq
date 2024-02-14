## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
| Method                   | Runtime  | Skip | Count | Mean     | Error     | StdDev    | Median   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |---------:|----------:|----------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| Linq                     | .NET 8.0 | 1000 | 100   | 2.017 μs | 0.0111 μs | 0.0093 μs | 2.015 μs |     baseline |         | 0.0954 |     200 B |             |
| LinqAF                   | .NET 8.0 | 1000 | 100   | 1.655 μs | 0.0283 μs | 0.0237 μs | 1.649 μs | 1.22x faster |   0.02x | 0.0153 |      32 B |  6.25x less |
| StructLinq               | .NET 8.0 | 1000 | 100   | 1.733 μs | 0.0346 μs | 0.0496 μs | 1.711 μs | 1.17x faster |   0.03x | 0.0572 |     120 B |  1.67x less |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   | 1.571 μs | 0.0204 μs | 0.0160 μs | 1.569 μs | 1.28x faster |   0.01x | 0.0153 |      32 B |  6.25x less |
| Hyperlinq                | .NET 8.0 | 1000 | 100   | 1.882 μs | 0.0374 μs | 0.0747 μs | 1.839 μs | 1.07x faster |   0.04x | 0.0153 |      32 B |  6.25x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   | 1.871 μs | 0.0359 μs | 0.0810 μs | 1.831 μs | 1.08x faster |   0.05x | 0.0153 |      32 B |  6.25x less |
|                          |          |      |       |          |           |           |          |              |         |        |           |             |
| Linq                     | .NET 9.0 | 1000 | 100   | 2.202 μs | 0.0176 μs | 0.0156 μs | 2.198 μs |     baseline |         | 0.0954 |     200 B |             |
| LinqAF                   | .NET 9.0 | 1000 | 100   | 2.063 μs | 0.0058 μs | 0.0045 μs | 2.062 μs | 1.07x faster |   0.01x | 0.0153 |      32 B |  6.25x less |
| StructLinq               | .NET 9.0 | 1000 | 100   | 1.669 μs | 0.0244 μs | 0.0229 μs | 1.662 μs | 1.32x faster |   0.02x | 0.0572 |     120 B |  1.67x less |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   | 1.789 μs | 0.0284 μs | 0.0291 μs | 1.775 μs | 1.23x faster |   0.02x | 0.0153 |      32 B |  6.25x less |
| Hyperlinq                | .NET 9.0 | 1000 | 100   | 1.602 μs | 0.0190 μs | 0.0148 μs | 1.597 μs | 1.37x faster |   0.01x | 0.0153 |      32 B |  6.25x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   | 1.646 μs | 0.0302 μs | 0.0528 μs | 1.617 μs | 1.34x faster |   0.05x | 0.0153 |      32 B |  6.25x less |
