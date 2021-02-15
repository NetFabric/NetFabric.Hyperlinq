## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   134.2 ns | 1.14 ns | 0.96 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   259.4 ns | 1.46 ns | 1.14 ns |  1.93 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,033.4 ns | 2.76 ns | 2.30 ns |  7.70 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 |   580.6 ns | 3.74 ns | 3.32 ns |  4.33 |    0.03 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 1,068.1 ns | 3.66 ns | 3.25 ns |  7.96 |    0.08 |      - |     - |     - |         - |
|           StructLinq |   100 |   377.3 ns | 2.73 ns | 2.56 ns |  2.81 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   186.7 ns | 0.58 ns | 0.52 ns |  1.39 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   397.1 ns | 4.00 ns | 3.54 ns |  2.96 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   196.1 ns | 1.08 ns | 0.91 ns |  1.46 |    0.02 |      - |     - |     - |         - |
