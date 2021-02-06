## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |       Mean |    Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-----------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                 ForeachLoop |   100 |   689.6 ns | 13.68 ns |  31.70 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                        Linq |   100 | 1,895.8 ns | 49.25 ns | 145.23 ns |  2.77 |    0.24 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |   100 | 1,692.0 ns | 33.53 ns |  80.97 ns |  2.46 |    0.17 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |   100 | 1,088.1 ns | 21.03 ns |  42.97 ns |  1.58 |    0.10 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |   100 |   749.0 ns | 14.96 ns |  30.90 ns |  1.09 |    0.06 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |   100 | 1,031.1 ns | 23.16 ns |  67.92 ns |  1.50 |    0.12 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |   100 |   739.9 ns | 14.69 ns |  30.67 ns |  1.08 |    0.07 | 0.0191 |     - |     - |      40 B |
