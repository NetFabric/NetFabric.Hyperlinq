## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|                   Method |           Job | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |    72.34 ns |  0.351 ns |  0.293 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |    72.40 ns |  0.489 ns |  0.433 ns |  1.00x slower |   0.01x |      - |         - |
|                     Linq |        .NET 6 |   100 |   549.94 ns |  2.731 ns |  2.554 ns |  7.60x slower |   0.04x | 0.0229 |      48 B |
|               LinqFaster |        .NET 6 |   100 |   348.60 ns |  1.284 ns |  1.201 ns |  4.82x slower |   0.02x | 0.3171 |     664 B |
|             LinqFasterer |        .NET 6 |   100 |   853.58 ns |  5.217 ns |  4.624 ns | 11.79x slower |   0.08x | 0.2136 |     448 B |
|                   LinqAF |        .NET 6 |   100 |   394.17 ns |  1.957 ns |  1.735 ns |  5.45x slower |   0.03x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 1,767.88 ns | 10.415 ns |  9.742 ns | 24.44x slower |   0.20x | 4.1485 |   8,682 B |
|                 SpanLinq |        .NET 6 |   100 |   309.18 ns |  2.312 ns |  2.163 ns |  4.28x slower |   0.04x |      - |         - |
|                  Streams |        .NET 6 |   100 | 1,655.67 ns |  4.942 ns |  4.623 ns | 22.87x slower |   0.12x | 0.2785 |     584 B |
|               StructLinq |        .NET 6 |   100 |   366.01 ns |  1.848 ns |  1.638 ns |  5.06x slower |   0.03x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   179.79 ns |  0.657 ns |  0.614 ns |  2.49x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |   295.39 ns |  5.023 ns |  4.698 ns |  4.09x slower |   0.07x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   223.41 ns |  0.499 ns |  0.417 ns |  3.09x slower |   0.01x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |    73.33 ns |  0.453 ns |  0.423 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |    73.55 ns |  0.423 ns |  0.396 ns |  1.00x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   352.90 ns |  1.515 ns |  1.417 ns |  4.81x slower |   0.03x | 0.0229 |      48 B |
|               LinqFaster |    .NET 6 PGO |   100 |   344.08 ns |  2.805 ns |  2.624 ns |  4.69x slower |   0.05x | 0.3171 |     664 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   499.16 ns |  1.202 ns |  1.004 ns |  6.81x slower |   0.05x | 0.2136 |     448 B |
|                   LinqAF |    .NET 6 PGO |   100 |   495.09 ns |  4.163 ns |  3.690 ns |  6.75x slower |   0.07x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 1,558.16 ns | 13.962 ns | 12.377 ns | 21.26x slower |   0.23x | 4.1485 |   8,682 B |
|                 SpanLinq |    .NET 6 PGO |   100 |   248.13 ns |  0.944 ns |  0.883 ns |  3.38x slower |   0.02x |      - |         - |
|                  Streams |    .NET 6 PGO |   100 | 1,210.94 ns |  7.357 ns |  6.522 ns | 16.52x slower |   0.16x | 0.2785 |     584 B |
|               StructLinq |    .NET 6 PGO |   100 |   365.45 ns |  5.562 ns |  5.203 ns |  4.98x slower |   0.08x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   217.77 ns |  0.689 ns |  0.611 ns |  2.97x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |   327.95 ns |  4.759 ns |  4.451 ns |  4.47x slower |   0.06x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   222.48 ns |  0.348 ns |  0.308 ns |  3.03x slower |   0.02x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |    66.65 ns |  0.263 ns |  0.246 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |    66.63 ns |  0.237 ns |  0.222 ns |  1.00x faster |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |   591.72 ns |  1.948 ns |  1.627 ns |  8.88x slower |   0.04x | 0.0229 |      48 B |
|               LinqFaster | .NET Core 3.1 |   100 |   309.83 ns |  1.485 ns |  1.316 ns |  4.65x slower |   0.02x | 0.3171 |     664 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   803.04 ns |  4.195 ns |  3.924 ns | 12.05x slower |   0.07x | 0.2136 |     448 B |
|                   LinqAF | .NET Core 3.1 |   100 |   422.63 ns |  1.745 ns |  1.633 ns |  6.34x slower |   0.04x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 1,782.30 ns | 14.141 ns | 13.227 ns | 26.74x slower |   0.14x | 4.1656 |   8,713 B |
|                 SpanLinq | .NET Core 3.1 |   100 |   390.20 ns |  1.478 ns |  1.382 ns |  5.85x slower |   0.03x |      - |         - |
|                  Streams | .NET Core 3.1 |   100 | 1,867.77 ns |  6.933 ns |  6.146 ns | 28.04x slower |   0.12x | 0.2785 |     584 B |
|               StructLinq | .NET Core 3.1 |   100 |   428.48 ns |  1.380 ns |  1.291 ns |  6.43x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   188.81 ns |  0.679 ns |  0.635 ns |  2.83x slower |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |   455.21 ns |  3.963 ns |  3.707 ns |  6.83x slower |   0.06x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   232.64 ns |  0.262 ns |  0.219 ns |  3.49x slower |   0.01x |      - |         - |
