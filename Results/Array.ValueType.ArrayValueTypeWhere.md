## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   428.2 ns |  2.40 ns |  1.87 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   472.9 ns |  0.97 ns |  0.86 ns |  1.10 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 |   896.1 ns |  5.08 ns |  4.51 ns |  2.09 |    0.01 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 |   982.7 ns |  9.48 ns |  8.87 ns |  2.29 |    0.02 | 2.9659 |     - |     - |    6208 B |
|               LinqAF |   100 | 1,085.4 ns | 14.92 ns | 13.96 ns |  2.53 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 |   612.4 ns |  2.10 ns |  1.86 ns |  1.43 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   531.8 ns |  0.55 ns |  0.46 ns |  1.24 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   606.9 ns |  2.49 ns |  2.08 ns |  1.42 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   531.6 ns |  3.68 ns |  3.07 ns |  1.24 |    0.01 |      - |     - |     - |         - |
