## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta20](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta20)

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
|     ForLoop | 1000 |   100 |    75.46 ns |  0.442 ns |  0.392 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
| ForeachLoop | 1000 |   100 | 2,361.18 ns | 16.082 ns | 14.256 ns | 31.29 |    0.30 | 0.0153 |     - |     - |      32 B |              1 |                       3 |
|        Linq | 1000 |   100 | 1,308.21 ns | 12.192 ns | 11.405 ns | 17.35 |    0.15 | 0.0725 |     - |     - |     152 B |              1 |                       1 |
|  LinqFaster | 1000 |   100 |   293.81 ns |  2.789 ns |  2.473 ns |  3.89 |    0.03 | 0.3095 |     - |     - |     648 B |              1 |                       1 |
|   Hyperlinq | 1000 |   100 |   383.62 ns |  3.074 ns |  2.876 ns |  5.09 |    0.05 |      - |     - |     - |         - |              0 |                       0 |
