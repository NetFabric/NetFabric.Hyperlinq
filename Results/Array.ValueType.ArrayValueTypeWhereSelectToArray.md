## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|                   Method |    Job |  Runtime | Count |       Mean |     Error |    StdDev |     Median |        Ratio | RatioSD |    Gen0 |    Gen1 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|----------:|----------:|-----------:|-------------:|--------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 | 1,380.8 ns |  27.17 ns |  58.50 ns | 1,357.5 ns |     baseline |         |  5.5237 |       - |   11.3 KB |             |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 1,572.7 ns |  40.14 ns | 116.44 ns | 1,519.2 ns | 1.15x slower |   0.09x |  5.5237 |       - |   11.3 KB |  1.00x more |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,625.4 ns |  25.06 ns |  19.56 ns | 1,625.2 ns | 1.17x slower |   0.06x |  3.9291 |       - |   8.03 KB |  1.41x less |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 1,241.7 ns |   9.18 ns |   7.17 ns | 1,240.2 ns | 1.12x faster |   0.07x |  4.7264 |       - |   9.67 KB |  1.17x less |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 2,378.7 ns |  45.17 ns |  83.72 ns | 2,353.0 ns | 1.72x slower |   0.09x |  6.0043 |       - |   12.3 KB |  1.09x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 2,447.8 ns |  35.08 ns |  64.15 ns | 2,433.4 ns | 1.77x slower |   0.10x |  5.5084 |       - |  11.27 KB |  1.00x less |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 7,755.1 ns | 193.77 ns | 555.95 ns | 7,558.6 ns | 5.63x slower |   0.46x | 52.0859 | 10.4141 | 131.63 KB | 11.65x more |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 | 2,086.3 ns |  37.54 ns |  41.72 ns | 2,072.1 ns | 1.52x slower |   0.08x |  5.5237 |       - |   11.3 KB |  1.00x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 7,024.9 ns |  52.51 ns |  41.00 ns | 7,021.2 ns | 5.06x slower |   0.28x |  5.7678 |       - |   11.8 KB |  1.04x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 1,420.6 ns |  28.32 ns |  36.82 ns | 1,419.6 ns | 1.03x slower |   0.06x |  1.7052 |       - |   3.49 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1,038.9 ns |   8.44 ns |   7.48 ns | 1,037.3 ns | 1.33x faster |   0.08x |  1.6575 |       - |    3.4 KB |  3.32x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1,702.6 ns |  35.77 ns | 104.92 ns | 1,651.1 ns | 1.23x slower |   0.08x |  1.6575 |       - |    3.4 KB |  3.32x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1,330.0 ns |  26.50 ns |  42.79 ns | 1,316.4 ns | 1.04x faster |   0.04x |  1.6575 |       - |    3.4 KB |  3.32x less |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 1,040.9 ns |  15.01 ns |  11.72 ns | 1,040.8 ns | 1.34x faster |   0.09x |  3.0670 |       - |   6.27 KB |  1.80x less |
|                          |        |          |       |            |           |           |            |              |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 | 1,268.9 ns |  15.30 ns |  12.78 ns | 1,265.0 ns |     baseline |         |  5.5237 |       - |   11.3 KB |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 1,305.5 ns |  14.78 ns |  16.42 ns | 1,303.1 ns | 1.03x slower |   0.02x |  5.5237 |       - |   11.3 KB |  1.00x more |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 1,185.1 ns |  23.37 ns |  29.55 ns | 1,188.2 ns | 1.05x faster |   0.02x |  3.9291 |       - |   8.03 KB |  1.41x less |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 1,195.1 ns |  12.50 ns |  11.08 ns | 1,190.8 ns | 1.06x faster |   0.01x |  4.7264 |       - |   9.67 KB |  1.17x less |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 1,973.3 ns |  35.08 ns |  31.09 ns | 1,960.6 ns | 1.56x slower |   0.02x |  6.0043 |       - |   12.3 KB |  1.09x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 1,779.4 ns |  34.19 ns |  95.88 ns | 1,743.1 ns | 1.42x slower |   0.10x |  5.5084 |       - |  11.27 KB |  1.00x less |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 7,372.5 ns |  83.33 ns |  77.95 ns | 7,335.0 ns | 5.81x slower |   0.06x | 52.0782 | 10.4065 | 131.62 KB | 11.65x more |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 | 2,014.8 ns |  15.01 ns |  13.31 ns | 2,009.5 ns | 1.59x slower |   0.02x |  5.5237 |       - |   11.3 KB |  1.00x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 6,745.1 ns | 128.11 ns | 301.97 ns | 6,604.0 ns | 5.41x slower |   0.19x |  5.7678 |       - |   11.8 KB |  1.04x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 1,168.6 ns |  11.29 ns |   9.43 ns | 1,164.5 ns | 1.09x faster |   0.01x |  1.7052 |       - |   3.49 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   937.6 ns |   5.91 ns |   5.24 ns |   936.5 ns | 1.35x faster |   0.01x |  1.6575 |       - |    3.4 KB |  3.32x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 1,050.5 ns |  20.59 ns |  28.87 ns | 1,039.2 ns | 1.21x faster |   0.04x |  1.6575 |       - |    3.4 KB |  3.32x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   981.3 ns |  18.24 ns |  18.73 ns |   972.3 ns | 1.29x faster |   0.02x |  1.6575 |       - |    3.4 KB |  3.32x less |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   919.1 ns |   8.16 ns |   7.23 ns |   918.6 ns | 1.38x faster |   0.01x |  3.0670 |       - |   6.27 KB |  1.80x less |
