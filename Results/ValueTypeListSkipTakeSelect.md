## ValueTypeListSkipTakeSelect

### Source
[ValueTypeListSkipTakeSelect.cs](../LinqBenchmarks/ValueType/Array/ValueTypeListSkipTakeSelect.cs)

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
|            Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 |    71.29 ns |  0.328 ns |  0.307 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 3,721.53 ns | 21.857 ns | 19.376 ns | 52.17 |    0.30 | 0.0191 |     - |     - |      40 B |
|              Linq | 1000 |   100 |   921.02 ns |  5.198 ns |  4.608 ns | 12.91 |    0.09 | 0.0725 |     - |     - |     152 B |
| Hyperlinq_Foreach | 1000 |   100 |   268.35 ns |  2.868 ns |  2.683 ns |  3.76 |    0.04 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 |   480.01 ns |  4.233 ns |  3.753 ns |  6.73 |    0.06 |      - |     - |     - |         - |
