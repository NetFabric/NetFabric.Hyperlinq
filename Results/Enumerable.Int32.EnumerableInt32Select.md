## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                      Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                 ForeachLoop |   100 |   518.8 ns |  7.32 ns |  6.49 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                        Linq |   100 | 1,237.5 ns | 18.77 ns | 16.64 ns |  2.39 |    0.04 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |   100 |   984.0 ns | 11.93 ns | 10.58 ns |  1.90 |    0.02 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |   100 |   732.3 ns |  7.56 ns |  7.07 ns |  1.41 |    0.02 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |   100 |   515.3 ns |  9.73 ns |  8.63 ns |  0.99 |    0.02 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |   100 |   772.0 ns |  4.93 ns |  4.11 ns |  1.49 |    0.02 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |   100 |   542.9 ns |  5.56 ns |  4.93 ns |  1.05 |    0.02 | 0.0191 |     - |     - |      40 B |
