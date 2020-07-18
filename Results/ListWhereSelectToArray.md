## ListWhereSelectToArray

### Source
[ListWhereSelectToArray.cs](../LinqBenchmarks/ListWhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 255.7 ns | 1.07 ns | 0.84 ns |  1.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 449.5 ns | 0.50 ns | 0.42 ns |  1.76 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 | 559.4 ns | 2.27 ns | 2.02 ns |  2.19 | 0.3939 |     - |     - |     824 B |
|           LinqFaster |   100 | 443.5 ns | 2.52 ns | 2.24 ns |  1.73 | 0.4168 |     - |     - |     872 B |
|           StructLinq |   100 | 652.9 ns | 2.06 ns | 1.83 ns |  2.55 | 0.4396 |     - |     - |     920 B |
| StructLinq_IFunction |   100 | 326.7 ns | 1.49 ns | 1.39 ns |  1.28 | 0.4396 |     - |     - |     920 B |
|            Hyperlinq |   100 | 600.4 ns | 1.49 ns | 1.39 ns |  2.35 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 653.2 ns | 1.25 ns | 1.11 ns |  2.56 | 0.0267 |     - |     - |      56 B |
