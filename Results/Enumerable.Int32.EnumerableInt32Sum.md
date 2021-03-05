## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **53.24 ns** |  **0.151 ns** |  **0.142 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    58.04 ns |  0.158 ns |  0.132 ns |  1.09 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    75.06 ns |  0.333 ns |  0.278 ns |  1.41 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    73.51 ns |  0.143 ns |  0.111 ns |  1.38 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    62.48 ns |  0.190 ns |  0.168 ns |  1.17 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    56.29 ns |  0.133 ns |  0.125 ns |  1.06 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **3,927.30 ns** | **10.529 ns** |  **9.849 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,201.72 ns | 14.078 ns | 13.168 ns |  1.07 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 4,733.49 ns | 15.571 ns | 14.566 ns |  1.21 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,711.62 ns |  7.981 ns |  7.465 ns |  1.20 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,193.76 ns |  7.185 ns |  6.369 ns |  1.07 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 4,203.20 ns | 15.263 ns | 14.277 ns |  1.07 | 0.0153 |     - |     - |      40 B |
