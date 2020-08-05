## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 | 1.617 μs | 0.0165 μs | 0.0154 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 5.755 μs | 0.1135 μs | 0.1062 μs |  3.56 |    0.06 | 0.0305 |     - |     - |      72 B |
|              Linq | 1000 |   100 | 2.539 μs | 0.0350 μs | 0.0293 μs |  1.57 |    0.02 | 0.1183 |     - |     - |     248 B |
|        LinqFaster | 1000 |   100 | 3.647 μs | 0.0364 μs | 0.0341 μs |  2.26 |    0.03 | 5.8136 |     - |     - |   12168 B |
|        StructLinq | 1000 |   100 | 2.457 μs | 0.0081 μs | 0.0063 μs |  1.52 |    0.02 | 0.0763 |     - |     - |     160 B |
| Hyperlinq_Foreach | 1000 |   100 | 1.877 μs | 0.0174 μs | 0.0163 μs |  1.16 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 | 1.870 μs | 0.0152 μs | 0.0142 μs |  1.16 |    0.01 |      - |     - |     - |         - |
