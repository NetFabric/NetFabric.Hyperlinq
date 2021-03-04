## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **61.47 ns** |  **0.259 ns** |  **0.216 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    64.86 ns |  0.164 ns |  0.137 ns |  1.06 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    98.78 ns |  0.378 ns |  0.335 ns |  1.61 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    77.49 ns |  0.385 ns |  0.341 ns |  1.26 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    61.64 ns |  0.219 ns |  0.205 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    86.51 ns |  0.356 ns |  0.333 ns |  1.41 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,563.94 ns** | **22.652 ns** | **21.189 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,330.26 ns | 27.537 ns | 24.411 ns |  0.95 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 5,636.25 ns | 17.755 ns | 16.608 ns |  1.23 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,321.74 ns | 18.754 ns | 16.625 ns |  0.95 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,296.08 ns | 15.973 ns | 14.941 ns |  0.94 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 5,864.06 ns | 36.251 ns | 30.271 ns |  1.28 | 0.0153 |     - |     - |      40 B |
