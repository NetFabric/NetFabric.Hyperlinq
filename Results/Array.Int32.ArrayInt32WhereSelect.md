## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|              ForLoop |   100 |  77.95 ns | 0.887 ns | 0.830 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  79.13 ns | 1.139 ns | 1.009 ns |  1.02 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 616.99 ns | 8.865 ns | 7.859 ns |  7.92 |    0.08 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 398.11 ns | 2.376 ns | 1.984 ns |  5.11 |    0.06 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 467.95 ns | 2.304 ns | 2.043 ns |  6.01 |    0.06 |      - |     - |     - |         - |
|           StructLinq |   100 | 412.34 ns | 1.873 ns | 1.661 ns |  5.29 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 199.70 ns | 1.230 ns | 1.027 ns |  2.56 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 354.70 ns | 1.502 ns | 1.331 ns |  4.55 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 209.65 ns | 0.617 ns | 0.515 ns |  2.69 |    0.03 |      - |     - |     - |         - |
