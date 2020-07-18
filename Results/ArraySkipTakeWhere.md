## ArraySkipTakeWhere

### Source
[ArraySkipTakeWhere.cs](../LinqBenchmarks/ArraySkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Skip | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |    77.68 ns | 0.305 ns | 0.286 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 2,299.90 ns | 6.556 ns | 6.133 ns | 29.61 |    0.12 | 0.0153 |     - |     - |      32 B |
|        Linq | 1000 |   100 | 1,245.39 ns | 3.836 ns | 3.588 ns | 16.03 |    0.07 | 0.0725 |     - |     - |     152 B |
|  LinqFaster | 1000 |   100 |   320.30 ns | 1.909 ns | 1.786 ns |  4.12 |    0.03 | 0.3095 |     - |     - |     648 B |
|   Hyperlinq | 1000 |   100 |   359.39 ns | 0.980 ns | 0.818 ns |  4.63 |    0.02 |      - |     - |     - |         - |
