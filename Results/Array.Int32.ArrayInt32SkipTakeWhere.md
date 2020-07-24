## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
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
|      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop | 1000 |   100 |    63.71 ns |  0.294 ns |  0.261 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       1 |
| ForeachLoop | 1000 |   100 | 2,362.71 ns | 14.239 ns | 13.319 ns | 37.08 |    0.31 | 0.0153 |     - |     - |      32 B |              1 |                       2 |
|        Linq | 1000 |   100 | 1,399.49 ns |  4.108 ns |  3.642 ns | 21.97 |    0.09 | 0.0725 |     - |     - |     152 B |              2 |                       1 |
|  LinqFaster | 1000 |   100 |   302.33 ns |  1.784 ns |  1.668 ns |  4.75 |    0.03 | 0.3095 |     - |     - |     648 B |              1 |                       1 |
|   Hyperlinq | 1000 |   100 |   369.90 ns |  2.417 ns |  2.142 ns |  5.81 |    0.04 |      - |     - |     - |         - |              0 |                       1 |
