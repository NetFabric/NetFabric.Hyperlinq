## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|                  ForLoop | .NET 6.0 |   100 |  65.37 ns |  0.324 ns |  0.271 ns |  65.34 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |  65.17 ns |  0.168 ns |  0.140 ns |  65.14 ns |  1.00x faster |   0.00x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 473.12 ns |  3.553 ns |  3.323 ns | 473.36 ns |  7.24x slower |   0.06x | 0.0229 |      48 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 281.64 ns |  2.741 ns |  2.289 ns | 281.72 ns |  4.31x slower |   0.03x | 0.3171 |     664 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 696.76 ns | 12.084 ns | 26.524 ns | 684.75 ns | 10.45x slower |   0.34x | 0.2136 |     448 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 393.25 ns |  8.675 ns | 25.030 ns | 378.86 ns |  6.17x slower |   0.43x |      - |         - |          NA |
|                 SpanLinq | .NET 6.0 |   100 | 301.16 ns |  4.819 ns |  8.182 ns | 298.68 ns |  4.68x slower |   0.16x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 309.55 ns |  5.694 ns | 10.412 ns | 309.78 ns |  4.78x slower |   0.15x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 162.63 ns |  1.186 ns |  0.990 ns | 162.19 ns |  2.49x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 311.84 ns |  6.223 ns | 11.989 ns | 312.01 ns |  4.71x slower |   0.15x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 204.10 ns |  1.178 ns |  0.984 ns | 203.63 ns |  3.12x slower |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 371.17 ns |  3.720 ns |  3.107 ns | 370.74 ns |  5.68x slower |   0.06x | 0.2027 |     424 B |          NA |
|                          |          |       |           |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  65.10 ns |  0.270 ns |  0.239 ns |  65.01 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  64.69 ns |  0.461 ns |  0.431 ns |  64.55 ns |  1.01x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 198.44 ns |  1.380 ns |  1.356 ns | 198.48 ns |  3.05x slower |   0.03x | 0.0229 |      48 B |          NA |
|               LinqFaster | .NET 8.0 |   100 | 177.16 ns |  2.994 ns |  4.196 ns | 176.98 ns |  2.72x slower |   0.06x | 0.3173 |     664 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 383.80 ns |  7.202 ns |  5.623 ns | 382.42 ns |  5.89x slower |   0.09x | 0.2141 |     448 B |          NA |
|                   LinqAF | .NET 8.0 |   100 | 158.43 ns |  2.980 ns |  3.189 ns | 157.48 ns |  2.44x slower |   0.05x |      - |         - |          NA |
|                 SpanLinq | .NET 8.0 |   100 | 185.10 ns |  3.433 ns |  4.217 ns | 182.81 ns |  2.86x slower |   0.08x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 | 126.65 ns |  2.435 ns |  2.278 ns | 125.79 ns |  1.95x slower |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  58.48 ns |  0.548 ns |  0.486 ns |  58.30 ns |  1.11x faster |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 | 100.94 ns |  1.053 ns |  0.879 ns | 100.72 ns |  1.55x slower |   0.02x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  76.22 ns |  1.049 ns |  0.930 ns |  75.96 ns |  1.17x slower |   0.01x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 233.14 ns |  3.457 ns |  3.233 ns | 232.54 ns |  3.58x slower |   0.06x | 0.2027 |     424 B |          NA |
