## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
| Method                   | Runtime  | Count | Mean      | Error    | StdDev    | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  71.98 ns | 0.829 ns |  0.692 ns |  71.76 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   | 117.82 ns | 2.394 ns |  5.354 ns | 114.99 ns | 1.65x slower |   0.07x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 262.81 ns | 5.153 ns |  6.328 ns | 260.79 ns | 3.65x slower |   0.11x | 0.0343 |      72 B |          NA |
| LinqFaster               | .NET 8.0 | 100   | 310.91 ns | 6.229 ns | 13.931 ns | 304.23 ns | 4.42x slower |   0.23x | 0.3095 |     648 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 265.05 ns | 3.529 ns |  3.128 ns | 263.85 ns | 3.68x slower |   0.05x | 0.3328 |     696 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 147.65 ns | 1.476 ns |  1.308 ns | 147.16 ns | 2.05x slower |   0.02x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 123.24 ns | 0.845 ns |  0.705 ns | 123.07 ns | 1.71x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  65.79 ns | 0.476 ns |  0.445 ns |  65.61 ns | 1.09x faster |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 110.41 ns | 2.251 ns |  4.059 ns | 108.76 ns | 1.54x slower |   0.05x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  86.94 ns | 1.265 ns |  1.506 ns |  86.65 ns | 1.20x slower |   0.02x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 386.02 ns | 5.421 ns |  6.243 ns | 384.17 ns | 5.38x slower |   0.12x | 0.3095 |     648 B |          NA |
|                          |          |       |           |          |           |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  84.37 ns | 0.547 ns |  0.427 ns |  84.23 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   | 113.60 ns | 0.791 ns |  0.660 ns | 113.32 ns | 1.35x slower |   0.01x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 255.11 ns | 3.910 ns |  4.655 ns | 253.32 ns | 3.01x slower |   0.05x | 0.0343 |      72 B |          NA |
| LinqFaster               | .NET 9.0 | 100   | 310.21 ns | 6.247 ns | 10.607 ns | 305.35 ns | 3.70x slower |   0.14x | 0.3095 |     648 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 258.07 ns | 3.062 ns |  2.864 ns | 257.42 ns | 3.06x slower |   0.04x | 0.3328 |     696 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 199.80 ns | 3.017 ns |  3.591 ns | 198.80 ns | 2.38x slower |   0.06x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 107.66 ns | 1.000 ns |  0.835 ns | 107.54 ns | 1.28x slower |   0.01x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  61.28 ns | 0.641 ns |  0.600 ns |  61.03 ns | 1.37x faster |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |  95.45 ns | 1.433 ns |  1.593 ns |  94.94 ns | 1.13x slower |   0.02x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  56.12 ns | 0.855 ns |  0.839 ns |  55.86 ns | 1.50x faster |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 369.06 ns | 7.225 ns |  7.730 ns | 365.08 ns | 4.37x slower |   0.10x | 0.3095 |     648 B |          NA |
