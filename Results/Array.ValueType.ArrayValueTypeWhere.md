## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   452.0 ns |  1.64 ns |  1.53 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   482.1 ns |  1.49 ns |  1.39 ns |  1.07 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 |   920.6 ns |  6.48 ns |  6.06 ns |  2.04 |    0.02 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 1,019.6 ns | 10.60 ns |  9.91 ns |  2.26 |    0.02 | 2.9659 |     - |     - |    6208 B |
|               LinqAF |   100 | 1,110.0 ns | 16.27 ns | 15.22 ns |  2.46 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 |   627.3 ns |  2.88 ns |  2.56 ns |  1.39 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   530.9 ns |  1.46 ns |  1.37 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   558.0 ns |  2.29 ns |  2.03 ns |  1.23 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   526.2 ns |  1.68 ns |  1.57 ns |  1.16 |    0.01 |      - |     - |     - |         - |
