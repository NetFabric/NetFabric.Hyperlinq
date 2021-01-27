## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    474.8 ns |     0.62 ns |     0.55 ns |    474.8 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 |  4,599.6 ns |    15.04 ns |    14.07 ns |  4,604.3 ns |  9.69 |    0.03 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 |  1,525.5 ns |     4.26 ns |     3.99 ns |  1,524.4 ns |  3.21 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 |  2,270.5 ns |    45.33 ns |    46.55 ns |  2,262.9 ns |  4.78 |    0.10 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 24,147.2 ns | 1,738.20 ns | 4,816.55 ns | 21,600.0 ns | 56.44 |   12.41 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |  1,920.7 ns |     2.88 ns |     2.40 ns |  1,921.1 ns |  4.04 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |  1,848.7 ns |     3.32 ns |     2.95 ns |  1,849.7 ns |  3.89 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |    642.6 ns |     2.16 ns |     1.92 ns |    642.0 ns |  1.35 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |    528.7 ns |     1.00 ns |     0.84 ns |    528.8 ns |  1.11 |    0.00 |      - |     - |     - |         - |
