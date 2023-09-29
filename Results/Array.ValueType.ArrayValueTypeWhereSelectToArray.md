## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                   Method |  Runtime | Count |       Mean |    Error |   StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 | 1,342.5 ns | 26.66 ns | 30.70 ns | 1,338.8 ns |     baseline |         | 5.5237 |   11.3 KB |             |
|              ForeachLoop | .NET 6.0 |   100 | 1,480.0 ns | 24.37 ns | 19.03 ns | 1,480.5 ns | 1.10x slower |   0.03x | 5.5237 |   11.3 KB |  1.00x more |
|                     Linq | .NET 6.0 |   100 | 1,627.9 ns | 25.44 ns | 23.80 ns | 1,627.3 ns | 1.21x slower |   0.03x | 3.9291 |   8.03 KB |  1.41x less |
|               LinqFaster | .NET 6.0 |   100 | 1,220.6 ns | 20.67 ns | 25.38 ns | 1,214.3 ns | 1.10x faster |   0.03x | 4.7264 |   9.67 KB |  1.17x less |
|             LinqFasterer | .NET 6.0 |   100 | 2,237.7 ns | 34.61 ns | 30.68 ns | 2,233.6 ns | 1.66x slower |   0.05x | 6.0043 |   12.3 KB |  1.09x more |
|                   LinqAF | .NET 6.0 |   100 | 2,427.8 ns | 48.01 ns | 64.09 ns | 2,420.9 ns | 1.81x slower |   0.07x | 5.5084 |  11.27 KB |  1.00x less |
|                 SpanLinq | .NET 6.0 |   100 | 2,070.1 ns | 36.91 ns | 61.67 ns | 2,065.5 ns | 1.55x slower |   0.07x | 5.5237 |   11.3 KB |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 1,406.4 ns | 15.43 ns | 12.89 ns | 1,409.9 ns | 1.05x slower |   0.03x | 1.7052 |   3.49 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 1,038.2 ns | 14.30 ns | 12.68 ns | 1,040.3 ns | 1.30x faster |   0.03x | 1.6575 |    3.4 KB |  3.32x less |
|                Hyperlinq | .NET 6.0 |   100 | 1,638.7 ns | 30.42 ns | 25.40 ns | 1,631.9 ns | 1.22x slower |   0.03x | 1.6575 |    3.4 KB |  3.32x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 1,238.8 ns | 24.72 ns | 39.21 ns | 1,226.2 ns | 1.09x faster |   0.05x | 1.6575 |    3.4 KB |  3.32x less |
|                  Faslinq | .NET 6.0 |   100 | 1,007.5 ns | 10.10 ns |  8.44 ns | 1,011.2 ns | 1.33x faster |   0.03x | 3.0670 |   6.27 KB |  1.80x less |
|                          |          |       |            |          |          |            |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |   908.6 ns | 17.87 ns | 19.12 ns |   902.5 ns |     baseline |         | 5.5246 |   11.3 KB |             |
|              ForeachLoop | .NET 8.0 |   100 |   973.3 ns | 20.31 ns | 58.28 ns |   972.4 ns | 1.02x slower |   0.05x | 5.5246 |   11.3 KB |  1.00x more |
|                     Linq | .NET 8.0 |   100 |   993.3 ns | 19.85 ns | 55.65 ns |   967.6 ns | 1.10x slower |   0.06x | 3.9291 |   8.03 KB |  1.41x less |
|               LinqFaster | .NET 8.0 |   100 |   879.8 ns | 16.16 ns | 12.61 ns |   877.6 ns | 1.04x faster |   0.03x | 4.7274 |   9.67 KB |  1.17x less |
|             LinqFasterer | .NET 8.0 |   100 | 1,407.9 ns | 29.47 ns | 82.64 ns | 1,392.1 ns | 1.61x slower |   0.10x | 6.0043 |   12.3 KB |  1.09x more |
|                   LinqAF | .NET 8.0 |   100 | 1,559.7 ns | 19.90 ns | 20.43 ns | 1,552.0 ns | 1.72x slower |   0.04x | 5.5084 |  11.27 KB |  1.00x less |
|                 SpanLinq | .NET 8.0 |   100 | 1,143.7 ns | 14.90 ns | 13.21 ns | 1,144.0 ns | 1.26x slower |   0.03x | 5.5237 |   11.3 KB |  1.00x more |
|               StructLinq | .NET 8.0 |   100 | 1,034.7 ns | 20.71 ns | 58.42 ns | 1,012.9 ns | 1.16x slower |   0.05x | 1.7052 |   3.49 KB |  3.23x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   702.1 ns | 17.87 ns | 51.56 ns |   683.3 ns | 1.34x faster |   0.14x | 1.6575 |    3.4 KB |  3.32x less |
|                Hyperlinq | .NET 8.0 |   100 |   765.6 ns | 20.13 ns | 57.43 ns |   745.0 ns | 1.12x faster |   0.06x | 1.6575 |    3.4 KB |  3.32x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   651.3 ns | 15.19 ns | 42.85 ns |   660.3 ns | 1.34x faster |   0.06x | 1.6575 |    3.4 KB |  3.32x less |
|                  Faslinq | .NET 8.0 |   100 |   597.4 ns |  4.32 ns |  3.61 ns |   597.5 ns | 1.53x faster |   0.04x | 3.0670 |   6.27 KB |  1.80x less |
