## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 1.621 μs | 0.0016 μs | 0.0014 μs |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.701 μs | 0.0026 μs | 0.0024 μs |  1.05 |      - |     - |     - |         - |
|                 Linq |   100 | 2.440 μs | 0.0024 μs | 0.0022 μs |  1.51 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 2.190 μs | 0.0046 μs | 0.0039 μs |  1.35 | 1.9226 |     - |     - |    4024 B |
|               LinqAF |   100 | 2.839 μs | 0.0038 μs | 0.0032 μs |  1.75 |      - |     - |     - |         - |
|           StructLinq |   100 | 2.041 μs | 0.0043 μs | 0.0038 μs |  1.26 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 1.698 μs | 0.0021 μs | 0.0019 μs |  1.05 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 2.060 μs | 0.0020 μs | 0.0018 μs |  1.27 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 2.085 μs | 0.0036 μs | 0.0034 μs |  1.29 |      - |     - |     - |         - |
