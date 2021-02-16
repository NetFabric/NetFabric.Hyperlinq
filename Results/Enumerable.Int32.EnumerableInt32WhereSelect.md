## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   487.1 ns | 0.83 ns | 0.78 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,027.9 ns | 3.27 ns | 2.73 ns |  2.11 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 |   859.6 ns | 1.49 ns | 1.32 ns |  1.76 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   761.3 ns | 1.87 ns | 1.66 ns |  1.56 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   536.8 ns | 2.33 ns | 1.95 ns |  1.10 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 |   832.4 ns | 3.06 ns | 2.87 ns |  1.71 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   569.3 ns | 2.43 ns | 2.15 ns |  1.17 | 0.0191 |     - |     - |      40 B |
