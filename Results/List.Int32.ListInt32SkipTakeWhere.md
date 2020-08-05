## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

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
|              ForLoop | 1000 |   100 |    81.65 ns |  0.762 ns |  0.712 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 3,800.29 ns | 29.190 ns | 27.305 ns | 46.55 |    0.69 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,247.72 ns |  7.153 ns |  6.690 ns | 15.28 |    0.17 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   818.52 ns |  3.529 ns |  2.755 ns | 10.01 |    0.11 | 0.7458 |     - |     - |    1560 B |
|           StructLinq | 1000 |   100 | 1,092.84 ns | 10.408 ns |  9.736 ns | 13.39 |    0.06 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   884.84 ns |  3.629 ns |  3.217 ns | 10.83 |    0.08 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq | 1000 |   100 |   335.73 ns |  1.213 ns |  1.075 ns |  4.11 |    0.04 |      - |     - |     - |         - |
