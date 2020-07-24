## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 269.1 ns | 1.82 ns | 1.61 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |              1 |                       0 |
|          ForeachLoop |   100 | 223.5 ns | 1.19 ns | 1.05 ns |  0.83 |    0.01 | 0.4170 |     - |     - |     872 B |              1 |                       0 |
|                 Linq |   100 | 580.4 ns | 3.04 ns | 2.84 ns |  2.16 |    0.02 | 0.3710 |     - |     - |     776 B |              2 |                       2 |
|           LinqFaster |   100 | 330.8 ns | 1.07 ns | 0.89 ns |  1.23 |    0.01 | 0.3095 |     - |     - |     648 B |              1 |                       1 |
|           StructLinq |   100 | 637.5 ns | 3.05 ns | 2.70 ns |  2.37 |    0.02 | 0.1297 |     - |     - |     272 B |              2 |                       2 |
| StructLinq_IFunction |   100 | 365.9 ns | 2.97 ns | 2.48 ns |  1.36 |    0.01 | 0.1297 |     - |     - |     272 B |              1 |                       1 |
|            Hyperlinq |   100 | 606.1 ns | 2.44 ns | 1.90 ns |  2.25 |    0.01 | 0.1068 |     - |     - |     224 B |              2 |                       2 |
|       Hyperlinq_Pool |   100 | 662.2 ns | 4.45 ns | 4.16 ns |  2.46 |    0.02 | 0.0267 |     - |     - |      56 B |              1 |                       2 |
