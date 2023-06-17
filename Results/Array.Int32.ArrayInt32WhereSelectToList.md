## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |    Error |   StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   241.6 ns |  1.46 ns |  1.37 ns |   241.2 ns |     baseline |         | 0.3095 |     648 B |             |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   242.6 ns |  2.28 ns |  2.02 ns |   242.4 ns | 1.00x slower |   0.01x | 0.3095 |     648 B |  1.00x more |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   471.8 ns |  3.44 ns |  2.68 ns |   471.1 ns | 1.95x slower |   0.02x | 0.3595 |     752 B |  1.16x more |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   361.2 ns |  7.19 ns |  6.72 ns |   359.6 ns | 1.49x slower |   0.03x | 0.4473 |     936 B |  1.44x more |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   576.3 ns |  7.30 ns | 11.36 ns |   571.1 ns | 2.39x slower |   0.06x | 0.6113 |    1280 B |  1.98x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   673.0 ns | 13.22 ns | 14.70 ns |   666.8 ns | 2.79x slower |   0.07x | 0.3090 |     648 B |  1.00x more |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,161.6 ns | 34.11 ns | 96.77 ns | 1,111.6 ns | 4.82x slower |   0.34x | 4.2629 |    8922 B | 13.77x more |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 |   526.9 ns | 10.57 ns | 25.72 ns |   514.7 ns | 2.21x slower |   0.15x | 0.3090 |     648 B |  1.00x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,247.5 ns | 12.39 ns |  9.68 ns | 1,242.8 ns | 5.16x slower |   0.05x | 0.5684 |    1192 B |  1.84x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   529.3 ns | 10.37 ns |  8.09 ns |   528.7 ns | 2.19x slower |   0.04x | 0.1755 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   297.5 ns |  5.97 ns |  7.76 ns |   295.0 ns | 1.24x slower |   0.04x | 0.1297 |     272 B |  2.38x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   666.7 ns |  4.01 ns |  3.94 ns |   665.1 ns | 2.76x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   353.2 ns |  3.13 ns |  2.44 ns |   352.9 ns | 1.46x slower |   0.01x | 0.1297 |     272 B |  2.38x less |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |   379.9 ns |  4.83 ns |  4.74 ns |   378.7 ns | 1.57x slower |   0.02x | 0.4206 |     880 B |  1.36x more |
|                          |        |          |       |            |          |          |            |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |   235.8 ns |  2.15 ns |  2.01 ns |   235.9 ns |     baseline |         | 0.3095 |     648 B |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   235.7 ns |  2.31 ns |  1.93 ns |   235.1 ns | 1.00x faster |   0.01x | 0.3095 |     648 B |  1.00x more |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   325.7 ns |  5.12 ns |  4.00 ns |   324.5 ns | 1.38x slower |   0.02x | 0.3595 |     752 B |  1.16x more |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   228.1 ns |  1.91 ns |  1.87 ns |   227.6 ns | 1.03x faster |   0.01x | 0.4475 |     936 B |  1.44x more |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   349.8 ns |  2.08 ns |  1.62 ns |   350.0 ns | 1.48x slower |   0.01x | 0.6118 |    1280 B |  1.98x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   363.6 ns |  7.64 ns | 21.55 ns |   352.3 ns | 1.54x slower |   0.09x | 0.3095 |     648 B |  1.00x more |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 |   957.3 ns |  7.64 ns |  7.15 ns |   955.5 ns | 4.06x slower |   0.03x | 4.2629 |    8921 B | 13.77x more |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 |   333.4 ns |  4.45 ns |  3.94 ns |   331.8 ns | 1.41x slower |   0.02x | 0.3090 |     648 B |  1.00x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,135.0 ns | 11.59 ns | 10.27 ns | 1,131.0 ns | 4.81x slower |   0.05x | 0.5684 |    1192 B |  1.84x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   408.9 ns |  8.47 ns | 23.89 ns |   395.1 ns | 1.74x slower |   0.11x | 0.1760 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   282.4 ns |  4.02 ns |  4.47 ns |   280.0 ns | 1.20x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   419.7 ns | 12.12 ns | 35.73 ns |   397.7 ns | 1.77x slower |   0.14x | 0.1297 |     272 B |  2.38x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   320.1 ns |  2.57 ns |  2.15 ns |   319.6 ns | 1.36x slower |   0.01x | 0.1297 |     272 B |  2.38x less |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   239.4 ns |  5.60 ns | 15.98 ns |   230.3 ns | 1.02x slower |   0.06x | 0.4206 |     880 B |  1.36x more |
