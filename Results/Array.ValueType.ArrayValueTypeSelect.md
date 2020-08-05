## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 1.542 μs | 0.0041 μs | 0.0038 μs |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.585 μs | 0.0147 μs | 0.0138 μs |  1.03 |      - |     - |     - |         - |
|                 Linq |   100 | 2.151 μs | 0.0117 μs | 0.0104 μs |  1.40 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 2.052 μs | 0.0189 μs | 0.0177 μs |  1.33 | 1.9226 |     - |     - |    4024 B |
|           StructLinq |   100 | 1.858 μs | 0.0194 μs | 0.0172 μs |  1.20 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 1.563 μs | 0.0124 μs | 0.0110 μs |  1.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 1.873 μs | 0.0165 μs | 0.0155 μs |  1.21 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 1.849 μs | 0.0044 μs | 0.0036 μs |  1.20 |      - |     - |     - |         - |
