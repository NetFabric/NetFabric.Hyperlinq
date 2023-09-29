## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                   Method |  Runtime | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |  64.85 ns |  0.625 ns |  0.554 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |  65.07 ns |  0.386 ns |  0.342 ns |  1.00x slower |   0.00x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 874.36 ns | 14.335 ns | 14.721 ns | 13.51x slower |   0.22x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 6.0 |   100 | 186.07 ns |  3.176 ns |  4.239 ns |  2.88x slower |   0.07x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 221.29 ns |  2.254 ns |  2.108 ns |  3.41x slower |   0.05x |      - |         - |          NA |
|                   LinqAF | .NET 6.0 |   100 | 221.39 ns |  3.245 ns |  3.333 ns |  3.42x slower |   0.07x |      - |         - |          NA |
|                 SpanLinq | .NET 6.0 |   100 | 280.22 ns |  2.620 ns |  2.046 ns |  4.32x slower |   0.05x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 251.32 ns |  2.439 ns |  2.162 ns |  3.88x slower |   0.04x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |  83.31 ns |  0.828 ns |  0.646 ns |  1.28x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 195.82 ns |  2.477 ns |  1.934 ns |  3.02x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 |  78.65 ns |  0.886 ns |  0.786 ns |  1.21x slower |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 334.80 ns |  5.451 ns |  4.255 ns |  5.16x slower |   0.09x | 0.2027 |     424 B |          NA |
|                          |          |       |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  65.99 ns |  1.306 ns |  1.504 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  65.50 ns |  1.015 ns |  1.086 ns |  1.01x faster |   0.03x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 170.12 ns |  1.179 ns |  0.985 ns |  2.56x slower |   0.06x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 8.0 |   100 | 101.49 ns |  2.020 ns |  1.791 ns |  1.53x slower |   0.05x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 107.83 ns |  2.100 ns |  2.579 ns |  1.64x slower |   0.07x |      - |         - |          NA |
|                   LinqAF | .NET 8.0 |   100 | 190.16 ns |  2.801 ns |  2.339 ns |  2.86x slower |   0.09x |      - |         - |          NA |
|                 SpanLinq | .NET 8.0 |   100 | 163.45 ns |  3.291 ns |  5.589 ns |  2.47x slower |   0.08x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 | 148.22 ns |  1.175 ns |  1.042 ns |  2.23x slower |   0.06x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  72.92 ns |  0.486 ns |  0.406 ns |  1.10x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 | 135.57 ns |  0.719 ns |  0.601 ns |  2.04x slower |   0.05x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  58.67 ns |  0.301 ns |  0.251 ns |  1.13x faster |   0.03x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 | 170.50 ns |  2.666 ns |  3.071 ns |  2.58x slower |   0.06x | 0.2027 |     424 B |          NA |
