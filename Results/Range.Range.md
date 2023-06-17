## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method |    Job |  Runtime | Start | Count |      Mean |    Error |   StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|---------------- |------- |--------- |------ |------ |----------:|---------:|---------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|         ForLoop | .NET 6 | .NET 6.0 |     0 |   100 |  34.55 ns | 0.724 ns | 1.479 ns |  33.81 ns |      baseline |         |      - |         - |          NA |
|            Linq | .NET 6 | .NET 6.0 |     0 |   100 | 394.07 ns | 7.153 ns | 8.237 ns | 390.43 ns | 11.39x slower |   0.51x | 0.0191 |      40 B |          NA |
|      LinqFaster | .NET 6 | .NET 6.0 |     0 |   100 | 109.49 ns | 1.395 ns | 1.165 ns | 109.33 ns |  3.21x slower |   0.13x | 0.2027 |     424 B |          NA |
| LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |   100 |  83.93 ns | 1.336 ns | 1.043 ns |  83.61 ns |  2.48x slower |   0.07x | 0.2027 |     424 B |          NA |
|          LinqAF | .NET 6 | .NET 6.0 |     0 |   100 | 164.21 ns | 1.097 ns | 0.916 ns | 163.93 ns |  4.81x slower |   0.16x |      - |         - |          NA |
|      StructLinq | .NET 6 | .NET 6.0 |     0 |   100 |  34.97 ns | 0.717 ns | 0.853 ns |  34.61 ns |  1.01x slower |   0.05x |      - |         - |          NA |
|       Hyperlinq | .NET 6 | .NET 6.0 |     0 |   100 |  42.06 ns | 0.488 ns | 0.381 ns |  41.94 ns |  1.24x slower |   0.03x |      - |         - |          NA |
|                 |        |          |       |       |           |          |          |           |               |         |        |           |             |
|         ForLoop | .NET 8 | .NET 8.0 |     0 |   100 |  33.60 ns | 0.198 ns | 0.155 ns |  33.55 ns |      baseline |         |      - |         - |          NA |
|            Linq | .NET 8 | .NET 8.0 |     0 |   100 | 194.91 ns | 3.309 ns | 3.095 ns | 195.22 ns |  5.81x slower |   0.11x | 0.0191 |      40 B |          NA |
|      LinqFaster | .NET 8 | .NET 8.0 |     0 |   100 | 110.88 ns | 2.002 ns | 1.563 ns | 110.49 ns |  3.30x slower |   0.05x | 0.2027 |     424 B |          NA |
| LinqFaster_SIMD | .NET 8 | .NET 8.0 |     0 |   100 |  81.52 ns | 0.662 ns | 0.552 ns |  81.40 ns |  2.42x slower |   0.02x | 0.2027 |     424 B |          NA |
|          LinqAF | .NET 8 | .NET 8.0 |     0 |   100 | 164.67 ns | 0.787 ns | 0.614 ns | 164.56 ns |  4.90x slower |   0.02x |      - |         - |          NA |
|      StructLinq | .NET 8 | .NET 8.0 |     0 |   100 |  36.15 ns | 0.743 ns | 0.826 ns |  35.99 ns |  1.08x slower |   0.02x |      - |         - |          NA |
|       Hyperlinq | .NET 8 | .NET 8.0 |     0 |   100 |  41.17 ns | 0.520 ns | 0.434 ns |  40.98 ns |  1.22x slower |   0.01x |      - |         - |          NA |
