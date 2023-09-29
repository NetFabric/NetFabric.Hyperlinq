## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                   Method |  Runtime | Skip | Count |        Mean |      Error |    StdDev |         Ratio | RatioSD |    Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |------------:|-----------:|----------:|--------------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6.0 | 1000 |   100 |   437.51 ns |   7.782 ns | 10.389 ns |      baseline |         |       - |         - |          NA |
|                     Linq | .NET 6.0 | 1000 |   100 | 2,024.24 ns |  21.770 ns | 19.298 ns |  4.63x slower |   0.11x |  0.1526 |     320 B |          NA |
|               LinqFaster | .NET 6.0 | 1000 |   100 | 2,049.13 ns |  36.907 ns | 34.523 ns |  4.68x slower |   0.15x | 10.7803 |   22560 B |          NA |
|             LinqFasterer | .NET 6.0 | 1000 |   100 | 1,730.09 ns |  33.291 ns | 38.338 ns |  3.94x slower |   0.14x |  4.6501 |    9744 B |          NA |
|                   LinqAF | .NET 6.0 | 1000 |   100 | 6,196.72 ns | 103.977 ns | 86.826 ns | 14.19x slower |   0.36x |       - |         - |          NA |
|                 SpanLinq | .NET 6.0 | 1000 |   100 |   699.78 ns |  11.417 ns |  9.534 ns |  1.60x slower |   0.04x |       - |         - |          NA |
|               StructLinq | .NET 6.0 | 1000 |   100 |   616.15 ns |   2.904 ns |  2.574 ns |  1.41x slower |   0.03x |  0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   519.88 ns |   2.117 ns |  1.980 ns |  1.19x slower |   0.03x |       - |         - |          NA |
|                Hyperlinq | .NET 6.0 | 1000 |   100 | 1,025.53 ns |   4.242 ns |  3.542 ns |  2.35x slower |   0.05x |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 |   811.63 ns |  15.641 ns | 18.619 ns |  1.85x slower |   0.06x |       - |         - |          NA |
|                          |          |      |       |             |            |           |               |         |         |           |             |
|                  ForLoop | .NET 8.0 | 1000 |   100 |    88.90 ns |   0.915 ns |  0.764 ns |      baseline |         |       - |         - |          NA |
|                     Linq | .NET 8.0 | 1000 |   100 |   970.21 ns |  18.755 ns | 25.037 ns | 10.94x slower |   0.37x |  0.1526 |     320 B |          NA |
|               LinqFaster | .NET 8.0 | 1000 |   100 | 1,777.29 ns |  26.226 ns | 31.221 ns | 20.08x slower |   0.32x | 10.7803 |   22560 B |          NA |
|             LinqFasterer | .NET 8.0 | 1000 |   100 | 1,237.84 ns |  13.792 ns | 11.517 ns | 13.92x slower |   0.18x |  4.6501 |    9744 B |          NA |
|                   LinqAF | .NET 8.0 | 1000 |   100 | 1,819.55 ns |   9.873 ns |  7.708 ns | 20.47x slower |   0.16x |       - |         - |          NA |
|                 SpanLinq | .NET 8.0 | 1000 |   100 |   208.44 ns |   1.230 ns |  1.150 ns |  2.34x slower |   0.02x |       - |         - |          NA |
|               StructLinq | .NET 8.0 | 1000 |   100 |   256.28 ns |   1.342 ns |  1.189 ns |  2.88x slower |   0.03x |  0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 |   126.29 ns |   0.455 ns |  0.404 ns |  1.42x slower |   0.01x |       - |         - |          NA |
|                Hyperlinq | .NET 8.0 | 1000 |   100 |   255.46 ns |   1.474 ns |  1.231 ns |  2.87x slower |   0.03x |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 |   113.82 ns |   2.265 ns |  3.024 ns |  1.28x slower |   0.04x |       - |         - |          NA |
