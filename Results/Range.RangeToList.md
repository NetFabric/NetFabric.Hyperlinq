## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|     Method |    Job |  Runtime | Start | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------- |------- |--------- |------ |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|    ForLoop | .NET 6 | .NET 6.0 |     0 |   100 | 291.26 ns | 5.846 ns | 13.550 ns | 284.28 ns |     baseline |         | 0.5660 |    1184 B |             |
|       Linq | .NET 6 | .NET 6.0 |     0 |   100 | 207.25 ns | 1.896 ns |  1.774 ns | 206.82 ns | 1.43x faster |   0.08x | 0.2370 |     496 B |  2.39x less |
| LinqFaster | .NET 6 | .NET 6.0 |     0 |   100 | 120.91 ns | 2.440 ns |  2.163 ns | 120.07 ns | 2.46x faster |   0.14x | 0.4206 |     880 B |  1.35x less |
|     LinqAF | .NET 6 | .NET 6.0 |     0 |   100 | 262.33 ns | 4.731 ns |  4.194 ns | 260.72 ns | 1.13x faster |   0.07x | 0.2179 |     456 B |  2.60x less |
| StructLinq | .NET 6 | .NET 6.0 |     0 |   100 |  84.80 ns | 1.322 ns |  1.358 ns |  84.63 ns | 3.48x faster |   0.22x | 0.2180 |     456 B |  2.60x less |
|  Hyperlinq | .NET 6 | .NET 6.0 |     0 |   100 |  49.27 ns | 1.002 ns |  1.154 ns |  48.97 ns | 5.97x faster |   0.38x | 0.2180 |     456 B |  2.60x less |
|            |        |          |       |       |           |          |           |           |              |         |        |           |             |
|    ForLoop | .NET 8 | .NET 8.0 |     0 |   100 | 266.61 ns | 4.659 ns |  3.890 ns | 265.66 ns |     baseline |         | 0.5660 |    1184 B |             |
|       Linq | .NET 8 | .NET 8.0 |     0 |   100 |  81.59 ns | 1.452 ns |  1.287 ns |  81.29 ns | 3.27x faster |   0.07x | 0.2370 |     496 B |  2.39x less |
| LinqFaster | .NET 8 | .NET 8.0 |     0 |   100 | 114.05 ns | 1.608 ns |  1.579 ns | 113.93 ns | 2.35x faster |   0.06x | 0.4207 |     880 B |  1.35x less |
|     LinqAF | .NET 8 | .NET 8.0 |     0 |   100 | 258.66 ns | 2.840 ns |  2.517 ns | 258.30 ns | 1.03x faster |   0.01x | 0.2179 |     456 B |  2.60x less |
| StructLinq | .NET 8 | .NET 8.0 |     0 |   100 |  71.06 ns | 0.706 ns |  0.551 ns |  70.91 ns | 3.76x faster |   0.07x | 0.2180 |     456 B |  2.60x less |
|  Hyperlinq | .NET 8 | .NET 8.0 |     0 |   100 |  53.49 ns | 0.860 ns |  1.364 ns |  53.10 ns | 4.95x faster |   0.21x | 0.2180 |     456 B |  2.60x less |
