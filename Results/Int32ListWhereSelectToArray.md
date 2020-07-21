## Int32ListWhereSelectToArray

### Source
[Int32ListWhereSelectToArray.cs](../LinqBenchmarks/Int32/List/Int32ListWhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 257.7 ns | 2.70 ns | 2.39 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 399.9 ns | 3.39 ns | 3.17 ns |  1.55 |    0.02 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 | 598.8 ns | 5.56 ns | 4.93 ns |  2.32 |    0.02 | 0.3939 |     - |     - |     824 B |
|           LinqFaster |   100 | 457.3 ns | 3.33 ns | 2.95 ns |  1.77 |    0.02 | 0.4168 |     - |     - |     872 B |
|           StructLinq |   100 | 657.8 ns | 4.93 ns | 4.61 ns |  2.55 |    0.03 | 0.4396 |     - |     - |     920 B |
| StructLinq_IFunction |   100 | 334.8 ns | 2.95 ns | 2.76 ns |  1.30 |    0.02 | 0.4396 |     - |     - |     920 B |
|            Hyperlinq |   100 | 657.4 ns | 5.04 ns | 4.47 ns |  2.55 |    0.03 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 623.1 ns | 4.44 ns | 3.71 ns |  2.42 |    0.02 | 0.0267 |     - |     - |      56 B |
