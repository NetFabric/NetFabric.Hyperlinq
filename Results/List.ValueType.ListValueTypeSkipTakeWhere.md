## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   609.5 ns |   2.86 ns |   2.68 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,610.8 ns |   9.53 ns |   8.91 ns |  7.56 |    0.03 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 | 1,543.4 ns |   5.97 ns |   5.30 ns |  2.53 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2,277.7 ns |  15.07 ns |  14.10 ns |  3.74 |    0.03 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 8,115.8 ns | 153.68 ns | 143.75 ns | 13.32 |    0.26 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   645.8 ns |   1.40 ns |   1.17 ns |  1.06 |    0.00 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   536.2 ns |   0.96 ns |   0.89 ns |  0.88 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   647.0 ns |   1.51 ns |   1.41 ns |  1.06 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   535.7 ns |   1.49 ns |   1.39 ns |  0.88 |    0.00 |      - |     - |     - |         - |
