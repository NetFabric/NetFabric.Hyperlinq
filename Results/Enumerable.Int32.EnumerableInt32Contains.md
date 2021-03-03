## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **58.52 ns** |  **0.215 ns** |  **0.168 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    62.16 ns |  0.269 ns |  0.238 ns |  1.06 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    98.33 ns |  0.289 ns |  0.226 ns |  1.68 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    72.34 ns |  0.192 ns |  0.180 ns |  1.24 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    62.14 ns |  0.194 ns |  0.162 ns |  1.06 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    81.03 ns |  0.171 ns |  0.159 ns |  1.38 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,425.38 ns** | **13.734 ns** | **11.469 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,195.63 ns | 10.254 ns |  9.090 ns |  0.95 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 5,722.88 ns | 14.255 ns | 11.903 ns |  1.29 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,444.56 ns | 14.044 ns | 11.728 ns |  1.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,430.62 ns |  9.898 ns |  9.258 ns |  1.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 5,202.08 ns | 12.079 ns | 10.708 ns |  1.18 | 0.0153 |     - |     - |      40 B |
