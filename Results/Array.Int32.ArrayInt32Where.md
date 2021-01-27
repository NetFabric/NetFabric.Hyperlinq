## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  73.74 ns | 0.126 ns | 0.098 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  73.50 ns | 0.264 ns | 0.247 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 447.38 ns | 0.621 ns | 0.519 ns |  6.07 |    0.01 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 279.58 ns | 1.631 ns | 1.362 ns |  3.79 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 378.23 ns | 1.350 ns | 1.263 ns |  5.13 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 272.53 ns | 0.666 ns | 0.590 ns |  3.70 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 161.96 ns | 2.427 ns | 2.026 ns |  2.20 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 239.04 ns | 0.581 ns | 0.486 ns |  3.24 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 183.64 ns | 2.105 ns | 1.758 ns |  2.49 |    0.03 |      - |     - |     - |         - |
