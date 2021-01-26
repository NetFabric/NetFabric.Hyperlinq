## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   132.5 ns |  0.60 ns |  0.53 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,929.5 ns | 61.47 ns | 54.49 ns | 37.22 |    0.46 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,388.4 ns |  6.53 ns |  6.11 ns | 10.48 |    0.08 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   948.1 ns |  8.29 ns |  7.35 ns |  7.16 |    0.06 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 5,614.5 ns | 14.44 ns | 12.80 ns | 42.39 |    0.17 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   361.6 ns |  1.98 ns |  1.75 ns |  2.73 |    0.02 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   198.8 ns |  0.66 ns |  0.59 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   287.6 ns |  1.13 ns |  1.00 ns |  2.17 |    0.01 |      - |     - |     - |         - |
