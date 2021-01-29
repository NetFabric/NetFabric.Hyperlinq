## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|              ForLoop |   100 |  79.27 ns | 0.751 ns | 0.702 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  79.36 ns | 0.990 ns | 0.926 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 493.47 ns | 4.818 ns | 4.507 ns |  6.23 |    0.08 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 312.23 ns | 3.907 ns | 3.655 ns |  3.94 |    0.05 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 410.88 ns | 5.425 ns | 5.074 ns |  5.18 |    0.07 |      - |     - |     - |         - |
|           StructLinq |   100 | 293.53 ns | 3.833 ns | 3.585 ns |  3.70 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 180.24 ns | 1.322 ns | 1.237 ns |  2.27 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 253.63 ns | 3.252 ns | 3.042 ns |  3.20 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 196.14 ns | 1.865 ns | 1.744 ns |  2.47 |    0.03 |      - |     - |     - |         - |
