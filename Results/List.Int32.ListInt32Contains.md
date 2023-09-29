## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|                  ForLoop | .NET 6.0 |   100 | 109.89 ns | 1.847 ns | 2.199 ns | 109.07 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 162.54 ns | 1.204 ns | 1.005 ns | 162.39 ns | 1.48x slower |   0.02x |      - |         - |          NA |
|              List_Exists | .NET 6.0 |   100 | 193.04 ns | 1.318 ns | 1.294 ns | 192.79 ns | 1.75x slower |   0.04x | 0.0305 |      64 B |          NA |
|                     Linq | .NET 6.0 |   100 |  33.41 ns | 0.192 ns | 0.179 ns |  33.36 ns | 3.30x faster |   0.07x |      - |         - |          NA |
|               LinqFaster | .NET 6.0 |   100 |  32.49 ns | 0.137 ns | 0.121 ns |  32.47 ns | 3.40x faster |   0.08x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 |  69.22 ns | 0.445 ns | 0.395 ns |  69.28 ns | 1.60x faster |   0.03x | 0.2027 |     424 B |          NA |
|                   LinqAF | .NET 6.0 |   100 |  30.27 ns | 0.120 ns | 0.100 ns |  30.25 ns | 3.64x faster |   0.07x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 |  79.27 ns | 1.590 ns | 1.633 ns |  78.95 ns | 1.39x faster |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |  63.97 ns | 1.247 ns | 1.041 ns |  63.74 ns | 1.72x faster |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 |  39.70 ns | 0.250 ns | 0.196 ns |  39.64 ns | 2.77x faster |   0.05x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 6.0 |   100 |  25.34 ns | 0.458 ns | 0.596 ns |  25.05 ns | 4.33x faster |   0.16x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 196.19 ns | 3.317 ns | 2.769 ns | 194.95 ns | 1.78x slower |   0.02x | 0.0305 |      64 B |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  83.87 ns | 1.609 ns | 1.853 ns |  83.04 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  72.55 ns | 0.306 ns | 0.255 ns |  72.58 ns | 1.16x faster |   0.03x |      - |         - |          NA |
|              List_Exists | .NET 8.0 |   100 |  98.66 ns | 2.037 ns | 5.844 ns |  96.88 ns | 1.17x slower |   0.08x | 0.0305 |      64 B |          NA |
|                     Linq | .NET 8.0 |   100 |  12.42 ns | 0.062 ns | 0.069 ns |  12.40 ns | 6.75x faster |   0.14x |      - |         - |          NA |
|               LinqFaster | .NET 8.0 |   100 |  11.96 ns | 0.057 ns | 0.050 ns |  11.94 ns | 7.04x faster |   0.19x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 |  50.95 ns | 1.048 ns | 2.723 ns |  49.92 ns | 1.62x faster |   0.07x | 0.2027 |     424 B |          NA |
|                   LinqAF | .NET 8.0 |   100 |  14.73 ns | 0.086 ns | 0.076 ns |  14.73 ns | 5.71x faster |   0.17x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |  56.58 ns | 0.850 ns | 0.754 ns |  56.28 ns | 1.49x faster |   0.05x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  44.59 ns | 0.617 ns | 0.633 ns |  44.40 ns | 1.88x faster |   0.05x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |  19.12 ns | 0.499 ns | 1.439 ns |  18.70 ns | 4.28x faster |   0.31x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 8.0 |   100 |  12.61 ns | 0.064 ns | 0.056 ns |  12.62 ns | 6.67x faster |   0.18x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 141.38 ns | 0.685 ns | 0.607 ns | 141.27 ns | 1.68x slower |   0.04x | 0.0305 |      64 B |          NA |
