## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   932.7 ns | 17.88 ns | 15.85 ns |  1.00 |    0.00 | 0.4349 |     - |     - |     912 B |
|                 Linq |   100 | 1,457.4 ns | 13.20 ns | 12.35 ns |  1.56 |    0.03 | 0.3967 |     - |     - |     832 B |
|               LinqAF |   100 | 1,251.8 ns | 10.56 ns |  9.87 ns |  1.34 |    0.02 | 0.4196 |     - |     - |     880 B |
|           StructLinq |   100 | 1,436.6 ns | 21.96 ns | 19.46 ns |  1.54 |    0.03 | 0.1678 |     - |     - |     352 B |
| StructLinq_IFunction |   100 | 1,040.0 ns | 20.25 ns | 32.69 ns |  1.09 |    0.05 | 0.1259 |     - |     - |     264 B |
|            Hyperlinq |   100 | 1,491.7 ns | 13.38 ns | 12.52 ns |  1.60 |    0.03 | 0.1259 |     - |     - |     264 B |
|       Hyperlinq_Pool |   100 | 1,468.2 ns | 20.09 ns | 18.79 ns |  1.57 |    0.03 | 0.0458 |     - |     - |      96 B |
