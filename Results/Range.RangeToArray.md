## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|          Method |    Job |  Runtime | Start | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|---------------- |------- |--------- |------ |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|         ForLoop | .NET 6 | .NET 6.0 |     0 |   100 |  78.17 ns | 1.628 ns |  1.360 ns |  78.46 ns |     baseline |         | 0.2027 |     424 B |             |
|            Linq | .NET 6 | .NET 6.0 |     0 |   100 |  81.33 ns | 1.744 ns |  4.890 ns |  79.34 ns | 1.06x slower |   0.05x | 0.2218 |     464 B |  1.09x more |
|      LinqFaster | .NET 6 | .NET 6.0 |     0 |   100 |  66.29 ns | 1.229 ns |  0.960 ns |  66.22 ns | 1.18x faster |   0.03x | 0.2027 |     424 B |  1.00x more |
| LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |   100 |  34.86 ns | 0.260 ns |  0.203 ns |  34.78 ns | 2.24x faster |   0.04x | 0.2027 |     424 B |  1.00x more |
|          LinqAF | .NET 6 | .NET 6.0 |     0 |   100 | 207.03 ns | 4.001 ns |  8.352 ns | 202.44 ns | 2.67x slower |   0.12x | 0.2027 |     424 B |  1.00x more |
|      StructLinq | .NET 6 | .NET 6.0 |     0 |   100 |  78.22 ns | 0.932 ns |  1.036 ns |  78.10 ns | 1.00x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
|       Hyperlinq | .NET 6 | .NET 6.0 |     0 |   100 |  40.93 ns | 0.871 ns |  2.170 ns |  39.77 ns | 1.91x faster |   0.11x | 0.2027 |     424 B |  1.00x more |
|                 |        |          |       |       |           |          |           |           |              |         |        |           |             |
|         ForLoop | .NET 8 | .NET 8.0 |     0 |   100 |  86.97 ns | 1.806 ns |  3.017 ns |  85.72 ns |     baseline |         | 0.2027 |     424 B |             |
|            Linq | .NET 8 | .NET 8.0 |     0 |   100 |  75.94 ns | 0.589 ns |  0.723 ns |  75.79 ns | 1.15x faster |   0.04x | 0.2218 |     464 B |  1.09x more |
|      LinqFaster | .NET 8 | .NET 8.0 |     0 |   100 |  63.01 ns | 0.809 ns |  0.675 ns |  62.76 ns | 1.38x faster |   0.05x | 0.2027 |     424 B |  1.00x more |
| LinqFaster_SIMD | .NET 8 | .NET 8.0 |     0 |   100 |  39.93 ns | 0.493 ns |  0.484 ns |  39.66 ns | 2.17x faster |   0.08x | 0.2027 |     424 B |  1.00x more |
|          LinqAF | .NET 8 | .NET 8.0 |     0 |   100 | 210.84 ns | 4.197 ns | 11.560 ns | 204.32 ns | 2.44x slower |   0.17x | 0.2027 |     424 B |  1.00x more |
|      StructLinq | .NET 8 | .NET 8.0 |     0 |   100 |  67.11 ns | 1.314 ns |  2.160 ns |  66.30 ns | 1.30x faster |   0.06x | 0.2027 |     424 B |  1.00x more |
|       Hyperlinq | .NET 8 | .NET 8.0 |     0 |   100 |  46.48 ns | 1.205 ns |  3.458 ns |  44.70 ns | 1.88x faster |   0.13x | 0.2027 |     424 B |  1.00x more |
