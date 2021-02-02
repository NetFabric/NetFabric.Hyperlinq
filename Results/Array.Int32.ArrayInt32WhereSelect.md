## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  73.66 ns | 0.234 ns | 0.208 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  73.66 ns | 0.242 ns | 0.214 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 565.50 ns | 1.953 ns | 1.827 ns |  7.68 |    0.04 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 361.49 ns | 1.932 ns | 1.613 ns |  4.91 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 428.27 ns | 0.783 ns | 0.694 ns |  5.81 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 378.00 ns | 6.132 ns | 5.120 ns |  5.13 |    0.07 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 183.59 ns | 0.232 ns | 0.194 ns |  2.49 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 368.14 ns | 1.241 ns | 1.100 ns |  5.00 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 191.02 ns | 0.333 ns | 0.278 ns |  2.59 |    0.01 |      - |     - |     - |         - |
