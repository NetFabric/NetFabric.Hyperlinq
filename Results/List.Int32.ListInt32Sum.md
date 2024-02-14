## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
| Method                   | Runtime  | Count | Mean      | Error    | StdDev   | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  59.49 ns | 1.231 ns | 1.600 ns |  58.75 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  65.52 ns | 0.282 ns | 0.220 ns |  65.48 ns | 1.09x slower |   0.03x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   |  16.99 ns | 0.255 ns | 0.331 ns |  16.85 ns | 3.50x faster |   0.12x |      - |         - |          NA |
| LinqFaster               | .NET 8.0 | 100   |  76.53 ns | 1.144 ns | 0.955 ns |  76.27 ns | 1.27x slower |   0.04x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   |  90.53 ns | 1.072 ns | 0.837 ns |  90.27 ns | 1.50x slower |   0.04x | 0.2027 |     424 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 256.69 ns | 4.842 ns | 5.382 ns | 254.59 ns | 4.30x slower |   0.16x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   |  60.39 ns | 0.324 ns | 0.270 ns |  60.25 ns | 1.00x slower |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  48.86 ns | 0.922 ns | 1.514 ns |  48.40 ns | 1.22x faster |   0.05x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |  12.48 ns | 0.282 ns | 0.732 ns |  12.14 ns | 4.77x faster |   0.28x |      - |         - |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  57.87 ns | 1.069 ns | 1.144 ns |  57.37 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  65.10 ns | 0.244 ns | 0.216 ns |  65.11 ns | 1.12x slower |   0.02x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   |  17.27 ns | 0.355 ns | 0.365 ns |  17.14 ns | 3.35x faster |   0.10x |      - |         - |          NA |
| LinqFaster               | .NET 9.0 | 100   |  82.60 ns | 1.272 ns | 1.190 ns |  82.09 ns | 1.43x slower |   0.04x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 103.46 ns | 1.822 ns | 2.942 ns | 102.43 ns | 1.79x slower |   0.04x | 0.2027 |     424 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 253.66 ns | 2.539 ns | 2.120 ns | 252.71 ns | 4.38x slower |   0.09x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   |  60.38 ns | 0.585 ns | 0.457 ns |  60.21 ns | 1.04x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  45.28 ns | 0.937 ns | 2.315 ns |  44.37 ns | 1.29x faster |   0.06x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |  11.51 ns | 0.167 ns | 0.164 ns |  11.50 ns | 5.04x faster |   0.07x |      - |         - |          NA |
