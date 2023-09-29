## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                  ForLoop | .NET 6.0 |   100 |  55.20 ns |  1.127 ns |  1.054 ns |  54.92 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |  56.65 ns |  1.112 ns |  1.040 ns |  56.37 ns |  1.03x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 632.57 ns | 11.989 ns | 10.011 ns | 630.86 ns | 11.44x slower |   0.27x | 0.0229 |      48 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 278.37 ns |  2.014 ns |  1.785 ns | 278.69 ns |  5.04x slower |   0.08x | 0.2027 |     424 B |          NA |
|          LinqFaster_SIMD | .NET 6.0 |   100 | 104.50 ns |  2.078 ns |  2.310 ns | 103.77 ns |  1.89x slower |   0.06x | 0.2027 |     424 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 624.25 ns |  6.885 ns |  6.440 ns | 622.01 ns | 11.31x slower |   0.26x | 0.2174 |     456 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 247.64 ns |  2.579 ns |  2.154 ns | 248.42 ns |  4.48x slower |   0.10x |      - |         - |          NA |
|                 SpanLinq | .NET 6.0 |   100 | 226.66 ns |  4.029 ns |  3.364 ns | 225.61 ns |  4.10x slower |   0.10x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 228.55 ns |  3.541 ns |  2.956 ns | 227.59 ns |  4.13x slower |   0.11x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 160.27 ns |  2.591 ns |  2.424 ns | 159.54 ns |  2.90x slower |   0.07x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 236.73 ns |  4.466 ns | 10.261 ns | 232.60 ns |  4.35x slower |   0.25x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 178.48 ns |  2.446 ns |  2.042 ns | 177.68 ns |  3.23x slower |   0.08x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 254.00 ns |  4.909 ns |  6.208 ns | 252.44 ns |  4.62x slower |   0.18x | 0.2027 |     424 B |          NA |
|                          |          |       |           |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  45.18 ns |  0.239 ns |  0.187 ns |  45.15 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  47.06 ns |  0.812 ns |  0.678 ns |  46.83 ns |  1.04x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 190.87 ns |  1.741 ns |  1.359 ns | 190.21 ns |  4.23x slower |   0.03x | 0.0229 |      48 B |          NA |
|               LinqFaster | .NET 8.0 |   100 | 174.16 ns |  2.739 ns |  2.931 ns | 173.47 ns |  3.86x slower |   0.07x | 0.2027 |     424 B |          NA |
|          LinqFaster_SIMD | .NET 8.0 |   100 |  97.79 ns |  1.156 ns |  0.903 ns |  97.57 ns |  2.16x slower |   0.02x | 0.2027 |     424 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 250.10 ns |  2.344 ns |  1.830 ns | 250.08 ns |  5.54x slower |   0.04x | 0.2179 |     456 B |          NA |
|                   LinqAF | .NET 8.0 |   100 | 138.97 ns |  1.669 ns |  1.480 ns | 138.38 ns |  3.07x slower |   0.02x |      - |         - |          NA |
|                 SpanLinq | .NET 8.0 |   100 |  84.16 ns |  1.278 ns |  1.067 ns |  83.76 ns |  1.86x slower |   0.03x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 | 117.90 ns |  2.379 ns |  5.561 ns | 115.11 ns |  2.57x slower |   0.11x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  59.60 ns |  0.861 ns |  0.673 ns |  59.38 ns |  1.32x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 | 114.84 ns |  2.322 ns |  3.880 ns | 112.92 ns |  2.51x slower |   0.09x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  46.45 ns |  0.891 ns |  1.094 ns |  45.97 ns |  1.02x slower |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 190.44 ns |  4.380 ns | 12.638 ns | 189.09 ns |  4.11x slower |   0.15x | 0.2027 |     424 B |          NA |
