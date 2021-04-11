## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |--------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |      **8.271 ns** |   **0.0436 ns** |   **0.0386 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     13.924 ns |   0.0330 ns |   0.0258 ns |  1.68 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |     72.294 ns |   0.4382 ns |   0.3884 ns |  8.74 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     26.371 ns |   0.0700 ns |   0.0655 ns |  3.19 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |     85.563 ns |   1.6824 ns |   2.4129 ns | 10.32 |    0.32 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |     50.031 ns |   0.1845 ns |   0.1541 ns |  6.05 |    0.04 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     43.953 ns |   0.3122 ns |   0.2767 ns |  5.31 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |     59.230 ns |   1.2044 ns |   2.1095 ns |  7.33 |    0.22 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     46.292 ns |   0.9593 ns |   1.2131 ns |  5.60 |    0.16 |      - |     - |     - |         - |
|                      |          |          |       |               |             |             |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |      7.468 ns |   0.0284 ns |   0.0252 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     14.039 ns |   0.0869 ns |   0.0770 ns |  1.88 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |     75.435 ns |   0.3519 ns |   0.2938 ns | 10.10 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     26.863 ns |   0.0484 ns |   0.0405 ns |  3.60 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |     84.130 ns |   1.4307 ns |   1.5308 ns | 11.26 |    0.23 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |     50.935 ns |   0.2102 ns |   0.1966 ns |  6.82 |    0.03 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     45.719 ns |   0.1397 ns |   0.1307 ns |  6.12 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |     60.805 ns |   1.2389 ns |   1.2168 ns |  8.13 |    0.16 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     46.006 ns |   0.8568 ns |   0.7155 ns |  6.16 |    0.10 |      - |     - |     - |         - |
|                      |          |          |       |               |             |             |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |    **876.677 ns** |   **3.8404 ns** |   **3.4044 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |  1,824.813 ns |   6.3492 ns |   5.3019 ns |  2.08 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 11,371.050 ns |  49.2393 ns |  43.6494 ns | 12.97 |    0.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 |  4,080.185 ns |  24.8493 ns |  23.2440 ns |  4.65 |    0.04 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 11,476.880 ns | 172.7846 ns | 161.6228 ns | 13.10 |    0.20 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |  4,993.384 ns |  20.7678 ns |  18.4101 ns |  5.70 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  1,967.864 ns |  22.3877 ns |  20.9415 ns |  2.24 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |  4,481.252 ns |  88.9373 ns | 169.2125 ns |  5.16 |    0.24 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  3,439.268 ns |  46.9683 ns |  43.9342 ns |  3.93 |    0.05 |      - |     - |     - |         - |
|                      |          |          |       |               |             |             |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |    901.634 ns |   3.7121 ns |   3.4723 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |  1,810.374 ns |   7.2437 ns |   6.4213 ns |  2.01 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 10,158.151 ns |  32.7400 ns |  29.0231 ns | 11.26 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 |  4,330.033 ns |  18.7305 ns |  17.5206 ns |  4.80 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 |  8,793.849 ns | 170.1145 ns | 208.9159 ns |  9.74 |    0.25 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |  5,054.870 ns |  38.1350 ns |  33.8057 ns |  5.60 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  1,960.141 ns |  16.9513 ns |  15.0269 ns |  2.17 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |  4,344.463 ns |  86.9192 ns | 197.9590 ns |  4.84 |    0.23 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  3,540.538 ns |  69.3132 ns |  82.5124 ns |  3.94 |    0.07 |      - |     - |     - |         - |
