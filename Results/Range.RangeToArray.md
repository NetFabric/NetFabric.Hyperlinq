## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta20](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta20)

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
|        ForLoop |     0 |   100 |  78.67 ns | 0.485 ns | 0.430 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |              0 |                       0 |
|           Linq |     0 |   100 |  83.11 ns | 0.525 ns | 0.466 ns |  1.06 |    0.01 | 0.2218 |     - |     - |     464 B |              0 |                       0 |
|     LinqFaster |     0 |   100 |  68.16 ns | 0.308 ns | 0.273 ns |  0.87 |    0.01 | 0.2027 |     - |     - |     424 B |              0 |                       0 |
|     StructLinq |     0 |   100 | 369.46 ns | 1.843 ns | 1.724 ns |  4.70 |    0.03 | 0.2141 |     - |     - |     448 B |              1 |                       0 |
|      Hyperlinq |     0 |   100 |  79.76 ns | 0.620 ns | 0.550 ns |  1.01 |    0.01 | 0.2027 |     - |     - |     424 B |              0 |                       0 |
| Hyperlinq_Pool |     0 |   100 | 121.63 ns | 1.009 ns | 0.944 ns |  1.54 |    0.01 | 0.0267 |     - |     - |      56 B |              0 |                       0 |
