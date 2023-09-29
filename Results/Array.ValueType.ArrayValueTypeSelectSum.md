## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|                  ForLoop | .NET 6.0 |   100 |  63.95 ns |  0.269 ns |  0.238 ns |  63.90 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 141.06 ns |  0.563 ns |  0.499 ns | 141.06 ns |  2.21x slower |   0.01x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 649.43 ns |  7.429 ns |  5.800 ns | 647.23 ns | 10.15x slower |   0.10x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 300.42 ns |  5.083 ns |  5.650 ns | 298.02 ns |  4.72x slower |   0.11x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 243.60 ns |  1.274 ns |  1.130 ns | 243.85 ns |  3.81x slower |   0.02x |      - |         - |          NA |
|                   LinqAF | .NET 6.0 |   100 | 667.84 ns | 12.698 ns | 18.613 ns | 665.48 ns | 10.37x slower |   0.27x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 226.83 ns |  0.922 ns |  0.720 ns | 226.91 ns |  3.54x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |  75.97 ns |  0.355 ns |  0.296 ns |  75.88 ns |  1.19x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 439.02 ns |  2.006 ns |  1.566 ns | 438.96 ns |  6.86x slower |   0.02x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 301.08 ns |  2.654 ns |  2.216 ns | 300.00 ns |  4.71x slower |   0.04x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 737.66 ns | 15.553 ns | 44.373 ns | 714.00 ns | 11.80x slower |   0.81x | 0.2174 |     456 B |          NA |
|                          |          |       |           |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  42.59 ns |  0.673 ns |  1.161 ns |  42.05 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  42.65 ns |  0.165 ns |  0.129 ns |  42.62 ns |  1.00x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 225.59 ns |  0.959 ns |  0.850 ns | 225.56 ns |  5.30x slower |   0.17x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 8.0 |   100 | 136.89 ns |  0.963 ns |  0.804 ns | 136.75 ns |  3.23x slower |   0.09x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 134.28 ns |  1.531 ns |  1.357 ns | 134.19 ns |  3.15x slower |   0.11x |      - |         - |          NA |
|                   LinqAF | .NET 8.0 |   100 | 274.98 ns |  1.693 ns |  1.321 ns | 274.89 ns |  6.48x slower |   0.21x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 | 178.34 ns |  1.709 ns |  1.427 ns | 177.71 ns |  4.20x slower |   0.14x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  85.54 ns |  1.670 ns |  2.649 ns |  84.11 ns |  2.00x slower |   0.09x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 | 122.03 ns |  0.537 ns |  0.419 ns | 122.01 ns |  2.87x slower |   0.10x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  40.13 ns |  0.321 ns |  0.268 ns |  40.00 ns |  1.06x faster |   0.04x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 256.52 ns |  2.118 ns |  1.768 ns | 256.05 ns |  6.05x slower |   0.21x | 0.2027 |     424 B |          NA |
