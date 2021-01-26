## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
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
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    77.40 ns |  0.382 ns |  0.339 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,130.11 ns | 34.789 ns | 30.839 ns | 53.36 |    0.40 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,025.87 ns |  8.298 ns |  7.356 ns | 13.25 |    0.09 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   921.37 ns |  7.955 ns |  6.643 ns | 11.91 |    0.07 | 0.6533 |     - |     - |    1368 B |
|               LinqAF | 1000 |   100 | 5,865.82 ns | 21.894 ns | 17.094 ns | 75.79 |    0.50 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   299.67 ns |  1.316 ns |  1.099 ns |  3.87 |    0.02 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   205.32 ns |  0.986 ns |  0.874 ns |  2.65 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | 1000 |   100 |   211.47 ns |  0.881 ns |  0.824 ns |  2.73 |    0.02 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |   212.36 ns |  0.477 ns |  0.423 ns |  2.74 |    0.01 |      - |     - |     - |         - |
