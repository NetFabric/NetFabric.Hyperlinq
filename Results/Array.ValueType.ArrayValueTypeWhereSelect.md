## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   830.7 ns |  2.34 ns |  2.07 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   910.8 ns |  3.72 ns |  3.30 ns |  1.10 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,425.9 ns |  3.50 ns |  3.10 ns |  1.72 |    0.01 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,466.8 ns |  8.18 ns |  7.25 ns |  1.77 |    0.01 | 2.9659 |     - |     - |    6208 B |
|               LinqAF |   100 | 1,943.1 ns | 19.31 ns | 17.12 ns |  2.34 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,162.3 ns |  2.49 ns |  2.32 ns |  1.40 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   946.6 ns |  1.41 ns |  1.32 ns |  1.14 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,110.3 ns |  3.44 ns |  2.87 ns |  1.34 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   993.2 ns |  2.81 ns |  2.35 ns |  1.20 |    0.00 |      - |     - |     - |         - |
