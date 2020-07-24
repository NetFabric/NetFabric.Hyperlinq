## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|      Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop | 1000 |   100 |   499.6 ns |  3.24 ns |  2.87 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
| ForeachLoop | 1000 |   100 | 4,178.3 ns | 34.26 ns | 32.04 ns |  8.36 |    0.07 | 0.0305 |     - |     - |      72 B |              2 |                       2 |
|        Linq | 1000 |   100 | 1,564.3 ns |  7.37 ns |  6.89 ns |  3.13 |    0.03 | 0.1183 |     - |     - |     248 B |              2 |                       1 |
|   Hyperlinq | 1000 |   100 |   730.9 ns |  2.23 ns |  2.09 ns |  1.46 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
