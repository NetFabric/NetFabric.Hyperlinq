## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|     Method |  Runtime | Start | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------- |--------- |------ |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|    ForLoop | .NET 6.0 |     0 |   100 | 277.79 ns | 3.677 ns |  4.086 ns | 276.08 ns |     baseline |         | 0.5660 |    1184 B |             |
|       Linq | .NET 6.0 |     0 |   100 | 201.18 ns | 1.369 ns |  1.214 ns | 201.33 ns | 1.38x faster |   0.03x | 0.2370 |     496 B |  2.39x less |
| LinqFaster | .NET 6.0 |     0 |   100 | 120.31 ns | 2.151 ns |  1.796 ns | 119.57 ns | 2.31x faster |   0.04x | 0.4206 |     880 B |  1.35x less |
|     LinqAF | .NET 6.0 |     0 |   100 | 254.15 ns | 3.507 ns |  3.109 ns | 253.24 ns | 1.10x faster |   0.02x | 0.2179 |     456 B |  2.60x less |
| StructLinq | .NET 6.0 |     0 |   100 |  86.26 ns | 1.038 ns |  0.810 ns |  86.44 ns | 3.23x faster |   0.05x | 0.2180 |     456 B |  2.60x less |
|  Hyperlinq | .NET 6.0 |     0 |   100 |  47.46 ns | 1.009 ns |  2.237 ns |  46.55 ns | 5.75x faster |   0.22x | 0.2180 |     456 B |  2.60x less |
|            |          |       |       |           |          |           |           |              |         |        |           |             |
|    ForLoop | .NET 8.0 |     0 |   100 | 271.51 ns | 5.477 ns | 11.673 ns | 268.88 ns |     baseline |         | 0.5660 |    1184 B |             |
|       Linq | .NET 8.0 |     0 |   100 |  48.48 ns | 1.234 ns |  3.579 ns |  46.88 ns | 5.56x faster |   0.42x | 0.2372 |     496 B |  2.39x less |
| LinqFaster | .NET 8.0 |     0 |   100 | 115.28 ns | 0.702 ns |  0.586 ns | 115.49 ns | 2.33x faster |   0.10x | 0.4206 |     880 B |  1.35x less |
|     LinqAF | .NET 8.0 |     0 |   100 | 198.79 ns | 3.973 ns |  7.842 ns | 196.76 ns | 1.38x faster |   0.08x | 0.2179 |     456 B |  2.60x less |
| StructLinq | .NET 8.0 |     0 |   100 |  70.78 ns | 0.846 ns |  0.707 ns |  70.55 ns | 3.80x faster |   0.15x | 0.2180 |     456 B |  2.60x less |
|  Hyperlinq | .NET 8.0 |     0 |   100 |  51.22 ns | 0.991 ns |  1.453 ns |  50.71 ns | 5.37x faster |   0.26x | 0.2180 |     456 B |  2.60x less |
