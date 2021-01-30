## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|              ForLoop |   100 |  73.88 ns |  0.196 ns |  0.183 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  73.58 ns |  0.142 ns |  0.126 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 999.88 ns | 19.844 ns | 51.578 ns | 13.28 |    0.70 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 432.18 ns |  1.736 ns |  1.539 ns |  5.85 |    0.03 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 463.35 ns |  1.389 ns |  1.231 ns |  6.27 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 595.16 ns | 11.848 ns | 28.387 ns |  7.92 |    0.32 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 184.73 ns |  0.362 ns |  0.321 ns |  2.50 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 641.98 ns | 12.574 ns | 24.525 ns |  8.83 |    0.38 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 193.77 ns |  0.517 ns |  0.458 ns |  2.62 |    0.01 |      - |     - |     - |         - |
