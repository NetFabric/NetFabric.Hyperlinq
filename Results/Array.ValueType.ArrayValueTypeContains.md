## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|                   Method |  Runtime | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 | 430.13 ns | 2.721 ns | 2.412 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 442.66 ns | 3.092 ns | 2.741 ns | 1.03x slower |   0.01x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 194.59 ns | 1.697 ns | 1.325 ns | 2.21x faster |   0.02x |      - |         - |          NA |
|               LinqFaster | .NET 6.0 |   100 | 194.74 ns | 2.893 ns | 2.706 ns | 2.21x faster |   0.03x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 190.08 ns | 1.222 ns | 1.200 ns | 2.26x faster |   0.02x |      - |         - |          NA |
|                   LinqAF | .NET 6.0 |   100 | 196.27 ns | 0.971 ns | 1.080 ns | 2.19x faster |   0.02x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 | 427.54 ns | 2.193 ns | 2.438 ns | 1.01x faster |   0.01x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 345.11 ns | 3.321 ns | 2.773 ns | 1.25x faster |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 206.77 ns | 1.514 ns | 1.342 ns | 2.08x faster |   0.02x | 0.0153 |      32 B |          NA |
|                  Faslinq | .NET 6.0 |   100 | 477.15 ns | 4.248 ns | 3.547 ns | 1.11x slower |   0.01x | 0.0305 |      64 B |          NA |
|                          |          |       |           |          |          |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 | 185.19 ns | 1.076 ns | 1.196 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 | 184.78 ns | 3.063 ns | 2.558 ns | 1.00x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |  52.51 ns | 0.815 ns | 0.636 ns | 3.52x faster |   0.05x |      - |         - |          NA |
|               LinqFaster | .NET 8.0 |   100 |  62.07 ns | 1.283 ns | 1.668 ns | 2.98x faster |   0.08x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 |  52.99 ns | 0.945 ns | 0.738 ns | 3.49x faster |   0.05x |      - |         - |          NA |
|                   LinqAF | .NET 8.0 |   100 |  55.03 ns | 1.047 ns | 1.205 ns | 3.36x faster |   0.08x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 | 275.40 ns | 1.901 ns | 1.587 ns | 1.49x slower |   0.01x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 221.49 ns | 2.175 ns | 1.816 ns | 1.20x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |  59.68 ns | 0.828 ns | 0.734 ns | 3.10x faster |   0.04x | 0.0153 |      32 B |          NA |
|                  Faslinq | .NET 8.0 |   100 | 278.63 ns | 2.173 ns | 1.814 ns | 1.51x slower |   0.01x | 0.0305 |      64 B |          NA |
