## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  85.28 ns | 0.110 ns | 0.103 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.52 ns | 0.207 ns | 0.193 ns |  0.94 |      - |     - |     - |         - |
|                 Linq |   100 | 628.95 ns | 1.420 ns | 1.186 ns |  7.37 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 246.62 ns | 0.374 ns | 0.332 ns |  2.89 |      - |     - |     - |         - |
|               LinqAF |   100 | 263.96 ns | 1.090 ns | 1.020 ns |  3.10 |      - |     - |     - |         - |
|           StructLinq |   100 | 376.16 ns | 0.691 ns | 0.647 ns |  4.41 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 175.88 ns | 0.204 ns | 0.170 ns |  2.06 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 211.03 ns | 0.325 ns | 0.304 ns |  2.47 |      - |     - |     - |         - |
