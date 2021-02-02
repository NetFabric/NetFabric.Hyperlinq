## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   599.6 ns |  2.63 ns |  2.46 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,335.6 ns | 21.28 ns | 18.86 ns |  8.89 |    0.05 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 | 1,534.6 ns |  7.00 ns |  6.55 ns |  2.56 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2,294.8 ns | 34.63 ns | 32.40 ns |  3.83 |    0.06 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 8,440.8 ns | 29.87 ns | 27.94 ns | 14.08 |    0.07 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   651.0 ns |  1.61 ns |  1.51 ns |  1.09 |    0.00 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   522.0 ns |  1.08 ns |  0.90 ns |  0.87 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   563.4 ns |  1.10 ns |  0.97 ns |  0.94 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   483.3 ns |  0.95 ns |  0.84 ns |  0.81 |    0.00 |      - |     - |     - |         - |
