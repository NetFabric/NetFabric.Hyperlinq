## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |     Error |    StdDev |     Median |         Ratio | RatioSD |    Gen0 |   Gen1 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|----------:|----------:|-----------:|--------------:|--------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 | 1,364.1 ns |  12.76 ns |   9.97 ns | 1,361.7 ns |      baseline |         |       - |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 1,097.7 ns |  20.48 ns |  29.38 ns | 1,084.2 ns |  1.25x faster |   0.03x |       - |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,777.5 ns |  19.87 ns |  15.51 ns | 1,772.2 ns |  1.30x slower |   0.02x |  0.1793 |      - |     376 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 2,235.4 ns |  42.05 ns |  71.40 ns | 2,207.3 ns |  1.65x slower |   0.07x |  3.8605 |      - |    8088 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 2,470.8 ns |  37.20 ns |  34.80 ns | 2,475.2 ns |  1.81x slower |   0.03x |  6.4087 |      - |   13416 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 2,479.1 ns |  29.97 ns |  23.40 ns | 2,473.9 ns |  1.82x slower |   0.02x |       - |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 7,988.5 ns | 119.37 ns | 122.58 ns | 7,971.8 ns |  5.87x slower |   0.11x | 62.4847 |      - |  134925 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 7,599.3 ns |  50.13 ns |  44.44 ns | 7,587.1 ns |  5.57x slower |   0.06x |  0.4730 |      - |    1000 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 1,169.6 ns |   9.56 ns |   7.98 ns | 1,167.8 ns |  1.17x faster |   0.01x |  0.0343 |      - |      72 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1,045.9 ns |   9.76 ns |   8.15 ns | 1,043.0 ns |  1.30x faster |   0.02x |       - |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1,509.3 ns |  30.01 ns |  71.32 ns | 1,467.4 ns |  1.10x slower |   0.05x |       - |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1,245.6 ns |   6.41 ns |   5.01 ns | 1,245.5 ns |  1.10x faster |   0.01x |       - |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 2,187.3 ns |  33.74 ns |  69.68 ns | 2,172.1 ns |  1.57x slower |   0.03x |  3.8605 |      - |    8088 B |          NA |
|                          |        |          |       |            |           |           |            |               |         |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |   495.5 ns |   2.03 ns |   1.90 ns |   495.4 ns |      baseline |         |       - |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   584.5 ns |   2.64 ns |   2.20 ns |   584.1 ns |  1.18x slower |   0.01x |       - |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 1,221.8 ns |  18.26 ns |  20.30 ns | 1,212.0 ns |  2.47x slower |   0.05x |  0.1793 |      - |     376 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 1,688.9 ns |  21.77 ns |  25.07 ns | 1,683.0 ns |  3.41x slower |   0.05x |  3.8605 |      - |    8088 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 1,983.1 ns |  37.69 ns |  33.41 ns | 1,971.2 ns |  4.00x slower |   0.07x |  6.4087 |      - |   13416 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 1,321.1 ns |   7.90 ns |   6.17 ns | 1,318.9 ns |  2.66x slower |   0.01x |       - |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 7,888.0 ns | 136.73 ns | 191.68 ns | 7,821.3 ns | 16.04x slower |   0.49x | 62.4542 | 0.0305 |  134906 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 6,321.0 ns | 111.48 ns |  93.09 ns | 6,314.2 ns | 12.75x slower |   0.19x |  0.4730 |      - |    1000 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 1,063.1 ns |  20.76 ns |  21.32 ns | 1,054.2 ns |  2.15x slower |   0.05x |  0.0343 |      - |      72 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   532.2 ns |   9.73 ns |   8.62 ns |   527.2 ns |  1.07x slower |   0.02x |       - |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 1,010.9 ns |  17.95 ns |  14.99 ns | 1,004.1 ns |  2.04x slower |   0.03x |       - |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   567.1 ns |   8.77 ns |  10.77 ns |   563.0 ns |  1.15x slower |   0.02x |       - |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 1,729.7 ns |  34.47 ns |  87.74 ns | 1,697.7 ns |  3.54x slower |   0.18x |  3.8605 |      - |    8088 B |          NA |
