## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   833.4 ns |  1.27 ns |  1.13 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   875.4 ns |  1.74 ns |  1.55 ns |  1.05 |      - |     - |     - |         - |
|                 Linq |   100 | 1,429.8 ns |  4.35 ns |  3.86 ns |  1.72 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,450.0 ns |  4.83 ns |  4.52 ns |  1.74 | 2.9659 |     - |     - |    6208 B |
|               LinqAF |   100 | 1,925.0 ns | 12.93 ns | 11.46 ns |  2.31 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,163.4 ns |  3.40 ns |  3.01 ns |  1.40 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   944.8 ns |  2.45 ns |  2.17 ns |  1.13 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,087.1 ns |  2.64 ns |  2.20 ns |  1.30 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   933.9 ns |  1.91 ns |  1.69 ns |  1.12 |      - |     - |     - |         - |
