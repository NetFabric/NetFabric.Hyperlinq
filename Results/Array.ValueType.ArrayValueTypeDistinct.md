## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|                   Method |  Runtime | Duplicates | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |    Gen0 | Allocated |   Alloc Ratio |
|------------------------- |--------- |----------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|--------:|----------:|--------------:|
|                  ForLoop | .NET 6.0 |          4 |   100 | 12.732 μs | 0.1808 μs | 0.1509 μs | 12.727 μs |     baseline |         | 12.8174 |   26976 B |               |
|              ForeachLoop | .NET 6.0 |          4 |   100 | 13.441 μs | 0.1823 μs | 0.1523 μs | 13.404 μs | 1.06x slower |   0.02x | 12.8174 |   26976 B |   1.000x more |
|                     Linq | .NET 6.0 |          4 |   100 | 15.380 μs | 0.2921 μs | 0.2732 μs | 15.369 μs | 1.21x slower |   0.03x | 12.8174 |   26848 B |   1.005x less |
|             LinqFasterer | .NET 6.0 |          4 |   100 | 14.881 μs | 0.1384 μs | 0.1080 μs | 14.906 μs | 1.17x slower |   0.02x | 22.5830 |   47544 B |   1.762x more |
|                   LinqAF | .NET 6.0 |          4 |   100 | 42.375 μs | 0.8329 μs | 0.9258 μs | 41.952 μs | 3.32x slower |   0.06x | 20.9351 |   43880 B |   1.627x more |
|               StructLinq | .NET 6.0 |          4 |   100 | 14.169 μs | 0.2308 μs | 0.2566 μs | 14.100 μs | 1.12x slower |   0.03x |  0.0153 |      56 B | 481.714x less |
| StructLinq_ValueDelegate | .NET 6.0 |          4 |   100 |  4.665 μs | 0.0380 μs | 0.0317 μs |  4.655 μs | 2.73x faster |   0.04x |       - |         - |            NA |
|                Hyperlinq | .NET 6.0 |          4 |   100 | 12.643 μs | 0.1771 μs | 0.1383 μs | 12.606 μs | 1.01x faster |   0.02x |       - |         - |            NA |
|                          |          |            |       |           |           |           |           |              |         |         |           |               |
|                  ForLoop | .NET 8.0 |          4 |   100 | 11.302 μs | 0.1453 μs | 0.1359 μs | 11.262 μs |     baseline |         | 12.8937 |   26976 B |               |
|              ForeachLoop | .NET 8.0 |          4 |   100 | 12.325 μs | 0.1219 μs | 0.0952 μs | 12.286 μs | 1.09x slower |   0.02x | 12.8937 |   26976 B |   1.000x more |
|                     Linq | .NET 8.0 |          4 |   100 | 13.553 μs | 0.3106 μs | 0.9061 μs | 13.125 μs | 1.21x slower |   0.09x | 12.8174 |   26848 B |   1.005x less |
|             LinqFasterer | .NET 8.0 |          4 |   100 | 15.774 μs | 0.1881 μs | 0.1571 μs | 15.766 μs | 1.40x slower |   0.02x | 22.7051 |   47544 B |   1.762x more |
|                   LinqAF | .NET 8.0 |          4 |   100 | 32.975 μs | 0.4173 μs | 0.3484 μs | 32.864 μs | 2.92x slower |   0.05x | 20.8740 |   43832 B |   1.625x more |
|               StructLinq | .NET 8.0 |          4 |   100 | 10.623 μs | 0.0370 μs | 0.0289 μs | 10.616 μs | 1.06x faster |   0.02x |  0.0153 |      56 B | 481.714x less |
| StructLinq_ValueDelegate | .NET 8.0 |          4 |   100 |  3.222 μs | 0.0639 μs | 0.1247 μs |  3.160 μs | 3.51x faster |   0.14x |       - |         - |            NA |
|                Hyperlinq | .NET 8.0 |          4 |   100 | 11.292 μs | 0.0624 μs | 0.0693 μs | 11.275 μs | 1.00x faster |   0.01x |       - |         - |            NA |
