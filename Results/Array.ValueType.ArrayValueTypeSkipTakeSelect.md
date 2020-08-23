## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 | 1.540 μs | 0.0056 μs | 0.0044 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4.117 μs | 0.0160 μs | 0.0149 μs |  2.67 |    0.01 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 2.563 μs | 0.0086 μs | 0.0081 μs |  1.66 |    0.00 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2.567 μs | 0.0191 μs | 0.0178 μs |  1.67 |    0.01 | 5.7678 |     - |     - |   12072 B |
|               LinqAF | 1000 |   100 | 6.529 μs | 0.0668 μs | 0.0625 μs |  4.23 |    0.04 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 3.215 μs | 0.0075 μs | 0.0070 μs |  2.09 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 2.955 μs | 0.0185 μs | 0.0173 μs |  1.92 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | 1000 |   100 | 1.862 μs | 0.0075 μs | 0.0062 μs |  1.21 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 | 1.877 μs | 0.0138 μs | 0.0129 μs |  1.22 |    0.01 |      - |     - |     - |         - |
