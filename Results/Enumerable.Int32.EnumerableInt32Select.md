## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** |    **10** |     **59.90 ns** |  **0.262 ns** |  **0.232 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq |    10 |    161.54 ns |  0.394 ns |  0.308 ns |  2.70 |    0.01 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |    10 |    127.69 ns |  0.273 ns |  0.242 ns |  2.13 |    0.01 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |    10 |     90.06 ns |  0.945 ns |  0.837 ns |  1.50 |    0.01 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |    10 |     63.19 ns |  0.695 ns |  0.853 ns |  1.06 |    0.02 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |    10 |     85.13 ns |  0.298 ns |  0.264 ns |  1.42 |    0.01 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |    10 |     61.79 ns |  0.210 ns |  0.196 ns |  1.03 |    0.01 | 0.0191 |     - |     - |      40 B |
|                             |       |              |           |           |       |         |        |       |       |           |
|                 **ForeachLoop** |  **1000** |  **4,681.56 ns** |  **9.574 ns** |  **8.487 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq |  1000 | 10,114.35 ns | 11.546 ns |  9.641 ns |  2.16 |    0.00 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |  1000 |  7,557.51 ns | 20.587 ns | 17.191 ns |  1.61 |    0.00 | 0.0153 |     - |     - |      40 B |
|                  StructLinq |  1000 |  5,981.37 ns | 16.638 ns | 14.749 ns |  1.28 |    0.00 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |  1000 |  4,687.15 ns |  9.039 ns |  8.013 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach |  1000 |  5,986.56 ns | 10.718 ns |  8.368 ns |  1.28 |    0.00 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |  1000 |  4,696.18 ns | 20.458 ns | 18.136 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
