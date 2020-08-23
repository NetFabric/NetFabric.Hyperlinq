## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    71.32 ns |  0.402 ns |  0.376 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 3,798.25 ns | 14.068 ns | 11.747 ns | 53.21 |    0.32 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 |   938.96 ns | 10.780 ns |  9.557 ns | 13.16 |    0.14 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   832.81 ns |  6.685 ns |  5.926 ns | 11.67 |    0.11 | 0.6533 |     - |     - |    1368 B |
|               LinqAF | 1000 |   100 | 5,796.34 ns | 70.609 ns | 62.593 ns | 81.22 |    1.04 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   329.66 ns |  1.936 ns |  1.716 ns |  4.62 |    0.03 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   193.08 ns |  1.196 ns |  1.119 ns |  2.71 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | 1000 |   100 |   283.76 ns |  2.287 ns |  2.139 ns |  3.98 |    0.04 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |   284.52 ns |  1.268 ns |  1.124 ns |  3.99 |    0.02 |      - |     - |     - |         - |
