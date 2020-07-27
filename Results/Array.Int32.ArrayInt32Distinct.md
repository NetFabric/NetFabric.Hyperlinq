## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|      Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop |          4 |   100 |   798.0 ns | 13.65 ns | 11.40 ns |  1.00 |    0.00 | 0.6304 |     - |     - |    1320 B |              2 |                       1 |
| ForeachLoop |          4 |   100 |   777.1 ns |  4.04 ns |  3.37 ns |  0.97 |    0.01 | 0.6304 |     - |     - |    1320 B |              2 |                       1 |
|        Linq |          4 |   100 | 1,698.1 ns | 10.68 ns |  9.99 ns |  2.13 |    0.04 | 0.5531 |     - |     - |    1160 B |              3 |                       3 |
|  StructLinq |          4 |   100 | 1,506.8 ns | 13.07 ns | 11.58 ns |  1.89 |    0.03 |      - |     - |     - |         - |              0 |                       2 |
|   Hyperlinq |          4 |   100 | 1,090.5 ns | 11.28 ns | 10.55 ns |  1.37 |    0.03 |      - |     - |     - |         - |              0 |                       2 |
