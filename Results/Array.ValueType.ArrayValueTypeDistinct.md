## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|              ForLoop |          4 |   100 |   597.552 μs | 4.5960 μs | 4.0742 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   587.565 μs | 4.7282 μs | 4.1914 μs | 0.983 |    0.01 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   602.280 μs | 5.7411 μs | 4.7941 μs | 1.007 |    0.01 | 1092.7734 |     - |     - | 2286672 B |
|               LinqAF |          4 |   100 | 1,948.535 μs | 7.4692 μs | 6.2371 μs | 3.259 |    0.02 | 2187.5000 |     - |     - | 4575073 B |
|           StructLinq |          4 |   100 |   658.070 μs | 3.1694 μs | 2.9646 μs | 1.102 |    0.01 | 1086.9141 |     - |     - | 2273657 B |
| StructLinq_IFunction |          4 |   100 |     5.068 μs | 0.0182 μs | 0.0162 μs | 0.008 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   561.058 μs | 3.9182 μs | 3.0591 μs | 0.938 |    0.01 | 1045.8984 |     - |     - | 2187585 B |
