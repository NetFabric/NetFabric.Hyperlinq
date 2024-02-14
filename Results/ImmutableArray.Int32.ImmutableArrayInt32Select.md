## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
| ForLoop                  | .NET 8.0 | 100   |  45.47 ns | 0.806 ns |  0.792 ns |  45.19 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  49.42 ns | 0.995 ns |  1.941 ns |  48.62 ns | 1.09x slower |   0.04x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 188.19 ns | 3.772 ns |  9.254 ns | 183.56 ns | 4.17x slower |   0.22x | 0.0229 |      48 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 357.58 ns | 4.457 ns |  3.480 ns | 357.01 ns | 7.86x slower |   0.19x | 0.4320 |     904 B |          NA |
| StructLinq               | .NET 8.0 | 100   | 115.40 ns | 0.921 ns |  0.719 ns | 115.13 ns | 2.54x slower |   0.05x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  83.19 ns | 1.343 ns |  1.599 ns |  82.71 ns | 1.83x slower |   0.05x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |  67.25 ns | 0.249 ns |  0.233 ns |  67.30 ns | 1.48x slower |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  46.17 ns | 0.911 ns |  0.894 ns |  45.90 ns | 1.02x slower |   0.02x |      - |         - |          NA |
|                          |          |       |           |          |           |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  47.19 ns | 0.978 ns |  1.338 ns |  46.68 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  56.57 ns | 0.406 ns |  0.339 ns |  56.42 ns | 1.20x slower |   0.03x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 184.20 ns | 3.224 ns |  3.960 ns | 182.64 ns | 3.90x slower |   0.14x | 0.0229 |      48 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 368.52 ns | 6.433 ns | 10.924 ns | 364.97 ns | 7.83x slower |   0.33x | 0.4320 |     904 B |          NA |
| StructLinq               | .NET 9.0 | 100   | 139.49 ns | 0.789 ns |  0.700 ns | 139.26 ns | 2.95x slower |   0.09x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  58.38 ns | 0.544 ns |  0.509 ns |  58.20 ns | 1.23x slower |   0.04x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |  84.99 ns | 1.027 ns |  0.802 ns |  84.96 ns | 1.81x slower |   0.05x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  58.10 ns | 0.955 ns |  0.798 ns |  57.72 ns | 1.23x slower |   0.04x |      - |         - |          NA |
