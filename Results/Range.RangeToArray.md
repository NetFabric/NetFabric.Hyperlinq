## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
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
|         Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|        ForLoop |     0 |   100 |  77.72 ns | 0.490 ns | 0.434 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |              0 |                       0 |
|           Linq |     0 |   100 |  87.64 ns | 0.772 ns | 0.684 ns |  1.13 |    0.01 | 0.2218 |     - |     - |     464 B |              0 |                       0 |
|     LinqFaster |     0 |   100 |  68.31 ns | 0.257 ns | 0.215 ns |  0.88 |    0.01 | 0.2027 |     - |     - |     424 B |              0 |                       0 |
|     StructLinq |     0 |   100 | 369.21 ns | 2.190 ns | 2.048 ns |  4.75 |    0.03 | 0.2141 |     - |     - |     448 B |              2 |                       0 |
|      Hyperlinq |     0 |   100 |  81.38 ns | 0.718 ns | 0.636 ns |  1.05 |    0.01 | 0.2027 |     - |     - |     424 B |              0 |                       0 |
| Hyperlinq_Pool |     0 |   100 | 120.14 ns | 0.711 ns | 0.665 ns |  1.54 |    0.01 | 0.0267 |     - |     - |      56 B |              0 |                       0 |
