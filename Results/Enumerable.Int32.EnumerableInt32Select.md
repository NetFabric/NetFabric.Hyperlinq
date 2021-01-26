## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   483.4 ns | 2.35 ns | 2.20 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,099.3 ns | 4.50 ns | 3.51 ns |  2.27 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 |   871.9 ns | 3.17 ns | 2.97 ns |  1.80 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   663.5 ns | 3.18 ns | 2.82 ns |  1.37 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   519.4 ns | 3.58 ns | 2.99 ns |  1.07 | 0.0191 |     - |     - |      40 B |
|    Hyperlinq_Foreach |   100 |   668.6 ns | 3.43 ns | 3.04 ns |  1.38 | 0.0191 |     - |     - |      40 B |
