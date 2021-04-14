## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  4.947 μs | 0.0224 μs | 0.0187 μs |  4.938 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  6.020 μs | 0.0378 μs | 0.0335 μs |  6.020 μs |  1.22 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 11.762 μs | 0.1109 μs | 0.0983 μs | 11.731 μs |  2.38 |    0.02 |  0.0458 |       - |     - |     104 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 14.268 μs | 0.2367 μs | 0.2214 μs | 14.266 μs |  2.89 |    0.04 | 45.4407 |       - |     - |  96,240 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 15.786 μs | 0.2995 μs | 0.3205 μs | 15.777 μs |  3.19 |    0.07 |       - |       - |     - |       1 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 76.338 μs | 0.6828 μs | 0.6387 μs | 76.332 μs | 15.40 |    0.09 | 86.9141 |       - |     - | 183,113 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 20.069 μs | 0.1575 μs | 0.1473 μs | 20.022 μs |  4.06 |    0.04 |  0.3662 |       - |     - |     824 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  8.178 μs | 0.0529 μs | 0.0442 μs |  8.170 μs |  1.65 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  6.933 μs | 0.0277 μs | 0.0245 μs |  6.936 μs |  1.40 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 14.433 μs | 0.0369 μs | 0.0327 μs | 14.435 μs |  2.92 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  9.044 μs | 0.0345 μs | 0.0306 μs |  9.045 μs |  1.83 |    0.01 |       - |       - |     - |         - |
|                      |        |          |       |           |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  4.977 μs | 0.0472 μs | 0.0418 μs |  4.961 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  5.925 μs | 0.0321 μs | 0.0300 μs |  5.921 μs |  1.19 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 11.444 μs | 0.0347 μs | 0.0308 μs | 11.437 μs |  2.30 |    0.02 |  0.0458 |       - |     - |     104 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 14.611 μs | 0.2593 μs | 0.6360 μs | 14.381 μs |  2.94 |    0.13 | 45.4407 |       - |     - |  96,240 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 16.115 μs | 0.2488 μs | 0.2327 μs | 16.087 μs |  3.24 |    0.04 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 60.255 μs | 0.4947 μs | 0.4131 μs | 60.189 μs | 12.13 |    0.13 | 81.0547 | 13.4277 |     - | 182,859 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 18.839 μs | 0.0998 μs | 0.0933 μs | 18.880 μs |  3.78 |    0.03 |  0.3662 |       - |     - |     824 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  7.673 μs | 0.0225 μs | 0.0211 μs |  7.671 μs |  1.54 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  5.612 μs | 0.0646 μs | 0.0573 μs |  5.589 μs |  1.13 |    0.02 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 12.163 μs | 0.0726 μs | 0.0644 μs | 12.173 μs |  2.44 |    0.03 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  8.655 μs | 0.0354 μs | 0.0314 μs |  8.660 μs |  1.74 |    0.02 |       - |       - |     - |         - |
