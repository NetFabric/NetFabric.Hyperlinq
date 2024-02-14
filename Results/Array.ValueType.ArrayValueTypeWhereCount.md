## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
| Method                   | Runtime  | Count | Mean      | Error    | StdDev   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  66.68 ns | 0.849 ns | 1.162 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  66.40 ns | 0.581 ns | 0.515 ns | 1.00x faster |   0.02x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 253.35 ns | 2.793 ns | 2.476 ns | 3.80x slower |   0.07x | 0.0153 |      32 B |          NA |
| LinqFaster               | .NET 8.0 | 100   | 128.58 ns | 1.843 ns | 2.263 ns | 1.93x slower |   0.05x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 128.34 ns | 2.365 ns | 2.428 ns | 1.92x slower |   0.06x |      - |         - |          NA |
| LinqAF                   | .NET 8.0 | 100   | 275.85 ns | 5.101 ns | 4.771 ns | 4.13x slower |   0.10x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 155.25 ns | 2.102 ns | 1.641 ns | 2.33x slower |   0.05x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  59.06 ns | 0.650 ns | 0.576 ns | 1.13x faster |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 125.68 ns | 0.746 ns | 0.661 ns | 1.89x slower |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  66.70 ns | 0.503 ns | 0.470 ns | 1.00x faster |   0.02x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 525.27 ns | 3.216 ns | 2.685 ns | 7.87x slower |   0.14x | 3.0670 |    6424 B |          NA |
|                          |          |       |           |          |          |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  65.78 ns | 0.655 ns | 0.547 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  65.70 ns | 0.322 ns | 0.269 ns | 1.00x faster |   0.01x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 231.33 ns | 4.364 ns | 6.532 ns | 3.54x slower |   0.15x | 0.0153 |      32 B |          NA |
| LinqFaster               | .NET 9.0 | 100   | 128.35 ns | 1.637 ns | 1.451 ns | 1.95x slower |   0.01x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 120.39 ns | 0.913 ns | 0.854 ns | 1.83x slower |   0.02x |      - |         - |          NA |
| LinqAF                   | .NET 9.0 | 100   | 278.45 ns | 2.741 ns | 2.430 ns | 4.23x slower |   0.07x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 143.02 ns | 2.061 ns | 1.827 ns | 2.17x slower |   0.02x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  89.84 ns | 0.601 ns | 0.668 ns | 1.37x slower |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 119.12 ns | 0.599 ns | 0.500 ns | 1.81x slower |   0.02x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  64.98 ns | 0.509 ns | 0.425 ns | 1.01x faster |   0.01x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 526.48 ns | 4.238 ns | 3.757 ns | 8.01x slower |   0.08x | 3.0670 |    6424 B |          NA |
