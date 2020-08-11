## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

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
|              ForLoop |   100 |   357.5 ns | 0.43 ns | 0.36 ns |  1.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 |   525.2 ns | 0.41 ns | 0.36 ns |  1.47 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 |   668.8 ns | 1.33 ns | 1.18 ns |  1.87 | 0.3939 |     - |     - |     824 B |
|           LinqFaster |   100 |   581.7 ns | 0.69 ns | 0.54 ns |  1.63 | 0.4168 |     - |     - |     872 B |
|               LinqAF |   100 | 1,261.8 ns | 1.39 ns | 1.16 ns |  3.53 | 0.4005 |     - |     - |     840 B |
|           StructLinq |   100 |   706.1 ns | 1.73 ns | 1.45 ns |  1.98 | 0.1297 |     - |     - |     272 B |
| StructLinq_IFunction |   100 |   401.2 ns | 1.72 ns | 1.61 ns |  1.12 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq |   100 |   698.5 ns | 1.57 ns | 1.22 ns |  1.95 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 |   747.4 ns | 1.66 ns | 1.47 ns |  2.09 | 0.0267 |     - |     - |      56 B |
