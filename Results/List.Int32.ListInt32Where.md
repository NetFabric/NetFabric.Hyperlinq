## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|                   Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   132.70 ns |  2.538 ns |  2.374 ns |   132.01 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   185.19 ns |  2.658 ns |  2.075 ns |   184.42 ns |  1.40x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   591.14 ns | 10.443 ns | 12.825 ns |   586.85 ns |  4.47x slower |   0.15x | 0.0343 |      72 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   444.98 ns |  8.904 ns |  8.329 ns |   440.78 ns |  3.35x slower |   0.06x | 0.3090 |     648 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   583.41 ns |  4.714 ns |  3.680 ns |   582.55 ns |  4.40x slower |   0.08x | 0.3328 |     696 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   954.67 ns | 18.102 ns | 44.064 ns |   933.75 ns |  7.22x slower |   0.28x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 2,111.61 ns | 30.235 ns | 25.248 ns | 2,105.28 ns | 15.93x slower |   0.40x | 4.1656 |    8722 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,444.50 ns | 12.103 ns |  9.449 ns | 1,442.36 ns | 10.89x slower |   0.18x | 0.2899 |     608 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   298.16 ns |  5.731 ns | 10.037 ns |   296.11 ns |  2.27x slower |   0.11x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   173.49 ns |  2.881 ns |  3.745 ns |   172.40 ns |  1.31x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   481.27 ns |  9.600 ns | 11.428 ns |   476.01 ns |  3.65x slower |   0.09x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   208.26 ns |  3.159 ns |  3.511 ns |   206.63 ns |  1.57x slower |   0.05x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |   485.26 ns |  9.848 ns | 27.776 ns |   471.62 ns |  3.68x slower |   0.25x | 0.3095 |     648 B |          NA |
|                          |        |          |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |    72.09 ns |  0.601 ns |  0.532 ns |    71.86 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   117.16 ns |  1.595 ns |  1.492 ns |   116.66 ns |  1.63x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   266.50 ns |  5.184 ns |  6.921 ns |   263.70 ns |  3.70x slower |   0.13x | 0.0343 |      72 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   304.09 ns |  4.544 ns |  6.660 ns |   303.56 ns |  4.24x slower |   0.10x | 0.3095 |     648 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   259.11 ns |  5.072 ns |  4.497 ns |   257.12 ns |  3.59x slower |   0.07x | 0.3328 |     696 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   281.80 ns |  2.195 ns |  1.714 ns |   281.63 ns |  3.91x slower |   0.03x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,880.47 ns | 32.995 ns | 30.863 ns | 1,872.51 ns | 26.09x slower |   0.46x | 4.1656 |    8721 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,121.76 ns |  6.232 ns |  5.524 ns | 1,121.66 ns | 15.56x slower |   0.12x | 0.2899 |     608 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   180.02 ns |  3.484 ns |  7.426 ns |   176.09 ns |  2.52x slower |   0.11x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   159.14 ns |  1.987 ns |  1.659 ns |   158.63 ns |  2.21x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   184.84 ns |  3.699 ns |  3.633 ns |   183.40 ns |  2.56x slower |   0.06x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   177.22 ns |  1.607 ns |  1.342 ns |   177.00 ns |  2.46x slower |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   388.90 ns |  4.888 ns |  4.800 ns |   387.24 ns |  5.40x slower |   0.07x | 0.3095 |     648 B |          NA |
