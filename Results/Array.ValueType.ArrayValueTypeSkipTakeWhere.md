## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|      Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop | 1000 |   100 |   472.3 ns |  3.56 ns |  3.33 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
| ForeachLoop | 1000 |   100 | 2,396.1 ns | 23.98 ns | 20.03 ns |  5.07 |    0.04 | 0.0153 |     - |     - |      32 B |              1 |                       2 |
|        Linq | 1000 |   100 | 1,637.1 ns | 15.54 ns | 14.54 ns |  3.47 |    0.04 | 0.1183 |     - |     - |     248 B |              2 |                       1 |
|  LinqFaster | 1000 |   100 |   964.4 ns | 10.47 ns |  9.28 ns |  2.04 |    0.02 | 2.8896 |     - |     - |    6048 B |              3 |                       1 |
|   Hyperlinq | 1000 |   100 |   700.0 ns |  3.03 ns |  2.68 ns |  1.48 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
