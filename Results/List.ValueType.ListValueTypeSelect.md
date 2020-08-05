## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|               Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 1.638 μs | 0.0120 μs | 0.0106 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.826 μs | 0.0144 μs | 0.0135 μs |  1.11 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 2.478 μs | 0.0239 μs | 0.0224 μs |  1.51 |    0.02 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 2.360 μs | 0.0272 μs | 0.0241 μs |  1.44 |    0.02 | 1.9379 |     - |     - |    4056 B |
|           StructLinq |   100 | 1.856 μs | 0.0184 μs | 0.0172 μs |  1.13 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 1.556 μs | 0.0142 μs | 0.0133 μs |  0.95 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 1.854 μs | 0.0190 μs | 0.0178 μs |  1.13 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 1.852 μs | 0.0187 μs | 0.0175 μs |  1.13 |    0.01 |      - |     - |     - |         - |
