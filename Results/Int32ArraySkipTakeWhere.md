## Int32ArraySkipTakeWhere

### Source
[Int32ArraySkipTakeWhere.cs](../LinqBenchmarks/Int32/Array/Int32ArraySkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |    62.70 ns |  0.721 ns |  0.674 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 2,335.70 ns | 23.291 ns | 19.449 ns | 37.29 |    0.59 | 0.0153 |     - |     - |      32 B |
|        Linq | 1000 |   100 | 1,358.80 ns | 14.114 ns | 13.202 ns | 21.67 |    0.27 | 0.0725 |     - |     - |     152 B |
|  LinqFaster | 1000 |   100 |   321.30 ns |  2.882 ns |  2.695 ns |  5.13 |    0.07 | 0.3095 |     - |     - |     648 B |
|   Hyperlinq | 1000 |   100 |   356.86 ns |  4.762 ns |  4.222 ns |  5.69 |    0.10 |      - |     - |     - |         - |
