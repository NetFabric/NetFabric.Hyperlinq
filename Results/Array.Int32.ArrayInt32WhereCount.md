## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |  68.59 ns | 0.307 ns | 0.272 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       1 |
|          ForeachLoop |   100 |  79.72 ns | 0.416 ns | 0.369 ns |  1.16 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
|                 Linq |   100 | 606.30 ns | 2.990 ns | 2.797 ns |  8.84 |    0.05 | 0.0153 |     - |     - |      32 B |              0 |                       1 |
|           LinqFaster |   100 | 257.52 ns | 1.255 ns | 1.174 ns |  3.76 |    0.02 |      - |     - |     - |         - |              0 |                       0 |
|           StructLinq |   100 | 332.94 ns | 1.287 ns | 1.204 ns |  4.85 |    0.03 | 0.0191 |     - |     - |      40 B |              0 |                       0 |
| StructLinq_IFunction |   100 | 164.50 ns | 1.076 ns | 0.954 ns |  2.40 |    0.02 | 0.0191 |     - |     - |      40 B |              0 |                       0 |
|            Hyperlinq |   100 | 171.72 ns | 0.676 ns | 0.599 ns |  2.50 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
