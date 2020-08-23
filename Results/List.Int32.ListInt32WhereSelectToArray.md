## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|              ForLoop |   100 |   266.2 ns | 3.65 ns | 3.23 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 |   409.2 ns | 3.62 ns | 3.21 ns |  1.54 |    0.03 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 |   583.9 ns | 4.33 ns | 4.05 ns |  2.19 |    0.03 | 0.3939 |     - |     - |     824 B |
|           LinqFaster |   100 |   553.1 ns | 3.48 ns | 3.08 ns |  2.08 |    0.03 | 0.4168 |     - |     - |     872 B |
|               LinqAF |   100 | 1,226.2 ns | 7.56 ns | 6.31 ns |  4.61 |    0.06 | 0.4005 |     - |     - |     840 B |
|           StructLinq |   100 |   674.2 ns | 4.44 ns | 3.94 ns |  2.53 |    0.03 | 0.1564 |     - |     - |     328 B |
| StructLinq_IFunction |   100 |   364.5 ns | 2.04 ns | 1.91 ns |  1.37 |    0.02 | 0.1068 |     - |     - |     224 B |
|            Hyperlinq |   100 |   634.9 ns | 3.59 ns | 3.18 ns |  2.39 |    0.03 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 |   689.9 ns | 5.13 ns | 4.55 ns |  2.59 |    0.04 | 0.0267 |     - |     - |      56 B |
