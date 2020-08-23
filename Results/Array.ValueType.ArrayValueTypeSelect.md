## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|              ForLoop |   100 | 1.529 μs | 0.0141 μs | 0.0132 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1.638 μs | 0.0111 μs | 0.0104 μs |  1.07 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 2.144 μs | 0.0199 μs | 0.0186 μs |  1.40 |    0.01 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 2.043 μs | 0.0148 μs | 0.0131 μs |  1.34 |    0.01 | 1.9226 |     - |     - |    4024 B |
|               LinqAF |   100 | 2.600 μs | 0.0243 μs | 0.0228 μs |  1.70 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 1.843 μs | 0.0081 μs | 0.0064 μs |  1.21 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 1.567 μs | 0.0066 μs | 0.0059 μs |  1.03 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 1.861 μs | 0.0076 μs | 0.0067 μs |  1.22 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 1.870 μs | 0.0139 μs | 0.0130 μs |  1.22 |    0.01 |      - |     - |     - |         - |
