## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|                  ForLoop | .NET 6.0 |   100 |  65.94 ns |  0.542 ns |  0.423 ns |  65.89 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |  65.72 ns |  0.568 ns |  0.444 ns |  65.62 ns |  1.00x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 666.55 ns |  4.844 ns |  3.782 ns | 666.21 ns | 10.11x slower |   0.04x | 0.0496 |     104 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 352.74 ns |  2.274 ns |  2.527 ns | 352.13 ns |  5.36x slower |   0.06x | 0.3171 |     664 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 900.40 ns |  5.715 ns |  5.346 ns | 899.00 ns | 13.66x slower |   0.10x | 0.4120 |     864 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 485.85 ns |  3.560 ns |  2.973 ns | 486.96 ns |  7.37x slower |   0.07x |      - |         - |          NA |
|                 SpanLinq | .NET 6.0 |   100 | 401.72 ns |  3.772 ns |  3.150 ns | 400.77 ns |  6.09x slower |   0.08x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 346.83 ns |  6.787 ns |  8.583 ns | 342.40 ns |  5.27x slower |   0.13x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 210.76 ns |  1.939 ns |  1.514 ns | 210.40 ns |  3.20x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 338.22 ns |  6.428 ns |  6.013 ns | 336.52 ns |  5.13x slower |   0.10x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 214.08 ns |  4.055 ns |  3.793 ns | 212.50 ns |  3.25x slower |   0.07x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 390.18 ns |  6.243 ns |  4.874 ns | 388.81 ns |  5.92x slower |   0.09x | 0.2027 |     424 B |          NA |
|                          |          |       |           |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  66.75 ns |  1.370 ns |  1.069 ns |  66.50 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  67.46 ns |  1.385 ns |  1.156 ns |  67.14 ns |  1.01x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 240.80 ns |  3.444 ns |  2.689 ns | 240.63 ns |  3.61x slower |   0.07x | 0.0496 |     104 B |          NA |
|               LinqFaster | .NET 8.0 |   100 | 185.82 ns |  3.237 ns |  5.584 ns | 184.10 ns |  2.77x slower |   0.08x | 0.3171 |     664 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 571.43 ns | 11.420 ns | 32.397 ns | 555.15 ns |  8.95x slower |   0.18x | 0.4129 |     864 B |          NA |
|                   LinqAF | .NET 8.0 |   100 | 181.23 ns |  3.456 ns |  6.053 ns | 179.43 ns |  2.70x slower |   0.08x |      - |         - |          NA |
|                 SpanLinq | .NET 8.0 |   100 | 239.42 ns |  3.059 ns |  3.273 ns | 238.60 ns |  3.59x slower |   0.09x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 | 179.59 ns |  3.939 ns | 11.365 ns | 173.22 ns |  2.72x slower |   0.20x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  88.07 ns |  0.886 ns |  0.739 ns |  87.92 ns |  1.32x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 | 178.17 ns |  2.014 ns |  1.682 ns | 177.48 ns |  2.67x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  78.45 ns |  1.463 ns |  2.320 ns |  77.39 ns |  1.19x slower |   0.05x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 200.80 ns |  2.278 ns |  1.903 ns | 199.78 ns |  3.01x slower |   0.05x | 0.2027 |     424 B |          NA |
