## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|                   Method |  Runtime | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |  67.71 ns |  0.322 ns |  0.269 ns |  67.68 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 143.32 ns |  0.804 ns |  0.713 ns | 143.31 ns |  2.12x slower |   0.01x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 737.59 ns | 14.310 ns | 12.685 ns | 733.96 ns | 10.90x slower |   0.21x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 264.80 ns |  4.363 ns |  4.285 ns | 263.09 ns |  3.91x slower |   0.08x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 254.18 ns |  1.721 ns |  1.344 ns | 254.19 ns |  3.75x slower |   0.02x |      - |         - |          NA |
|                   LinqAF | .NET 6.0 |   100 | 645.73 ns | 12.831 ns | 24.411 ns | 640.09 ns |  9.46x slower |   0.26x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 285.74 ns |  5.305 ns |  4.142 ns | 283.99 ns |  4.22x slower |   0.07x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 168.04 ns |  0.963 ns |  0.805 ns | 167.76 ns |  2.48x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 467.16 ns |  1.687 ns |  1.409 ns | 466.90 ns |  6.90x slower |   0.03x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 338.21 ns |  6.404 ns |  5.990 ns | 335.03 ns |  5.00x slower |   0.10x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 760.79 ns | 14.740 ns | 13.067 ns | 760.10 ns | 11.20x slower |   0.15x | 3.0670 |    6424 B |          NA |
|                          |          |       |           |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  66.03 ns |  0.529 ns |  0.495 ns |  65.85 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  65.76 ns |  0.277 ns |  0.231 ns |  65.72 ns |  1.00x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 263.06 ns |  1.125 ns |  0.879 ns | 263.47 ns |  3.99x slower |   0.03x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 8.0 |   100 | 125.94 ns |  1.022 ns |  0.956 ns | 125.62 ns |  1.91x slower |   0.02x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 127.26 ns |  1.940 ns |  1.515 ns | 127.33 ns |  1.93x slower |   0.03x |      - |         - |          NA |
|                   LinqAF | .NET 8.0 |   100 | 254.48 ns |  1.959 ns |  1.833 ns | 254.43 ns |  3.85x slower |   0.04x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 | 161.27 ns |  3.227 ns |  4.524 ns | 161.79 ns |  2.43x slower |   0.09x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  74.67 ns |  0.732 ns |  0.612 ns |  74.56 ns |  1.13x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 | 126.03 ns |  1.131 ns |  0.945 ns | 125.71 ns |  1.91x slower |   0.02x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  77.89 ns |  6.155 ns | 18.147 ns |  67.72 ns |  1.02x slower |   0.08x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 556.82 ns |  6.885 ns |  6.440 ns | 553.47 ns |  8.43x slower |   0.13x | 3.0670 |    6424 B |          NA |
