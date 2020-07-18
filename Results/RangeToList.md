## RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/RangeToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Start | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 | 281.11 ns | 1.401 ns | 1.242 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
| ForeachLoop |     0 |   100 | 716.19 ns | 4.146 ns | 3.675 ns |  2.55 | 0.5922 |     - |     - |    1240 B |
|        Linq |     0 |   100 | 190.52 ns | 0.722 ns | 0.640 ns |  0.68 | 0.2370 |     - |     - |     496 B |
|  LinqFaster |     0 |   100 | 126.51 ns | 0.707 ns | 0.662 ns |  0.45 | 0.4206 |     - |     - |     880 B |
|  StructLinq |     0 |   100 | 274.84 ns | 1.759 ns | 1.645 ns |  0.98 | 0.5774 |     - |     - |    1208 B |
|   Hyperlinq |     0 |   100 |  97.07 ns | 0.483 ns | 0.452 ns |  0.35 | 0.2333 |     - |     - |     488 B |
