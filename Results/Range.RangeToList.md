## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|      Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop |     0 |   100 | 287.14 ns | 1.609 ns | 1.426 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |              1 |                       0 |
| ForeachLoop |     0 |   100 | 681.57 ns | 3.624 ns | 3.212 ns |  2.37 |    0.02 | 0.5922 |     - |     - |    1240 B |              3 |                       3 |
|        Linq |     0 |   100 | 193.78 ns | 1.216 ns | 1.137 ns |  0.68 |    0.00 | 0.2370 |     - |     - |     496 B |              1 |                       1 |
|  LinqFaster |     0 |   100 | 128.62 ns | 0.859 ns | 0.762 ns |  0.45 |    0.00 | 0.4206 |     - |     - |     880 B |              1 |                       1 |
|  StructLinq |     0 |   100 | 388.53 ns | 1.402 ns | 1.243 ns |  1.35 |    0.01 | 0.2294 |     - |     - |     480 B |              2 |                       0 |
|   Hyperlinq |     0 |   100 |  97.67 ns | 1.000 ns | 0.936 ns |  0.34 |    0.00 | 0.2333 |     - |     - |     488 B |              0 |                       0 |
