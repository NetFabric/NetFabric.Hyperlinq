## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   772.4 ns |  1.33 ns |  1.24 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   846.9 ns |  1.05 ns |  0.93 ns |  1.10 |      - |     - |     - |         - |
|                 Linq |   100 | 1,330.8 ns |  3.44 ns |  3.22 ns |  1.72 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,371.8 ns |  5.21 ns |  4.62 ns |  1.78 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,764.5 ns | 11.54 ns | 10.23 ns |  2.28 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,075.3 ns |  2.29 ns |  1.92 ns |  1.39 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   878.4 ns |  1.45 ns |  1.29 ns |  1.14 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,054.1 ns |  1.73 ns |  1.62 ns |  1.36 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   929.5 ns |  1.39 ns |  1.23 ns |  1.20 |      - |     - |     - |         - |
