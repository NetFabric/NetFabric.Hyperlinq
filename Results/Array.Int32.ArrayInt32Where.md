## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

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
|              ForLoop |   100 |  73.85 ns | 0.219 ns | 0.205 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  73.78 ns | 0.176 ns | 0.165 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 446.40 ns | 1.812 ns | 1.513 ns |  6.05 |    0.03 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 281.79 ns | 1.767 ns | 1.567 ns |  3.82 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 383.30 ns | 4.072 ns | 3.400 ns |  5.19 |    0.05 |      - |     - |     - |         - |
|           StructLinq |   100 | 268.83 ns | 0.742 ns | 0.657 ns |  3.64 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 167.90 ns | 0.479 ns | 0.425 ns |  2.27 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 259.00 ns | 0.847 ns | 0.751 ns |  3.51 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 183.46 ns | 0.273 ns | 0.242 ns |  2.48 |    0.01 |      - |     - |     - |         - |
