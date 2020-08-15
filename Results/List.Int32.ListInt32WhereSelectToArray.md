## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   364.4 ns | 0.41 ns | 0.32 ns |  1.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 |   462.3 ns | 1.57 ns | 1.46 ns |  1.27 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 |   652.3 ns | 1.43 ns | 1.19 ns |  1.79 | 0.3939 |     - |     - |     824 B |
|           LinqFaster |   100 |   587.4 ns | 2.83 ns | 2.65 ns |  1.61 | 0.4168 |     - |     - |     872 B |
|               LinqAF |   100 | 1,284.8 ns | 3.93 ns | 3.68 ns |  3.52 | 0.4005 |     - |     - |     840 B |
|           StructLinq |   100 |   671.7 ns | 0.67 ns | 0.52 ns |  1.84 | 0.1297 |     - |     - |     272 B |
| StructLinq_IFunction |   100 |   412.1 ns | 0.57 ns | 0.51 ns |  1.13 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq |   100 |   697.9 ns | 2.28 ns | 2.02 ns |  1.92 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 |   716.2 ns | 0.80 ns | 0.67 ns |  1.97 | 0.0267 |     - |     - |      56 B |
