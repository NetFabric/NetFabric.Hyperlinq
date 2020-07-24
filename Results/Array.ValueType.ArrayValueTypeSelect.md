## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|               Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 | 1.532 μs | 0.0076 μs | 0.0067 μs |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 | 1.602 μs | 0.0063 μs | 0.0059 μs |  1.05 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 2.216 μs | 0.0075 μs | 0.0070 μs |  1.45 |    0.01 | 0.0381 |     - |     - |      80 B |              1 |                       1 |
|           LinqFaster |   100 | 2.047 μs | 0.0118 μs | 0.0110 μs |  1.34 |    0.01 | 1.9226 |     - |     - |    4024 B |              9 |                       2 |
|           StructLinq |   100 | 1.855 μs | 0.0044 μs | 0.0039 μs |  1.21 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
| StructLinq_IFunction |   100 | 1.572 μs | 0.0065 μs | 0.0057 μs |  1.03 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 1.901 μs | 0.0104 μs | 0.0093 μs |  1.24 |    0.01 |      - |     - |     - |         - |              0 |                       1 |
|        Hyperlinq_For |   100 | 2.092 μs | 0.0278 μs | 0.0246 μs |  1.37 |    0.02 |      - |     - |     - |         - |              0 |                       1 |
