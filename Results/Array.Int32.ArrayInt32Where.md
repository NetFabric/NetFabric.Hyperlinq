## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  66.25 ns | 0.400 ns | 0.355 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  78.22 ns | 0.201 ns | 0.168 ns |  1.18 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 485.08 ns | 1.995 ns | 1.768 ns |  7.32 |    0.05 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 309.87 ns | 2.964 ns | 2.773 ns |  4.68 |    0.03 | 0.3171 |     - |     - |     664 B |
|               LinqAF |   100 | 367.49 ns | 1.455 ns | 1.215 ns |  5.55 |    0.04 |      - |     - |     - |         - |
|           StructLinq |   100 | 286.25 ns | 1.633 ns | 1.527 ns |  4.32 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 187.87 ns | 0.435 ns | 0.386 ns |  2.84 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 289.93 ns | 0.598 ns | 0.530 ns |  4.38 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 181.47 ns | 0.412 ns | 0.385 ns |  2.74 |    0.02 |      - |     - |     - |         - |
