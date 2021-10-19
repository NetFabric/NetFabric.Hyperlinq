## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job | Count |     Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |------ |---------:|----------:|----------:|-------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |   100 | 1.683 μs | 0.0088 μs | 0.0083 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop |        .NET 6 |   100 | 1.813 μs | 0.0135 μs | 0.0127 μs | 1.08x slower |   0.01x |  5.5237 |       - |     11 KB |
|                     Linq |        .NET 6 |   100 | 1.807 μs | 0.0137 μs | 0.0128 μs | 1.07x slower |   0.01x |  4.0035 |       - |      8 KB |
|               LinqFaster |        .NET 6 |   100 | 2.075 μs | 0.0225 μs | 0.0211 μs | 1.23x slower |   0.02x |  5.5237 |       - |     11 KB |
|             LinqFasterer |        .NET 6 |   100 | 2.026 μs | 0.0095 μs | 0.0075 μs | 1.20x slower |   0.01x |  6.3934 |       - |     13 KB |
|                   LinqAF |        .NET 6 |   100 | 3.727 μs | 0.0287 μs | 0.0269 μs | 2.21x slower |   0.02x |  5.5122 |       - |     11 KB |
|            LinqOptimizer |        .NET 6 |   100 | 9.709 μs | 0.1081 μs | 0.0958 μs | 5.77x slower |   0.06x | 49.3774 | 12.3444 |    132 KB |
|                  Streams |        .NET 6 |   100 | 2.815 μs | 0.0196 μs | 0.0184 μs | 1.67x slower |   0.02x |  5.7716 |       - |     12 KB |
|               StructLinq |        .NET 6 |   100 | 1.632 μs | 0.0181 μs | 0.0160 μs | 1.03x faster |   0.01x |  1.7109 |       - |      4 KB |
| StructLinq_ValueDelegate |        .NET 6 |   100 | 1.211 μs | 0.0184 μs | 0.0173 μs | 1.39x faster |   0.02x |  1.6575 |       - |      3 KB |
|                Hyperlinq |        .NET 6 |   100 | 1.747 μs | 0.0124 μs | 0.0110 μs | 1.04x slower |   0.01x |  1.6575 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 | 1.392 μs | 0.0114 μs | 0.0106 μs | 1.21x faster |   0.01x |  1.6575 |       - |      3 KB |
|                          |               |       |          |           |           |              |         |         |         |           |
|                  ForLoop |    .NET 6 PGO |   100 | 1.634 μs | 0.0216 μs | 0.0202 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop |    .NET 6 PGO |   100 | 1.761 μs | 0.0110 μs | 0.0103 μs | 1.08x slower |   0.02x |  5.5237 |       - |     11 KB |
|                     Linq |    .NET 6 PGO |   100 | 1.908 μs | 0.0041 μs | 0.0032 μs | 1.16x slower |   0.01x |  4.0016 |       - |      8 KB |
|               LinqFaster |    .NET 6 PGO |   100 | 2.100 μs | 0.0178 μs | 0.0157 μs | 1.28x slower |   0.01x |  5.5237 |       - |     11 KB |
|             LinqFasterer |    .NET 6 PGO |   100 | 2.034 μs | 0.0082 μs | 0.0064 μs | 1.24x slower |   0.01x |  6.3934 |       - |     13 KB |
|                   LinqAF |    .NET 6 PGO |   100 | 3.140 μs | 0.0276 μs | 0.0258 μs | 1.92x slower |   0.03x |  5.5122 |       - |     11 KB |
|            LinqOptimizer |    .NET 6 PGO |   100 | 9.943 μs | 0.1812 μs | 0.1606 μs | 6.07x slower |   0.13x | 50.0031 | 16.6626 |    132 KB |
|                  Streams |    .NET 6 PGO |   100 | 2.823 μs | 0.0186 μs | 0.0165 μs | 1.72x slower |   0.02x |  5.7716 |       - |     12 KB |
|               StructLinq |    .NET 6 PGO |   100 | 1.509 μs | 0.0174 μs | 0.0155 μs | 1.09x faster |   0.01x |  1.7109 |       - |      4 KB |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 | 1.100 μs | 0.0181 μs | 0.0161 μs | 1.49x faster |   0.03x |  1.6575 |       - |      3 KB |
|                Hyperlinq |    .NET 6 PGO |   100 | 1.840 μs | 0.0200 μs | 0.0187 μs | 1.13x slower |   0.01x |  1.6575 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 | 1.395 μs | 0.0096 μs | 0.0085 μs | 1.17x faster |   0.01x |  1.6575 |       - |      3 KB |
|                          |               |       |          |           |           |              |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |   100 | 1.602 μs | 0.0283 μs | 0.0265 μs |     baseline |         |  5.5237 |       - |     11 KB |
|              ForeachLoop | .NET Core 3.1 |   100 | 1.926 μs | 0.0237 μs | 0.0221 μs | 1.20x slower |   0.02x |  5.5237 |       - |     11 KB |
|                     Linq | .NET Core 3.1 |   100 | 1.847 μs | 0.0130 μs | 0.0122 μs | 1.15x slower |   0.02x |  4.0035 |       - |      8 KB |
|               LinqFaster | .NET Core 3.1 |   100 | 1.944 μs | 0.0218 μs | 0.0193 μs | 1.22x slower |   0.02x |  5.5237 |       - |     11 KB |
|             LinqFasterer | .NET Core 3.1 |   100 | 1.981 μs | 0.0176 μs | 0.0156 μs | 1.24x slower |   0.03x |  6.3934 |       - |     13 KB |
|                   LinqAF | .NET Core 3.1 |   100 | 4.910 μs | 0.0371 μs | 0.0347 μs | 3.07x slower |   0.06x |  5.5084 |       - |     11 KB |
|            LinqOptimizer | .NET Core 3.1 |   100 | 9.374 μs | 0.1505 μs | 0.1408 μs | 5.85x slower |   0.11x | 62.7441 |  4.2267 |    132 KB |
|                  Streams | .NET Core 3.1 |   100 | 2.821 μs | 0.0207 μs | 0.0193 μs | 1.76x slower |   0.03x |  5.7716 |       - |     12 KB |
|               StructLinq | .NET Core 3.1 |   100 | 1.746 μs | 0.0215 μs | 0.0180 μs | 1.09x slower |   0.03x |  1.7109 |       - |      4 KB |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 | 1.396 μs | 0.0141 μs | 0.0132 μs | 1.15x faster |   0.02x |  1.6632 |       - |      3 KB |
|                Hyperlinq | .NET Core 3.1 |   100 | 2.185 μs | 0.0157 μs | 0.0139 μs | 1.37x slower |   0.02x |  1.6632 |       - |      3 KB |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 | 1.680 μs | 0.0118 μs | 0.0104 μs | 1.05x slower |   0.02x |  1.6632 |       - |      3 KB |
