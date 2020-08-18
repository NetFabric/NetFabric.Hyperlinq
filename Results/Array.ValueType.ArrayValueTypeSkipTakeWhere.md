## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|      Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |   518.4 ns |  0.54 ns |  0.45 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 3,253.7 ns |  7.76 ns |  6.48 ns |  6.28 |    0.01 | 0.0153 |     - |     - |      32 B |
|        Linq | 1000 |   100 | 1,791.6 ns |  4.16 ns |  3.69 ns |  3.46 |    0.01 | 0.1183 |     - |     - |     248 B |
|  LinqFaster | 1000 |   100 | 1,708.8 ns |  5.07 ns |  4.23 ns |  3.30 |    0.01 | 6.7329 |     - |     - |   14096 B |
|      LinqAF | 1000 |   100 | 5,933.7 ns | 23.80 ns | 21.10 ns | 11.44 |    0.04 |      - |     - |     - |         - |
|  StructLinq | 1000 |   100 | 1,735.6 ns |  4.41 ns |  3.91 ns |  3.35 |    0.01 | 0.0763 |     - |     - |     160 B |
|   Hyperlinq | 1000 |   100 |   810.8 ns |  2.04 ns |  1.81 ns |  1.56 |    0.00 |      - |     - |     - |         - |
