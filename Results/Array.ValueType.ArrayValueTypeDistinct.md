## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   517.037 μs | 2.1654 μs | 1.9195 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   519.228 μs | 3.5164 μs | 3.2892 μs | 1.005 |    0.01 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   537.312 μs | 2.8324 μs | 2.3652 μs | 1.039 |    0.01 | 1092.7734 |     - |     - | 2286672 B |
|               LinqAF |          4 |   100 | 1,665.023 μs | 8.2303 μs | 7.6986 μs | 3.221 |    0.02 | 2187.5000 |     - |     - | 4575074 B |
|           StructLinq |          4 |   100 |   577.159 μs | 1.9049 μs | 1.6886 μs | 1.116 |    0.01 | 1086.9141 |     - |     - | 2273657 B |
| StructLinq_IFunction |          4 |   100 |     4.526 μs | 0.0094 μs | 0.0083 μs | 0.009 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   505.113 μs | 4.1054 μs | 3.8402 μs | 0.976 |    0.01 | 1045.8984 |     - |     - | 2187585 B |
