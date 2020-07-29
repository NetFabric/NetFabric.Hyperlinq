## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta21](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta21)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----- |------ |-----------:|---------:|---------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop | 1000 |   100 |   490.2 ns |  2.29 ns |  2.14 ns |  1.00 |    0.00 |     339 B |      - |     - |     - |         - |              0 |                       0 |
| ForeachLoop | 1000 |   100 | 2,703.5 ns |  9.62 ns |  9.00 ns |  5.51 |    0.03 |     537 B | 0.0153 |     - |     - |      32 B |              1 |                       2 |
|        Linq | 1000 |   100 | 1,673.1 ns | 12.79 ns | 10.68 ns |  3.41 |    0.03 |    1894 B | 0.1183 |     - |     - |     248 B |              3 |                       2 |
|  LinqFaster | 1000 |   100 | 1,634.4 ns |  9.78 ns |  7.63 ns |  3.33 |    0.03 |    1532 B | 6.7329 |     - |     - |   14096 B |             11 |                       2 |
|  StructLinq | 1000 |   100 | 1,561.6 ns |  8.19 ns |  6.84 ns |  3.18 |    0.01 |    1653 B | 0.0763 |     - |     - |     160 B |              2 |                       1 |
|   Hyperlinq | 1000 |   100 |   716.9 ns |  4.29 ns |  3.58 ns |  1.46 |    0.01 |    1060 B |      - |     - |     - |         - |              0 |                       1 |
