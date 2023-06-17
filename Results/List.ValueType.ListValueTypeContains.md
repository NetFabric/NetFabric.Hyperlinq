## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|                   Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 | 570.33 ns |  1.496 ns |  1.249 ns | 570.14 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 692.07 ns | 13.330 ns | 22.993 ns | 683.92 ns | 1.21x slower |   0.04x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 223.34 ns |  2.817 ns |  2.893 ns | 222.68 ns | 2.55x faster |   0.04x |      - |         - |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 207.10 ns |  4.823 ns | 13.761 ns | 199.54 ns | 2.83x faster |   0.14x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 599.26 ns | 15.738 ns | 44.901 ns | 577.85 ns | 1.11x slower |   0.08x | 3.0670 |    6424 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 223.84 ns |  1.153 ns |  1.079 ns | 223.58 ns | 2.55x faster |   0.01x |      - |         - |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 430.86 ns | 10.053 ns | 28.843 ns | 414.03 ns | 1.29x faster |   0.09x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 432.08 ns |  5.461 ns |  5.363 ns | 431.52 ns | 1.32x faster |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 236.92 ns |  4.753 ns | 12.521 ns | 229.72 ns | 2.42x faster |   0.11x | 0.0153 |      32 B |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 539.96 ns |  7.047 ns |  5.502 ns | 537.16 ns | 1.06x faster |   0.01x | 0.0305 |      64 B |          NA |
|                          |        |          |       |           |           |           |           |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 | 265.87 ns |  2.110 ns |  1.762 ns | 265.45 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 353.31 ns |  4.681 ns |  4.807 ns | 352.04 ns | 1.33x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |  52.62 ns |  0.778 ns |  0.865 ns |  52.27 ns | 5.04x faster |   0.08x |      - |         - |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |  53.80 ns |  0.283 ns |  0.251 ns |  53.75 ns | 4.94x faster |   0.04x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 471.18 ns |  9.020 ns |  7.043 ns | 469.20 ns | 1.77x slower |   0.03x | 3.0670 |    6424 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |  53.21 ns |  1.046 ns |  1.887 ns |  52.32 ns | 5.01x faster |   0.16x |      - |         - |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 285.85 ns |  2.730 ns |  2.280 ns | 285.23 ns | 1.08x slower |   0.01x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 277.32 ns |  2.921 ns |  2.281 ns | 276.44 ns | 1.04x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |  61.13 ns |  0.886 ns |  1.088 ns |  60.73 ns | 4.36x faster |   0.10x | 0.0153 |      32 B |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 420.12 ns |  4.557 ns |  4.476 ns | 419.20 ns | 1.58x slower |   0.02x | 0.0305 |      64 B |          NA |
