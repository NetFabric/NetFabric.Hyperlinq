## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|                   Method |    Job |  Runtime | Start | Count |      Mean |     Error |   StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |------ |----------:|----------:|---------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |     0 |   100 |  43.60 ns |  0.291 ns | 0.323 ns |  43.52 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |     0 |   100 | 649.02 ns | 11.268 ns | 8.797 ns | 646.38 ns | 14.89x slower |   0.23x | 0.0420 |      88 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |     0 |   100 | 365.35 ns |  4.176 ns | 4.469 ns | 364.52 ns |  8.38x slower |   0.11x | 0.4053 |     848 B |          NA |
|          LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |   100 | 147.41 ns |  2.985 ns | 8.320 ns | 145.14 ns |  3.42x slower |   0.24x | 0.4053 |     848 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |     0 |   100 | 215.47 ns |  2.927 ns | 2.875 ns | 214.47 ns |  4.94x slower |   0.08x |      - |         - |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |     0 |   100 | 205.72 ns |  2.914 ns | 2.275 ns | 205.13 ns |  4.72x slower |   0.07x | 0.0114 |      24 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |     0 |   100 | 166.24 ns |  2.378 ns | 2.108 ns | 165.73 ns |  3.81x slower |   0.06x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |     0 |   100 | 234.41 ns |  4.714 ns | 8.380 ns | 229.73 ns |  5.38x slower |   0.20x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |     0 |   100 | 170.07 ns |  0.795 ns | 0.664 ns | 169.94 ns |  3.90x slower |   0.04x |      - |         - |          NA |
|                          |        |          |       |       |           |           |          |           |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |     0 |   100 |  44.31 ns |  0.919 ns | 1.878 ns |  43.40 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |     0 |   100 | 248.49 ns |  4.890 ns | 6.185 ns | 246.22 ns |  5.61x slower |   0.29x | 0.0420 |      88 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |     0 |   100 | 199.90 ns |  1.372 ns | 1.071 ns | 199.81 ns |  4.41x slower |   0.23x | 0.4053 |     848 B |          NA |
|          LinqFaster_SIMD | .NET 8 | .NET 8.0 |     0 |   100 | 131.39 ns |  2.575 ns | 2.529 ns | 130.68 ns |  2.94x slower |   0.15x | 0.4053 |     848 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |     0 |   100 | 183.01 ns |  0.957 ns | 1.064 ns | 182.82 ns |  4.11x slower |   0.20x |      - |         - |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |     0 |   100 | 157.60 ns |  0.533 ns | 0.445 ns | 157.53 ns |  3.49x slower |   0.19x | 0.0114 |      24 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |     0 |   100 | 137.80 ns |  1.703 ns | 1.593 ns | 137.39 ns |  3.07x slower |   0.16x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |     0 |   100 | 145.43 ns |  2.258 ns | 2.002 ns | 144.76 ns |  3.23x slower |   0.19x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |     0 |   100 | 142.27 ns |  2.210 ns | 2.631 ns | 140.91 ns |  3.21x slower |   0.15x |      - |         - |          NA |
