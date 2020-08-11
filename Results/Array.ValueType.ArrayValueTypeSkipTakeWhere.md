## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|      Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |   518.9 ns |  0.31 ns |  0.26 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 2,915.4 ns |  5.03 ns |  4.70 ns |  5.62 |    0.01 | 0.0153 |     - |     - |      32 B |
|        Linq | 1000 |   100 | 1,802.0 ns |  4.03 ns |  3.37 ns |  3.47 |    0.01 | 0.1183 |     - |     - |     248 B |
|  LinqFaster | 1000 |   100 | 1,674.6 ns |  2.90 ns |  2.26 ns |  3.23 |    0.01 | 6.7329 |     - |     - |   14096 B |
|      LinqAF | 1000 |   100 | 5,750.3 ns | 30.99 ns | 25.88 ns | 11.08 |    0.05 |      - |     - |     - |         - |
|  StructLinq | 1000 |   100 | 1,745.7 ns | 19.94 ns | 18.65 ns |  3.37 |    0.04 | 0.0763 |     - |     - |     160 B |
|   Hyperlinq | 1000 |   100 |   840.4 ns |  0.67 ns |  0.56 ns |  1.62 |    0.00 |      - |     - |     - |         - |
