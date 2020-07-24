## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|     ForLoop | 1000 |   100 |   472.4 ns |  3.48 ns |  3.26 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
| ForeachLoop | 1000 |   100 | 2,415.0 ns | 29.96 ns | 26.56 ns |  5.11 |    0.06 | 0.0153 |     - |     - |      32 B |              1 |                       2 |
|        Linq | 1000 |   100 | 1,617.1 ns | 11.49 ns | 10.75 ns |  3.42 |    0.03 | 0.1183 |     - |     - |     248 B |              2 |                       1 |
|  LinqFaster | 1000 |   100 |   970.0 ns | 10.03 ns |  9.38 ns |  2.05 |    0.03 | 2.8896 |     - |     - |    6048 B |              2 |                       1 |
|   Hyperlinq | 1000 |   100 |   713.9 ns |  5.42 ns |  5.07 ns |  1.51 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
