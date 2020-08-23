## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|               Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 1.619 μs | 0.0111 μs | 0.0103 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.813 μs | 0.0058 μs | 0.0049 μs |  1.12 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 2.501 μs | 0.0188 μs | 0.0176 μs |  1.54 |    0.01 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 2.396 μs | 0.0188 μs | 0.0176 μs |  1.48 |    0.02 | 1.9379 |     - |     - |    4056 B |
|               LinqAF |   100 | 2.997 μs | 0.0185 μs | 0.0173 μs |  1.85 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 1.826 μs | 0.0089 μs | 0.0069 μs |  1.13 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 1.588 μs | 0.0050 μs | 0.0044 μs |  0.98 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 1.903 μs | 0.0165 μs | 0.0154 μs |  1.18 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 1.913 μs | 0.0210 μs | 0.0197 μs |  1.18 |    0.02 |      - |     - |     - |         - |
