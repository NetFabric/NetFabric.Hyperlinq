## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                       Method |  Runtime | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------- |--------- |------ |----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                      ForLoop | .NET 6.0 |   100 | 325.93 ns |  1.481 ns |  1.646 ns |     baseline |         | 0.5660 |    1184 B |             |
|                  ForeachLoop | .NET 6.0 |   100 | 324.50 ns |  2.461 ns |  2.735 ns | 1.00x faster |   0.01x | 0.5660 |    1184 B |  1.00x more |
|                         Linq | .NET 6.0 |   100 | 294.68 ns |  2.353 ns |  1.965 ns | 1.11x faster |   0.01x | 0.2522 |     528 B |  2.24x less |
|                   LinqFaster | .NET 6.0 |   100 | 345.84 ns |  3.856 ns |  4.286 ns | 1.06x slower |   0.02x | 0.4358 |     912 B |  1.30x less |
|                 LinqFasterer | .NET 6.0 |   100 | 279.46 ns |  1.851 ns |  1.546 ns | 1.17x faster |   0.01x | 0.6232 |    1304 B |  1.10x more |
|                       LinqAF | .NET 6.0 |   100 | 678.64 ns |  8.627 ns |  6.735 ns | 2.08x slower |   0.03x | 0.5655 |    1184 B |  1.00x more |
|                   StructLinq | .NET 6.0 |   100 | 265.70 ns |  2.861 ns |  2.810 ns | 1.23x faster |   0.01x | 0.2484 |     520 B |  2.28x less |
|     StructLinq_ValueDelegate | .NET 6.0 |   100 | 128.49 ns |  1.623 ns |  1.869 ns | 2.54x faster |   0.04x | 0.2370 |     496 B |  2.39x less |
|                    Hyperlinq | .NET 6.0 |   100 | 201.44 ns |  3.207 ns |  2.843 ns | 1.62x faster |   0.03x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 119.00 ns |  1.417 ns |  1.256 ns | 2.74x faster |   0.04x | 0.2179 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 6.0 |   100 |  85.79 ns |  1.395 ns |  1.660 ns | 3.79x faster |   0.07x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 6.0 |   100 |  55.73 ns |  1.040 ns |  0.922 ns | 5.86x faster |   0.11x | 0.2180 |     456 B |  2.60x less |
|                      Faslinq | .NET 6.0 |   100 | 412.24 ns |  7.424 ns |  6.945 ns | 1.26x slower |   0.02x | 0.5660 |    1184 B |  1.00x more |
|                              |          |       |           |           |           |              |         |        |           |             |
|                      ForLoop | .NET 8.0 |   100 | 315.88 ns |  6.242 ns |  6.131 ns |     baseline |         | 0.5660 |    1184 B |             |
|                  ForeachLoop | .NET 8.0 |   100 | 325.51 ns |  4.449 ns |  3.715 ns | 1.03x slower |   0.02x | 0.5660 |    1184 B |  1.00x more |
|                         Linq | .NET 8.0 |   100 | 142.77 ns |  2.761 ns |  2.712 ns | 2.21x faster |   0.05x | 0.2522 |     528 B |  2.24x less |
|                   LinqFaster | .NET 8.0 |   100 | 251.43 ns |  2.117 ns |  1.768 ns | 1.26x faster |   0.02x | 0.4358 |     912 B |  1.30x less |
|                 LinqFasterer | .NET 8.0 |   100 | 218.36 ns |  4.430 ns |  7.154 ns | 1.45x faster |   0.06x | 0.6235 |    1304 B |  1.10x more |
|                       LinqAF | .NET 8.0 |   100 | 554.51 ns | 10.697 ns | 15.342 ns | 1.77x slower |   0.08x | 0.5655 |    1184 B |  1.00x more |
|                   StructLinq | .NET 8.0 |   100 | 161.90 ns |  2.828 ns |  3.144 ns | 1.95x faster |   0.05x | 0.2484 |     520 B |  2.28x less |
|     StructLinq_ValueDelegate | .NET 8.0 |   100 | 118.11 ns |  1.011 ns |  0.844 ns | 2.68x faster |   0.06x | 0.2370 |     496 B |  2.39x less |
|                    Hyperlinq | .NET 8.0 |   100 | 170.56 ns |  3.083 ns |  2.407 ns | 1.86x faster |   0.04x | 0.2179 |     456 B |  2.60x less |
|      Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  92.36 ns |  0.870 ns |  0.771 ns | 3.43x faster |   0.08x | 0.2180 |     456 B |  2.60x less |
|               Hyperlinq_SIMD | .NET 8.0 |   100 |  54.14 ns |  0.585 ns |  0.518 ns | 5.85x faster |   0.12x | 0.2180 |     456 B |  2.60x less |
| Hyperlinq_ValueDelegate_SIMD | .NET 8.0 |   100 |  44.50 ns |  0.893 ns |  0.955 ns | 7.10x faster |   0.25x | 0.2180 |     456 B |  2.60x less |
|                      Faslinq | .NET 8.0 |   100 | 348.99 ns |  3.645 ns |  3.044 ns | 1.10x slower |   0.02x | 0.5660 |    1184 B |  1.00x more |
