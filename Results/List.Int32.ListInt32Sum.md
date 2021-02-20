## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **11.266 ns** |   **0.3142 ns** |   **0.4506 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     40.213 ns |   0.3437 ns |   0.3047 ns |  3.55 |    0.11 |      - |     - |     - |         - |
|                 Linq |    10 |    161.502 ns |   3.1947 ns |   5.5953 ns | 14.31 |    0.63 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |    10 |     12.661 ns |   0.3562 ns |   0.9508 ns |  1.14 |    0.10 |      - |     - |     - |         - |
|               LinqAF |    10 |    166.154 ns |   3.2897 ns |   7.0814 ns | 14.70 |    0.84 |      - |     - |     - |         - |
|           StructLinq |    10 |     22.466 ns |   0.1633 ns |   0.1364 ns |  1.99 |    0.07 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |      9.336 ns |   0.2720 ns |   0.5175 ns |  0.83 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     15.712 ns |   0.4007 ns |   1.0970 ns |  1.42 |    0.12 |      - |     - |     - |         - |
|                      |       |               |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |    **977.209 ns** |   **3.5541 ns** |   **3.3245 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  2,716.079 ns |   8.6548 ns |   7.2272 ns |  2.78 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 14,823.436 ns | 293.7407 ns | 465.9040 ns | 15.13 |    0.45 | 0.0153 |     - |     - |      40 B |
|           LinqFaster |  1000 |    685.914 ns |   4.3059 ns |   3.5956 ns |  0.70 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 |  9,373.819 ns | 185.6587 ns | 469.1832 ns |  9.73 |    0.44 |      - |     - |     - |         - |
|           StructLinq |  1000 |    687.861 ns |   2.2654 ns |   2.0082 ns |  0.70 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |    555.122 ns |   0.9287 ns |   0.8687 ns |  0.57 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |     96.064 ns |   0.5999 ns |   0.5318 ns |  0.10 |    0.00 |      - |     - |     - |         - |
