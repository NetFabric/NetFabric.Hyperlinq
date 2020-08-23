## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   426.9 ns | 3.53 ns | 3.13 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,018.6 ns | 7.37 ns | 6.53 ns |  2.39 |    0.03 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 |   851.4 ns | 6.70 ns | 5.59 ns |  1.99 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   670.8 ns | 6.07 ns | 5.38 ns |  1.57 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   477.3 ns | 3.80 ns | 3.37 ns |  1.12 |    0.01 | 0.0191 |     - |     - |      40 B |
|    Hyperlinq_Foreach |   100 |   750.5 ns | 4.73 ns | 4.19 ns |  1.76 |    0.02 | 0.0191 |     - |     - |      40 B |
