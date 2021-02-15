## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  59.20 ns | 0.255 ns | 0.238 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  44.92 ns | 0.177 ns | 0.166 ns |  0.76 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 446.29 ns | 2.297 ns | 2.036 ns |  7.54 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |  50.20 ns | 0.219 ns | 0.183 ns |  0.85 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |   100 |  12.16 ns | 0.073 ns | 0.068 ns |  0.21 |    0.00 |      - |     - |     - |         - |
|               LinqAF |   100 | 208.01 ns | 0.329 ns | 0.275 ns |  3.52 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 |  83.41 ns | 0.166 ns | 0.155 ns |  1.41 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  62.21 ns | 0.170 ns | 0.159 ns |  1.05 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |  15.40 ns | 0.096 ns | 0.085 ns |  0.26 |    0.00 |      - |     - |     - |         - |
