## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|              ForLoop |   100 |   248.9 ns | 1.18 ns | 0.99 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 |   464.6 ns | 1.68 ns | 1.49 ns |  1.87 |    0.01 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 |   553.4 ns | 2.45 ns | 2.17 ns |  2.22 |    0.01 | 0.3824 |     - |     - |     800 B |
|           LinqFaster |   100 |   591.5 ns | 4.47 ns | 3.96 ns |  2.38 |    0.02 | 0.4320 |     - |     - |     904 B |
|               LinqAF |   100 | 1,199.6 ns | 8.94 ns | 8.36 ns |  4.81 |    0.03 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 |   656.7 ns | 4.71 ns | 4.40 ns |  2.64 |    0.02 | 0.1717 |     - |     - |     360 B |
| StructLinq_IFunction |   100 |   374.3 ns | 2.26 ns | 2.00 ns |  1.50 |    0.01 | 0.1221 |     - |     - |     256 B |
|            Hyperlinq |   100 |   665.3 ns | 4.51 ns | 3.77 ns |  2.67 |    0.02 | 0.1564 |     - |     - |     328 B |
