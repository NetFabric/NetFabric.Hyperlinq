## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   518.873 μs |  2.1047 μs |  1.8657 μs |   518.767 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   530.738 μs |  3.5915 μs |  2.8040 μs |   530.026 μs | 1.023 |    0.01 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   565.756 μs | 19.6265 μs | 56.9401 μs |   530.930 μs | 1.232 |    0.11 | 1092.7734 |     - |     - | 2286672 B |
|               LinqAF |          4 |   100 | 1,665.409 μs |  4.8329 μs |  4.2842 μs | 1,665.288 μs | 3.210 |    0.01 | 2187.5000 |     - |     - | 4575072 B |
|           StructLinq |          4 |   100 |   604.479 μs |  3.7650 μs |  3.3375 μs |   603.873 μs | 1.165 |    0.01 | 1086.9141 |     - |     - | 2273658 B |
| StructLinq_IFunction |          4 |   100 |     4.455 μs |  0.0134 μs |  0.0119 μs |     4.457 μs | 0.009 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   493.249 μs |  3.1337 μs |  2.9312 μs |   494.133 μs | 0.950 |    0.01 | 1045.8984 |     - |     - | 2187584 B |
