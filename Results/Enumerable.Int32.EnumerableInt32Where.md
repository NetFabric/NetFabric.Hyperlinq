## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                 Linq |   100 | 1,623.8 ns | 32.29 ns | 59.84 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 | 1,401.5 ns | 27.72 ns | 59.07 ns |  0.86 |    0.05 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,334.2 ns | 26.73 ns | 78.80 ns |  0.82 |    0.07 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   940.9 ns | 20.37 ns | 60.05 ns |  0.58 |    0.04 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,362.0 ns | 27.09 ns | 67.47 ns |  0.84 |    0.05 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   927.7 ns | 18.46 ns | 50.23 ns |  0.58 |    0.04 | 0.0191 |     - |     - |      40 B |
