## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                 Linq |   100 | 1,674.6 ns | 33.38 ns | 79.98 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 | 1,456.2 ns | 29.09 ns | 58.10 ns |  0.87 |    0.05 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,397.0 ns | 27.87 ns | 78.62 ns |  0.83 |    0.06 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   969.0 ns | 19.34 ns | 44.43 ns |  0.58 |    0.04 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,433.4 ns | 31.01 ns | 91.43 ns |  0.86 |    0.07 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   970.3 ns | 23.07 ns | 67.65 ns |  0.58 |    0.05 | 0.0191 |     - |     - |      40 B |
