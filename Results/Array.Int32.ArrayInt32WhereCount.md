## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |  82.35 ns | 0.808 ns | 0.756 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |  78.95 ns | 0.239 ns | 0.223 ns |  0.96 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 611.82 ns | 3.633 ns | 3.398 ns |  7.43 |    0.08 | 0.0153 |     - |     - |      32 B |              0 |                       1 |
|           LinqFaster |   100 | 219.55 ns | 1.244 ns | 1.164 ns |  2.67 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
|           StructLinq |   100 | 339.27 ns | 2.097 ns | 1.962 ns |  4.12 |    0.05 | 0.0191 |     - |     - |      40 B |              0 |                       1 |
| StructLinq_IFunction |   100 | 164.32 ns | 0.783 ns | 0.733 ns |  2.00 |    0.02 | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|            Hyperlinq |   100 | 350.78 ns | 2.174 ns | 1.928 ns |  4.26 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
