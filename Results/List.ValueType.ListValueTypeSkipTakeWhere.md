## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   502.1 ns |  1.58 ns |  1.32 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,488.6 ns | 26.31 ns | 23.32 ns | 10.93 |    0.05 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 | 1,921.6 ns |  5.45 ns |  4.84 ns |  3.83 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2,437.8 ns | 32.49 ns | 28.80 ns |  4.85 |    0.06 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 9,394.6 ns | 34.69 ns | 27.08 ns | 18.71 |    0.08 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   707.1 ns | 14.04 ns | 21.45 ns |  1.39 |    0.05 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   546.7 ns |  4.37 ns |  3.87 ns |  1.09 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   550.8 ns |  1.69 ns |  1.41 ns |  1.10 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   489.4 ns |  2.11 ns |  1.87 ns |  0.97 |    0.00 |      - |     - |     - |         - |
