## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 273.2 ns | 0.55 ns | 0.49 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 | 273.7 ns | 0.55 ns | 0.49 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 | 589.9 ns | 0.81 ns | 0.64 ns |  2.16 |    0.01 | 0.3595 |     - |     - |     752 B |
|           LinqFaster |   100 | 431.7 ns | 1.23 ns | 1.09 ns |  1.58 |    0.00 | 0.4320 |     - |     - |     904 B |
|               LinqAF |   100 | 864.7 ns | 2.72 ns | 2.41 ns |  3.17 |    0.01 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 | 709.8 ns | 1.60 ns | 1.41 ns |  2.60 |    0.01 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 | 422.4 ns | 1.21 ns | 1.07 ns |  1.55 |    0.01 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 | 755.3 ns | 4.84 ns | 4.29 ns |  2.76 |    0.02 | 0.1564 |     - |     - |     328 B |
