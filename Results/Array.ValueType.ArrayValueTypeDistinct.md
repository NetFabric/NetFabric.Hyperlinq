## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   534.593 μs | 2.5159 μs | 2.1009 μs | 1.000 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   521.481 μs | 2.3813 μs | 2.2275 μs | 0.976 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   632.424 μs | 7.3414 μs | 6.5079 μs | 1.184 | 1092.7734 |     - |     - | 2286672 B |
|               LinqAF |          4 |   100 | 1,683.623 μs | 7.1052 μs | 6.2986 μs | 3.150 | 2187.5000 |     - |     - | 4575074 B |
|           StructLinq |          4 |   100 |   583.754 μs | 2.3020 μs | 2.1533 μs | 1.093 | 1086.9141 |     - |     - | 2273657 B |
| StructLinq_IFunction |          4 |   100 |     4.459 μs | 0.0158 μs | 0.0148 μs | 0.008 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   483.287 μs | 3.3168 μs | 3.1025 μs | 0.904 | 1045.8984 |     - |     - | 2187584 B |
