## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                  ForLoop | .NET 6 | .NET 6.0 |   100 | 1,183.9 ns |  15.29 ns |  20.41 ns | 1,189.1 ns |     baseline |         |  3.8605 |       - |    7.9 KB |             |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 1,282.6 ns |  24.74 ns |  20.66 ns | 1,281.1 ns | 1.08x slower |   0.02x |  3.8605 |       - |    7.9 KB |  1.00x more |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,503.0 ns |  12.87 ns |  12.04 ns | 1,504.1 ns | 1.27x slower |   0.02x |  3.9673 |       - |   8.11 KB |  1.03x more |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 1,567.1 ns |  37.96 ns | 110.14 ns | 1,512.6 ns | 1.32x slower |   0.08x |  6.4087 |       - |   13.1 KB |  1.66x more |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 2,839.7 ns |  63.11 ns | 181.07 ns | 2,745.4 ns | 2.37x slower |   0.15x |  9.0332 |       - |  18.48 KB |  2.34x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 2,330.8 ns |  42.14 ns |  93.39 ns | 2,295.3 ns | 1.98x slower |   0.08x |  3.8605 |       - |    7.9 KB |  1.00x more |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 7,571.1 ns | 193.64 ns | 549.33 ns | 7,276.5 ns | 6.60x slower |   0.52x | 64.5142 |       - | 135.07 KB | 17.10x more |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 | 1,828.0 ns |  36.02 ns |  60.19 ns | 1,802.5 ns | 1.55x slower |   0.05x |  3.8605 |       - |    7.9 KB |  1.00x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 6,970.8 ns | 136.20 ns | 379.67 ns | 6,787.7 ns | 5.96x slower |   0.32x |  4.1199 |       - |   8.43 KB |  1.07x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 1,527.0 ns |  32.19 ns |  91.83 ns | 1,480.8 ns | 1.30x slower |   0.08x |  1.7223 |       - |   3.52 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1,148.4 ns |  22.96 ns |  55.45 ns | 1,123.3 ns | 1.03x faster |   0.06x |  1.6766 |       - |   3.43 KB |  2.30x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1,633.2 ns |  30.17 ns |  62.98 ns | 1,600.8 ns | 1.38x slower |   0.06x |  1.6766 |       - |   3.43 KB |  2.30x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1,301.0 ns |  10.86 ns |   8.48 ns | 1,297.0 ns | 1.09x slower |   0.02x |  1.6766 |       - |   3.43 KB |  2.30x less |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 1,580.6 ns |  36.17 ns | 103.76 ns | 1,526.1 ns | 1.34x slower |   0.10x |  6.1531 |       - |  12.58 KB |  1.59x more |
|                          |        |          |       |            |           |           |            |              |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 | 1,044.8 ns |  20.74 ns |  46.39 ns | 1,028.1 ns |     baseline |         |  3.8605 |       - |    7.9 KB |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 1,095.8 ns |  18.57 ns |  17.37 ns | 1,090.9 ns | 1.02x slower |   0.04x |  3.8605 |       - |    7.9 KB |  1.00x more |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 1,166.4 ns |  15.20 ns |  12.69 ns | 1,168.7 ns | 1.08x slower |   0.05x |  3.9673 |       - |   8.11 KB |  1.03x more |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 1,574.6 ns |  64.13 ns | 187.07 ns | 1,472.1 ns | 1.55x slower |   0.22x |  6.4087 |       - |   13.1 KB |  1.66x more |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 2,407.6 ns |  45.95 ns | 106.50 ns | 2,369.1 ns | 2.31x slower |   0.12x |  9.0332 |       - |  18.48 KB |  2.34x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 1,482.9 ns |  30.62 ns |  86.86 ns | 1,457.7 ns | 1.43x slower |   0.12x |  3.8605 |       - |    7.9 KB |  1.00x more |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 7,866.9 ns | 155.67 ns | 351.37 ns | 7,776.4 ns | 7.55x slower |   0.43x | 53.3295 | 13.3209 | 135.05 KB | 17.10x more |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 | 1,458.0 ns |  30.97 ns |  89.37 ns | 1,420.1 ns | 1.39x slower |   0.10x |  3.8605 |       - |    7.9 KB |  1.00x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 6,512.3 ns | 124.32 ns | 127.66 ns | 6,442.9 ns | 6.09x slower |   0.27x |  4.1199 |       - |   8.43 KB |  1.07x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 1,090.8 ns |   8.34 ns |   6.97 ns | 1,089.9 ns | 1.01x slower |   0.05x |  1.7223 |       - |   3.52 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   986.6 ns |   6.35 ns |   4.95 ns |   986.8 ns | 1.10x faster |   0.05x |  1.6766 |       - |   3.43 KB |  2.30x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 1,066.4 ns |  11.64 ns |  10.31 ns | 1,066.7 ns | 1.01x faster |   0.05x |  1.6766 |       - |   3.43 KB |  2.30x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 1,075.2 ns |  15.39 ns |  12.85 ns | 1,076.9 ns | 1.01x faster |   0.04x |  1.6766 |       - |   3.43 KB |  2.30x less |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 1,412.6 ns |  28.25 ns |  59.59 ns | 1,394.5 ns | 1.35x slower |   0.09x |  6.1531 |       - |  12.58 KB |  1.59x more |
