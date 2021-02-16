## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 144.5 ns | 0.54 ns | 0.48 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 255.7 ns | 1.46 ns | 1.22 ns |  1.77 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 792.0 ns | 3.39 ns | 3.00 ns |  5.48 |    0.03 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 402.5 ns | 1.49 ns | 1.32 ns |  2.78 |    0.01 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 980.4 ns | 5.15 ns | 4.82 ns |  6.78 |    0.04 |      - |     - |     - |         - |
|           StructLinq |   100 | 270.4 ns | 1.08 ns | 0.90 ns |  1.87 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 166.0 ns | 0.51 ns | 0.43 ns |  1.15 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 280.8 ns | 1.17 ns | 1.03 ns |  1.94 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 196.1 ns | 0.45 ns | 0.38 ns |  1.36 |    0.00 |      - |     - |     - |         - |
