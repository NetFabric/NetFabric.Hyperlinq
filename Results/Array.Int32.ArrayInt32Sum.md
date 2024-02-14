## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
| Method                   | Runtime  | Count | Mean      | Error    | StdDev   | Median     | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  40.88 ns | 0.643 ns | 0.537 ns |  40.719 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  40.80 ns | 0.307 ns | 0.256 ns |  40.841 ns | 1.00x faster |   0.02x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   |  17.82 ns | 0.381 ns | 0.439 ns |  17.648 ns | 2.29x faster |   0.08x |      - |         - |          NA |
| LinqFaster               | .NET 8.0 | 100   |  43.01 ns | 0.902 ns | 0.926 ns |  42.627 ns | 1.06x slower |   0.03x |      - |         - |          NA |
| LinqFaster_SIMD          | .NET 8.0 | 100   |  14.09 ns | 0.288 ns | 0.554 ns |  13.884 ns | 2.84x faster |   0.16x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   |  83.58 ns | 0.367 ns | 0.307 ns |  83.606 ns | 2.04x slower |   0.02x |      - |         - |          NA |
| LinqAF                   | .NET 8.0 | 100   | 222.67 ns | 4.316 ns | 4.432 ns | 220.784 ns | 5.47x slower |   0.14x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   |  62.05 ns | 0.531 ns | 0.471 ns |  61.876 ns | 1.52x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  83.18 ns | 1.075 ns | 0.898 ns |  82.794 ns | 2.03x slower |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |  11.25 ns | 0.255 ns | 0.559 ns |  11.317 ns | 3.79x faster |   0.18x |      - |         - |          NA |
|                          |          |       |           |          |          |            |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  41.48 ns | 0.391 ns | 0.326 ns |  41.441 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  43.56 ns | 0.893 ns | 0.917 ns |  43.218 ns | 1.05x slower |   0.03x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   |  17.44 ns | 0.203 ns | 0.159 ns |  17.404 ns | 2.38x faster |   0.03x |      - |         - |          NA |
| LinqFaster               | .NET 9.0 | 100   |  42.81 ns | 0.876 ns | 0.900 ns |  42.445 ns | 1.04x slower |   0.03x |      - |         - |          NA |
| LinqFaster_SIMD          | .NET 9.0 | 100   |  16.85 ns | 0.208 ns | 0.163 ns |  16.794 ns | 2.46x faster |   0.03x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   |  59.40 ns | 0.524 ns | 0.438 ns |  59.321 ns | 1.43x slower |   0.01x |      - |         - |          NA |
| LinqAF                   | .NET 9.0 | 100   | 220.98 ns | 4.363 ns | 4.285 ns | 218.685 ns | 5.34x slower |   0.13x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   |  61.13 ns | 1.118 ns | 0.991 ns |  60.796 ns | 1.47x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  44.18 ns | 0.518 ns | 0.404 ns |  44.119 ns | 1.07x slower |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   |  10.16 ns | 0.228 ns | 0.624 ns |   9.863 ns | 4.00x faster |   0.25x |      - |         - |          NA |
