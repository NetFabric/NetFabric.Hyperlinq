## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop | 1000 |   100 | 1.510 μs | 0.0066 μs | 0.0062 μs |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | 1000 |   100 | 3.853 μs | 0.0305 μs | 0.0285 μs |  2.55 |    0.02 | 0.0153 |     - |     - |      32 B |              1 |                       2 |
|              Linq | 1000 |   100 | 2.565 μs | 0.0160 μs | 0.0133 μs |  1.70 |    0.01 | 0.1183 |     - |     - |     248 B |              2 |                       1 |
|        LinqFaster | 1000 |   100 | 2.054 μs | 0.0187 μs | 0.0174 μs |  1.36 |    0.01 | 1.9226 |     - |     - |    4024 B |              4 |                       1 |
| Hyperlinq_Foreach | 1000 |   100 | 1.909 μs | 0.0101 μs | 0.0095 μs |  1.26 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
|     Hyperlinq_For | 1000 |   100 | 2.088 μs | 0.0101 μs | 0.0094 μs |  1.38 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
