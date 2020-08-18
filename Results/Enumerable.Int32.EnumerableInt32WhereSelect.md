## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   525.0 ns |  1.84 ns |  1.72 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,096.1 ns |  2.25 ns |  1.99 ns |  2.09 |    0.01 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 | 1,148.0 ns |  2.88 ns |  2.69 ns |  2.19 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,004.8 ns |  3.08 ns |  2.88 ns |  1.91 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   618.6 ns |  2.45 ns |  2.29 ns |  1.18 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,084.4 ns | 11.63 ns | 10.31 ns |  2.07 |    0.02 | 0.0191 |     - |     - |      40 B |
