## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|                   Method |    Job |  Runtime | Count |     Mean |    Error |   StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |---------:|---------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 | 41.57 ns | 0.845 ns | 1.098 ns | 41.14 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 41.71 ns | 0.425 ns | 0.355 ns | 41.58 ns | 1.00x faster |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 36.99 ns | 0.420 ns | 0.413 ns | 36.85 ns | 1.13x faster |   0.04x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 74.39 ns | 2.890 ns | 8.430 ns | 70.11 ns | 1.93x slower |   0.24x | 0.2142 |     448 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 99.83 ns | 2.012 ns | 5.156 ns | 97.11 ns | 2.42x slower |   0.14x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 77.89 ns | 1.564 ns | 2.614 ns | 76.77 ns | 1.89x slower |   0.10x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 39.08 ns | 0.311 ns | 0.243 ns | 38.99 ns | 1.06x faster |   0.03x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |   100 | 23.79 ns | 0.505 ns | 1.042 ns | 23.26 ns | 1.73x faster |   0.10x |      - |         - |          NA |
|                          |        |          |       |          |          |          |          |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 | 40.72 ns | 0.399 ns | 0.443 ns | 40.63 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 57.85 ns | 0.988 ns | 0.924 ns | 57.44 ns | 1.42x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 13.63 ns | 0.194 ns | 0.151 ns | 13.57 ns | 3.00x faster |   0.04x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 49.81 ns | 1.168 ns | 3.276 ns | 48.48 ns | 1.22x slower |   0.09x | 0.2142 |     448 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 79.27 ns | 1.019 ns | 0.851 ns | 79.21 ns | 1.94x slower |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 66.65 ns | 1.308 ns | 1.021 ns | 66.31 ns | 1.63x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 18.19 ns | 0.292 ns | 0.312 ns | 18.09 ns | 2.24x faster |   0.04x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 8 | .NET 8.0 |   100 | 13.19 ns | 0.193 ns | 0.171 ns | 13.13 ns | 3.09x faster |   0.05x |      - |         - |          NA |
