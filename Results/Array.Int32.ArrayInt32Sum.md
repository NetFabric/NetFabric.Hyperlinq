## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|              ForLoop |   100 |  57.90 ns | 0.159 ns | 0.133 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  57.53 ns | 0.163 ns | 0.153 ns |  0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 433.95 ns | 1.120 ns | 0.993 ns |  7.49 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |  48.96 ns | 0.136 ns | 0.120 ns |  0.85 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |   100 |  11.82 ns | 0.047 ns | 0.042 ns |  0.20 |    0.00 |      - |     - |     - |         - |
|               LinqAF |   100 | 206.11 ns | 0.797 ns | 0.746 ns |  3.56 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |  81.72 ns | 0.704 ns | 0.658 ns |  1.41 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  61.21 ns | 0.124 ns | 0.116 ns |  1.06 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |  18.64 ns | 0.136 ns | 0.128 ns |  0.32 |    0.00 |      - |     - |     - |         - |
