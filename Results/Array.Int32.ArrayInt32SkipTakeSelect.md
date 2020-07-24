## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|            Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop | 1000 |   100 |    53.90 ns |  0.230 ns |  0.204 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | 1000 |   100 | 2,654.03 ns | 17.810 ns | 15.788 ns | 49.24 |    0.34 | 0.0153 |     - |     - |      32 B |              1 |                       2 |
|              Linq | 1000 |   100 |   993.86 ns |  6.627 ns |  6.199 ns | 18.44 |    0.12 | 0.0725 |     - |     - |     152 B |              2 |                       1 |
|        LinqFaster | 1000 |   100 |   277.10 ns |  1.700 ns |  1.507 ns |  5.14 |    0.03 | 0.2027 |     - |     - |     424 B |              1 |                       1 |
| Hyperlinq_Foreach | 1000 |   100 |   267.53 ns |  1.801 ns |  1.685 ns |  4.96 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
|     Hyperlinq_For | 1000 |   100 |   472.15 ns |  2.321 ns |  1.938 ns |  8.76 |    0.05 |      - |     - |     - |         - |              0 |                       0 |
