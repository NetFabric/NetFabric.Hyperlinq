## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|                   Method |  Runtime | Count |      Mean |    Error |    StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |  42.72 ns | 0.467 ns |  0.365 ns |  42.57 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |  44.24 ns | 0.590 ns |  0.656 ns |  43.99 ns |  1.04x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 444.83 ns | 7.212 ns |  6.394 ns | 443.57 ns | 10.41x slower |   0.17x | 0.0267 |      56 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 111.59 ns | 1.426 ns |  1.191 ns | 111.61 ns |  2.61x slower |   0.04x | 0.2142 |     448 B |          NA |
|               StructLinq | .NET 6.0 |   100 | 117.78 ns | 1.405 ns |  1.561 ns | 117.82 ns |  2.75x slower |   0.05x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |  59.76 ns | 0.310 ns |  0.259 ns |  59.77 ns |  1.40x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 |  22.00 ns | 0.401 ns |  0.477 ns |  21.79 ns |  1.95x faster |   0.04x |      - |         - |          NA |
|                          |          |       |           |          |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  39.62 ns | 0.314 ns |  0.262 ns |  39.54 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  38.01 ns | 0.533 ns |  0.947 ns |  37.65 ns |  1.05x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 187.96 ns | 3.797 ns | 10.330 ns | 185.51 ns |  4.74x slower |   0.26x | 0.0267 |      56 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 108.50 ns | 2.553 ns |  7.365 ns | 105.36 ns |  2.80x slower |   0.16x | 0.2142 |     448 B |          NA |
|               StructLinq | .NET 8.0 |   100 | 116.68 ns | 2.254 ns |  3.159 ns | 115.55 ns |  2.99x slower |   0.09x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  83.24 ns | 0.371 ns |  0.290 ns |  83.22 ns |  2.10x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |  11.19 ns | 0.256 ns |  0.652 ns |  10.90 ns |  3.50x faster |   0.19x |      - |         - |          NA |
