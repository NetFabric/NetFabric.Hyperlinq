## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 1.652 μs | 0.0022 μs | 0.0020 μs | 1.652 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.692 μs | 0.0038 μs | 0.0032 μs | 1.692 μs |  1.02 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 2.420 μs | 0.0051 μs | 0.0045 μs | 2.419 μs |  1.46 |    0.00 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 2.233 μs | 0.0114 μs | 0.0107 μs | 2.232 μs |  1.35 |    0.01 | 1.9226 |     - |     - |    4024 B |
|               LinqAF |   100 | 2.932 μs | 0.0028 μs | 0.0024 μs | 2.931 μs |  1.77 |    0.00 |      - |     - |     - |         - |
|           StructLinq |   100 | 2.062 μs | 0.0010 μs | 0.0009 μs | 2.062 μs |  1.25 |    0.00 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 1.684 μs | 0.0041 μs | 0.0038 μs | 1.683 μs |  1.02 |    0.00 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 2.212 μs | 0.0434 μs | 0.1064 μs | 2.170 μs |  1.36 |    0.10 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 2.163 μs | 0.0277 μs | 0.0272 μs | 2.154 μs |  1.31 |    0.02 |      - |     - |     - |         - |
