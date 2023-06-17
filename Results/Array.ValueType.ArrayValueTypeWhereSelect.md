## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |     Error |    StdDev |     Median |         Ratio | RatioSD |    Gen0 |    Gen1 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|----------:|----------:|-----------:|--------------:|--------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   891.5 ns |   6.17 ns |   4.82 ns |   891.3 ns |      baseline |         |       - |       - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   956.4 ns |  18.68 ns |  16.56 ns |   949.1 ns |  1.07x slower |   0.02x |       - |       - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,580.7 ns |  18.33 ns |  14.31 ns | 1,576.8 ns |  1.77x slower |   0.02x |  0.1030 |       - |     216 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 1,712.4 ns |  14.66 ns |  13.00 ns | 1,710.8 ns |  1.92x slower |   0.02x |  4.7264 |       - |    9904 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 3,407.0 ns |  20.11 ns |  17.83 ns | 3,405.2 ns |  3.82x slower |   0.02x |  6.0196 |       - |   12624 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 1,943.6 ns |  23.10 ns |  18.04 ns | 1,939.9 ns |  2.18x slower |   0.02x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 7,896.6 ns | 129.55 ns | 114.84 ns | 7,855.0 ns |  8.85x slower |   0.13x | 52.0782 | 10.4065 |  134824 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 | 1,532.2 ns |  30.66 ns |  40.92 ns | 1,544.5 ns |  1.70x slower |   0.04x |       - |       - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 6,707.8 ns |  41.64 ns |  36.92 ns | 6,700.4 ns |  7.52x slower |   0.05x |  0.4578 |       - |     976 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 1,172.2 ns |   9.30 ns |   8.24 ns | 1,170.9 ns |  1.31x slower |   0.01x |  0.0305 |       - |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1,015.3 ns |  19.93 ns |  25.21 ns | 1,004.2 ns |  1.14x slower |   0.03x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1,491.8 ns |  19.95 ns |  15.57 ns | 1,491.5 ns |  1.67x slower |   0.02x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1,844.6 ns |  36.28 ns |  30.30 ns | 1,834.1 ns |  2.07x slower |   0.04x |       - |       - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 2,650.0 ns |  51.64 ns | 115.49 ns | 2,599.8 ns |  3.02x slower |   0.14x |  3.0670 |       - |    6424 B |          NA |
|                          |        |          |       |            |           |           |            |               |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |   423.2 ns |   8.47 ns |   7.92 ns |   419.8 ns |      baseline |         |       - |       - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   466.6 ns |   9.22 ns |  13.79 ns |   459.3 ns |  1.10x slower |   0.03x |       - |       - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 1,043.2 ns |   7.07 ns |   6.27 ns | 1,040.7 ns |  2.46x slower |   0.05x |  0.1030 |       - |     216 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 1,646.4 ns |  17.21 ns |  18.41 ns | 1,640.9 ns |  3.89x slower |   0.10x |  4.7264 |       - |    9904 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 2,831.0 ns |  26.68 ns |  20.83 ns | 2,825.8 ns |  6.67x slower |   0.12x |  6.0234 |       - |   12624 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 2,152.1 ns |  33.79 ns |  28.22 ns | 2,141.7 ns |  5.08x slower |   0.13x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 7,207.2 ns |  65.08 ns |  54.34 ns | 7,187.4 ns | 17.01x slower |   0.32x | 62.4695 |  0.0229 |  134810 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 | 1,155.6 ns |  12.13 ns |   9.47 ns | 1,153.1 ns |  2.72x slower |   0.06x |       - |       - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 6,405.0 ns |  42.42 ns |  39.68 ns | 6,399.7 ns | 15.14x slower |   0.30x |  0.4578 |       - |     976 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   991.8 ns |   6.96 ns |   5.43 ns |   990.5 ns |  2.34x slower |   0.04x |  0.0305 |       - |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   527.6 ns |  10.35 ns |   9.18 ns |   523.3 ns |  1.25x slower |   0.04x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   975.5 ns |  19.37 ns |  30.16 ns |   975.0 ns |  2.28x slower |   0.10x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   525.7 ns |  10.22 ns |   8.53 ns |   522.8 ns |  1.24x slower |   0.02x |       - |       - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 1,879.0 ns |  37.33 ns |  66.36 ns | 1,861.3 ns |  4.51x slower |   0.14x |  3.0670 |       - |    6424 B |          NA |
