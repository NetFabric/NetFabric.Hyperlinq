## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|-----------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   604.378 μs |  2.7204 μs |  2.2716 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   603.198 μs |  6.8925 μs |  5.7556 μs | 0.998 |    0.01 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   610.925 μs |  6.4248 μs |  5.6954 μs | 1.011 |    0.01 | 1092.7734 |     - |     - | 2286672 B |
|               LinqAF |          4 |   100 | 2,045.875 μs | 15.2469 μs | 12.7318 μs | 3.385 |    0.02 | 2187.5000 |     - |     - | 4575077 B |
|           StructLinq |          4 |   100 |   658.103 μs |  2.4525 μs |  2.0479 μs | 1.089 |    0.01 | 1086.9141 |     - |     - | 2273633 B |
| StructLinq_IFunction |          4 |   100 |     5.214 μs |  0.0538 μs |  0.0503 μs | 0.009 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   577.389 μs |  8.4225 μs |  7.0332 μs | 0.955 |    0.01 | 1045.8984 |     - |     - | 2187585 B |
