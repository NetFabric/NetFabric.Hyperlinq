## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

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
|              ForLoop |   100 | 1.629 μs | 0.0027 μs | 0.0024 μs |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.694 μs | 0.0029 μs | 0.0026 μs |  1.04 |      - |     - |     - |         - |
|                 Linq |   100 | 2.441 μs | 0.0009 μs | 0.0007 μs |  1.50 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 2.209 μs | 0.0052 μs | 0.0049 μs |  1.36 | 1.9226 |     - |     - |    4024 B |
|               LinqAF |   100 | 2.882 μs | 0.0020 μs | 0.0016 μs |  1.77 |      - |     - |     - |         - |
|           StructLinq |   100 | 2.056 μs | 0.0013 μs | 0.0012 μs |  1.26 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 1.705 μs | 0.0006 μs | 0.0005 μs |  1.05 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 2.085 μs | 0.0028 μs | 0.0024 μs |  1.28 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 2.110 μs | 0.0050 μs | 0.0042 μs |  1.30 |      - |     - |     - |         - |
