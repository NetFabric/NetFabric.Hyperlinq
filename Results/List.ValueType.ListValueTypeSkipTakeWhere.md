## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |     Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   614.0 ns |   1.99 ns |  1.67 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,605.2 ns |  15.49 ns | 13.73 ns |  7.50 |    0.02 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 | 1,537.4 ns |   4.13 ns |  3.86 ns |  2.50 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2,273.5 ns |  22.16 ns | 20.73 ns |  3.71 |    0.03 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 8,112.7 ns | 103.66 ns | 91.90 ns | 13.23 |    0.14 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   644.0 ns |   1.56 ns |  1.46 ns |  1.05 |    0.00 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   509.6 ns |   1.69 ns |  1.41 ns |  0.83 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   515.4 ns |   1.01 ns |  0.90 ns |  0.84 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   482.0 ns |   0.94 ns |  0.84 ns |  0.79 |    0.00 |      - |     - |     - |         - |
