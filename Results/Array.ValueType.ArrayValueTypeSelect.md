## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                   Method |  Runtime | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 | 1,535.32 ns |  7.617 ns |  5.947 ns | 1,534.76 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 1,628.00 ns | 24.790 ns | 25.458 ns | 1,615.40 ns |  1.06x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 2,186.98 ns |  8.935 ns |  7.921 ns | 2,185.69 ns |  1.42x slower |   0.01x | 0.0496 |     104 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 3,372.96 ns | 62.585 ns | 64.270 ns | 3,353.23 ns |  2.19x slower |   0.05x | 3.0670 |    6424 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 2,645.58 ns | 25.042 ns | 19.551 ns | 2,649.87 ns |  1.72x slower |   0.01x | 3.0861 |    6456 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 2,660.41 ns | 44.696 ns | 47.824 ns | 2,645.97 ns |  1.72x slower |   0.03x |      - |         - |          NA |
|                 SpanLinq | .NET 6.0 |   100 | 2,133.30 ns | 36.946 ns | 41.066 ns | 2,119.85 ns |  1.40x slower |   0.03x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 1,787.87 ns | 35.171 ns | 65.191 ns | 1,747.63 ns |  1.17x slower |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 1,721.46 ns |  8.445 ns |  6.593 ns | 1,718.14 ns |  1.12x slower |   0.00x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 1,916.78 ns | 38.320 ns | 72.907 ns | 1,876.08 ns |  1.26x slower |   0.05x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 1,722.65 ns | 20.450 ns | 20.085 ns | 1,715.56 ns |  1.12x slower |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 2,596.00 ns | 36.159 ns | 30.194 ns | 2,587.12 ns |  1.69x slower |   0.02x | 3.0670 |    6424 B |          NA |
|                          |          |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   103.80 ns |  0.516 ns |  0.507 ns |   103.67 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |    97.85 ns |  1.869 ns |  1.560 ns |    97.34 ns |  1.06x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |   979.09 ns |  7.130 ns |  7.925 ns |   978.77 ns |  9.43x slower |   0.09x | 0.0496 |     104 B |          NA |
|               LinqFaster | .NET 8.0 |   100 |   777.01 ns | 12.966 ns | 10.827 ns |   774.27 ns |  7.49x slower |   0.11x | 3.0670 |    6424 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 |   991.59 ns | 10.311 ns |  9.140 ns |   991.76 ns |  9.56x slower |   0.09x | 3.0861 |    6456 B |          NA |
|                   LinqAF | .NET 8.0 |   100 | 1,078.59 ns |  3.484 ns |  2.909 ns | 1,077.32 ns | 10.39x slower |   0.05x |      - |         - |          NA |
|                 SpanLinq | .NET 8.0 |   100 |   191.48 ns |  3.406 ns |  5.303 ns |   189.03 ns |  1.84x slower |   0.05x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |   251.99 ns |  1.486 ns |  1.390 ns |   252.00 ns |  2.43x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   135.67 ns |  0.666 ns |  0.590 ns |   135.55 ns |  1.31x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |   320.83 ns |  4.771 ns |  6.369 ns |   318.16 ns |  3.11x slower |   0.07x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |    97.07 ns |  1.434 ns |  1.197 ns |    96.63 ns |  1.07x faster |   0.01x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 |   843.36 ns | 16.849 ns | 35.540 ns |   827.93 ns |  8.18x slower |   0.30x | 3.0670 |    6424 B |          NA |
