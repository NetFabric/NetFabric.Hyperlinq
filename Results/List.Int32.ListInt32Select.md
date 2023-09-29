## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3516/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-rc.1.23463.5
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-VLSRZF : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-CRYVOQ : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2


```
|                   Method |  Runtime | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 | 108.73 ns |  2.072 ns |  1.938 ns | 107.86 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 161.86 ns |  1.704 ns |  1.423 ns | 161.61 ns | 1.49x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 802.65 ns | 16.075 ns | 33.198 ns | 786.21 ns | 7.43x slower |   0.33x | 0.0343 |      72 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 452.24 ns |  5.619 ns |  5.770 ns | 450.29 ns | 4.16x slower |   0.08x | 0.2179 |     456 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 613.57 ns |  8.535 ns |  7.566 ns | 614.29 ns | 5.64x slower |   0.15x | 0.4196 |     880 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 395.98 ns |  2.998 ns |  3.333 ns | 396.18 ns | 3.64x slower |   0.07x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 206.33 ns |  2.559 ns |  2.394 ns | 205.71 ns | 1.90x slower |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 159.41 ns |  0.629 ns |  0.557 ns | 159.30 ns | 1.47x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 206.99 ns |  3.732 ns |  2.914 ns | 205.54 ns | 1.90x slower |   0.05x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 175.29 ns |  0.647 ns |  0.505 ns | 175.33 ns | 1.61x slower |   0.03x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 556.15 ns |  5.343 ns |  4.462 ns | 553.86 ns | 5.11x slower |   0.09x | 0.5655 |    1184 B |          NA |
|                          |          |       |           |           |           |           |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  70.33 ns |  1.043 ns |  0.871 ns |  70.09 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 | 110.16 ns |  2.112 ns |  2.892 ns | 108.60 ns | 1.56x slower |   0.04x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 294.27 ns |  1.856 ns |  1.645 ns | 293.65 ns | 4.19x slower |   0.05x | 0.0343 |      72 B |          NA |
|               LinqFaster | .NET 8.0 |   100 | 295.68 ns |  2.894 ns |  2.565 ns | 295.33 ns | 4.21x slower |   0.07x | 0.2179 |     456 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 282.03 ns |  1.485 ns |  1.159 ns | 281.69 ns | 4.02x slower |   0.05x | 0.4206 |     880 B |          NA |
|                   LinqAF | .NET 8.0 |   100 | 214.97 ns |  1.172 ns |  1.039 ns | 214.47 ns | 3.06x slower |   0.04x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |  91.24 ns |  0.903 ns |  0.966 ns |  90.97 ns | 1.30x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  59.09 ns |  0.823 ns |  0.729 ns |  58.80 ns | 1.19x faster |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 | 136.20 ns |  0.562 ns |  0.469 ns | 136.19 ns | 1.94x slower |   0.03x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  48.22 ns |  0.478 ns |  0.424 ns |  48.12 ns | 1.46x faster |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 424.31 ns |  4.481 ns |  3.499 ns | 423.18 ns | 6.05x slower |   0.07x | 0.5660 |    1184 B |          NA |
