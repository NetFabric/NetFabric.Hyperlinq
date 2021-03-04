## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **7.011 ns** |  **0.0355 ns** |  **0.0315 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.785 ns |  0.0336 ns |  0.0298 ns |  1.11 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    89.452 ns |  0.6309 ns |  0.5901 ns | 12.77 |    0.10 | 0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |    47.125 ns |  0.2709 ns |  0.2402 ns |  6.72 |    0.05 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    64.312 ns |  0.1920 ns |  0.1603 ns |  9.18 |    0.04 |      - |     - |     - |         - |
|           StructLinq |    10 |    58.735 ns |  0.2200 ns |  0.2058 ns |  8.38 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    51.352 ns |  0.1358 ns |  0.1204 ns |  7.33 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    52.098 ns |  0.1347 ns |  0.1260 ns |  7.43 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    47.791 ns |  0.1545 ns |  0.1446 ns |  6.82 |    0.04 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,113.194 ns** | **11.5179 ns** | **10.7739 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,115.291 ns | 14.3376 ns | 12.7099 ns |  1.00 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 7,821.645 ns | 39.1388 ns | 36.6105 ns |  7.03 |    0.07 | 0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 5,221.256 ns | 25.2107 ns | 22.3486 ns |  4.69 |    0.05 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF |  1000 | 6,303.680 ns | 22.8403 ns | 21.3648 ns |  5.66 |    0.05 |      - |     - |     - |         - |
|           StructLinq |  1000 | 5,577.664 ns | 21.9999 ns | 18.3709 ns |  5.01 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 1,646.918 ns | 22.4682 ns | 19.9175 ns |  1.48 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,423.363 ns | 21.7512 ns | 18.1632 ns |  4.87 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 2,988.914 ns | 20.5472 ns | 19.2198 ns |  2.69 |    0.02 |      - |     - |     - |         - |
