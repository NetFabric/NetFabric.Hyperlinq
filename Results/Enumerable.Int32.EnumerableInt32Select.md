## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   496.9 ns | 2.44 ns | 2.16 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,087.2 ns | 8.58 ns | 7.60 ns |  2.19 | 0.0458 |     - |     - |      96 B |
|           StructLinq |   100 |   684.4 ns | 3.17 ns | 2.81 ns |  1.38 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   471.3 ns | 3.82 ns | 3.39 ns |  0.95 | 0.0191 |     - |     - |      40 B |
|    Hyperlinq_Foreach |   100 |   788.8 ns | 6.58 ns | 5.49 ns |  1.59 | 0.0191 |     - |     - |      40 B |
