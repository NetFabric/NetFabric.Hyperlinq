## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------------ |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|           ForLoop | 1000 |   100 | 1.495 μs | 0.0045 μs | 0.0040 μs |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|       ForeachLoop | 1000 |   100 | 3.819 μs | 0.0264 μs | 0.0234 μs |  2.55 |    0.02 | 0.0153 |     - |     - |      32 B |              1 |                       2 |
|              Linq | 1000 |   100 | 2.583 μs | 0.0165 μs | 0.0155 μs |  1.73 |    0.01 | 0.1183 |     - |     - |     248 B |              3 |                       1 |
|        LinqFaster | 1000 |   100 | 2.035 μs | 0.0191 μs | 0.0179 μs |  1.36 |    0.01 | 1.9226 |     - |     - |    4024 B |              8 |                       2 |
| Hyperlinq_Foreach | 1000 |   100 | 1.869 μs | 0.0112 μs | 0.0100 μs |  1.25 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
|     Hyperlinq_For | 1000 |   100 | 1.874 μs | 0.0144 μs | 0.0134 μs |  1.25 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
