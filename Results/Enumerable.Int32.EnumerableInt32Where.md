## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                 **Linq** |    **10** |   **164.89 ns** |  **1.394 ns** |  **1.304 ns** |  **1.00** |    **0.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |    10 |   130.06 ns |  1.929 ns |  1.804 ns |  0.79 |    0.02 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   108.91 ns |  2.139 ns |  2.855 ns |  0.65 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    77.28 ns |  0.507 ns |  0.423 ns |  0.47 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    99.26 ns |  1.950 ns |  2.394 ns |  0.60 |    0.02 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    77.94 ns |  0.356 ns |  0.316 ns |  0.47 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |        |       |       |           |
|                 **Linq** |  **1000** | **8,457.83 ns** | **48.722 ns** | **43.190 ns** |  **1.00** |    **0.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |  1000 | 7,936.61 ns | 50.195 ns | 46.953 ns |  0.94 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 7,172.17 ns | 18.764 ns | 15.669 ns |  0.85 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 5,084.98 ns | 30.145 ns | 28.197 ns |  0.60 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 6,718.17 ns | 40.697 ns | 38.068 ns |  0.79 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 5,650.60 ns | 35.682 ns | 33.377 ns |  0.67 |    0.01 | 0.0153 |     - |     - |      40 B |
