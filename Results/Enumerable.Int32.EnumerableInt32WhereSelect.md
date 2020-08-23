## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|          ForeachLoop |   100 |   449.6 ns | 4.26 ns | 3.77 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 |   997.7 ns | 9.01 ns | 7.99 ns |  2.22 |    0.03 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 | 1,050.2 ns | 7.80 ns | 6.91 ns |  2.34 |    0.03 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   896.2 ns | 5.12 ns | 4.79 ns |  1.99 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   584.7 ns | 4.18 ns | 3.91 ns |  1.30 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 |   999.0 ns | 6.50 ns | 6.08 ns |  2.22 |    0.03 | 0.0191 |     - |     - |      40 B |
