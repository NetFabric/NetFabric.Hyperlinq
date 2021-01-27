## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|              ForLoop |   100 |  74.02 ns | 0.187 ns | 0.165 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  73.99 ns | 0.309 ns | 0.258 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 762.03 ns | 6.470 ns | 5.736 ns | 10.29 |    0.09 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 358.77 ns | 1.498 ns | 1.251 ns |  4.85 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 416.50 ns | 2.264 ns | 1.891 ns |  5.63 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 403.80 ns | 1.043 ns | 0.924 ns |  5.46 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 179.89 ns | 0.606 ns | 0.537 ns |  2.43 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 360.54 ns | 1.270 ns | 1.126 ns |  4.87 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 191.58 ns | 0.496 ns | 0.440 ns |  2.59 |    0.01 |      - |     - |     - |         - |
