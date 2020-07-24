## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|      Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop |          4 |   100 |   931.3 ns | 17.68 ns | 45.94 ns |  1.00 |    0.00 | 0.6294 |     - |     - |    1320 B |              4 |                       1 |
| ForeachLoop |          4 |   100 |   768.1 ns |  4.10 ns |  3.64 ns |  0.80 |    0.04 | 0.6304 |     - |     - |    1320 B |              2 |                       1 |
|        Linq |          4 |   100 | 1,624.7 ns | 11.23 ns | 10.50 ns |  1.69 |    0.08 | 0.5531 |     - |     - |    1160 B |              4 |                       3 |
|  StructLinq |          4 |   100 | 1,500.1 ns | 10.04 ns |  8.90 ns |  1.56 |    0.08 |      - |     - |     - |         - |              0 |                       2 |
|   Hyperlinq |          4 |   100 | 1,128.9 ns | 10.17 ns |  8.49 ns |  1.17 |    0.06 |      - |     - |     - |         - |              0 |                       2 |
