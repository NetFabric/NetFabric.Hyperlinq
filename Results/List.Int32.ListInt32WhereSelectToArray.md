## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|              ForLoop |   100 |   375.6 ns |  2.51 ns |  2.10 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 |   645.6 ns | 12.91 ns | 16.32 ns |  1.70 |    0.04 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 |   938.5 ns | 17.41 ns | 15.44 ns |  2.49 |    0.04 | 0.3929 |     - |     - |     824 B |
|           LinqFaster |   100 |   745.0 ns | 11.14 ns | 10.42 ns |  1.98 |    0.03 | 0.4168 |     - |     - |     872 B |
|               LinqAF |   100 | 1,153.6 ns |  4.35 ns |  3.63 ns |  3.07 |    0.01 | 0.4005 |     - |     - |     840 B |
|           StructLinq |   100 |   860.1 ns | 13.00 ns | 12.16 ns |  2.29 |    0.04 | 0.1564 |     - |     - |     328 B |
| StructLinq_IFunction |   100 |   436.7 ns |  4.17 ns |  3.70 ns |  1.16 |    0.01 | 0.1068 |     - |     - |     224 B |
|            Hyperlinq |   100 |   827.5 ns | 12.57 ns | 11.76 ns |  2.20 |    0.04 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 |   875.5 ns | 11.89 ns | 11.12 ns |  2.33 |    0.03 | 0.0267 |     - |     - |      56 B |
