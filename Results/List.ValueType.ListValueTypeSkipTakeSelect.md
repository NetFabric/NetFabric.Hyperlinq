## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|               Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |  1.614 μs | 0.0069 μs | 0.0061 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 |  5.825 μs | 0.0472 μs | 0.0441 μs |  3.61 |    0.03 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 |  2.549 μs | 0.0163 μs | 0.0153 μs |  1.58 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 |  3.670 μs | 0.0293 μs | 0.0274 μs |  2.27 |    0.02 | 5.8136 |     - |     - |   12168 B |
|               LinqAF | 1000 |   100 | 10.527 μs | 0.1296 μs | 0.1212 μs |  6.51 |    0.06 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |  3.201 μs | 0.0181 μs | 0.0151 μs |  1.98 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |  2.949 μs | 0.0179 μs | 0.0167 μs |  1.83 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | 1000 |   100 |  1.887 μs | 0.0053 μs | 0.0047 μs |  1.17 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |  1.953 μs | 0.0125 μs | 0.0117 μs |  1.21 |    0.01 |      - |     - |     - |         - |
