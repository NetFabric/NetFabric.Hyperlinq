## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|              ForLoop |   100 |  59.07 ns | 0.619 ns | 0.579 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |  44.61 ns | 0.260 ns | 0.230 ns |  0.75 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 651.79 ns | 5.214 ns | 4.071 ns | 11.05 |    0.12 | 0.0229 |     - |     - |      48 B |              0 |                       1 |
|           LinqFaster |   100 | 248.94 ns | 2.478 ns | 2.318 ns |  4.21 |    0.05 | 0.2027 |     - |     - |     424 B |              1 |                       1 |
|           StructLinq |   100 | 251.11 ns | 1.538 ns | 1.439 ns |  4.25 |    0.05 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 158.80 ns | 1.104 ns | 1.033 ns |  2.69 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 233.47 ns | 1.609 ns | 1.505 ns |  3.95 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For |   100 | 460.38 ns | 3.730 ns | 3.489 ns |  7.80 |    0.09 |      - |     - |     - |         - |              0 |                       0 |
