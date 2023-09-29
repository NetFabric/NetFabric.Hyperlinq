## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|                   Method |  Runtime | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |  40.86 ns | 0.357 ns | 0.279 ns |  40.76 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |  42.17 ns | 0.855 ns | 1.050 ns |  41.66 ns | 1.03x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 |  32.89 ns | 0.184 ns | 0.143 ns |  32.89 ns | 1.24x faster |   0.01x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 |  69.92 ns | 0.921 ns | 1.023 ns |  69.51 ns | 1.71x slower |   0.04x | 0.2142 |     448 B |          NA |
|               StructLinq | .NET 6.0 |   100 | 100.59 ns | 1.103 ns | 0.861 ns | 100.48 ns | 2.46x slower |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |  75.76 ns | 1.456 ns | 1.496 ns |  75.22 ns | 1.86x slower |   0.05x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 |  38.09 ns | 0.560 ns | 0.496 ns |  38.23 ns | 1.07x faster |   0.02x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 6.0 |   100 |  24.24 ns | 0.139 ns | 0.123 ns |  24.25 ns | 1.68x faster |   0.01x |      - |         - |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  40.45 ns | 0.834 ns | 1.142 ns |  39.91 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  43.20 ns | 0.803 ns | 0.892 ns |  43.01 ns | 1.07x slower |   0.04x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |  14.33 ns | 0.074 ns | 0.066 ns |  14.30 ns | 2.82x faster |   0.09x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 |  49.99 ns | 0.466 ns | 0.413 ns |  50.12 ns | 1.24x slower |   0.04x | 0.2142 |     448 B |          NA |
|               StructLinq | .NET 8.0 |   100 |  84.35 ns | 1.630 ns | 3.544 ns |  82.42 ns | 2.09x slower |   0.08x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  85.12 ns | 0.613 ns | 0.478 ns |  84.95 ns | 2.12x slower |   0.05x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |  19.25 ns | 0.455 ns | 1.307 ns |  18.82 ns | 2.05x faster |   0.13x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 8.0 |   100 |  13.20 ns | 0.290 ns | 0.459 ns |  12.97 ns | 3.05x faster |   0.15x |      - |         - |          NA |
