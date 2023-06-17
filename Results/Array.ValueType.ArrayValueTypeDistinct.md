## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|                   Method |    Job |  Runtime | Duplicates | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |    Gen0 | Allocated |   Alloc Ratio |
|------------------------- |------- |--------- |----------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|--------:|----------:|--------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |          4 |   100 | 12.686 μs | 0.2478 μs | 0.2652 μs | 12.616 μs |     baseline |         | 12.8174 |   26976 B |               |
|              ForeachLoop | .NET 6 | .NET 6.0 |          4 |   100 | 13.525 μs | 0.2527 μs | 0.5601 μs | 13.326 μs | 1.07x slower |   0.03x | 12.8174 |   26976 B |   1.000x more |
|                     Linq | .NET 6 | .NET 6.0 |          4 |   100 | 15.941 μs | 0.1191 μs | 0.1169 μs | 15.927 μs | 1.26x slower |   0.03x | 12.8174 |   26848 B |   1.005x less |
|             LinqFasterer | .NET 6 | .NET 6.0 |          4 |   100 | 14.909 μs | 0.2736 μs | 0.2425 μs | 14.793 μs | 1.18x slower |   0.03x | 22.5830 |   47544 B |   1.762x more |
|                   LinqAF | .NET 6 | .NET 6.0 |          4 |   100 | 40.588 μs | 0.4204 μs | 0.3510 μs | 40.490 μs | 3.20x slower |   0.08x | 20.9351 |   43904 B |   1.628x more |
|               StructLinq | .NET 6 | .NET 6.0 |          4 |   100 | 14.282 μs | 0.1068 μs | 0.0947 μs | 14.258 μs | 1.13x slower |   0.03x |       - |      56 B | 481.714x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |          4 |   100 |  4.731 μs | 0.0355 μs | 0.0296 μs |  4.713 μs | 2.69x faster |   0.07x |       - |         - |            NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |          4 |   100 | 19.253 μs | 0.0906 μs | 0.0757 μs | 19.205 μs | 1.52x slower |   0.04x |       - |         - |            NA |
|                          |        |          |            |       |           |           |           |           |              |         |         |           |               |
|                  ForLoop | .NET 8 | .NET 8.0 |          4 |   100 | 10.966 μs | 0.2167 μs | 0.3038 μs | 10.899 μs |     baseline |         | 12.8937 |   26976 B |               |
|              ForeachLoop | .NET 8 | .NET 8.0 |          4 |   100 | 11.247 μs | 0.2240 μs | 0.5237 μs | 11.119 μs | 1.05x slower |   0.05x | 12.8937 |   26976 B |   1.000x more |
|                     Linq | .NET 8 | .NET 8.0 |          4 |   100 | 14.176 μs | 0.3568 μs | 1.0521 μs | 13.663 μs | 1.32x slower |   0.12x | 12.8174 |   26848 B |   1.005x less |
|             LinqFasterer | .NET 8 | .NET 8.0 |          4 |   100 | 18.908 μs | 0.7676 μs | 2.1271 μs | 19.728 μs | 1.50x slower |   0.22x | 22.7051 |   47544 B |   1.762x more |
|                   LinqAF | .NET 8 | .NET 8.0 |          4 |   100 | 34.178 μs | 0.3931 μs | 0.3283 μs | 34.183 μs | 3.14x slower |   0.11x | 21.8506 |   45720 B |   1.695x more |
|               StructLinq | .NET 8 | .NET 8.0 |          4 |   100 | 11.349 μs | 0.0986 μs | 0.0770 μs | 11.326 μs | 1.04x slower |   0.03x |  0.0153 |      56 B | 481.714x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |          4 |   100 |  3.693 μs | 0.0532 μs | 0.0710 μs |  3.677 μs | 2.97x faster |   0.11x |       - |         - |            NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |          4 |   100 | 11.970 μs | 0.2332 μs | 0.3419 μs | 11.856 μs | 1.09x slower |   0.05x |       - |         - |            NA |
