## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                 **Linq** |    **10** |   **155.58 ns** |  **0.443 ns** |  **0.370 ns** |  **1.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |    10 |   126.32 ns |  1.071 ns |  1.002 ns |  0.81 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   102.53 ns |  0.349 ns |  0.309 ns |  0.66 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    77.45 ns |  0.274 ns |  0.242 ns |  0.50 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    94.48 ns |  0.313 ns |  0.293 ns |  0.61 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    72.23 ns |  0.205 ns |  0.192 ns |  0.46 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|                 **Linq** |  **1000** | **8,187.98 ns** | **32.306 ns** | **30.219 ns** |  **1.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |  1000 | 7,984.85 ns | 33.408 ns | 27.897 ns |  0.97 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 7,195.48 ns | 25.984 ns | 21.698 ns |  0.88 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 5,648.57 ns | 21.231 ns | 18.821 ns |  0.69 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 7,201.20 ns | 22.039 ns | 20.615 ns |  0.88 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 5,125.08 ns | 28.125 ns | 23.486 ns |  0.63 | 0.0153 |     - |     - |      40 B |
