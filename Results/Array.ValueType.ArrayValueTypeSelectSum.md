## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|                   Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |  65.68 ns |  0.477 ns |  0.399 ns |  65.53 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 145.92 ns |  0.876 ns |  0.731 ns | 145.99 ns |  2.22x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 637.24 ns |  3.763 ns |  2.938 ns | 636.18 ns |  9.71x slower |   0.10x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 322.77 ns |  6.397 ns | 11.857 ns | 316.52 ns |  4.99x slower |   0.20x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 208.00 ns |  4.620 ns | 13.030 ns | 201.34 ns |  3.19x slower |   0.23x |      - |         - |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 666.77 ns | 11.867 ns | 21.699 ns | 657.71 ns | 10.08x slower |   0.38x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 489.42 ns |  3.594 ns |  2.806 ns | 489.33 ns |  7.45x slower |   0.06x | 0.0114 |      24 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 558.47 ns |  4.776 ns |  3.988 ns | 557.00 ns |  8.50x slower |   0.07x | 0.1717 |     360 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 203.45 ns |  2.186 ns |  1.826 ns | 202.58 ns |  3.10x slower |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  77.93 ns |  1.403 ns |  1.171 ns |  77.46 ns |  1.19x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 455.54 ns |  9.121 ns | 19.240 ns | 444.99 ns |  6.93x slower |   0.29x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 312.30 ns |  5.622 ns |  4.983 ns | 310.10 ns |  4.74x slower |   0.08x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 724.78 ns | 14.470 ns | 33.824 ns | 710.66 ns | 11.24x slower |   0.63x | 0.2174 |     456 B |          NA |
|                          |        |          |       |           |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |  43.01 ns |  0.844 ns |  1.068 ns |  42.67 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 134.93 ns |  1.009 ns |  0.944 ns | 134.60 ns |  3.13x slower |   0.10x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 294.45 ns |  3.576 ns |  2.792 ns | 294.12 ns |  6.84x slower |   0.22x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 135.56 ns |  2.415 ns |  1.885 ns | 135.07 ns |  3.15x slower |   0.10x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 110.58 ns |  0.756 ns |  0.590 ns | 110.51 ns |  2.57x slower |   0.08x |      - |         - |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 271.75 ns |  5.435 ns | 14.029 ns | 274.71 ns |  6.08x slower |   0.28x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 291.89 ns |  1.219 ns |  0.952 ns | 291.77 ns |  6.78x slower |   0.21x | 0.0114 |      24 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 555.37 ns |  7.415 ns |  8.242 ns | 551.98 ns | 12.91x slower |   0.27x | 0.1717 |     360 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 178.58 ns |  0.743 ns |  0.580 ns | 178.51 ns |  4.15x slower |   0.13x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |  48.25 ns |  0.296 ns |  0.263 ns |  48.21 ns |  1.12x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 126.59 ns |  2.512 ns |  3.603 ns | 125.09 ns |  2.95x slower |   0.09x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |  83.83 ns |  1.700 ns |  3.193 ns |  84.18 ns |  1.91x slower |   0.07x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 255.58 ns |  1.375 ns |  1.286 ns | 254.95 ns |  5.93x slower |   0.18x | 0.2027 |     424 B |          NA |
