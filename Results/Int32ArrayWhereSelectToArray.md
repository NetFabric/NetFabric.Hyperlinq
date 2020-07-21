## Int32ArrayWhereSelectToArray

### Source
[Int32ArrayWhereSelectToArray.cs](../LinqBenchmarks/Int32/Array/Int32ArrayWhereSelectToArray.cs)

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
|              ForLoop |   100 | 265.9 ns | 1.72 ns | 1.52 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 234.4 ns | 1.66 ns | 1.55 ns |  0.88 |    0.01 | 0.4165 |     - |     - |     872 B |
|                 Linq |   100 | 585.6 ns | 2.50 ns | 2.34 ns |  2.20 |    0.02 | 0.3710 |     - |     - |     776 B |
|           LinqFaster |   100 | 331.6 ns | 2.36 ns | 2.09 ns |  1.25 |    0.01 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 653.6 ns | 4.89 ns | 4.09 ns |  2.46 |    0.02 | 0.4396 |     - |     - |     920 B |
| StructLinq_IFunction |   100 | 335.4 ns | 3.26 ns | 2.89 ns |  1.26 |    0.01 | 0.4396 |     - |     - |     920 B |
|            Hyperlinq |   100 | 643.7 ns | 3.23 ns | 3.02 ns |  2.42 |    0.02 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 619.3 ns | 5.36 ns | 5.02 ns |  2.33 |    0.02 | 0.0267 |     - |     - |      56 B |
