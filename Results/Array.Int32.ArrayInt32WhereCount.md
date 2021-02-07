## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

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
|              ForLoop |   100 |  77.51 ns | 0.172 ns | 0.143 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  77.64 ns | 0.179 ns | 0.158 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 623.88 ns | 1.938 ns | 1.813 ns |  8.05 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 212.50 ns | 0.498 ns | 0.442 ns |  2.74 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 262.61 ns | 1.646 ns | 1.459 ns |  3.39 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 265.92 ns | 1.596 ns | 1.415 ns |  3.43 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |  81.57 ns | 0.176 ns | 0.156 ns |  1.05 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 190.98 ns | 0.411 ns | 0.343 ns |  2.46 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  75.20 ns | 0.212 ns | 0.188 ns |  0.97 |    0.00 |      - |     - |     - |         - |
