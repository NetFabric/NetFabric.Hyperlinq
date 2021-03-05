## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **10.157 ns** | **0.0190 ns** | **0.0169 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    24.485 ns | 0.0726 ns | 0.0643 ns |  2.41 |      - |     - |     - |         - |
|                 Linq |    10 |    11.487 ns | 0.0487 ns | 0.0432 ns |  1.13 |      - |     - |     - |         - |
|           LinqFaster |    10 |     7.822 ns | 0.0258 ns | 0.0228 ns |  0.77 |      - |     - |     - |         - |
|               LinqAF |    10 |     7.695 ns | 0.0392 ns | 0.0327 ns |  0.76 |      - |     - |     - |         - |
|           StructLinq |    10 |    16.132 ns | 0.0930 ns | 0.0824 ns |  1.59 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    10.073 ns | 0.0303 ns | 0.0268 ns |  0.99 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    11.781 ns | 0.0295 ns | 0.0247 ns |  1.16 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    16.941 ns | 0.0309 ns | 0.0274 ns |  1.67 |      - |     - |     - |         - |
|                      |       |              |           |           |       |        |       |       |           |
|              **ForLoop** |  **1000** | **1,039.137 ns** | **2.1042 ns** | **1.7571 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,085.600 ns | 8.2011 ns | 6.4029 ns |  2.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   233.281 ns | 0.4563 ns | 0.4045 ns |  0.22 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   238.692 ns | 0.9349 ns | 0.7807 ns |  0.23 |      - |     - |     - |         - |
|               LinqAF |  1000 |   229.525 ns | 0.5373 ns | 0.4763 ns |  0.22 |      - |     - |     - |         - |
|           StructLinq |  1000 |   535.152 ns | 1.2131 ns | 1.1347 ns |  0.52 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   785.379 ns | 1.4283 ns | 1.3360 ns |  0.76 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   240.365 ns | 0.5272 ns | 0.4402 ns |  0.23 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   108.154 ns | 0.1861 ns | 0.1554 ns |  0.10 |      - |     - |     - |         - |
