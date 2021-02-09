## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|              ForLoop |   100 |  57.76 ns | 0.397 ns | 0.352 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  57.61 ns | 0.221 ns | 0.196 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 408.79 ns | 1.192 ns | 0.995 ns |  7.07 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |  49.01 ns | 0.109 ns | 0.102 ns |  0.85 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |   100 |  11.89 ns | 0.123 ns | 0.109 ns |  0.21 |    0.00 |      - |     - |     - |         - |
|               LinqAF |   100 | 206.39 ns | 0.471 ns | 0.418 ns |  3.57 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |  81.07 ns | 0.262 ns | 0.245 ns |  1.40 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  60.97 ns | 0.114 ns | 0.106 ns |  1.06 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |  21.21 ns | 0.086 ns | 0.072 ns |  0.37 |    0.00 |      - |     - |     - |         - |
