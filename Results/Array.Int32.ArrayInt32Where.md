## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  74.04 ns |  0.248 ns |  0.220 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  73.90 ns |  0.194 ns |  0.181 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 734.12 ns | 15.755 ns | 45.959 ns |  9.72 |    0.67 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 280.79 ns |  1.496 ns |  1.399 ns |  3.79 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 683.15 ns | 17.686 ns | 51.871 ns |  8.49 |    0.32 |      - |     - |     - |         - |
|           StructLinq |   100 | 541.02 ns | 11.797 ns | 34.784 ns |  7.22 |    0.48 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 166.91 ns |  0.376 ns |  0.333 ns |  2.25 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 541.43 ns | 13.216 ns | 38.968 ns |  7.30 |    0.47 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 188.41 ns |  0.659 ns |  0.585 ns |  2.54 |    0.01 |      - |     - |     - |         - |
