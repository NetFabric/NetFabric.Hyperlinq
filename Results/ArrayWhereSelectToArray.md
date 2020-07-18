## ArrayWhereSelectToArray

### Source
[ArrayWhereSelectToArray.cs](../LinqBenchmarks/ArrayWhereSelectToArray.cs)

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
|              ForLoop |   100 | 258.9 ns | 1.00 ns | 0.93 ns |  1.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 247.2 ns | 0.92 ns | 0.82 ns |  0.95 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 | 565.1 ns | 1.98 ns | 1.76 ns |  2.18 | 0.3710 |     - |     - |     776 B |
|           LinqFaster |   100 | 350.6 ns | 1.90 ns | 1.59 ns |  1.35 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 631.5 ns | 1.93 ns | 1.80 ns |  2.44 | 0.4396 |     - |     - |     920 B |
| StructLinq_IFunction |   100 | 326.3 ns | 1.67 ns | 1.48 ns |  1.26 | 0.4396 |     - |     - |     920 B |
|            Hyperlinq |   100 | 605.3 ns | 2.34 ns | 2.08 ns |  2.34 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 646.7 ns | 2.75 ns | 2.57 ns |  2.50 | 0.0267 |     - |     - |      56 B |
