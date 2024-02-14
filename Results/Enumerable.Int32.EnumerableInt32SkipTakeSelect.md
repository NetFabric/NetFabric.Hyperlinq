## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
| Linq                     | .NET 8.0 | 1000 | 100   | 2.021 μs | 0.0031 μs | 0.0028 μs | 2.021 μs |     baseline |         | 0.0954 |     200 B |             |
| LinqAF                   | .NET 8.0 | 1000 | 100   | 1.600 μs | 0.0163 μs | 0.0136 μs | 1.604 μs | 1.26x faster |   0.01x | 0.0153 |      32 B |  6.25x less |
| StructLinq               | .NET 8.0 | 1000 | 100   | 1.633 μs | 0.0318 μs | 0.0514 μs | 1.614 μs | 1.25x faster |   0.04x | 0.0572 |     120 B |  1.67x less |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   | 1.667 μs | 0.0527 μs | 0.1512 μs | 1.597 μs | 1.27x faster |   0.07x | 0.0153 |      32 B |  6.25x less |
| Hyperlinq                | .NET 8.0 | 1000 | 100   | 1.563 μs | 0.0310 μs | 0.0706 μs | 1.525 μs | 1.29x faster |   0.06x | 0.0153 |      32 B |  6.25x less |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   | 1.578 μs | 0.0302 μs | 0.0283 μs | 1.566 μs | 1.28x faster |   0.02x | 0.0153 |      32 B |  6.25x less |
|                          |          |      |       |          |           |           |          |              |         |        |           |             |
| Linq                     | .NET 9.0 | 1000 | 100   | 1.993 μs | 0.0399 μs | 0.0698 μs | 1.957 μs |     baseline |         | 0.0954 |     200 B |             |
| LinqAF                   | .NET 9.0 | 1000 | 100   | 1.853 μs | 0.0359 μs | 0.0504 μs | 1.832 μs | 1.07x faster |   0.05x | 0.0153 |      32 B |  6.25x less |
| StructLinq               | .NET 9.0 | 1000 | 100   | 1.638 μs | 0.0324 μs | 0.0504 μs | 1.615 μs | 1.22x faster |   0.05x | 0.0572 |     120 B |  1.67x less |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   | 1.699 μs | 0.0331 μs | 0.0418 μs | 1.692 μs | 1.17x faster |   0.05x | 0.0153 |      32 B |  6.25x less |
| Hyperlinq                | .NET 9.0 | 1000 | 100   | 1.524 μs | 0.0284 μs | 0.0237 μs | 1.514 μs | 1.32x faster |   0.05x | 0.0153 |      32 B |  6.25x less |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   | 1.520 μs | 0.0082 μs | 0.0073 μs | 1.517 μs | 1.32x faster |   0.05x | 0.0153 |      32 B |  6.25x less |
